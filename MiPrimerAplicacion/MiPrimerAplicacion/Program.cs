using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerAplicacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita los estilos visuales para la aplicación.
            Application.SetCompatibleTextRenderingDefault(false); // Establece la compatibilidad de renderizado de texto.
            Application.Run(new Form1()); // Aquí se inicia la aplicación con el formulario principal llamado Form1.
        }
    }
}
