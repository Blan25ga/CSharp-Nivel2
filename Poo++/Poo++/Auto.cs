using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo2
{
    internal class Auto : Vehiculo // La clase Auto hereda de la clase Vehiculo
    {
        public int CantidadPuertas { get; set; }

        // Constructor para inicializar las propiedades Marca, Modelo,CantidadPuertas.
        // También llama al constructor de la clase base (Vehiculo) para inicializar Marca y Modelo 
        public Auto(string marca, string modelo, int puertas) : base(marca, modelo) 
        {
            CantidadPuertas = puertas;
        }

        public void TocarBocina() // Método(funcion) específico de la clase Auto para simular el sonido de la bocina
        {
            Console.WriteLine("¡Beep beep!");
        }
    }
}
