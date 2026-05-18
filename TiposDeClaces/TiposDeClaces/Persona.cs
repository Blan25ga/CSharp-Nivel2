using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    abstract class Persona //
    {
        public string Nombre { get; set; }
        public abstract void MostrarInfo();
        // Contrato obligatorio, cada clase que herede de Persona debe implementar este método,
        // por eso es abstracto, no tiene implementación aquí, cada clase hija lo implementará a su manera.
        // Es obligatorio implementar este método en las clases que hereden de Persona, si no lo hacen, el código no compilará.

    }
}
