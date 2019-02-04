using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Cimal.Clases
{
    public class Opciones : Conexion
    {
        public int IDUsuario { get; set; }
        public int IDFormulario { get; set; }
        public bool Autorizacion { get; set; }
        public DataTable Carga_Usuarios()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Usuario T0 , Personal T1 where T0.IDUsuario = T1.IDPersonal";
                comm.CommandType = CommandType.Text;
                DataTable dtSeccion = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtSeccion);
                conn.Close();
                return dtSeccion;
            }
            catch
            {
                return null;
            }
        }
        public bool GuardarAutorizacionesPersonal(int usuario, int formulario)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Opciones (IDUsuario,IDFormulario,Autorizacion) values (?,?,0)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", usuario);
                comm.Parameters.AddWithValue("@Formuario", formulario);

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
            catch (Exception)
            {

                throw;
            }
        }
        public bool GuardarAutorizacionesCliente(int usuario, int formulario)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Opciones (IDUsuario,IDFormulario,Autorizacion) values (?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", usuario);
                comm.Parameters.AddWithValue("@Formuario", formulario);

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
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarAutorizacion()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Opciones set Autorizacion = ? where IDUsuario = ? and IDFormulario = ?";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@Autorizacion", Autorizacion);
                comm.Parameters.AddWithValue("@ID", IDUsuario);
                comm.Parameters.AddWithValue("@Nodocumento", IDFormulario);

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

        public DataTable ComprobarAutorizaciones(int usuario)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select IDUsuario,T0.IDFormulario,T1.Nombre,Autorizacion from Opciones T0,Formulario T1 where T0.IDFormulario = T1.IDFormulario and  IDUsuario = ? ";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", usuario);
                DataTable dtSeccion = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtSeccion);
                conn.Close();
                return dtSeccion;
            }
            catch
            {
                return null;
            }
        }
        public DataTable CargaTodo()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Formulario";
                comm.CommandType = CommandType.Text;
                DataTable dtSeccion = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtSeccion);
                conn.Close();
                return dtSeccion;
            }
            catch
            {
                return null;
            }
        }
        public bool existe2(int usuario, int autorizacion)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Autorizaciones where IDUsuario = ? and NoDocumento = ?";
                comm.Parameters.AddWithValue("@ID", usuario);
                comm.Parameters.AddWithValue("@Nodocumento", autorizacion);
                OleDbDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
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
        public bool existe(int usuario, int Documento)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select Autorizacion from Opciones where IDUsuario = ? and IDFormulario = ?";
                comm.Parameters.AddWithValue("@ID", usuario);
                comm.Parameters.AddWithValue("@Nodocumento", Documento);
                OleDbDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    return Convert.ToBoolean(reader[0].ToString());
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
        public DataTable CargarFormulariosCliente()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Formulario where Tipo = 'Cliente'";
                comm.CommandType = CommandType.Text;
                DataTable dtSeccion = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtSeccion);
                conn.Close();
                return dtSeccion;
            }
            catch
            {
                return null;
            }
        }
        public DataTable CargarFormulariosPersonal()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Formulario where Tipo = 'Personal'";
                comm.CommandType = CommandType.Text;
                DataTable dtSeccion = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtSeccion);
                conn.Close();
                return dtSeccion;
            }
            catch
            {
                return null;
            }
        }
       
    }
}
