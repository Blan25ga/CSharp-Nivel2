using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Botella
    {
        //Botella: Capacidad, Color, Material.

        private int capacidad;
        private string color;
        private string material;

        //Propiedad: Es una forma de encapsular un atributo de una clase, es decir, es una forma de controlar
        //el acceso a un atributo de la clase, permitiendo definir métodos para obtener y establecer su valor.

        //! Formato propiedad    
        public int Capacidad
            {
                get { return capacidad; } //El get devuelve el valor de la variable capacidad.
                set { capacidad = value; } //El set asigna el valor de value a la variable capacidad.
        }
    
            public string Color
            {
                get { return color; } //Devuelve el valor de la variable color.
                set { color = value; } //Asigna el valor de value a la variable color.
            }
    
            public string Material
            {
                get { return material; } //Devuelve el valor de la variable material.
                set { material = value; } //Asigna el valor de value a la variable material.
        }


    }
}   