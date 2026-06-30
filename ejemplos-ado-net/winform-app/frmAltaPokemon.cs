using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Pokemon y la clase PokemonNegocio para agregar un nuevo Pokémon.
            Pokemon poke = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            // lee los datos ingrsados y Captura exepciones si no son validos.

            try
            {
                // Crear un nuevo objeto Pokemon y Asigna los valores ingresados por el usuario.
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                //Aca se castea el "Elemento" seleccionado en el ComboBox del objeto Pokemon para cargar lo selecc por el usuario..
                poke.Tipo = (Elemento)cboTipo.SelectedItem;
                poke.Debilidad = (Elemento)cboDebilidad.SelectedItem;


                negocio.agregar(poke);

                MessageBox.Show("Se agrego correctamente");
                Close();

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre una excepción durante la captura de datos o la adición del Pokémon.
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            //Traer tipo y debilidad de la base de datos y cargarlos en los ComboBox.
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboDebilidad.DataSource = elementoNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
