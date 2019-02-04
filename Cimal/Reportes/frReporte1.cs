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
    public partial class frReporte1 : Form
    {
        public frReporte1()
        {
            InitializeComponent();
        }
        Clases.Reportes rep = new Clases.Reportes();
        private void frReporte1_Load(object sender, EventArgs e)
        {

        }
        private void cargardatos()
        {
            dgvCargo.Rows.Clear();
            foreach (DataRow fila in rep.PedidosPorRango(Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value)).Rows)
            {

                string estad = "";
                switch (Convert.ToInt32(fila[6]))
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
                dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(), fila[4].ToString(), fila[5].ToString(),estad);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
