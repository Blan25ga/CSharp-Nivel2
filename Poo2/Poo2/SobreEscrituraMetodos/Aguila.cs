using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class Aguila :Animal, IVolador
    {
        public override void Comunicar()// Sobrescribe el método Comunicar de la clase base
        {
            Console.WriteLine("El águila grita: ¡Aahhhheee!");
        }

        public override void Volar() // Sobrescribe el método Volar de la clase base
        {
            Console.WriteLine("El águila vuela majestuosamente por el cielo.");
        }
    }
}
