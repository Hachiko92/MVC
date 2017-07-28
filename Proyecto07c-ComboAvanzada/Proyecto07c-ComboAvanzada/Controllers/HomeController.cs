using Proyecto07c_ComboAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto07c_ComboAvanzada.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //LLenarComboFormaUno();
            //LlenarComboFormaDos();
            //return View();

            var items = ciudades;
            var vm = new VMComboCities();
            vm.Cities = items;

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(VMComboCities info)
        {
            var id = info.SelectedCity;
            var city = ciudades.FirstOrDefault(c => c.ID == id);
            return View();
        }
        //public ActionResult Index(string SelectedCity)
        //{
        //    var id = Int32.Parse(selectedCity);
        //    var city = ciudades.FirstOrDefault(c => c.ID == id);
        //    return View();
        //}
        //public ActionResult Index(string Cities)
        //{
        //    var ID = Int32.Parse(Cities);
        //    var city = ciudades.FirstOrDefault(c => c.ID == ID);
        //    return View();
        //}

        private List<Ciudad> ciudades = new List<Ciudad>
        {
            new Ciudad { ID = 1, Nombre = "Cáceres", CP = "C23", ComunidadID = 1 },
            new Ciudad { ID = 2, Nombre = "Madrid", CP = "M08", ComunidadID = 2 },
            new Ciudad { ID = 3, Nombre = "Barcelona", CP = "B09", ComunidadID = 3 },
            new Ciudad { ID = 4, Nombre = "Tarragona", CP = "T07", ComunidadID = 4 }
        };

        /* FORMA UNO */ 
        private void LLenarComboFormaUno()
        {
            var items = new List<SelectListItem>();
            items = ciudades.Select(c => new SelectListItem()
                {
                    Text = c.Nombre,
                    Value = c.ID.ToString()
                }).ToList();

            ViewBag.Cities = items;
        }

        /* FORMA DOS */
        private void LlenarComboFormaDos()
        {
            var items = ciudades;
            ViewBag.Cities = new SelectList(items, "ID", "Nombre");
        }
    }
}