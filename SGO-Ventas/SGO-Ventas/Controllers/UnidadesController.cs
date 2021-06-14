using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SGO_Ventas.Controllers
{
    public class UnidadesController : Controller
    {
        public ActionResult Index(int pagina = 1, string unidad="")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Unidades> u = new List<Unidades>();
            var unidadesPaginadas = new Models.ViewModels.IndexUnidades();
            if (string.IsNullOrEmpty(unidad))
            {
                u = UnidadesRepository.ObtenerUnidadesPaginado(pagina, registrosPorPágina);
                unidadesPaginadas.TotalDeRegistros = UnidadesRepository.TotalRegistros();
            }
            else
            {
                u = UnidadesRepository.ObtenerUnidadesPaginado(pagina, registrosPorPágina, unidad);
                unidadesPaginadas.TotalDeRegistros = UnidadesRepository.TotalRegistros(unidad);
            }
            unidadesPaginadas.Unidades = u;
            unidadesPaginadas.PaginaActual = pagina;            
            unidadesPaginadas.RegistrosPorPagina = registrosPorPágina;

            return View(unidadesPaginadas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Unidades u = new Unidades();
            return View(u);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Descripcion")] Unidades unidad)
        {
            UnidadesRepository.InsertarUnidad(unidad);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var u = UnidadesRepository.ObtenerUnidad(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Unidades unidad)
        {
            UnidadesRepository.EditarUnidad(unidad);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            UnidadesRepository.EliminarUnidad(id);
            return RedirectToAction("Index");
        }
    }
}