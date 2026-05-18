using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mensajes.Bienvenida();

            // Uso de clases concretas, herencia y métodos específicos
            Doctor d1 = new Doctor { Nombre = "Dr. López", Especialidad = "Cardiología" };
            Paciente p1 = new Paciente { Nombre = "Gabriel", Edad = 39 };

            // Mostrar información y realizar atención
            d1.MostrarInfo();
            p1.MostrarInfo();
            d1.Atender(p1);

            Mensajes.MostrarSeparador(); // Uso de clase estática para mostrar un mensaje común

            // Uso de clase sellada
            HistoriaClinica hc = new HistoriaClinica { Paciente = p1 }; // Se crea una historia clínica para el paciente Gabriel
            hc.AgregarNota("Consulta inicial: presión alta.");
            hc.AgregarNota("Se recomienda dieta baja en sodio.");
            hc.MostrarNotas();

            Mensajes.MostrarSeparador();

            Console.WriteLine("=== Fin de la ejecución ===");
            Console.ReadKey();
        }
    }
}
