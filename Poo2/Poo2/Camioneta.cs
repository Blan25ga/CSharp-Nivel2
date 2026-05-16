using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2
{
    internal class Camioneta : Vehiculo
    {
        // Propiedad para indicar si la camioneta tiene capacidad de carga
        public bool TieneCarga { get; set; }

        // Constructor para inicializar las propiedades Marca, Modelo y TieneCarga.
        // También llama al constructor de la clase base (Vehiculo) para inicializar Marca y Modelo
        public Camioneta(string marca, string modelo, bool caja) : base(marca, modelo)
        {
            TieneCarga = caja;
        }

        public void Cargar() // Método (funcion) específico de la clase Camioneta para simular la carga de objetos
        {
            Console.WriteLine("La camioneta está cargando objetos.");
        }
    }
}
