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
    public partial class frReportes : Form
    {
        public frReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frReporte3 f = new frReporte3();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frReporte1 f = new frReporte1();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frReporte2 f = new frReporte2();
            f.ShowDialog();
        }
    }
}
