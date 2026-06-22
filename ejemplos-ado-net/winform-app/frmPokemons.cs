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

        private List<Pokemon> listaPokemon;// Esta lista se utiliza para almacenar los datos que se obtienen de la base de datos y se muestran en el DataGridView.

        public frmPokemons()
        {
            InitializeComponent();
        }

        // Evento Load del formulario, se ejecuta cuando el formulario se carga por primera vez.
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            // Crear una instancia de PokemonNegocio para acceder
            // a la lógica de negocio relacionada con los Pokémon.
            PokemonNegocio negocio = new PokemonNegocio();// Obtener la lista de Pokémon utilizando el método listar() del negocio.
            
            listaPokemon = negocio.listar();// Asignar la lista de Pokémon al DataSource del DataGridView para mostrar los datos en la interfaz.
            
            dgvPokemons.DataSource = listaPokemon;//Toma la primera columna del DataGridView y ajusta su tamaño para que se ajuste al contenido.
            
            dgvPokemons.Columns["UrlImagen"].Visible = false; // Oculta la columna "UrlImagen" del DataGridView, ya que no es necesario mostrarla al usuario.
            
            cargarImagen(listaPokemon[0].UrlImagen);// Toma el primer Pokémon de la lista y mostrar su imagen en el PictureBox.

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //CUANDO CAMBIO SELECCION DE GRILLA CAMBIA AL POKEMO SELECCIONADO.
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;// Obtener el Pokémon seleccionado a partir de la fila actual del DataGridView.
            cargarImagen(seleccionado.UrlImagen);// Cargar la imagen del Pokémon seleccionado en el PictureBox.
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
                pbxPokemon.Load("https://st.depositphotos.com/2934765/53192/v/450/depositphotos_531920820-stock-illustration-photo-available-vector-icon-default.jpg");
            }
        }
    }
}   
