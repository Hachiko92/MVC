using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto02.Models
{
    public class Product
    {
        public int IDproduct { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}