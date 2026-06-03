using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWindows2
{
    public partial class DatosPersonales : Form
    {
        public DatosPersonales()
        {
            InitializeComponent();
        }

        // Evento Load del formulario
        private void DatosPersonales_Load(object sender, EventArgs e)
        {

        }

        // Evento Click del botón Aceptar, y de campos de textos para validar que no estén vacíos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
        
            bool camposValidos = true; //Bandera para verificar si todos los campos son válidos

            // Nombre
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                textBoxNombre.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxNombre.BackColor = Color.White;
            }

            // Apellido
            if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
            {
                textBoxApellido.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxApellido.BackColor = Color.White;
            }

            // Edad
            if (string.IsNullOrWhiteSpace(textBoxEdad.Text))
            {
                textBoxEdad.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxEdad.BackColor = Color.White;
            }

            // Dirección
            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                textBoxDireccion.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxDireccion.BackColor = Color.White;
            }

            // Si todos los campos están completos
            if (camposValidos)
            {
                // Muestra datos ingresados
                /*textBoxResultado.Text = "Apellido y Nombre: " + textBoxApellido.Text + " " + textBoxNombre.Text + Environment.NewLine +
                                        "Edad: " + textBoxEdad.Text + Environment.NewLine +
                                        "Dirección: " + textBoxDireccion.Text;
                */
                // Muestra el resultado mreeemplazando por "x" los datos originales
                textBoxResultado.Text = "Apellido y Nombre: "
                           + new string('X', textBoxApellido.Text.Length) + " "
                           + new string('X', textBoxNombre.Text.Length) + Environment.NewLine +
                           "Edad: " + new string('X', textBoxEdad.Text.Length) + Environment.NewLine +
                           "Dirección: " + new string('X', textBoxDireccion.Text.Length);
            }
        }


        // Evento Click del botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();// Cierra el formulario

        }

        // Evento KeyPress del TextBox Edad para validar la entrada de solo números
        private void textBoxEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite la entrada de dígitos y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignora la tecla presionada
            }

            //Valida que la edad esté dentro de un rango
            if (int.TryParse(textBoxEdad.Text, out int edad))
            {
                if (edad < 0 || edad > 99)
                {
                    textBoxEdad.BackColor = Color.Red;
                }
                else
                {
                    textBoxEdad.BackColor = Color.White;
                }

            }
            else
            {
                // Si está vacío o no es número
                textBoxEdad.BackColor = Color.Red;
            }
        }
    }
}
