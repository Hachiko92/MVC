using Proyecto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Proyecto01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "Voy a navegar a una URL y mostrar un mensaje";
        }

        /* viewResult porque el resultado lo voy a volcar en una vista */
        public ViewResult AutoProperty()
        {
            Models.Product producto = new Models.Product();
            producto.Nombre = "Kayak";
            string productName = producto.Nombre;
            /* View (nome della vista a cui si manda il dato, il dato)
             * il dato deve essere convertito in oggetto */
            return View("Result", (object)String.Format("Product Name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product producto = new Product
            {
                IDproduct = 100,
                Nombre = "Kayak",
                Descripcion = "Una bota para una persona",
                Precio = 775M,
                Categoria = "Watersports"
            };

            return View("Result", (object)String.Format("Product Description: {0}", producto.Descripcion));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "vaca", "perro", "gato" };
            List<int> listaEnteros = new List<int> { 10, 23, 65 };
            Dictionary<string, int> miDiccionario = new Dictionary<string, int>
            {
                {"vaca", 10},
                {"perro", 5},
                {"gato", 3}
            };

            return View("Result", (object)String.Format("Valor de impresion: {0}", stringArray[1]));
        }

        public ViewResult CreateProduct2()
        {
            Product producto = new Product
            {
                IDproduct = 100,
                Nombre = "Kayak",
                Descripcion = "Una bota para una persona",
                Precio = 775M,
                Categoria = "Watersports"
            };

            return View(producto);
        }

        public ViewResult ListaProductos()
        {
            List<Product> listaProductos = new List<Product>
            {
                new Product {IDproduct = 1, Nombre = "Kayak", Categoria = "Watersports", Precio = 275m  },
                new Product {IDproduct = 2, Nombre = "Lifejacket", Categoria = "Watersports", Precio = 48.95m  },
                new Product {IDproduct = 3, Nombre = "Soccer Ball", Categoria = "Soccer", Precio = 19.50m  },
                new Product {IDproduct = 4, Nombre = "Corner Flag", Categoria = "Soccer", Precio = 34.95m  },
            };
            
            decimal total = ((listaProductos
                            .Where(p => p.Categoria == "Soccer")
                            .Select(p => p.Precio)).ToList()).Sum();

            return View("Result", (object)String.Format("Este es el resultado del Soccer: {0}", total));
        }

        public ViewResult ListaProductos2()
        {
            List<Product> productos = new List<Product>
            {
                new Product {IDproduct = 1, Nombre = "Kayak", Categoria = "Watersports", Precio = 275m  },
                new Product {IDproduct = 2, Nombre = "Lifejacket", Categoria = "Watersports", Precio = 48.95m  },
                new Product {IDproduct = 3, Nombre = "Soccer Ball", Categoria = "Soccer", Precio = 19.50m  },
                new Product {IDproduct = 4, Nombre = "Corner Flag", Categoria = "Soccer", Precio = 34.95m  },
            };

            var result = productos.Sum(p => p.Precio);
            productos[2] = new Product { IDproduct = 5, Nombre = "Stadium", Precio = 75987m };

            /* .Sum no no admite valores diferidos, entonces no va a sumar el estadio */
            return View("Result", (object)String.Format("Este es el resultado: {0}", result));
        }

        public ViewResult ListaProductos3()
        {
            List<Product> productos = new List<Product>
            {
                new Product {IDproduct = 1, Nombre = "Kayak", Categoria = "Watersports", Precio = 275m  },
                new Product {IDproduct = 2, Nombre = "Lifejacket", Categoria = "Watersports", Precio = 48.95m  },
                new Product {IDproduct = 3, Nombre = "Soccer Ball", Categoria = "Soccer", Precio = 19.50m  },
                new Product {IDproduct = 4, Nombre = "Corner Flag", Categoria = "Soccer", Precio = 34.95m  },
            };

            var foundProducts = productos
                               .OrderByDescending(e => e.Precio)
                               .Take(3)
                               .Select(e => new
                               {
                                   e.Nombre,
                                   e.Precio
                               });

            productos[2] = new Product { IDproduct = 5, Nombre = "Stadium", Precio = 75987m };

            StringBuilder resultado = new StringBuilder();
            foreach (var p in foundProducts)
            {
                resultado.AppendFormat("{0}: {1}", p.Nombre, p.Precio);
            }

            return View("Result", (object)String.Format("Este es el resultado: \n{0}", resultado));
        }

    }
}