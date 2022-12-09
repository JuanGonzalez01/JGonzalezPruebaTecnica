using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("\nNombre del libro:");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("\nAutor:\t1) J. A. Gonzalez\t2) L. Escogido\t3) I. Espinoza\t4) U. Tapia\t5) F. Gutierrez");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNúmero de páginas:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("\nFecha de publicación: (DD-MM-YYYY)");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("\nEditorial:\t1) E. Digis\t2) E. Aguilar\t3) Miranda L.\t4) Digis\t5) Hernandez P.");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEdición:");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("\nGénero:\t1) Romance\t2) Terror\t3) Ciencia\t4) Fantasía\t5) Tecnología");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                Console.WriteLine("\n*****Libro ingresado con éxito.******");
            }
            else
            {
                Console.WriteLine($"\nxxxxxx Error: {result.Message} xxxxxx");
            }
        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("\nID del libro:");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNombre del libro:");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("\nN° del autor:");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNúmero de páginas:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("\nFecha de publicación: (DD-MM-YYYY)");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("\nN° de la editorial:");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEdición:");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("\nN° del Género:");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine("\n*****Libro modificado con éxito.******");
            }
            else
            {
                Console.WriteLine($"\nxxxxxx Error: {result.Message} xxxxxx");
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine($"- ID: \t{libro.IdLibro}");
                    Console.WriteLine($"- Nombre: \t{libro.Nombre}");
                    Console.WriteLine($"- Autor: \t{libro.Autor.Nombre}");
                    Console.WriteLine($"- N° de páginas: \t{libro.NumeroPaginas}");
                    Console.WriteLine($"- Fecha de publicación: \t{libro.FechaPublicacion}");
                    Console.WriteLine($"- Editorial: \t{libro.Editorial.Nombre}");
                    Console.WriteLine($"- Edición: \t{libro.Edicion}");
                    Console.WriteLine($"- Género: \t{libro.Genero.Nombre}");
                }
            }
            else
            {
                Console.WriteLine($"\nxxxxxx Error: {result.Message} xxxxxx");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("\nID del libro:");
            int idLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(idLibro);

            if (result.Correct)
            {
                ML.Libro libro = (ML.Libro)result.Object;

                Console.WriteLine("===========================================");
                Console.WriteLine($"- ID: \t{libro.IdLibro}");
                Console.WriteLine($"- Nombre: \t{libro.Nombre}");
                Console.WriteLine($"- Autor: \t{libro.Autor.Nombre}");
                Console.WriteLine($"- N° de páginas: \t{libro.NumeroPaginas}");
                Console.WriteLine($"- Fecha de publicación: \t{libro.FechaPublicacion}");
                Console.WriteLine($"- Editorial: \t{libro.Editorial.Nombre}");
                Console.WriteLine($"- Edición: \t{libro.Edicion}");
                Console.WriteLine($"- Género: \t{libro.Genero.Nombre}");
            }
            else
            {
                Console.WriteLine($"\nxxxxxx Error: {result.Message} xxxxxx");
            }
        }

        public static void Delete()
        {
            Console.WriteLine("\nID del libro:");
            int idLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(idLibro);

            if (result.Correct)
            {
                Console.WriteLine("\n*****Libro eliminado con éxito.******");
            }
            else
            {
                Console.WriteLine($"\nxxxxxx Error: {result.Message} xxxxxx");
            }
        }
    }
}
