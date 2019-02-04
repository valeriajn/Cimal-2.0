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
    public partial class frActualizarMueble : Form
    {
        public frActualizarMueble()
        {
            InitializeComponent();
        }
        Clases.Muebles muebl = new Clases.Muebles();
        public int id;
        private void frActualizarMueble_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                foreach (DataRow fila in muebl.CargarTablerosid(id).Rows)
                {

                    txtNombre.Text = fila[1].ToString();
                    txtDescripcion.Text = fila[2].ToString();
                    pictureBox1.Image = muebl.ObtenerImagen(id);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "*.bmp;*.jpg;*.png|*.bmp;*.gif;*.jpg;*.png ";
            Abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Abrir.Title = "Seleccione una Imagen";
            Abrir.RestoreDirectory = true;
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                lblruta.Text = Abrir.FileName;
                // txtNombre.Text = Abrir.SafeFileName;
                pictureBox1.Image = Image.FromFile(Abrir.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                lblruta.Text = "";
                pictureBox1.Image = null;
            }
        }
        private bool Validar()
        {
            muebl.ID = id;
            muebl.Nombre = txtNombre.Text;
            muebl.Descripcion = txtDescripcion.Text;


            return true;
        }
        private bool Verificar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserte un nombre correcto");
                return false;
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Inserte un Precio correcto");
                return false;
            }
            if (pictureBox1.Image == null )
            {
                MessageBox.Show("Inserte una imagen valida");
                return false;
            }

            return true;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verificar())
                {
                    return;
                }
                if (Validar())
                {
                    muebl.ActualizarMueble();
                    if (lblruta.Text != "")
                    {
                        muebl.ActualizarImagen(lblruta.Text);
                    }
                    MessageBox.Show("Registrado");
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
