using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Reportes
{
    public partial class frReporte2 : Form
    {
        public frReporte2()
        {
            InitializeComponent();
        }
        Clases.Reportes rep = new Clases.Reportes();
        private void frReporte2_Load(object sender, EventArgs e)
        {

        }
        private void cargardatos()
        {
            dgvCargo.Rows.Clear();
            foreach (DataRow fila in rep.CantidadTablerosVendidos(Convert.ToDateTime(dateTimePicker1.Value),Convert.ToDateTime(dateTimePicker2.Value)).Rows)
            {
                dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
