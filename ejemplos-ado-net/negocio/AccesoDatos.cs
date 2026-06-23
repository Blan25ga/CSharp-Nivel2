using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    //! Esta clase se encarga de la conexion a la base de datos y de ejecutar comandos SQL.
    public class AccesoDatos 
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader lector;
      
        public AccesoDatos () // Constructor de la clase AccesoDatos
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand(); // Este comando se utiliza para ejecutar comandos SQL en la base de datos.

        }

        // Este metodo se utiliza para establecer la consulta SQL que se va a ejecutar.
        public void setearConsulta(string consulta) // setea la consulta SQL que se va a ejecutar en el comando.
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        // Funcion para ejecutar la lectura.
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Funcion para cerrar la conexion a la base de datos.
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
                conexion.Close();
        }
    }
}
