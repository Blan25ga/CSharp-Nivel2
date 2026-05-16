using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class Golondrina : Animal, IVolador
    {
        public override void Comunicar()// Sobrescribe el método Comunicar de la clase base
        {
            Console.WriteLine("La golondrina canta: ¡Tri tri tri!");
        }

        public override void Volar() // Sobrescribe el método Volar de la clase base.
        {
            Console.WriteLine("La golondrina vuela rápidamente por el cielo.");
        }
    }
}
