using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio8_2.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }

        public virtual Fotografo Forografo { get; set; }
    }
}