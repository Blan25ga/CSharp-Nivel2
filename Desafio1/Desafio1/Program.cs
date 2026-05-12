using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creación de objeto Telefono
            Telefono telefono1 = new Telefono("Samsung", "Galaxy S21");
            telefono1.NumeroTelefonico = "123456789"; //Asignación del número telefónico.
            telefono1.CodigoOperador = 1; //Asignación del código de operador.

            // Mostrar información
            Console.WriteLine("Marca: " + telefono1.Marca);
            Console.WriteLine("Modelo: " + telefono1.Modelo);
            Console.WriteLine("Número: " + telefono1.NumeroTelefonico);
            Console.WriteLine("Operador: " + telefono1.CodigoOperador);

            // Probar métodos
            Console.WriteLine(telefono1.Llamar());//Llamada sin contacto específico.
            Console.WriteLine(telefono1.Llamar("Gabriel"));//Llamada a un contacto específico.

        }
    }
}
