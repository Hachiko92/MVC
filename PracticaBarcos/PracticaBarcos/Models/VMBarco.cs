using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaBarcos.Models
{
    public class VMBarco
    {
        public List<Barco> Barcos { get; set; }
        public int BarcoSeleccionado { get; set; }
    }
}