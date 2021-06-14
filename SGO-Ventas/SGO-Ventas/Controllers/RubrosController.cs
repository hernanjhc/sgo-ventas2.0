using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class RubrosController : Controller
    {
        public ActionResult Index(int pagina = 1, string rubro = "")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Rubros> r = new List<Rubros>();
            var RubrosPaginados = new Models.ViewModels.IndexRubros();
            if (string.IsNullOrEmpty(rubro))
            {
                r = RubrosRepository.ObtenerRubrosPaginado(pagina, registrosPorPágina);
                RubrosPaginados.TotalDeRegistros = RubrosRepository.TotalRegistros();
            }
            else
            {
                r = RubrosRepository.ObtenerRubrosPaginado(pagina, registrosPorPágina, rubro);
                RubrosPaginados.TotalDeRegistros = RubrosRepository.TotalRegistros(rubro);
            }
            RubrosPaginados.Rubros = r;
            RubrosPaginados.PaginaActual = pagina;            
            RubrosPaginados.RegistrosPorPagina = registrosPorPágina;

            return View(RubrosPaginados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Rubros m = new Rubros();
            //return PartialView("ModalPartial", td);
            return View(m);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Descripcion")] Rubros rubro)
        {
            RubrosRepository.InsertarRubro(rubro);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var m = RubrosRepository.ObtenerRubro(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Rubros rubro)
        {
            RubrosRepository.EditarRubro(rubro);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            RubrosRepository.EliminarRubro(id);
            return RedirectToAction("Index");
        }
    }
}