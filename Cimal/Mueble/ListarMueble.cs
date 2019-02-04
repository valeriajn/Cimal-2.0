using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Mueble
{
    public partial class ListarMueble : Form
    {
        public ListarMueble()
        {
            InitializeComponent();
        }
        Clases.Muebles muebl = new Clases.Muebles();
        int id;
        private void ListarMueble_Load(object sender, EventArgs e)
        {
            dgvCargo.RowTemplate.Height = 70;
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in muebl.CargarMuebles().Rows)
                {
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), muebl.ObtenerImagen(Convert.ToInt32(fila[0])));
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frGuardarMueble f = new frGuardarMueble();
            f.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frActualizarMueble f = new frActualizarMueble();
            f.id = this.id;
            f.ShowDialog();
            Cargardatos();
        }

        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCargo.CurrentRow != null)
                {
                    id = Convert.ToInt32(dgvCargo.CurrentRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            muebl.Anular(id);
            MessageBox.Show("Eliminado");
            Cargardatos();
        }
    }
}
