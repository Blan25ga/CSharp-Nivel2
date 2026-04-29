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
            // Condicionales
            //if (condición)
            //switch (variable)

            int numero = 5;

            if (numero > 0)
            {
                Console.WriteLine("El número es positivo");
            }
            else if (numero < 0)
            {
                Console.WriteLine("El número es negativo");
            }
            else
            {
                Console.WriteLine("El número es cero");
            }

            Console.ReadKey(); // Espera a que el usuario presione una tecla para cerrar la consola

            //switch
            int opcion = 2;

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Elegiste la opción 1");
                    break;
                case 2:
                    Console.WriteLine("Elegiste la opción 2");
                    break;
                case 3:
                    Console.WriteLine("Elegiste la opción 3");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

            Console.ReadKey();// Espera a que el usuario presione una tecla para cerrar la consola
        }
    }
}
