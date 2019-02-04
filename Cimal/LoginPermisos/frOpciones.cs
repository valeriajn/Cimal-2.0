using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Cimal.LoginPermisos
{
    public partial class frOpciones : Form
    {
        public frOpciones()
        {
            InitializeComponent();
        }
        Clases.Opciones Aut = new Clases.Opciones();
        private void frOpciones_Load(object sender, EventArgs e)
        {
            DGV();
            lbxUsuarios.DisplayMember = "Login";
            lbxUsuarios.ValueMember = "IDUsuario";
            lbxUsuarios.DataSource = Aut.Carga_Usuarios();
            /////////////////
            dgvAutorizacion.Rows.Clear();
        }
        private void DGV()
        {

            DataGridViewCheckBoxColumn Autorizado = new DataGridViewCheckBoxColumn();
            Autorizado.Name = "Autorizado";
            Autorizado.HeaderText = "Autorizado";
            dgvAutorizacion.Columns.Insert(3, Autorizado);
            DataGridViewCheckBoxColumn NoAutorizado = new DataGridViewCheckBoxColumn();
            NoAutorizado.Name = "NoAutorizado";
            NoAutorizado.HeaderText = "No Autorizado";
            dgvAutorizacion.Columns.Insert(4, NoAutorizado);
        }
        private void CargarDatos(DataTable tabla)
        {

            dgvAutorizacion.Rows.Clear();
            int Row = 0;
            bool a = false;
            bool b = false;
            bool c = false;
            foreach (DataRow dt in tabla.Rows)
            {

                if (Convert.ToBoolean(dt[3].ToString()) == true)
                {
                    a = true;
                    b = false;

                }
                if (Convert.ToBoolean(dt[3].ToString()) == false)
                {
                    a = false;
                    b = true;

                }

                dgvAutorizacion.Rows.Add(Convert.ToInt32(dt[0].ToString()), Convert.ToInt32(dt[1].ToString()), dt[2].ToString(), a, b);

                Row++;

            }

        }

        private void lbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lbxUsuarios.SelectedValue) != 0)
                {
                     CargarDatos(Aut.ComprobarAutorizaciones(Convert.ToInt32(lbxUsuarios.SelectedValue)));
                }
                   
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lbxUsuarios.SelectedValue) != 0)
                {
                    int c = 0;
                    foreach (DataGridViewRow row in dgvAutorizacion.Rows)
                    {
                        Aut.IDUsuario = Convert.ToInt32(row.Cells["IDUsuario"].Value);
                        Aut.IDFormulario = Convert.ToInt32(row.Cells["NoDocumento"].Value);

                        if (Convert.ToInt32(row.Cells["Autorizado"].Value) == 1)
                        {
                            Aut.Autorizacion = true;
                        }
                        if (Convert.ToInt32(row.Cells["NoAutorizado"].Value) == 1)
                        {
                            Aut.Autorizacion = false;
                        }
                        if (Aut.ActualizarAutorizacion())
                        {
                            c++;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                            return;
                        }
                    }
                    CargarDatos(Aut.ComprobarAutorizaciones(Convert.ToInt32(lbxUsuarios.SelectedValue)));
                    MessageBox.Show("Datos Actualizados");

                }
                else
                {
                    MessageBox.Show("Seleccione un Usuario primero");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
