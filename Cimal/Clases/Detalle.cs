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
    public  class Detalle : Conexion
    {
        public int ID { get; set; }
        public int IDPedido { get; set; }
        public int IDTablero { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal subtotal { get; set; }

        ////
        public int IDMueble { get; set; }
        public int CantidadMueble { get; set; }
        public int IDDetalleMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDDetalle) + 1 from Detalle";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obti
        public bool GuardarDetalle1()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Detalle (IDDetalle,IDPedido,IDTablero,Precio,Cantidad,SubTotal) values (?,?,?,?,?,?)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", IDPedido);
                comm.Parameters.AddWithValue("@ID", IDTablero);
                comm.Parameters.AddWithValue("@ID", Precio);
                comm.Parameters.AddWithValue("@ID", Cantidad);
                comm.Parameters.AddWithValue("@ID", subtotal);
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
        public bool GuardarDetalle2()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO DetalleMueble (IDPedido,IDMueble,Cantidad) values (?,?,?)";
                comm.CommandType = CommandType.Text;
               
                comm.Parameters.AddWithValue("@ID", IDPedido);
                comm.Parameters.AddWithValue("@ID", IDMueble);
                comm.Parameters.AddWithValue("@ID", CantidadMueble);
        
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
        public DataTable CargarMuebles(int idpedido)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select T0.IDMueble,T1.Nombre,T0.Cantidad from DetalleMueble T0, Mueble T1 where T0.IDMueble = T1.IDMueble  and IDPedido = ?";
                comm.Parameters.AddWithValue("@ID", idpedido);
                DataTable dtCargo = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtCargo);
                return dtCargo;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Cargardetalle(int idpedido)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select T0.IDTablero, T1.Nombre, T0.Precio ,T0.Cantidad , SubTotal from Detalle T0, Tablero T1 where T0.IDTablero = T1.IDTablero and T0.IDPedido = ?";
                comm.Parameters.AddWithValue("@ID", idpedido);
                DataTable dtCargo = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtCargo);
                return dtCargo;
            }
            catch
            {
                return null;
            }
        }
    }
}
