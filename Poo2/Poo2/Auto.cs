using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2
{
    internal class Auto : Vehiculo
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

        private Motor motor = new Motor(); // Composición: un Auto tiene un Motor
        public void EncenderMotor() // Método para encender el motor del auto
        {
            motor.Encender();// Llama al método Encender del Motor para encender el motor del auto
            Console.WriteLine("El motor del auto se ha encendido.");
        }

    }
}
