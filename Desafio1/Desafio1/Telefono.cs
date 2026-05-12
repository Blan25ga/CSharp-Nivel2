using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    public class Telefono
    {
        /*atributos:
        Modelo string. //Solo lectura 
        Marca string. //Solo lectura
        NumeroTelefonico string. //Lectura y escritura
        CodigoOperador int (1, 2 o 3) //Lectura y escritura. 
        Validar escritura que solo admita 1, 2 o 3, caso contrario escribir un cero.//
        */


        private int codigoOperador; //Guardado de datos privados ingresados.

        public string Modelo { get; }
        public string Marca { get; }
        public string NumeroTelefonico { get; set; }

        public int CodigoOperador//Propiedad para validar el ingreso de datos.
        {
            get { return codigoOperador; }//Retorna el valor guardado.
            set //Validación para aceptar solo 1, 2 o 3, caso contrario asignar cero.
            {
                if (value == 1 || value == 2 || value == 3)
                {
                    codigoOperador = value;
                }
                else
                {
                    codigoOperador = 0;
                }
            }
        }

        // constructor que recibe marca y modelo 
        public Telefono(string marca, string modelo) 
        {
            this.Marca = marca;
            this.Modelo = modelo;
        }

        // MÉTODOS
        public string Llamar() //metodo que retorna un string indicando que se está realizando una llamada.
        {
            return "Realizando llamada...";
        }

        //Sobrecarga del metodo LLamar.
        public string Llamar(string contacto)
        {
            return "Llamando a " + contacto;
        }

    }
}
