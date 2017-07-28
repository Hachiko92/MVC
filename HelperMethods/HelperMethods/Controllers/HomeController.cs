using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//ejemplo 11.6
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new string[] { "New York", "London", "Paris" };
            string message = "This is an HTML element: <input>";
            return View((object)message);
        }
       
        /* Cara A la parte que va */
        public ActionResult CreatePerson()
        {
            return View(new Person());
        }
        /* Cara B la parte que viene */
        [HttpPost]
        public ActionResult CreatePerson(Person persona)
        {
            return View(persona);
        }
    }
}
