using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio8_2.Models
{
    public class Fotografo
    {
        public int IdFotografo { get; set; }
        public string NombreApell { get; set; }
        public string Direccion { get; set; }
        public int IdEvento { get; set; }

        public virtual ICollection<Evento> eventos { get; set; }
    }
}