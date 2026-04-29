using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            //int float bool char
            //double, decimal, long, short, string, datatime

            int a, b, c;

            
            Console.WriteLine("Hola, segui las intrucciónes");
            Console.WriteLine("Ingresa un numero:");
            a = int.Parse(Console.ReadLine());
            b = 10;
            c = a + b;
            Console.WriteLine("El resultado de la suma es: " + c);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
