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
    public class Prueba : Conexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
     

        public int IDPruebaMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDPrueba) + 1 from Prueba";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obtiene el sgte Id para registrar
        public bool GuardarPrueba()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Prueba (IDPrueba,NombrePrueba,ApellidoPrueba,fecha,Estado) values (?,?,?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", Nombre);
                comm.Parameters.AddWithValue("@ID", Apellido);
                comm.Parameters.AddWithValue("@ID", Fecha.Date);
                

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
        public bool ActualizarPrueba()//Actualiza en la Tabla Persona
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Prueba SET NombrePrueba = ?,ApellidoPrueba= ?,fecha = ? where IDPrueba = ?";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@Nombre", Nombre);
                comm.Parameters.AddWithValue("@Apellido", Apellido);
                comm.Parameters.AddWithValue("@fecha", Fecha.Date);
                
                comm.Parameters.AddWithValue("@ID", ID);

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
        public bool Anular(int id)//Actualiza en la Tabla Persona
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Prueba SET Estado = 0  where IDPrueba = ?";
                //para eliminar completo: comm.CommandText = "Delete from Prueba where IDPrueba = ?";
                comm.CommandType = CommandType.Text;


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
        public DataTable CargarPersonaPersonal()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Prueba  where Estado = 1";
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
