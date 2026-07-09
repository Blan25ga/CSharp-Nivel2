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
            cboCampo.Items.Add("Número");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //CUANDO CAMBIO SELECCION DE GRILLA CAMBIA AL POKEMO SELECCIONADO.
            if (dgvPokemons.CurrentRow == null) // Verifica si no hay una fila seleccionada en el DataGridView.
                return; // Si no hay una fila seleccionada, se sale del método.
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
                ocultarColumnas();// Llamar al método ocultarColumnas() para ocultar las columnas que no se desean mostrar en el DataGridView.
                cargarImagen(listaPokemon[0].UrlImagen);// Cargar la imagen del primer Pokémon en el PictureBox al cargar el formulario.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Mostrar un mensaje de error si ocurre una excepción al obtener la lista de Pokémon.
                
            }
        }


        private void ocultarColumnas()
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            dgvPokemons.Columns["Id"].Visible = false;
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

        private void btnEliminarFisico_Click(object sender, EventArgs e)// Evento click del botón "Eliminar Físico", se ejecuta cuando el usuario hace clic en el botón.
        {
            eliminar(false);

        }

        private void btnEliminacionLogica_Click(object sender, EventArgs e)// Evento click del botón "Eliminar Lógico", se ejecuta cuando el usuario hace clic en el botón.
        {
            eliminar(true);
        }


        //! Función para eliminar un Pokémon, ya sea de forma física o lógica, según el parámetro logico.
        private void eliminar(bool logico = false)
        {
            PokemonNegocio negocio = new PokemonNegocio(); // Crear una instancia de PokemonNegocio para acceder a la lógica de negocio relacionada con los Pokémon.
            Pokemon seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el Pokémon seleccionado?", "Eliminar Pokémon", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // Mostrar un mensaje de confirmación antes de eliminar el Pokémon.
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

                    if (logico)
                    {
                        negocio.eliminarLogico(seleccionado.Id); // Llama al método eliminarLogico() del negocio para realizar una eliminación lógica del Pokémon seleccionado.
                    }
                    else
                    {
                        negocio.eliminar(seleccionado.Id); // Llama al método eliminar() del negocio para eliminar el Pokémon seleccionado de la base de datos.
                    cargar(); // Actualiza la lista de Pokémon en el DataGridView después de la eliminación.
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Mostrar un mensaje de error si ocurre una excepción al eliminar el Pokémon.
            }
        }


        private bool validarFiltro()// Método para validar los filtros antes de realizar la búsqueda avanzada.
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un campo para filtrar.");
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio para filtrar.");
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtFiltroAvanzado.Text))
            {
                MessageBox.Show("Ingrese un valor para filtrar.");
                return true;
            }

            // Validación específica para el campo Número
            if (cboCampo.SelectedItem.ToString() == "Número")
            {
                if (string.IsNullOrWhiteSpace(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debe ingresar un número en el campo.");
                    return true;
                }

                if (!int.TryParse(txtFiltroAvanzado.Text, out _)) // Retorna true si no se puede convertir a número, lo que indica que el valor ingresado no es válido.
                {
                    MessageBox.Show("Debe ingresar un número válido.");
                    return true;
                }
            }

            return false; //Si todo está correcto, retorna false
        }
        private bool soloNumeros(string cadena) // Método para validar si una cadena contiene solo números.
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter)) // Verifica si el carácter no es un dígito.
                    return false;
            }
            return true;
        }

        //? BOTON FILTRAR POKEMON
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro != "")
            {
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaPokemon;
            }

            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnas();
        }


        //! Método que se ejecuta cuando se cambia la selección del ComboBox cboCampo, y actualiza las opciones del ComboBox cboCriterio según el campo seleccionado.
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Número")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}

