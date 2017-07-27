using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] frutas = new string[] { "Apple", "Orange", "Pear" };
            return View(frutas);
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        /* el metodo que aparece debaho de [ChildActionOnly] es lo que lo utiliza
         * el ChildAction siempre se asocia a una PartialView */
        [ChildActionOnly]
        public ActionResult Time()
        {
            return PartialView(DateTime.Now);
        }
    }
}
