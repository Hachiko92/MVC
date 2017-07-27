using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio7_1.Models
{
    public class Barco
    {
        public int BarcoId { get; set;}
        public string NombreBarco { get; set; }
        public int CosteConstruccion { get; set; }
        public int AñoConstruccion { get; set; }
        public DateTime FechaUltimaReparacion { get; set; }

        /* parte del uno */
        public virtual ICollection<Tripulante> tripulacion { get; set; }
    }
}