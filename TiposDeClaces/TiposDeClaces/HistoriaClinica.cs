using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    sealed class HistoriaClinica //Clase sellada, no se puede heredar nada de esta clase.
    {
        public Paciente Paciente { get; set; } // Relación de composición: HistoriaClinica tiene un Paciente.
        public List<string> Notas { get; set; } = new List<string>();// Lista de notas médicas, se inicializa vacía.


        // Método para agregar una nota a la historia clínica, recibe un string como parámetro y lo agrega a la lista de notas.
        public void AgregarNota(string nota)
        {
            Notas.Add(nota);
        }


        // Método para mostrar todas las notas de la historia clínica, itera sobre la lista de notas; muestra en consola.
        public void MostrarNotas()
        {
            Console.WriteLine($"Historia clínica de {Paciente.Nombre}:");
            foreach (var nota in Notas) // Itera sobre la lista de notas y se muestra cada una en la consola.
            {
                Console.WriteLine($"- {nota}"); // Muestra cada nota con un guion para mejor formato.
            }
        }
    }
}
