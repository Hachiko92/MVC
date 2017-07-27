using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect05_Routing.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult Alter(string id)
        {
            string otraVariable = id;
            return View("ActionName");
        }

        /* se puede utilizar los dos */
        //public RedirectResult MyRedireccionado() { }
        public RedirectToRouteResult MyRedireccionado()
        {
            /* se puede rediccionar solo a otro metodo del mismo controllador */
            return RedirectToAction("Index");
        }
    }
}