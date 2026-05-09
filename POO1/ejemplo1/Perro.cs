using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Perro // CLASE PERRO
    {
        // Nombre, Color, Origen.
        private string nombre;
        private string color;
        private string origen;

        // Formato Propiedad (encapsulamiento de atributos de la clase)
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }
    }
}
