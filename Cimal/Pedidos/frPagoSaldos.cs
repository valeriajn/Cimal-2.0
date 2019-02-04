using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Pedidos
{
    public partial class frPagoSaldos : Form
    {
        public frPagoSaldos()
        {
            InitializeComponent();
        }
        Clases.Ingreso pag = new Clases.Ingreso();
        Clases.Pedido ped = new Clases.Pedido();
        public int idpedido = 0;
        private void frPagoSaldos_Load(object sender, EventArgs e)
        {

        }
        public bool Validar()
        {
            pag.ID = pag.IDIngresoMax();
            pag.Pedido = idpedido;
            pag.Glosa = "Pago Recibido por " + txtNombre.Text;
            pag.Monto = Convert.ToDecimal(txtefectivo.Text);
            if (rdEfectivo.Checked)
            {
                pag.Tipo = "Efectivo";
            }
            else
            {
                pag.Tipo = "Tarjeta";
            }
            return true;
        }
        private void txtefectivo_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtefectivo.Text) > Convert.ToDecimal(txtTotal.Text))
            {
                txtefectivo.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    pag.GuardarIngreso();
                    ped.ActualizarSaldo(idpedido, Convert.ToDecimal(txtTotal.Text) - pag.Monto);
                    if (Convert.ToDecimal(txtefectivo.Text) == Convert.ToDecimal(txtTotal.Text))
                    {
                        ped.CambiarEstado(2, idpedido);
                    }


                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rdTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTarjeta.Checked == true)
            {
                txtTarjeta.Enabled = true;
                txtTarjeta.Text = "";
            }
        }

        private void rdEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdEfectivo.Checked == true)
            {
                txtTarjeta.Enabled = false;
                txtTarjeta.Text = "";
            }
        }

        private void txtefectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtefectivo.Text.Length; i++)
            {
                if (txtefectivo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
