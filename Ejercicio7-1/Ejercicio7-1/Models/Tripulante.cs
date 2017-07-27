﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio7_1.Models
{
    public class Tripulante
    {
        public int TripulanteId { get; set; }
        public string NombreTripulante { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaTituloNavegacion { get; set; }
        public int BarcoId { get; set; }

        /* parte del mucho */
        public virtual Barco Barco { get; set; }
    }
}