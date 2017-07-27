using Ejercicio8_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio8_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Fotografo> fotos = CrearFotografos();

            var query = fotos
                       .Select(e => e)
                       .ToList();

            return View();
        }

        public ActionResult Felicita()
        {
            List<Fotografo> fotos = CrearFotografos();

            var query = fotos
                       .Select(f => new
                       {
                           f.IdFotografo,
                           suma = f.eventos.Sum(fo => fo.Importe)
                       })
                       .ToList();

            var id = query
                    .Where(f => f.suma == query.Max(fo => fo.suma))
                    .Select(f => f.IdFotografo)
                    .FirstOrDefault();

            var fotografo = fotos
                           .Where(f => f.IdFotografo.Equals(id))
                           .Select(f => new
                           {
                               f.NombreApell,
                               f.Direccion
                           }).FirstOrDefault();
            TempData["fotografo"] = fotografo.NombreApell;
            TempData["direccion"] = fotografo.Direccion;
            return View();
        }

        public List<Fotografo> CrearFotografos()
        {
            List<Fotografo> fotografos = new List<Fotografo>
            {
                new Fotografo {IdFotografo=1,NombreApell="Juán Sánchez",Direccion="Dirección1"},
                new Fotografo {IdFotografo=2,NombreApell="Ana Gonzélez",Direccion="Dirección2"},
                new Fotografo {IdFotografo=3,NombreApell="Isabel Guzmán",Direccion="Dirección3"},
                new Fotografo {IdFotografo=4,NombreApell="José Tomás",Direccion="Dirección4"},
                new Fotografo {IdFotografo=5,NombreApell="Inés Mora",Direccion="Dirección5"}

            };
            fotografos[0].eventos = new List<Evento>{new Evento{IdEvento=1,Descripcion="Boda de Juan e Isabel",Fecha=Convert.ToDateTime("12/07/2014"),Importe=275M},
                                                     new Evento{IdEvento=2,Descripcion="Comunión de Jaimito",Fecha=Convert.ToDateTime("05/06/2014"),Importe=125M}};
            fotografos[1].eventos = new List<Evento>{new Evento{IdEvento=3,Descripcion="Cumpleaños de Rociito",Fecha=Convert.ToDateTime("10/08/2014"),Importe=60M},
                                                     new Evento{IdEvento=4,Descripcion="Entierro del Conde Orgaz",Fecha=Convert.ToDateTime("13/01/2014"),Importe=167M}};
            fotografos[2].eventos = new List<Evento>{new Evento{IdEvento=5,Descripcion="Boda de Juan Carlos",Fecha=Convert.ToDateTime("10/08/2014"),Importe=160M},
                                                     new Evento{IdEvento=6,Descripcion="Graduacion de Andrésito",Fecha=Convert.ToDateTime("10/08/2014"),Importe=160M},
                                                     new Evento{IdEvento=7,Descripcion="Graduación de Felix",Fecha=Convert.ToDateTime("16/01/2015"),Importe=267M}};
            fotografos[3].eventos = new List<Evento>{new Evento{IdEvento=8,Descripcion="Boda Ivan",Fecha=Convert.ToDateTime("10/08/2014"),Importe=160M},
                                                     new Evento{IdEvento=9,Descripcion="Aniversario de Bodas",Fecha=Convert.ToDateTime("11/08/2014"),Importe=160M},
                                                     new Evento{IdEvento=10,Descripcion="Bautizo de Julia",Fecha=Convert.ToDateTime("16/03/2015"),Importe=267M}};
            fotografos[4].eventos = new List<Evento>{new Evento{IdEvento=11,Descripcion="Boda María",Fecha=Convert.ToDateTime("11/09/2014"),Importe=160M},
                                                     new Evento{IdEvento=12,Descripcion="Bodas De Plata Maria y Juan",Fecha=Convert.ToDateTime("25/06/2014"),Importe=160M}};


            return fotografos;
        }
    }
}