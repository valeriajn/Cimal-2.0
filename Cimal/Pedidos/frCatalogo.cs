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
    public partial class frCatalogo : Form
    {
        public frCatalogo()
        {
            InitializeComponent();
        }
        Clases.Muebles muebl = new Clases.Muebles();
        Clases.Tablero tab = new Clases.Tablero();
        public DataTable dt = new DataTable();
        int id;
        Clases.ListaMaterial  list = new Clases.ListaMaterial();
        private void LlenarTabla()
        {
            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
        }
        private void frCatalogo_Load(object sender, EventArgs e)
        {
            DGV();
            Cargardatos();
            LlenarTabla();

        }
        private void DGV()
        {
            DataGridViewCheckBoxColumn Autorizado = new DataGridViewCheckBoxColumn();
            Autorizado.Name = "Seleccionar";
            Autorizado.HeaderText = "Seleccionar";
            dgvCargo.Columns.Insert(3, Autorizado);
            dgvCargo.Columns[3].Width = 100;
            
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in muebl.CargarMuebles().Rows)
                {
                    dgvCargo.Rows.Add   (fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), 0);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void CargardatosTablero()
        {
            try
            {
                dgvTablero.Rows.Clear();
                foreach (DataRow fila in list.CargarLista(id).Rows)
                {
                    dgvTablero.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), (fila[3].ToString()), fila[4].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCargo.CurrentRow != null)
                {
                    id = Convert.ToInt32(dgvCargo.CurrentRow.Cells[0].Value.ToString());
                    pictureBox1.Image = muebl.ObtenerImagen(id);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    CargardatosTablero();
                }
                else
                {
                    
                    pictureBox2.Image = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            foreach (DataGridViewRow row in dgvCargo.Rows)
            {
                if (Convert.ToBoolean(row.Cells[3].Value) == true)
                {
                    dt.Rows.Add(Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(), 1);
                }
                
            }
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("No hay muebles seleccionados");
            //    return;
            //}
            frConfirmarPedido f = new frConfirmarPedido();
            f.MdiParent = this.MdiParent;
            f.dt = this.dt;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
