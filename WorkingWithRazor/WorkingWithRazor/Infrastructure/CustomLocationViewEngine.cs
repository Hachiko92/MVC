using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithRazor.Infrastructure
{
    //EJEMPLO 10.1
    //Establecemos una variedad de búsqueda de vistas: contiene solo entradas para .cshtml y en vez de buscar
    //en Views/Shared buscará en Views/Common

    public class CustomLocationViewEngine : RazorViewEngine
    {
        public CustomLocationViewEngine()
        {
            ViewLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/Common/{0}.cshtml" };
        }
    }
}