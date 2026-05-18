using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    class Paciente : Persona
    {
        public int Edad { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Paciente: {Nombre}, Edad: {Edad}"); 
            // Toma el nombre y la edad del paciente y los muestra en la consola con un formato específico.
        }
    }
}
