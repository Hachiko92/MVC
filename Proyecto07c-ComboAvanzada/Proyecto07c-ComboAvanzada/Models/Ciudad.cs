using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto07c_ComboAvanzada.Models
{
    public class Ciudad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CP { get; set; }
        public int ComunidadID { get; set; }
    }
}