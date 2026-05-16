using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class Animal
    {
        // Método virtual que puede ser sobrescrito por las clases derivadas
        public virtual void Comunicar() // Método virtual
        {
            Console.WriteLine("El animal emite un sonido genérico.");
        }

        // Método Volar en la base
        public virtual void Volar() // Método virtual que puede ser sobrescrito por las clases derivadas
        {
            Console.WriteLine("Este animal no puede volar.");
        }
    }
}
