namespace Cimal.LoginPermisos
{
    partial class frOpciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAutorizaciones = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvAutorizacion = new System.Windows.Forms.DataGridView();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lbxUsuarios = new System.Windows.Forms.ListBox();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAutorizaciones
            // 
            this.lblAutorizaciones.AutoSize = true;
            this.lblAutorizaciones.Location = new System.Drawing.Point(280, 10);
            this.lblAutorizaciones.Name = "lblAutorizaciones";
            this.lblAutorizaciones.Size = new System.Drawing.Size(89, 12);
            this.lblAutorizaciones.TabIndex = 17;
            this.lblAutorizaciones.Text = "Autorizaciones";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.Location = new System.Drawing.Point(112, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 21);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Location = new System.Drawing.Point(17, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 21);
            this.button1.TabIndex = 15;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvAutorizacion
            // 
            this.dgvAutorizacion.AllowUserToAddRows = false;
            this.dgvAutorizacion.AllowUserToDeleteRows = false;
            this.dgvAutorizacion.AllowUserToResizeColumns = false;
            this.dgvAutorizacion.AllowUserToResizeRows = false;
            this.dgvAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUsuario,
            this.NoDocumento,
            this.Descripcion});
            this.dgvAutorizacion.Location = new System.Drawing.Point(282, 24);
            this.dgvAutorizacion.Name = "dgvAutorizacion";
            this.dgvAutorizacion.RowHeadersVisible = false;
            this.dgvAutorizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutorizacion.Size = new System.Drawing.Size(402, 369);
            this.dgvAutorizacion.TabIndex = 14;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(14, 10);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(54, 12);
            this.lblUsuarios.TabIndex = 13;
            this.lblUsuarios.Text = "Usuarios";
            // 
            // lbxUsuarios
            // 
            this.lbxUsuarios.FormattingEnabled = true;
            this.lbxUsuarios.ItemHeight = 12;
            this.lbxUsuarios.Location = new System.Drawing.Point(17, 24);
            this.lbxUsuarios.Name = "lbxUsuarios";
            this.lbxUsuarios.Size = new System.Drawing.Size(257, 364);
            this.lbxUsuarios.TabIndex = 12;
            this.lbxUsuarios.SelectedIndexChanged += new System.EventHandler(this.lbxUsuarios_SelectedIndexChanged);
            // 
            // IDUsuario
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.IDUsuario.DefaultCellStyle = dataGridViewCellStyle4;
            this.IDUsuario.HeaderText = "IDUsuario";
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.ReadOnly = true;
            this.IDUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IDUsuario.Visible = false;
            // 
            // NoDocumento
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NoDocumento.DefaultCellStyle = dataGridViewCellStyle5;
            this.NoDocumento.HeaderText = "NoDocumento";
            this.NoDocumento.Name = "NoDocumento";
            this.NoDocumento.ReadOnly = true;
            this.NoDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoDocumento.Visible = false;
            // 
            // Descripcion
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle6;
            this.Descripcion.HeaderText = "Descipcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descripcion.Width = 200;
            // 
            // frOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 438);
            this.Controls.Add(this.lblAutorizaciones);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvAutorizacion);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.lbxUsuarios);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.frOpciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAutorizaciones;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvAutorizacion;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.ListBox lbxUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}