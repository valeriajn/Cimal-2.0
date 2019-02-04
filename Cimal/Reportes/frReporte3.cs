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
    public partial class frReporte3 : Form
    {
        public frReporte3()
        {
            InitializeComponent();
        }
        Clases.Reportes rep = new Clases.Reportes();
        private void frReporte3_Load(object sender, EventArgs e)
        {
            cargardatos();
        }
        private void cargardatos()
        {
            dgvCargo.Rows.Clear();
            foreach (DataRow fila in rep.Saldos().Rows)
            {
                dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(),fila[3]);
            }
        }
    }
}
