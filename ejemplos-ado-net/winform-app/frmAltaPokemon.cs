using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;// Agregar la referencia a System.Configuration para poder acceder a ConfigurationManager

namespace winform_app
{
   
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        private OpenFileDialog archivo = null;

        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Pokemon y la clase PokemonNegocio para agregar un nuevo Pokémon.
            PokemonNegocio negocio = new PokemonNegocio();

            // lee los datos ingrsados y Captura exepciones si no son validos.

            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                if (pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");
                }

                // Guardar la imagen en la carpeta de imágenes del proyecto si se seleccionó un archivo y la URL de imagen no es una URL HTTP.
                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                {
                    // Copia la imagen seleccionada a la carpeta de imágenes del proyecto.
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }

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
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                if (pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text); // Carga la imagen del Pokémon en el PictureBox cuando el usuario deja de editar el campo de URL de imagen.
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen); //Si falla la carga de imagen. Carga imagen suplemtaria insertada en el catch.
            }
            catch (Exception ex)
            {
                pbxPokemon.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            // levantar imagen desde nuestra pc
            archivo = new OpenFileDialog();// Crear una instancia de OpenFileDialog para seleccionar un archivo de imagen desde la computadora del usuario.
            archivo.Filter = "JPG|*.jpg;|PNG|*.png"; // Filtro para mostrar solo archivos JPG y PNG.
            

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName; // Asigna la ruta del archivo seleccionado al TextBox de URL de imagen.
                cargarImagen(archivo.FileName); // Carga la imagen seleccionada en el PictureBox.

                //! Guardar imagen en proyecto y en DB, pero no guardar en la DB la ruta de la imagen, sino el nombre del archivo y tambien crea una copia de imagen.
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName); // Copia la imagen seleccionada a la carpeta de imágenes del proyecto.

                
            }
        }
    }
}
