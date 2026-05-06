using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1 //Le hace referencia al proyecto, es decir, a la carpeta donde se encuentra el proyecto, en este caso ejemplo1,
                   //y dentro de esa carpeta se encuentra la clase Persona.
{
    class Persona
    {
        //Persona : Edad, Sueldo, Nombre.

        //En la clase de declarona los atributos de la clase, es decir,
        //las variables que van a contener los datos de cada persona.
        private int edad; 
        private float sueldo;
        private string nombre;

        //Los atributos deben cumplir con el principio de encapsulamiento, es decir,
        //deben ser privados para que no puedan ser accedidos desde fuera de la clase,
        //y se deben proporcionar métodos públicos (getters y setters) para acceder y modificar estos atributos
        //de manera controlada.

        //--Modificadores de visibilidad: public, private, protected, internal, protected internal, private protected--

        //Funcion para acceder a los atributos de la clase.
        public void SetEdad(int e)//SetEdad es un método que permite asignar un valor a la variable Edad desde fuera de la clase.
        {
            edad = e; //Edad recibe el valor de e, que es el valor que se le asigna a la variable Edad desde fuera de la clase.

        }

        public int GetEdad() //GetEdad es un método que permite obtener (leer) el valor de la variable Edad desde fuera de la clase.
        {
            return edad; //Devuelve el valor de la variable edad.
        }
    }
}
