﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cimal.Clases;
namespace Cimal.Cliente
{
    public partial class frGuardarCliente : Form
    {
        public frGuardarCliente()
        {
            InitializeComponent();
        }
        Usuario user = new Usuario();
        Persona persona = new Persona();
        Validar val = new Validar();
        Opciones op = new Opciones();
        private bool Verificar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserte un nombre correcto");
                return false;
            }
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Inserte un apellido correcto");
                return false;
            }
            if (txtNit.Text == "")
            {
                txtNit.Text = "0";
            }
            if (txtCedula.Text == " ")
            {
                txtCedula.Text = "0";
            }
            if (txtLogin.Text == " ")
            {
                 MessageBox.Show("Inserte un nombre de usuario /Login correcto");
                return false;
            }
            if (txtPassword.Text == " ")
            {
                MessageBox.Show("Inserte un Password correcto");
                return false;
            }
            return true;
        }
        private bool Validar()
        {
            persona.ID = persona.IDPersonaMax();
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Nit= txtNit.Text;
            persona.CI = txtCedula.Text;
            persona.Direccion = txtDireccion.Text;
            persona.Correo = txtCorreo.Text;
            persona.Telefono = txtTelefono.Text;
            user.ID = persona.ID;
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Text;

            return true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verificar())
                {
                    return;
                }
                if(Validar())
                {
                    persona.GuardarPersona();
                    persona.GuardarCliente();
                    user.GuardarUsuario();
                    foreach (DataRow row in op.CargarFormulariosCliente().Rows)
                    {
                        op.GuardarAutorizacionesCliente(Convert.ToInt32(persona.ID), Convert.ToInt32(row[0].ToString()));
                    }
                    MessageBox.Show("Registrado");
                }
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.MPermitirNumeros(e);
        }

        private void frGuardarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
