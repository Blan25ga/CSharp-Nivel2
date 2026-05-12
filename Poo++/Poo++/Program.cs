using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
              // TIPOS VALOR
            int velocidad = 100; // dato tipo valor, se almacena directamente
            int otraVelocidad = velocidad; // copia independiente
            otraVelocidad = 150;
            // velocidad sigue siendo 100, otraVelocidad es 150
            Console.WriteLine("Velocidad original: " + velocidad + ", copia: " + otraVelocidad);

            // TIPOS REFERENCIA
            Auto auto1 = new Auto("Ford", "Focus", 4);
            Auto auto2 = auto1; // apunta al mismo objeto en memoria
            auto2.Marca = "Chevrolet";

            Console.WriteLine("auto1 marca: " + auto1.Marca + ", auto2 marca: " + auto2.Marca);
            // Ambos muestran "Chevrolet" porque auto1 y auto2 referencian el mismo objeto


            //? COLECCIONES!!

            // Crear una lista de vehículos, que puede contener autos y camionetas
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            // Agregar objetos de distintas clases (herencia)
            vehiculos.Add(new Auto("Toyota", "Corolla", 4)); 
            vehiculos.Add(new Camioneta("Volkswagen", "Amarok", true));
            vehiculos.Add(new Auto("Renault", "Clio", 3));

            Console.WriteLine("Vehículos agregados a la lista."); 

            // Contar elementos. 
            Console.WriteLine("Cantidad de vehículos: " + vehiculos.Count);

            // Buscar un vehículo por marca (ejemplo: Toyota)
            Vehiculo buscado = vehiculos.Find(v => v.Marca == "Toyota");
            if (buscado != null)//
            {
                Console.WriteLine("Vehículo encontrado: " + buscado.Marca + " " + buscado.Modelo);
            }

            // Eliminar el vehículo encontrado
            vehiculos.Remove(buscado);
            Console.WriteLine("Se eliminó el vehículo Toyota Corolla.");

            // Recorrer colección de vehículos
            foreach (Vehiculo vehiculoActual in vehiculos)// Vehiculo es la clase base, puede contener Auto o Camioneta
            {
                vehiculoActual.Arrancar();// Acción común para todos los vehículos

                // Diferenciar según el tipo específico 
                if (vehiculoActual is Auto autoEnLista)// Verificar si el vehículo actual es un Auto
                {
                    Console.WriteLine("Es un Auto con " + autoEnLista.CantidadPuertas + " puertas.");
                    autoEnLista.TocarBocina();
                }
                else if (vehiculoActual is Camioneta camionetaEnLista)// Verificar si el vehículo actual es una Camioneta
                {
                    Console.WriteLine("Es una Camioneta.");
                    camionetaEnLista.Cargar();
                }
            }

            // Mostrar lista final después de eliminar
            Console.WriteLine("\nLista final de vehículos:");
            foreach (Vehiculo v in vehiculos)
            {
                Console.WriteLine(v.Marca + " " + v.Modelo);
            }
        }


    }
}

