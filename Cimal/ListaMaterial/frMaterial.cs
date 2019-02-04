using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.ListaMaterial
{
    public partial class frMaterial : Form
    {
        public frMaterial()
        {
            InitializeComponent();
        }
        Clases.Muebles muebl = new Clases.Muebles();
        Clases.ListaMaterial list = new Clases.ListaMaterial();
        private void añadirFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvCargo.Rows.Add("", "","","",Convert.ToInt32(0));
        }

        private void eliminarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCargo.Rows.Count != 0)
            {
                dgvCargo.Rows.RemoveAt(dgvCargo.CurrentRow.Index);
            }
            
        }

        private void frMaterial_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "IDMueble";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DataSource = muebl.CargarMuebles(); 
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.DataSource != null)
            {
                Cargardatos(Convert.ToInt32(comboBox1.SelectedValue));
            }
        }
        private void Validar()
        {
            list.IDMueble = Convert.ToInt32(comboBox1.SelectedValue);

        }
        private void Cargardatos(int id)
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in list.CargarLista(id).Rows)
                {
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(), fila[4].ToString(), Convert.ToInt32(fila[5].ToString()));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvCargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (dgvCargo.CurrentCell == dgvCargo.CurrentRow.Cells[1])
                {
                    Tablero.frListadoTablero list = new Tablero.frListadoTablero();
                    list.ShowDialog();
                    if (list.DialogResult == DialogResult.OK)
                    {
                        dgvCargo.CurrentRow.Cells[3].Value = list.color;
                        
                        dgvCargo.CurrentRow.Cells[0].Value = list.id;
                        dgvCargo.CurrentRow.Cells[1].Value = list.nombre.ToString();
                        dgvCargo.CurrentRow.Cells[2].Value = list.precio;
                        dgvCargo.CurrentRow.Cells[4].Value = list.dimension;


                    }
                }
                if (dgvCargo.CurrentCell == dgvCargo.CurrentRow.Cells[0])
                {
                    Tablero.frListadoTablero list = new Tablero.frListadoTablero();
                    list.ShowDialog();
                    if (list.DialogResult == DialogResult.OK)
                    {
                        dgvCargo.CurrentRow.Cells[3].Value = list.color;

                        dgvCargo.CurrentRow.Cells[0].Value = list.id;
                        dgvCargo.CurrentRow.Cells[1].Value = list.nombre.ToString();
                        dgvCargo.CurrentRow.Cells[2].Value = list.precio;
                        dgvCargo.CurrentRow.Cells[4].Value = list.dimension;

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Validar();
            list.EliminarLista();

            foreach (DataGridViewRow row in dgvCargo.Rows)
            {
                if (row.Cells[0].Value.ToString() == "")
                {
                    MessageBox.Show("Verifique que los Insumos esten Correctamente Añadidos");
                    return;
                }
                if (row.Cells[5].Value.ToString() == "0" || row.Cells[5].Value.ToString() == "")
                {
                    MessageBox.Show("la cantidad no puede ser 0 o estar vacia");
                    return;
                }
            }
            foreach (DataGridViewRow row in dgvCargo.Rows)
            {
                list.IDTablero= Convert.ToInt32(row.Cells[0].Value);
                list.Cantidad = Convert.ToInt32(row.Cells[5].Value);
                list.GuardarLista();
            }
        }
    }
}
