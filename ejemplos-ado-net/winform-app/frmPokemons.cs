using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmPokemons : Form
    {
        // Esta lista se utiliza para almacenar los datos que se obtienen de la base de datos y se muestran en el DataGridView.
        private List<Pokemon> listaPokemon;

        public frmPokemons()
        {
            InitializeComponent();
        }

        // Evento Load del formulario, se ejecuta cuando el formulario se carga por primera vez.
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            cargar(); // Llama al método cargar() para obtener la lista de Pokémon y mostrarla en el DataGridView.)

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //CUANDO CAMBIO SELECCION DE GRILLA CAMBIA AL POKEMO SELECCIONADO.
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;// Obtener el Pokémon seleccionado a partir de la fila actual del DataGridView.
            cargarImagen(seleccionado.UrlImagen);// Cargar la imagen del Pokémon seleccionado en el PictureBox.
        }

        private void cargar()
        {
            // Crear una instancia de PokemonNegocio para acceder
            // a la lógica de negocio relacionada con los Pokémon.
            PokemonNegocio negocio = new PokemonNegocio();// Obtener la lista de Pokémon utilizando el método listar() del negocio.

            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;// Asignar la lista de Pokémon al DataSource del DataGridView para mostrar los datos en la interfaz.
                dgvPokemons.Columns["UrlImagen"].Visible = false;// Ocultar la columna "UrlImagen" en el DataGridView, ya que no es necesario mostrarla al usuario.
                dgvPokemons.Columns["Id"].Visible = false;
                cargarImagen(listaPokemon[0].UrlImagen);// Cargar la imagen del primer Pokémon en el PictureBox al cargar el formulario.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Mostrar un mensaje de error si ocurre una excepción al obtener la lista de Pokémon.
                
            }
        }

        //Exepcion para imagen no encontrada.
        //Esta funcion carga la imagen del Pokémon en el PictureBox, y si ocurre un error, carga una imagen x defecto.
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

        //! BOTON AGREGAR POKEMON
        private void btnAgregar_Click(object sender, EventArgs e)// Evento click del botón "Agregar", se ejecuta cuando el usuario hace clic en el botón.
        {
            frmAltaPokemon alta = new frmAltaPokemon();// Crear una instancia del formulario frmAltaPokemon para agregar un nuevo Pokémon.
            alta.ShowDialog();// Esta línea (ShowDialog) muestra el formulario de alta de Pokémon.
            cargar(); // Llama al método cargar() para actualizar la lista de Pokémon en el DataGridView después de agregar un nuevo Pokémon.
        }

        //! BOTON MODIFICAR POKEMON
        private void btnModifcar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}   
