using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo2
{
    internal class Botella
    {
       
        private int capacidad;
        private string color;
        private string material;

        // Constructor, se llama igual que la clase y se ejecuta al crear un objeto
        public Botella(string color, string material)
        {
            this.color = color;// "this" se refiere al objeto actual, diferencia entre el parámetro y el campo de la clase
            this.material = material;
        }

        // Propiedad, permite acceder a la capacidad de la botella
        public int Capacidad
        {
            get { return capacidad; }// "get" devuelve el valor de capacidad
            set { capacidad = value; }// "value" es el valor que se asigna a la propiedad, se guarda en el campo capacidad
        }

        // Método: acción que realiza la botella, en este caso mostrar su información
        public void MostrarInfo()
        {
            // Este método no devuelve nada (void), solo muestra datos
            Console.WriteLine("Color: " + this.color);
            Console.WriteLine("Material: " + this.material);
            Console.WriteLine("Capacidad: " + this.capacidad + " ml");
        }

        //? Otro método: llenar la botella
        public void Llenar(int cantidad)
        {
            capacidad += cantidad; // suma la cantidad a la capacidad actual
        }

        //! Método con retorno: calcular si está llena
        public bool EstaLlena(int maximo)// Devuelve un valor booleano (true o false) indicando si la capacidad es mayor o igual al máximo permitido
        {
            return capacidad >= maximo;
        }


    }
}
