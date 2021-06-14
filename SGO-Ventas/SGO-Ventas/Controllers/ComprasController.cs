using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Index(int pagina = 1)
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            var c = ComprasRepository.ObtenerComprasPaginado(pagina, registrosPorPágina);
            ViewBag.Proveedores = ProveedoresRepository.ObtenerProveedores();
            ViewBag.TiposPago = TiposPagoRepository.ObtenerTiposPago();

            var ComprasPaginados = new Models.ViewModels.IndexCompras();
            ComprasPaginados.Compras = c;
            ComprasPaginados.PaginaActual = pagina;
            ComprasPaginados.TotalDeRegistros = ComprasRepository.TotalRegistros();
            ComprasPaginados.RegistrosPorPagina = registrosPorPágina;

            return View(ComprasPaginados);
        }

        public ActionResult Create()
        {
            ViewBag.RazonSocial = ProveedoresRepository.CargarSelectListProveedores();
            ViewBag.TiposPago = TiposPagoRepository.CargarSelectListTiposPago();
            ViewBag.Productos = ProductosRepository.CargarSelectListProductos();
            return View();
        }

        [HttpPost]
        public JsonResult Create(CompraViewModel compra)
        {
            ComprasRepository.GuardarCompra(compra);
            return Json("La compra fué registrada correctamente.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getProveedor(int id)
        {
            var direccion = ProveedoresRepository.ObtenerProveedor(id).Direccion;
            return Json(direccion, JsonRequestBehavior.AllowGet);
        }
    }
}