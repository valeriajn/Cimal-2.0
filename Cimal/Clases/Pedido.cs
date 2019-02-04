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
    public class Pedido : Conexion
    {
        public int ID { get; set; }
        public int Cliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total{ get; set; }
        public decimal Saldo{ get; set; }
        public string Comentarios { get; set; }
        public int IDTPedidoMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDPedido) + 1 from Pedido";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obti
        public bool GuardarPedido()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Pedido (IDPedido,IDCliente,FechaPedido,FechaEntrega,Total,Saldo,Comentarios,Estado) values (?,?,GETDATE(),?,?,?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", Cliente);
                comm.Parameters.AddWithValue("@ID", FechaEntrega.Date);
                comm.Parameters.AddWithValue("@ID", Total);
                comm.Parameters.AddWithValue("@ID", Total);
                comm.Parameters.AddWithValue("@ID", Comentarios);

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
        public bool CambiarEstado(int est,int id)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Pedido SET Estado = ? where IDPedido= ?";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@Estado", est);
        
                comm.Parameters.AddWithValue("@ID", id);

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
        }
        public bool ActualizarSaldo(int id,decimal saldo)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Pedido SET Saldo = ? where IDPedido= ?";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", saldo);
                comm.Parameters.AddWithValue("@ID", id);

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
        }
        public DataTable CargarTableros()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select IDPedido,T0.IDCliente, RTRIM(T1.Nombre) +' ' + RTRIM(T1.Apellido) 'Cliente',Nit,Total,Saldo,FechaPedido,FechaEntrega,Comentarios,T0.Estado from Pedido T0, Persona T1 where T0.IDCliente = T1.IDPersona";

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
        public DataTable CargarTablerosxCliente(int id)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select IDPedido,T0.IDCliente, RTRIM(T1.Nombre) +' ' + RTRIM(T1.Apellido) 'Cliente',Nit,Total,Saldo,FechaPedido,FechaEntrega,Comentarios,T0.Estado from Pedido T0, Persona T1 where T0.IDCliente = T1.IDPersona and T1.IDPersona = ?";
                comm.Parameters.AddWithValue("@ID", id);
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
