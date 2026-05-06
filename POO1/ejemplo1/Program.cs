using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Program // CLASE PROGRAM
    {
        static void Main(string[] args)
        { // DENTRO DA LA CALSE ESTA LA FUNCION POR DEFECTO MAIN, QUE ES LA QUE SE EJECUTA CUANDO CORREMOS EL PROGRAMA
          // Para agregar una clase al proyecto, hacemos click derecho en el proyecto, luego en agregar y luego en clase,
          // le damos un nombre a la clase y listo, ya tenemos una clase nueva en nuestro proyecto.

            //Perona: Edad, Sueldo, Nombre. 
            
            int edad;
            float sueldo;
            string nombre;

            //Variables para guardar datos de 10 personas en vectores.
            int[] edades = new int[10];
            float[] sueldos = new float[10];
            string[] nombres = new string[10];

            Persona p1 = new Persona();// Variable tipo Persona que se llama p1, asigna un nuevo objeto de tipo Persona, es decir, se crea una nueva persona.
            p1.SetEdad(20);// Se llama SetEdad de la clase Persona para asignar un valor a la variable Edad de la persona p1
                           // el valor que se le asigna es el valor de la variable edad, que es una variable local dentro del método Main.

            Console.WriteLine("La edad de la persona es: " + p1.GetEdad());
            // Se llama GetEdad de la clase Persona para obtener el valor de la variable Edad de la persona p1


            // Trabajando con Propiedades:

            Botella b1 = new Botella(); // Variable tipo Botella que se llama b1, asigna un nuevo objeto de tipo Botella, es decir, se crea una nueva botella.

            //Todo: Llamada a las propiedades de la clase Botella para asignar un valor.

            b1.Capacidad = 500;//! se llama a la propiedad y se le asigna un valor.
            Console.WriteLine("La capacidad de la botella es: " + b1.Capacidad);

            b1.Color = "Rojo"; // Se llama la propiedad Color de la clase Botella para asignar un valor a la variable color de la botella b1
            Console.WriteLine("El color de la botella es: " + b1.Color);   
            
            b1.Material = "Plástico"; // Se llama la propiedad Material de la clase Botella para asignar un valor a la variable material de la botella b1
            Console.WriteLine("El material de la botella es: " + b1.Material);

            Console.ReadKey();
        }

    }
}
