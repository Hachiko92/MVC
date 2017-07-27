using Ejercicio2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio2_1.Controllers
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
            return "Index";
        }

        public ViewResult CrearCoche()
        {
            Coche coche = new Coche { Color = "Verde", Marca = "Renault", Modelo = "Clio" };
            return View("Result", (object)String.Format("Coche creado:\n{0} {1} color {2}", coche.Marca, coche.Modelo, coche.Color));
        }

        public ViewResult CrearCliente()
        {
            string[] clientes =
            {
                "Pepe",
                "Tizio",
                "Sempronio"
            };

            return View("Result", (object)String.Format("Segundo cliente: {0}", clientes[1]));
        }

        public ViewResult CrearArrayCoches()
        {
            Coche[] coches =
            {
                new Coche { Color = "Verde", Marca = "Renault", Modelo = "Clio" },
                new Coche { Color = "Azul claro", Marca = "Alfa Romeo", Modelo = "195" },
                new Coche { Color = "Negro", Marca = "Fiat", Modelo = "Panda" }
            };

            var cochesElejidos = (coches
                    .OrderByDescending(c => c.Marca)
                    .Select (c => new
                    {
                        c.Color,
                        c.Marca,
                        c.Modelo
                    }));

            StringBuilder resultado = new StringBuilder();
            foreach (var c in cochesElejidos)
            {
                resultado.AppendFormat("{0} {1} color {2}\n", c.Marca, c.Modelo, c.Color);
            }

            return View("Result", (object)resultado);
        }

        public ViewResult mediaPrecio()
        {
            Coche[] coches =
            {
                new Coche { Color = "Verde", Marca = "Renault", Modelo = "Clio", Precio = 25000m },
                new Coche { Color = "Azul claro", Marca = "Alfa Romeo", Modelo = "195", Precio = 29000m },
                new Coche { Color = "Negro", Marca = "Fiat", Modelo = "Panda", Precio = 20000m }
            };

            var media = coches
                       .Select(p => p.Precio)
                       .Average();

            return View("Result", (object)String.Format("Media precios coches: {0}", media));
        }
    }
}