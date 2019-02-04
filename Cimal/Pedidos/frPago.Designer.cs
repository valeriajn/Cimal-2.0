namespace Cimal.Pedidos
{
    partial class frPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdTarjeta = new System.Windows.Forms.RadioButton();
            this.rdEfectivo = new System.Windows.Forms.RadioButton();
            this.txtefectivo = new System.Windows.Forms.TextBox();
            this.lblefectivo = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.lblIdPaciente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCarnetIdentidad = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(189)))), ((int)(((byte)(0)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdTarjeta);
            this.panel2.Controls.Add(this.rdEfectivo);
            this.panel2.Controls.Add(this.txtefectivo);
            this.panel2.Controls.Add(this.lblefectivo);
            this.panel2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(17, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 47);
            this.panel2.TabIndex = 10;
            // 
            // rdTarjeta
            // 
            this.rdTarjeta.AutoSize = true;
            this.rdTarjeta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTarjeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdTarjeta.Location = new System.Drawing.Point(296, 25);
            this.rdTarjeta.Name = "rdTarjeta";
            this.rdTarjeta.Size = new System.Drawing.Size(63, 16);
            this.rdTarjeta.TabIndex = 9;
            this.rdTarjeta.Text = "Tarjeta";
            this.rdTarjeta.UseVisualStyleBackColor = true;
            this.rdTarjeta.CheckedChanged += new System.EventHandler(this.rdTarjeta_CheckedChanged);
            // 
            // rdEfectivo
            // 
            this.rdEfectivo.AutoSize = true;
            this.rdEfectivo.Checked = true;
            this.rdEfectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdEfectivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdEfectivo.Location = new System.Drawing.Point(296, 3);
            this.rdEfectivo.Name = "rdEfectivo";
            this.rdEfectivo.Size = new System.Drawing.Size(68, 16);
            this.rdEfectivo.TabIndex = 8;
            this.rdEfectivo.TabStop = true;
            this.rdEfectivo.Text = "Efectivo";
            this.rdEfectivo.UseVisualStyleBackColor = true;
            this.rdEfectivo.CheckedChanged += new System.EventHandler(this.rdEfectivo_CheckedChanged);
            // 
            // txtefectivo
            // 
            this.txtefectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtefectivo.Location = new System.Drawing.Point(133, 10);
            this.txtefectivo.MaxLength = 7;
            this.txtefectivo.Name = "txtefectivo";
            this.txtefectivo.Size = new System.Drawing.Size(156, 26);
            this.txtefectivo.TabIndex = 4;
            this.txtefectivo.Text = "0";
            this.txtefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtefectivo.TextChanged += new System.EventHandler(this.txtefectivo_TextChanged);
            this.txtefectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtefectivo_KeyPress);
            // 
            // lblefectivo
            // 
            this.lblefectivo.AutoSize = true;
            this.lblefectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblefectivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblefectivo.Location = new System.Drawing.Point(4, 14);
            this.lblefectivo.Name = "lblefectivo";
            this.lblefectivo.Size = new System.Drawing.Size(123, 18);
            this.lblefectivo.TabIndex = 3;
            this.lblefectivo.Text = "Monto a Pagar";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(20, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 2);
            this.label18.TabIndex = 50;
            this.label18.Text = "label18";
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtIDCliente.Enabled = false;
            this.txtIDCliente.Location = new System.Drawing.Point(149, 56);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(35, 20);
            this.txtIDCliente.TabIndex = 49;
            // 
            // lblIdPaciente
            // 
            this.lblIdPaciente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPaciente.Location = new System.Drawing.Point(20, 59);
            this.lblIdPaciente.Name = "lblIdPaciente";
            this.lblIdPaciente.Size = new System.Drawing.Size(125, 15);
            this.lblIdPaciente.TabIndex = 48;
            this.lblIdPaciente.Text = "IDCliente";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(17, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 2);
            this.label6.TabIndex = 46;
            this.label6.Text = "label6";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(17, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 2);
            this.label4.TabIndex = 45;
            this.label4.Text = "label4";
            // 
            // lblCarnetIdentidad
            // 
            this.lblCarnetIdentidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnetIdentidad.Location = new System.Drawing.Point(17, 105);
            this.lblCarnetIdentidad.Name = "lblCarnetIdentidad";
            this.lblCarnetIdentidad.Size = new System.Drawing.Size(128, 15);
            this.lblCarnetIdentidad.TabIndex = 44;
            this.lblCarnetIdentidad.Text = "Nit";
            // 
            // txtNit
            // 
            this.txtNit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNit.Enabled = false;
            this.txtNit.Location = new System.Drawing.Point(149, 101);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(121, 20);
            this.txtNit.TabIndex = 43;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(149, 80);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(259, 20);
            this.txtNombre.TabIndex = 42;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.Location = new System.Drawing.Point(17, 83);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(114, 15);
            this.lblNombreCompleto.TabIndex = 41;
            this.lblNombreCompleto.Text = "Nombre Completo";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(20, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 2);
            this.label1.TabIndex = 53;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "No Tarjeta";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTarjeta.Enabled = false;
            this.txtTarjeta.Location = new System.Drawing.Point(149, 127);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(121, 20);
            this.txtTarjeta.TabIndex = 51;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(189)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(315, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 36);
            this.button2.TabIndex = 60;
            this.button2.Text = "Finalizar Compra";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 61;
            this.label3.Text = "PAGO";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(20, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 2);
            this.label5.TabIndex = 64;
            this.label5.Text = "label5";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 63;
            this.label7.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(149, 153);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(121, 20);
            this.txtTotal.TabIndex = 62;
            // 
            // frPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 297);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtIDCliente);
            this.Controls.Add(this.lblIdPaciente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCarnetIdentidad);
            this.Controls.Add(this.txtNit);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombreCompleto);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pago";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdTarjeta;
        private System.Windows.Forms.RadioButton rdEfectivo;
        public System.Windows.Forms.TextBox txtefectivo;
        private System.Windows.Forms.Label lblefectivo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblIdPaciente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCarnetIdentidad;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtIDCliente;
        public System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtTotal;
    }
}