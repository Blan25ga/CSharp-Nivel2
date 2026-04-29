using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ciclos
            // Ciclo for, while, do while
            // ++ incremento, -- decremento, +=, -=
            // *=, /=, 

            // Ciclo FOR: muestra los números del 1 al 5
            Console.WriteLine("Ciclo FOR:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Número: " + i);
            }

            // Ciclo WHILE: cuenta hacia atrás desde 5 hasta 1
            Console.WriteLine("Ciclo WHILE:");
            int j = 5;
            while (j > 0)
            {
                Console.WriteLine("Número: " + j);
                j--;
            }

            Console.ReadKey();

        }
    }
}
