using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Pruebas de Polimorfismo y Sobreescritura ===");

            // Lista polimórfica de animales
            List<Animal> animales = new List<Animal> // Lista tipo base (Animal) que puede contener objetos de cualquier clase derivada.
        {
            new Perro(),
            new Gato(),
            new Aguila(),
            new Golondrina()
        };


            // Iteramos sobre la lista y llamamos al método Comunicar() de cada animal.
            foreach (var animal in animales)
            {
                animal.Comunicar();
            }

            Console.WriteLine("=== Pruebas de Polimorfismo con Volar() ===");

            // Lista polimórfica de voladores (solo los que implementan IVolador)
            List<IVolador> voladores = new List<IVolador>
            {
                new Aguila(),
                new Golondrina()
            };

            foreach (var ave in voladores)
            {
                ave.Volar();
            }

            Console.WriteLine("=== Fin de la ejecución ===");
            Console.ReadKey();

            
        }
    }  
}

