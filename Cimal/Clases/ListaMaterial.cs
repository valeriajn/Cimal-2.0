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
    public class ListaMaterial : Conexion
    {
        public int IDMueble { get; set; }
        public int IDTablero { get; set; }
        public int Cantidad { get; set; }
        public bool GuardarLista()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO ListaMaterial(IDMueble,IDTablero,Cantidad) values (?,?,?)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", IDMueble);
                comm.Parameters.AddWithValue("@ID", IDTablero);
                comm.Parameters.AddWithValue("@ID", Cantidad);


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
        public bool EliminarLista()//Guarda en la Tabla Insumo
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM ListaMaterial where IDMueble = ?";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", IDMueble);
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
        public DataTable CargarLista(int mueble)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select T0.IDTablero, T2.Nombre, T2.Precio ,Color , Dimensiones,Cantidad from ListaMaterial T0,Mueble T1, Tablero T2 where T0.IDMueble = T1.IDMueble and T0.IDTablero = T2.IDTablero and T2.Estado = 1 and T0.IDMueble = ?";
                comm.Parameters.AddWithValue("@ID", mueble);
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
