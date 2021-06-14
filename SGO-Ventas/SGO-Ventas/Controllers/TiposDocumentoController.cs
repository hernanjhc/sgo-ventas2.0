using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class TiposDocumentoController : Controller
    {
        // GET: TiposDocumento
        public ActionResult Index(int pagina = 1)
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            var t = TiposDocumentoRepository.ObtenerTiposDocumentoPaginado(pagina, registrosPorPágina);

            var TiposDocumentoPaginados = new Models.ViewModels.IndexTiposDocumento();
            TiposDocumentoPaginados.TiposDocumento = t;
            TiposDocumentoPaginados.PaginaActual = pagina;
            TiposDocumentoPaginados.TotalDeRegistros = TiposDocumentoRepository.TotalRegistros();
            TiposDocumentoPaginados.RegistrosPorPagina = registrosPorPágina;

            return View(TiposDocumentoPaginados);
        }

        [HttpGet]
        public  ActionResult Create()
        {
            TiposDocumento td = new TiposDocumento();
            //return PartialView("ModalPartial", td);
            return View(td);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Descripcion")] TiposDocumento tipoDocumento)
        {
            TiposDocumentoRepository.InsertarTipoDocumento(tipoDocumento);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var td = TiposDocumentoRepository.ObtenerTipoDocumento(id);
            return View(td);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] TiposDocumento tipoDocumento)
        {
            TiposDocumentoRepository.EditarTipoDocumento(tipoDocumento);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            TiposDocumentoRepository.EliminarTipoDocumento(id);
            return RedirectToAction("Index");
        }
    }
}