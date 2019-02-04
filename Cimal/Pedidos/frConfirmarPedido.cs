using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Pedidos
{
    public partial class frConfirmarPedido : Form
    {
        public frConfirmarPedido()
        {
            InitializeComponent();
        }
        public DataTable dt = new DataTable();
        Clases.Muebles muebl = new Clases.Muebles();
        Clases.ListaMaterial lista = new Clases.ListaMaterial();
        Clases.Persona per = new Clases.Persona();
        Clases.Pedido ped = new Clases.Pedido();
        Clases.Detalle det = new Clases.Detalle();
        public int id;
        private void frConfirmarPedido_Load(object sender, EventArgs e)
        {
            Cargardatos();
            CargardatosCliente();
            decimal tot = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                tot = tot + Convert.ToDecimal(row.Cells[4].Value);
            }
            txtTotal.Text = tot.ToString();
        }
        private void CargardatosCliente()
        {
            try
            {
                
                foreach (DataRow fila in per.CargarPersonaCliente2(Program.IDUsuario).Rows)
                {
                    txtIDCliente.Text = fila[0].ToString();
                    txtNombre.Text = fila[1].ToString() + fila[2].ToString();
                    txtNit.Text = fila[3].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void Cargardatos()
        {
            try
            {
                dgvMueble.Rows.Clear();
                foreach (DataRow fila in dt.Rows)
                {
                    dgvMueble.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString());
                    CargardatosTablero(Convert.ToInt32(fila[0].ToString()),Convert.ToInt32(fila[2].ToString()));
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void CargardatosTablero(int mueble,int cantidadm)
        {
            try
            {
                dgvDetalle.Rows.Clear();
                foreach (DataRow fila in lista.CargarLista(mueble).Rows)
                {
                    int cant = Convert.ToInt32(fila[5]) * cantidadm ;
                    dgvDetalle.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), cant,Convert.ToDecimal(fila[2]) * cant);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void dgvMueble_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    id = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[0].Value.ToString());
                    pictureBox1.Image = muebl.ObtenerImagen(id);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                }
                else
                {

                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvMueble_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMueble.Rows.Count != 0 )
            {
                if (dgvMueble.Columns[e.ColumnIndex].Name == "Cantidad")
                {
                    foreach (DataGridViewRow row in dgvMueble.Rows)
                    {
                        CargardatosTablero(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[2].Value));
                    }
                }
            }
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                total = total + Convert.ToDecimal(row.Cells[4].Value);
            }
            txtTotal.Text = total.ToString();
        }
        private bool validar()
        {
            ped.ID = ped.IDTPedidoMax();
            ped.Cliente =Convert.ToInt32( txtIDCliente.Text);
            ped.Comentarios = txtComentarios.Text;
            ped.FechaEntrega = Convert.ToDateTime(dtFecha.Value);
            ped.Total = Convert.ToDecimal(txtTotal.Text.Replace(',','.'));
            ped.Saldo = Convert.ToDecimal(txtTotal.Text.Replace(',','.'));
             return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma el siguiente paso?, no podra volver atras a partir de este punto", "Confirmacion de pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
                if (validar())
                {
                    ped.GuardarPedido();
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        det.ID = det.IDDetalleMax();
                        det.IDPedido = ped.ID;
                        det.IDTablero = Convert.ToInt32(row.Cells[0].Value);
                        det.Precio = Convert.ToDecimal(row.Cells[2].Value);
                        det.Cantidad = Convert.ToInt32(row.Cells[3].Value);
                        det.subtotal = Convert.ToDecimal(row.Cells[4].Value);
                        det.GuardarDetalle1();
                    }
                    if (dgvMueble.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow row1 in dgvMueble.Rows)
                        {

                            det.IDPedido = ped.ID;
                            det.IDMueble = Convert.ToInt32(row1.Cells[0].Value);
                            det.CantidadMueble = Convert.ToInt32(row1.Cells[2].Value);
                            det.GuardarDetalle2();
                        } 
                    }
                    

                    frPago f = new frPago();
                    f.idpedido = ped.ID;
                    f.txtIDCliente.Text = txtIDCliente.Text;
                    f.txtNombre.Text = txtNombre.Text;
                    f.txtNit.Text = txtNit.Text;
                    f.txtTotal.Text = txtTotal.Text;
                    f.txtefectivo.Text = txtTotal.Text;
                   
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (dgvDetalle.CurrentCell == dgvDetalle.CurrentRow.Cells[1])
                {
                    Tablero.frListadoTablero list = new Tablero.frListadoTablero();
                    list.ShowDialog();
                    if (list.DialogResult == DialogResult.OK)
                    {
                        

                        dgvDetalle.CurrentRow.Cells[0].Value = list.id;
                        dgvDetalle.CurrentRow.Cells[1].Value = list.nombre.ToString();
                        dgvDetalle.CurrentRow.Cells[2].Value = list.precio;
                        

                    }
                }
                if (dgvDetalle.CurrentCell == dgvDetalle.CurrentRow.Cells[0])
                {
                    Tablero.frListadoTablero list = new Tablero.frListadoTablero();
                    list.ShowDialog();
                    if (list.DialogResult == DialogResult.OK)
                    {
                      
                        dgvDetalle.CurrentRow.Cells[0].Value = list.id;
                        dgvDetalle.CurrentRow.Cells[1].Value = list.nombre.ToString();
                        dgvDetalle.CurrentRow.Cells[2].Value = list.precio;
                      

                    }
                }
            }
        }

        private void añadirFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Add("", "", "",  Convert.ToInt32(0),"0");
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Columns[e.ColumnIndex].Name == "integerGridColumn1")
            {
               dgvDetalle.CurrentRow.Cells[4].Value  =   Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[2].Value) * Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[3].Value);
            }
            if (dgvDetalle.Columns[e.ColumnIndex].Name == "Precio")
            {
                dgvDetalle.CurrentRow.Cells[4].Value = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[2].Value) * Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[3].Value);
            }
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                total = total + Convert.ToDecimal(row.Cells[4].Value);
            }
            txtTotal.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
