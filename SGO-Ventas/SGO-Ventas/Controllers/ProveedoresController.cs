using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class ProveedoresController : Controller
    {
        public ActionResult Index(int pagina = 1, string proveedor = "")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Proveedores> p = new List<Proveedores>();
            var ProveedoresPaginados = new Models.ViewModels.IndexProveedores();

            if (string.IsNullOrEmpty(proveedor))
            {                
                p = ProveedoresRepository.ObtenerProveedoresPaginado(pagina, registrosPorPágina);
                ProveedoresPaginados.TotalDeRegistros = ProveedoresRepository.TotalRegistros();
            }
            else
            {
                p = ProveedoresRepository.ObtenerProveedoresPaginado(pagina, registrosPorPágina, proveedor);
                ProveedoresPaginados.TotalDeRegistros = ProveedoresRepository.TotalRegistros(proveedor);
            }
            ProveedoresPaginados.Proveedores = p;
            ProveedoresPaginados.PaginaActual = pagina;
            ProveedoresPaginados.RegistrosPorPagina = registrosPorPágina;

            ViewBag.TiposDocumento = TiposDocumentoRepository.ObtenerTiposDocumento();
            return View(ProveedoresPaginados);
        }
        
        
        public ActionResult Create()
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            Proveedores p = new Proveedores();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones")] Proveedores proveedor)
        {
            ProveedoresRepository.GuardarProveedor(proveedor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            var p = ProveedoresRepository.ObtenerProveedor(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones")] Proveedores proveedor)
        {
            ProveedoresRepository.EditarProveedor(proveedor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProveedoresRepository.EliminarProveedor(id);
            return RedirectToAction("Index");
        }


    }
}