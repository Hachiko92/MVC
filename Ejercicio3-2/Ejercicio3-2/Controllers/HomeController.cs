using Ejercicio3_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio3_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            @ViewBag.Titulo = "";
            return View("Index", (object)"Index");
        }

        public Alumno[] CreateAlumnos()
        {
            return new Alumno[]
            {
                new Alumno { AlumnoID = 1, Nombre = "Marco Pero", Edad = 22, Trabaja = false, Nota = 7.5f },
                new Alumno { AlumnoID = 2, Nombre = "Pepe Suaréz", Edad = 21, Trabaja = true, Nota = 4f },
                new Alumno { AlumnoID = 3, Nombre = "Eva Sanchez", Edad = 23, Trabaja = true, Nota = 8.5f },
                new Alumno { AlumnoID = 4, Nombre = "Roberto Gimenéz", Edad = 24, Trabaja = false, Nota = 9f },
                new Alumno { AlumnoID = 5, Nombre = "Paola Martini", Edad = 22, Trabaja = false, Nota = 7f },
                new Alumno { AlumnoID = 6, Nombre = "Piero Carboni", Edad = 25, Trabaja = false, Nota = 8f },
            };
        }

        public ActionResult GetAlumnos()
        {
            /* Con el Session */
            ViewBag.TipoMetodo = 0;
            @ViewBag.Titulo = "Todos los alumnos";

            return View("Result", (object)CreateAlumnos());
        }

        public ActionResult GetAlumnosTrabajadores()
        {
            /* Con el Session */
            ViewBag.TipoMetodo = 0;
            @ViewBag.Titulo = "Alumnos trabajadores";

            Alumno[] alumnos = CreateAlumnos();
            var alumnostrabajadores = (alumnos
                                      .Where(a => a.Trabaja == true)
                                      .OrderBy(a => a.AlumnoID)
                                      .Select(a => a)).ToArray();
            
            return View("Result", (object)alumnostrabajadores);
        }

        public ActionResult GetMayor()
        {
            Alumno[] alumnos = CreateAlumnos();
            @ViewBag.Titulo = "Alumno mayor de edad";
            var mayor = (alumnos
                       .OrderByDescending(a => a.Edad)
                       .ThenBy(a => a.AlumnoID)
                       .Select(a => a)
                       .Take(1)).FirstOrDefault();

            //var query = alumnos
            //           .Where(a => a.Edad.Equals(alumnos
            //                                    .Select(al => al.Edad).Max()))
            //           .Select(a => a);

            string result = mayor.Nombre + " de " + mayor.Edad + " años, con nota igual a " + mayor.Nota;

            return View("Index", (object)result);
        }

        public ActionResult GetSuspensosTrabajadores()
        {
            @ViewBag.Titulo = "Alumnos trabajadores suspensos";
            ViewBag.TipoMetodo = 1;
            Alumno[] alumnos = CreateAlumnos();

            //var suspensos = (alumnos
            //                .Where(a => a.Nota < 6 && a.Trabaja == true)
            //                .Select(a => a)).FirstOrDefault();

            //if (suspensos == null)
            //{
            //    return View("Index", (object)"No hay alumnos con estos criterios");
            //}
            //else
            //{
            //    var result = alumnos
            //                .Where(a => a.Nota < 6 && a.Trabaja == true)
            //                .Select(a => a)
            //                .ToArray();

            //    return View("Result", (object)result);
            //}

            var query = alumnos
                       .Where(a => a.Trabaja && a.Nota < 5)
                       .Select(a => a)
                       .ToList();

            if (query.Count > 0)
            { 
                return View("Result", (object)query.ToArray());
            }
            else
            {
                return View("Index", (object)"No hay alumnos con estos criterios");
            }
        }

        public ActionResult SuperiorInferiorMedia()
        {
            @ViewBag.Titulo = "Alumnos trabajadores suspensos";
            ViewBag.TipoMetodo = 2;
            Alumno[] alumnos = CreateAlumnos();

            var query = alumnos.Average(a => a.Nota);
            ViewBag.Media = query;
            return View("Result", (object)alumnos);
        }

    }
}