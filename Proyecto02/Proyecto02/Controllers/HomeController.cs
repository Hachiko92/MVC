using Proyecto02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto02.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            IDproduct = 1,
            Nombre = "Kayak",
            Descripcion = "A boat for one person",
            Precio = 275M,
            Categoria = "Watersport"
        };

        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array =
            {
                new Product {Nombre = "Kayak", Precio = 275m },
                new Product {Nombre = "Lifejacket", Precio = 48.95m },
                new Product {Nombre = "Kayak", Precio = 19.50m },
                new Product {Nombre = "Kayak", Precio = 44.95m }
            };

            //Product[] array = null;

            return View(array);
        }
    }
}