using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class Perro : AnimalDomestico
    {
        public override void Comunicar()// Sobrescribe el método Comunicar de la clase base
        {
            Console.WriteLine("El perro ladra: ¡Guau guau!");
        }
    }
}
