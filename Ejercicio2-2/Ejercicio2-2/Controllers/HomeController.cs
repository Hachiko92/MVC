using Ejercicio2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio2_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "Index";
        }

        public List<Jugador> ListadoJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>
            {
                new Jugador {IDjugador = 1, Nombre = "Mario Rossi", Posicion="CC", Sueldo=683 },
                new Jugador {IDjugador = 2, Nombre = "Carlo Mendez", Posicion="PT", Sueldo=510 },
                new Jugador {IDjugador = 3, Nombre = "Pepe Santos", Posicion="CD", Sueldo=568 },
                new Jugador {IDjugador = 4, Nombre = "Layton Paz", Posicion="AS", Sueldo=572 },
            };

            return jugadores;
        }

        public ActionResult GetJugadores()
        {
            List<Jugador> jugadores = ListadoJugadores();

            StringBuilder listaJugadores = new StringBuilder();
            foreach (Jugador j in jugadores)
            {
                listaJugadores.AppendLine(String.Format("ID: {0}Nombre: {1}Posicion: {2}Sueldo: {3}", j.IDjugador, j.Nombre, j.Posicion, j.Sueldo));
            }

            return View("Result", (object)(listaJugadores).ToString());
        }

        public ViewResult SueldoMayor()
        {
            List<Jugador> jugadores = ListadoJugadores();

            //var jugador = (from j in jugadores
            //               orderby j.Sueldo descending
            //               select j.Nombre).Take(1);

            var mayor = jugadores
                       .Where(j => j.Sueldo.Equals(jugadores
                                                  .Select(ju => ju.Sueldo)
                                                  .Max()))
                       .Select(j => j.Nombre)
                       .FirstOrDefault();

            return View("Result", (object)String.Format("Jugador con el sueldo mas alto: {0}", mayor));
        }

        public ViewResult TotalSueldos()
        {
            List<Jugador> jugadores = ListadoJugadores();

            int total = jugadores.Sum(p => p.Sueldo);

            return View("Result", (object)String.Format("El total de los sueldos es: {0}", total));
        }

        public List<Jugador> AddJugador(List<Jugador> jugadores)
        {
            jugadores.Add(new Jugador { IDjugador = 5, Nombre = "Diego Costa", Posicion = "Delantero", Sueldo = 430 });
            return jugadores;
        }

        public ViewResult sueldoMenor()
        {
            List<Jugador> jugadores = ListadoJugadores();
            jugadores = AddJugador(jugadores);

            var result = jugadores
                        .OrderBy(j => j.Sueldo)
                        .Take(3)
                        .Select(j => new
                        {
                            j.Nombre,
                            j.Sueldo
                        });

            StringBuilder listaJugadores = new StringBuilder();
            foreach (var j in result)
            {
                listaJugadores.AppendLine(String.Format("Nombre: {0} Sueldo: {1}", j.Nombre, j.Sueldo));
            }

            return View("Result", (object)(listaJugadores).ToString());
        }

        public ViewResult debajoMedia()
        {
            List<Jugador> jugadores = ListadoJugadores();
            jugadores = AddJugador(jugadores);

            double media = (jugadores
                           .Select(j => j.Sueldo)).Average();

            var result = jugadores
                        .Where(j => j.Sueldo < media)
                        .Select(j => j);

            StringBuilder listaJugadores = new StringBuilder();
            foreach (Jugador j in result)
            {
                listaJugadores.AppendLine(String.Format("ID: {0}Nombre: {1}Posicion: {2}Sueldo: {3}", j.IDjugador, j.Nombre, j.Posicion, j.Sueldo));
            }

            return View("Result", (object)(listaJugadores).ToString());
        }
    }
}