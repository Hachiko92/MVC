using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect07_Controladores.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int id = 1)
        {
            int identificador = id;
            if (TempData["Message"] != null)
            {
                string mensaje = TempData["Message"].ToString();
            }
            return View();
        }

        public ActionResult Otro()
        {
            /* RedirectToAction es util para pasar valores entre metodos */
            return RedirectToAction("Index", new { id = 23 });
        }

        public ActionResult UnoMas()
        {
            TempData["Message"] = "Hola";
            TempData["Fecha"] = DateTime.Now;
            /* Redirect si utiliza cuando no se quieren pasar valores */
            return Redirect("Index");
        }
    }
}