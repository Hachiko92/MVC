using Ejercicio3_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio3_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index", (object)"Index");
        }

        private Persona CreatePersona()
        {
            Persona persona = new Persona
            {
                IDpersona = 1,
                Nombre = "Mario Rossi",
                Edad = 45,
                Profesion = "Fontanero",
                Sueldo = 1100
            };

            return persona;
        }

        public ActionResult ViewPersona()
        {
            return View("Result", CreatePersona());
        }

        public ActionResult Impuestos()
        {
            Persona persona = CreatePersona();

            ViewBag.Hijo = true;
            ViewBag.Porgentaje = 10;

            if (ViewBag.Hijo)
            {
                ViewBag.Sueldo = Convert.ToInt32(persona.Sueldo) * Convert.ToInt32(ViewBag.Porgentaje);
            }

            return View("Result", persona);

        }

        private Persona[] CreatePersonas()
        {
            return new Persona[]
            {
                new Persona {IDpersona = 1, Nombre = "Eva Barns", Edad = 43, Profesion = "Grafica" },
                new Persona {IDpersona = 2, Nombre = "Paolo Pret", Edad = 35, Profesion = "RRHH" },
                new Persona {IDpersona = 3, Nombre = "Pepe Suaréz", Edad = 48, Profesion = "Jefe Ventas" },
                new Persona {IDpersona = 4, Nombre = "Tizio Sempronio", Edad = 25, Profesion = "Contable" },
                new Persona {IDpersona = 5, Nombre = "Catalin Franz", Edad = 37, Profesion = "Jefe" },
            };
        }

        public ActionResult ViewArrayPersonas()
        {
            return View("ResultArray", (object)CreatePersonas());
        }

    }
}