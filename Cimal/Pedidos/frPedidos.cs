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
    public partial class frPedidos : Form
    {
        public frPedidos()
        {
            InitializeComponent();
        }
        Clases.Pedido ped = new Clases.Pedido();
        public int idpedido;
        public int idcliente;
        public string cliente;
        public string nit;
        public string total;
        public string saldo;
        public DateTime fechaped;
        public DateTime fechaentre;
        public string comentario;
        public string estado;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Program.Cliente== false)
            {
                MessageBox.Show("No eres Cliente");
                return;
            }
            frCatalogo f = new frCatalogo();
            f.ShowDialog();
            Cargardatosid();
        }

        private void frPedidos_Load(object sender, EventArgs e)
        {
            if (Program.Cliente == true)
            {
                Cargardatosid();
            }
            else
            {
                Cargardatos();
            }
        }
       
        private void Cargardatosid()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in ped.CargarTablerosxCliente(Program.IDUsuario).Rows)
                {

                    string estad = "" ;
                    switch (Convert.ToInt32(fila[9]))
                    {
                        case 1:
                            estad = "Pendiente";
                            break;
                        case 2:
                            estad = "Pagado";
                            break;
                        case 3:
                            estad = "Realizado";
                            break;
                    }
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), (fila[3].ToString()), fila[4].ToString(), (fila[5].ToString()), fila[6].ToString(), fila[7].ToString(),fila[8].ToString(),estad);
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
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in ped.CargarTableros().Rows)
                {
                    string estad = "" ;
                    switch (Convert.ToInt32(fila[9]))
                    {
                        case 1:
                            estad = "Pendiente";
                            break;
                        case 2:
                            estad = "Pagado";
                            break;
                        case 3:
                            estad = "Realizado";
                            break;
                    }
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), (fila[3].ToString()), fila[4].ToString(), (fila[5].ToString()), fila[6].ToString(), fila[7].ToString(),fila[8].ToString(),estad);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Program.Cliente != true)
            {
                Clases.Pedido ped = new Clases.Pedido();
                ped.CambiarEstado(3, idpedido);
                Cargardatos();
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("No puedes eliminar");
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (estado == "Pendiente")
            {
                frVerPedido f = new frVerPedido();
                f.txtNoEstudio.Text = idpedido.ToString() ;
                f.txtIDCliente.Text = idcliente.ToString();
                f.txtNombre.Text = cliente;
                f.txtNit.Text = nit;
                f.txtTotal.Text = total;
                f.txtSaldo.Text = saldo;
                f.dtFechaPedido.Value = fechaped.Date;
                f.dtFechaEntrega.Value = fechaentre.Date;
                f.txtComentarios.Text = comentario;
                f.txtEstado.Text = estado;
                f.id = idpedido;
                f.ShowDialog();
            }

            if (Program.Cliente == true)
            {
                Cargardatosid();
            }
            else
            {
                Cargardatos();
            }
        }

        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCargo.CurrentRow != null)
                {
                    idpedido = Convert.ToInt32(dgvCargo.CurrentRow.Cells[0].Value.ToString());
                    idcliente = Convert.ToInt32(dgvCargo.CurrentRow.Cells[1].Value.ToString());
                    cliente = dgvCargo.CurrentRow.Cells[2].Value.ToString();
                    nit = dgvCargo.CurrentRow.Cells[3].Value.ToString();
                    total = dgvCargo.CurrentRow.Cells[4].Value.ToString();
                    saldo = dgvCargo.CurrentRow.Cells[5].Value.ToString();
                    fechaped = Convert.ToDateTime(dgvCargo.CurrentRow.Cells[6].Value.ToString());
                    fechaentre= Convert.ToDateTime(dgvCargo.CurrentRow.Cells[7].Value.ToString());
                    comentario = dgvCargo.CurrentRow.Cells[8].Value.ToString();
                    estado = dgvCargo.CurrentRow.Cells[9].Value.ToString();
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
    }
}
