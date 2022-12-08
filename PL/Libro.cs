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
