using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botella botella1 = new Botella("Verde", "Vidrio"); // Instancia de Botella con color y material
            botella1.Capacidad = 500;

            // Llamar al método MostrarInfo
            botella1.MostrarInfo();

            // Llamar al método Llenar
            botella1.Llenar(250);// Llenar la botella con 250 ml, lo que aumenta su capacidad a 750.
            botella1.MostrarInfo(); // ahora muestra 750 ml

            // Llamar a método con retorno
            bool llena = botella1.EstaLlena(700);// Verificar si la botella está llena con un máximo de 700 ml
            Console.WriteLine("¿Está llena? " + llena);
        }
    }
}
