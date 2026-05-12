using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo2
{
    internal class Vehiculo
    {
        // Propiedades para almacenar la marca y el modelo del vehículo
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Vehiculo(string marca, string modelo) //Constructor para inicializar las propiedades Marca y Modelo
        {
            Marca = marca;
            Modelo = modelo;
        }

        public void Arrancar() // Método (funcion) para simular el arranque del vehículo
        {
            Console.WriteLine($"{Marca} {Modelo} arrancó.");
        }
    }
}
