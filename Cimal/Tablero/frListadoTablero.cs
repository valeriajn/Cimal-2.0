using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Tablero
{
    public partial class frListadoTablero : Form
    {
        public frListadoTablero()
        {
            InitializeComponent();
        }
        Clases.Tablero  tab = new Clases.Tablero();
        DataTable dt = new DataTable();
        DataView dw;
        public int id;
        public string nombre;
        public string precio;
        public string color;
        public string dimension;
        private void frListadoTablero_Load(object sender, EventArgs e)
        {
            dw = new DataView(tab.CargarTableros());
            dgvCargo.DataSource = dw;

            dgvCargo.Columns[0].Width = 100;
            dgvCargo.Columns[1].Width = 200;
            dgvCargo.Columns[2].Width = 100;
            dgvCargo.Columns[3].Width = 100;
            dgvCargo.Columns[4].Width = 100;

            dgvCargo.ReadOnly = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dw.RowFilter = "Nombre like '%" + this.txtBuscar.Text + "%'";
            dgvCargo.DataSource = dw;

            dgvCargo.Columns[0].Width = 100;
            dgvCargo.Columns[1].Width = 200;
            dgvCargo.Columns[2].Width = 100;
            dgvCargo.Columns[3].Width = 100;
            dgvCargo.Columns[4].Width = 100;

            dgvCargo.ReadOnly = true;
        }

        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCargo.CurrentRow != null)
                {
                    id = Convert.ToInt32(dgvCargo.CurrentRow.Cells[0].Value.ToString());
                    nombre = dgvCargo.CurrentRow.Cells[1].Value.ToString();
                    precio = (dgvCargo.CurrentRow.Cells[2].Value.ToString());
                    color = (dgvCargo.CurrentRow.Cells[3].Value.ToString());
                    dimension = (dgvCargo.CurrentRow.Cells[4].Value.ToString());

                }
            }
            catch (Exception e1)
            {

                MessageBox.Show(e1.ToString());
            }
        }

        private void dgvCargo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
