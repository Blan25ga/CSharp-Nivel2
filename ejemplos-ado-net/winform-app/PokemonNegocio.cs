using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;// Esta clase se encarga de la conexion a la base de datos y de traer los datos.

namespace winform_app
{
    // Esta clase se encarga de la logica de negocio, de la conexion a la base de datos y de traer los datos
    class PokemonNegocio 
    {
        public List<Pokemon> listar() // Este metodo se encarga de traer los datos de la base de datos y devolver una lista.
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();// Esta clase se encarga de la conexion a la base de datos.
            SqlCommand comando = new SqlCommand();// Esta clase se encarga de ejecutar comandos SQL en la base de datos.
            SqlDataReader lector;// Esta clase se encarga de leer los datos que devuelve la base de datos.


            // En este bloque de codigo se establece la conexion a la base de datos.
            // Se ejecuta el comando SQL y se leen los datos que devuelve la base de datos.
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, Descripcion From POKEMONS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                // En este bloque de codigo se lee cada fila que devuelve la base de datos y crea un objeto Pokemon con los datos de cada fila.
                while (lector.Read())// El metodo Read() devuelve true si hay una fila para leer, y false si no hay mas filas.
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0);// Uso de ejemplo de lectura por indice, (es recomdable usar el nombre de la columna para evitar errores).
                    aux.Nombre = (string)lector["Nombre"]; // Es recomendable usar el nombre de la columna para evitar errores.
                    aux.Descripcion = (string)lector["Descripcion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            // En este bloque se captura cualquier error que pueda ocurrir durante la conexion a la DB o la ejecucion del comando SQL.
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
