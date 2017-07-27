using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio2_2.Models
{
    public class Jugador
    {
        public int IDjugador { get; set; }
        public string Nombre{ get; set; }
        public string Posicion { get; set; }
        public int Sueldo { get; set; }
    }
}