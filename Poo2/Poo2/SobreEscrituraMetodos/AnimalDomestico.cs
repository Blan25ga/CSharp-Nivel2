using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Poo2.SobreEscrituraMetodos
{
    internal class AnimalDomestico : Animal
    {
        public override void Comunicar() // Sobrescribe el método Comunicar de la clase base
        {
            Console.WriteLine("El animal doméstico se comunica con su dueño.");
        }

    }
}
