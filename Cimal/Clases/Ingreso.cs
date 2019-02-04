using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;
using System.Collections;

namespace Cimal.Clases
{
    public class Ingreso : Conexion
    {
        public int ID { get; set; }
        public int Pedido { get; set; }
        public decimal Monto { get; set; }
        public string Glosa { get; set; }
        public string Tipo { get; set; }
        public int IDIngresoMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDPago) + 1 from Pago";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obti
        public bool GuardarIngreso()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Pago (IDPago,IDPedido,Glosa,Monto,Tipo) values (?,?,?,?,?)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", Pedido);
                comm.Parameters.AddWithValue("@ID", Glosa);
                comm.Parameters.AddWithValue("@ID", Monto);
                comm.Parameters.AddWithValue("@ID", Tipo);
                

                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return false;

            }

        }//Guarda en la Tabla Clientes
    }
}
