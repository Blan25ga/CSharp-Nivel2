using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vectores
            // Funciones

            // Declaramos un vector de enteros con 5 posiciones
            int[] numeros = new int[5];

            // Asignamos valores a cada posición del vector
            numeros[0] = 10; // primer elemento
            numeros[1] = 20; // segundo elemento
            numeros[2] = 30; // tercer elemento
            numeros[3] = 40; // cuarto elemento
            numeros[4] = 50; // quinto elemento

            // Recorremos el vector con un ciclo for
            for (int x = 0; x < numeros.Length; x++)
            {
                Console.WriteLine("Elemento en posición " + x + ": " + numeros[x]);
            }

            Console.ReadKey(); // pausa para ver el resultado

            // funciones:

            // Llamamos a la función Sumar con dos valores
            int resultado = Sumar(5, 7);

            // Mostramos el resultado en pantalla
            Console.WriteLine("La suma es: " + resultado);

            Console.ReadKey(); // pausa para ver el resultado
        }
        // Definición de la función Sumar que recibe dos enteros y devuelve su suma
        static int Sumar(int a, int b)
        {
            return a + b; // devuelve el resultado de la suma
        }
    }
}
