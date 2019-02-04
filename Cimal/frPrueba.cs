using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal
{
    public partial class frPrueba : Form
    {
        public frPrueba()
        {
            InitializeComponent();
        }
        Clases.Prueba persona = new Clases.Prueba();
      
       private bool Validar()
        {
            persona.ID = persona.IDPruebaMax();
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Fecha = dtfecha.Value;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Validar())
                {
                    persona.GuardarPrueba();
                   
                   
                    MessageBox.Show("Registrado");
                    Cargardatos();
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frPrueba_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in persona.CargarPersonaPersonal().Rows)
                {
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(), fila[4].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }



   
       
    }
}
