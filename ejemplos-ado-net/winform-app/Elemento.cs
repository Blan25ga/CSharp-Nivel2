using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app
{
    internal class Elemento // Clase para representar los elementos de tipo y debilidad de los pokemons.
    {
        public int Id { get; set; } // Esta propiedad se utiliza para mapear el Id de la tabla Elementos de la base de datos, aunque no se utiliza en este proyecto, es recomendable tenerla para futuras implementaciones.
        public string Descripcion { get; set; }// Esta propiedad se utiliza para mapear la descripcion de la tabla Elementos de la base de datos, y se utiliza para mostrar el tipo y la debilidad.


        // Este metodo se utiliza para mostrar la descripcion del elemento en el ComboBox, ya que el ComboBox utiliza el metodo ToString() para mostrar el valor de cada item.
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
