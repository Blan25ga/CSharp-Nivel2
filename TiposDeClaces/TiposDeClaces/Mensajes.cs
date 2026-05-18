using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeClaces
{
    static class Mensajes // clase estática para mensajes comunes, no se puede instanciar ni heredar
    {
        // Se pueden agregar métodos estáticos para mostrar mensajes comunes en la aplicación.
        public static void MostrarSeparador()
        {
            Console.WriteLine("====================================");
        }

        public static void Bienvenida()
        {
            Console.WriteLine("Bienvenido al Ejemplo de Tipos de Clases");
        }
    }
}
