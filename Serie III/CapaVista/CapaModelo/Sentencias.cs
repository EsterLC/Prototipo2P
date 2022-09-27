using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Sentencias
    {
        Conexion con = new Conexion();

        public OdbcDataAdapter llenarTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

        public void insertar(string dato, string tipo, string tabla)
        {

            string sql = "insert into " + tabla + "(" + tipo + ") values (" + dato + ")";
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            cmd.ExecuteNonQuery();

        }

        public void actualizar(string dato, string condicion, string tabla)
        {

            string sql = "Update " + tabla + " " + dato + " where " + condicion;
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            cmd.ExecuteNonQuery();

        }

        public void eliminar(int clave, string campo, string tabla)
        {
            string sql = "delete from " + tabla + " where " + campo + "=" + clave + ";";
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            cmd.ExecuteNonQuery();
        }

        public string buscarid(string tabla, string tipo)
        {
            string dato = " ";
            string sql = "select " + tipo + " from " + tabla + " Order by " + tipo + " Desc Limit 1";
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            OdbcDataReader lr = cmd.ExecuteReader();
            while (lr.Read())
            {
                dato = lr.GetString(0);
            }

            return dato;
        }

    }
}
