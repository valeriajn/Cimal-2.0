using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cimal.Clases;
using Cimal.LoginPermisos;
namespace Cimal
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        Opciones aut = new Opciones();
        private void Principal_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
                this.Dispose();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente.ListarClientes f = new Cliente.ListarClientes();
            if (aut.existe(Program.IDUsuario, 1) || aut.existe(Program.IDUsuario, 2))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Personal.frListarPersonal f = new Personal.frListarPersonal();
            if (aut.existe(Program.IDUsuario, 5))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tablero.ListarTablero f = new Tablero.ListarTablero();
            if (aut.existe(Program.IDUsuario, 7))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mueble.ListarMueble f = new Mueble.ListarMueble();
            if (aut.existe(Program.IDUsuario, 6))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                 
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginPermisos.frOpciones f = new frOpciones();
            if (aut.existe(Program.IDUsuario, 10)   )
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pedidos.frPedidos f = new Pedidos.frPedidos();
            if (aut.existe(Program.IDUsuario, 4) || aut.existe(Program.IDUsuario, 3))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaMaterial.frMaterial f = new ListaMaterial.frMaterial();
            if (aut.existe(Program.IDUsuario, 9))
            {

                f.MdiParent = this.MdiParent;
                f.ShowDialog();
            }
            else
            {
                if (Program.IDUsuario == 0)
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Acceso No Autorizado");
                }


            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Reportes.frReportes f = new Reportes.frReportes();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frPrueba f = new frPrueba();
            f.ShowDialog();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            frPrueba f = new frPrueba();
            f.ShowDialog();
        }
    }
}
