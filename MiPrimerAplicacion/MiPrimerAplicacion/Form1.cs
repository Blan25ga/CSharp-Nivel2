using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerAplicacion
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1() // Constructor del formulario, se llama cuando se crea una instancia de Form1.
        {
            // Este método es generado automáticamente por el diseñador de Visual Studio y se encarga de inicializar los componentes del formulario.
            // Es importante no modificar este método manualmente, ya que cualquier cambio podría ser sobrescrito por el diseñador.
            InitializeComponent();
        }

        // Este método se ejecuta cuando el formulario se carga por primera vez("Haciendo doble click en el formulario").
        // Aquí puedes agregar cualquier código que necesites para inicializar tu formulario o cargar datos.
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido a mi primer aplicación de Windows Forms!");
            // MessageBox.Show es un método que muestra un cuadro de diálogo con un mensaje.
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("¡Hasta luego! Chauu Chaaaaauuuu");
            // Este método se ejecuta cuando el formulario se cierra.
            // Aquí puedes agregar cualquier código que necesites para limpiar o realizar acciones antes de cerrar la app.
        }


        // Este método se ejecuta cuando se hace doble clic en el botón llamado "boton".
        private void boton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se disparo el evento Click", "Atención");
            this.BackColor = Color.Aqua; // Cambia el color de fondo del formulario a Aqua. 

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando se hace clic en cualquier parte del formulario
            // (Excepto en los controles que tengan eventos de clic propios).
            MouseEventArgs click = (MouseEventArgs)e;
            if (click.Button == MouseButtons.Left)
                MessageBox.Show("Presiono el botón Izquierdo", "Atención");
            else if (click.Button == MouseButtons.Right)
                MessageBox.Show("Presiono el Botón Derecho", "Atención");
            else
                if (click.Button == MouseButtons.Middle)
                    MessageBox.Show("Presiono el botón del Medio", "Atención");
        }
    }
}
