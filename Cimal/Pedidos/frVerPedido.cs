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
    public partial class frVerPedido : Form
    {
        public frVerPedido()
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
        private void pnEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CargarMuebles()
        {
            try
            {
                dgvMueble.Rows.Clear();
                foreach (DataRow fila in det.CargarMuebles(id).Rows)
                {
                    dgvMueble.Rows.Add(fila[0], fila[1], fila[2]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void CargarTableros()
        {
            try
            {
                dgvDetalle.Rows.Clear();
                foreach (DataRow fila in det.Cargardetalle(id).Rows)
                {
                    dgvDetalle.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4]);
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

        private void frVerPedido_Load(object sender, EventArgs e)
        {
            CargarMuebles();
            CargarTableros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                    frPagoSaldos f = new frPagoSaldos();
                    f.idpedido = Convert.ToInt32(txtNoEstudio.Text);
                    f.txtIDCliente.Text = txtIDCliente.Text;
                    f.txtNombre.Text = txtNombre.Text;
                    f.txtNit.Text = txtNit.Text;
                    f.txtTotal.Text = txtSaldo.Text;
                    f.txtefectivo.Text = txtSaldo.Text;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        
    }
}
