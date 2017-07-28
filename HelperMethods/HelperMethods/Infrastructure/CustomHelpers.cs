using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        //EJEMPLO 11.2
        //CREANDO UN EXTERNAL HELPER METHOD
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("ul");
            foreach (string str in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }
        //EJEMPLO 11.4
        //DEMOSTRANDO EL PROBLEMA DE LAS CADENAS CODIFICADAS
        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        {
            string result = String.Format("This is the message: <p>{0}</p>", msg);
            return new MvcHtmlString(result);
        }
        //EJEMPLO 11.5
        //BUSCANDO SOLUCIONES AL PROBLEMA
        //public static string DisplayMessage(this HtmlHelper html, string msg)
        //{
        //    return String.Format("This is the message: <p>{0}</p>", msg);
        //}
        //EJEMPLO 11.6
        //SOLUCIONANDO LA CODIFICACION DE <p>
        //public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        //{
        //    string encodedMessage = html.Encode(msg);
        //    string result = String.Format("This is the message: <p>{0}</p>", encodedMessage);
        //    return new MvcHtmlString(result);
        //}
    }
}