using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    class Doctor : Persona
    {
        public string Especialidad { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Doctor: {Nombre}, Especialidad: {Especialidad}");
        }

        public void Atender(Paciente paciente) // método específico de Doctor, no forma parte del contrato de Persona
        {
            Console.WriteLine($"El doctor {Nombre} atiende al paciente {paciente.Nombre}");
        }
    }
}
