using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio3_2.Models
{
    public class Alumno
    {
        public int AlumnoID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Trabaja { get; set; }
        public float Nota { get; set; }
    }
}