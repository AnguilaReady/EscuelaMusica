using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class BD
    {
        private NpgsqlConnection conexionConBD;
        private NpgsqlCommand orden;
        private NpgsqlDataReader lector;
        static string strConexion;

        public BD()
        {
            strConexion = string.Format("server=localhost; " +
                "port=5432;" +
                "Database=EscuelaSanJuanDB;" +
                "User ID=postgres;" +
                "Password=1234");
            conexionConBD = null;
            orden = null;
            lector = null;
        }

        public void Abrir()
        {
            //Abrir conexion con la BD
            conexionConBD = new NpgsqlConnection(strConexion);
            conexionConBD.Open();
        }
        public void Cerrar()
        {
            //Cerrar la conexion la BD.
            if (lector != null)
            {
                lector.Close();
            }

            if (conexionConBD != null)
            {
                conexionConBD.Close();
            }
        }

        public NpgsqlDataReader EjecutarSelect(string SQL)
        {
            //Ejecuta solo select ya que devuelve datos
            orden = new NpgsqlCommand(SQL, conexionConBD);
            lector = orden.ExecuteReader();
            return lector;
        }

        public int EjecutarOrden(string SQL)
        {
            try
            {
                //Ejecutar cualquier tipo de orden menos selects ya que devuelve cantidad de datos afectados.
                int filasAfectadas = 0;
                orden = new NpgsqlCommand(SQL, conexionConBD);
                filasAfectadas = orden.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch(Npgsql.PostgresException)
            {
                return -1;
            }
            
        }
    }
}
