using Microsoft.AspNetCore.Mvc;
using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class ComisionesController : Controller
    {
        public System.Web.Mvc.ActionResult Index(int pagina = 1, string comision="")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Comisiones> c = new List<Comisiones>();
            var ComisionesPaginado = new Models.ViewModels.IndexComisiones();
            if (string.IsNullOrEmpty(comision))
            {
                c = ComisionesRepository.ObtenerComisionesPaginado(pagina, registrosPorPágina);
                ComisionesPaginado.TotalDeRegistros = ComisionesRepository.TotalRegistros();
            }
            else
            {
                c = ComisionesRepository.ObtenerComisionesPaginado(pagina, registrosPorPágina, comision);
                ComisionesPaginado.TotalDeRegistros = ComisionesRepository.TotalRegistros(comision);
            }
            ComisionesPaginado.Comisiones = c;
            ComisionesPaginado.PaginaActual = pagina;            ;
            ComisionesPaginado.RegistrosPorPagina = registrosPorPágina;
            
            ViewBag.TiposDocumento = TiposDocumentoRepository.ObtenerTiposDocumento();
            return View(ComisionesPaginado);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            Comisiones m = new Comisiones();
            return View(m);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones")] Comisiones comision)
        {
            ComisionesRepository.InsertarComision(comision);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            var c = ComisionesRepository.ObtenerComision(id);
            return View(c);
        }



        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones,IdComision")] Comisiones comision)
        {
            ComisionesRepository.EditarComision(comision);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            ComisionesRepository.EliminarComision(id);
            return RedirectToAction("Index");
        }
    }
}