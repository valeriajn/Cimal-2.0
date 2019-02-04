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
    public class Reportes : Conexion
    {
        public DataTable CantidadTablerosVendidos(DateTime inicio, DateTime fin)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select Top 100 T0.IDTablero,T1.Nombre , Sum(Cantidad) 'Cantidad'from   Detalle T0 , Tablero T1, Pedido T2  where T0.IDTablero  = T1.IDTablero and T2.IDPedido= T0.IDPedido and T2.FechaPedido >= ? and T2.FechaPedido <= ? Group by T0.IDTablero ,T1.Nombre Order by count(1) desc ";
                comm.Parameters.AddWithValue("@ID", inicio.Date);
                comm.Parameters.AddWithValue("@ID", fin.Date);
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
        public DataTable PedidosPorRango(DateTime inicio, DateTime fin)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select IDPedido, T0.IDCliente, (RTRIM(T1.Nombre)+ RTRIM(T1.Apellido))'Nombre', FechaPedido , Total,Saldo,T0.Estado from Pedido T0, Persona T1 where T0.IDCliente = T1.IDPersona and  T0.FechaPedido >= ? and T0.FechaPedido <= ?";
                comm.Parameters.AddWithValue("@ID", inicio.Date);
                comm.Parameters.AddWithValue("@ID", fin.Date);
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
        public DataTable Saldos()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "select Distinct T0.IDCliente, (RTRIM(T1.Nombre)+ RTRIM(T1.Apellido))'Nombre',Sum(Total) 'Total',Sum(Saldo)'Saldo' from Pedido T0, Persona T1 where T0.IDCliente = T1.IDPersona and T0.Estado = 1 group by IDCliente,Nombre,Apellido,T0.Estado";
              
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
