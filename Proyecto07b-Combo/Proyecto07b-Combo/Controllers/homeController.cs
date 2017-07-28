using Proyecto07b_Combo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto07b_Combo.Controllers
{
    public class HomeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            List<Pais> paisesFinal = CrearPaises();
            LlenarDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(int Pais)
        {
            return View();
        }

        private List<Pais> CrearPaises()
        {
            List<Pais> paises = new List<Pais>
            {
                new Pais { IdPais = 1, Nombre = "Francia" },
                new Pais { IdPais = 2, Nombre = "España" },
                new Pais { IdPais = 3, Nombre = "Italia" },
                new Pais { IdPais = 4, Nombre = "Bulgaria" }
            };

            return paises
                  .Select(p => p)
                  .OrderBy(p => p.Nombre)
                  .ToList();
        }

        /* private void LlenarDropDownList(int? IdPais = 0) permitería valores nulos en entrada */
        private void LlenarDropDownList(int IdPais = 0)
        {
            List<SelectListItem> paisesFinal = new List<SelectListItem>();
            paisesFinal.Add(new SelectListItem()
            {
                Value = "0",
                Text = " - Choose - ",
                Selected = true
            });

            List<Pais> paises = CrearPaises();
            foreach(var p in paises)
            {
                paisesFinal.Add(new SelectListItem()
                {
                    Value = p.IdPais.ToString(),
                    Text = p.Nombre,
                    Selected = ( IdPais == p.IdPais ? true : false )
                });
            }

            ViewData["Paises"] = paisesFinal;
        }
    }
}