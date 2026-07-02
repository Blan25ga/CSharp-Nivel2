using System;
using System.Collections.Generic;
using System.Data.SqlClient;// Esta clase se encarga de la conexion a la base de datos y de traer los datos.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    // Esta clase se encarga de la logica de negocio, de la conexion a la base de datos y de traer los datos
    public class PokemonNegocio 
    {
        public List<Pokemon> listar() // Este metodo se encarga de traer los datos de la base de datos y devolver una lista.
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();// Esta clase se encarga de la conexion a la base de datos.
            SqlCommand comando = new SqlCommand();// Esta clase se encarga de ejecutar comandos SQL en la base de datos.
            SqlDataReader lector;// Esta clase se encarga de leer los datos que devuelve la base de datos.


            // "En este bloque de codigo se establece la conexion a la base de datos".
            // Se ejecuta el comando SQL y se leen los datos que devuelve la base de datos.
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                //! Este bloque lee cada fila que devuelve la base de datos y SE CREA CADA OBJETO que se puso en la consulta SQL, y se agrega a la lista de pokemons.
                while (lector.Read())// El metodo Read() devuelve true si hay una fila para leer, y false si no hay mas filas.
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);// Uso de ejemplo de lectura por indice, (es recomdable usar el nombre de la columna para evitar errores).
                    aux.Nombre = (string)lector["Nombre"]; // Es recomendable usar el nombre de la columna para evitar errores.
                    aux.Descripcion = (string)lector["Descripcion"];//mapea el valor de la columna "Descripcion" a la propiedad Descripcion del objeto Pokemon.

                    //Validacion para evitar leer valores nulos en la columna "UrlImagen" y asignar un valor por defecto si es nulo.

                    // Validación de NULL en UrlImagen
                    if (!lector.IsDBNull(lector.GetOrdinal("UrlImagen")))
                        aux.UrlImagen = (string)lector["UrlImagen"];
                    else
                        aux.UrlImagen = "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png"; // valor por defecto

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];  
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

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


        //! Esta funcion se encarga de agregar un nuevo pokemon a la base de datos, recibe como parametro un objeto Pokemon y lo inserta en la tabla POKEMONS.
        public void agregar(Pokemon nuevo)
        {
            // Esta accion "Agrega" un nuevo pokemon a la base de datos, recibe como parametro un objeto Pokemon y lo Inserta en la tabla POKEMONS.
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // "En este bloque de codigo se establece la conexion a la base de datos y se ejecuta el comando SQL para insertar un nuevo pokemon". "Con el @ se indica que se va a pasar un parametro a la consulta SQL, y con el AddWithValue se le asigna el valor del parametro."
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @IdTipo, @IdDebilidad, @UrlImagen)");
                
                // Asignar valores a los parámetros
                datos.setearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.setearParametro("@IdDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);

                datos.ejecutarAccion();// Se ejecuta el comando SQL para insertar un nuevo pokemon en la tabla POKEMONS.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally // Este bloque se ejecuta siempre, haya o no haya ocurrido un error, y se encarga de cerrar la conexion a la base de datos.
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
