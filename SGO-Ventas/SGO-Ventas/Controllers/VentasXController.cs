using System.Web.Mvc;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Repositories;

namespace SGO_Ventas.Controllers
{
    public class VentasXController : Controller
    {
        public ActionResult Index(int pagina = 1)
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            var v = VentasXRepository.ObtenerVentasXPaginado(pagina, registrosPorPágina);
            ViewBag.Clientes = ClientesRepository.ObtenerClientes();
            ViewBag.TiposPago = TiposPagoRepository.ObtenerTiposPago();

            var VentasXPaginados = new Models.ViewModels.IndexVentasX();
            VentasXPaginados.VentasX = v;
            VentasXPaginados.PaginaActual = pagina;
            VentasXPaginados.TotalDeRegistros = VentasXRepository.TotalRegistros();
            VentasXPaginados.RegistrosPorPagina = registrosPorPágina;

            return View(VentasXPaginados);
        }

        public ActionResult Create()
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            ViewBag.RazonSocial = ClientesRepository.CargarSelectListClientes();
            ViewBag.TiposPago = TiposPagoRepository.CargarSelectListTiposPago();
            ViewBag.Productos = ProductosRepository.CargarSelectListProductos();
            return View();
        }

        [HttpPost]
        public JsonResult Create(VentaViewModel venta)
        {
            VentasXRepository.GuardarVenta(venta);
            return Json("La venta fué registrada correctamente.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuscarCliente(decimal? nroDocumento)//, string RazonSocial, string Direccion)
        {
            var cliente = ClientesRepository.ObtenerCliente(nroDocumento);
            return PartialView("_buscarCliente", cliente);
            //ViewBag.Clientes = cliente;
            //return View(cliente);
        }

        [HttpGet]
        public JsonResult getCliente(int id)
        {
            var direccion = ClientesRepository.ObtenerCliente(id).Direccion;
            return Json(direccion, JsonRequestBehavior.AllowGet);
            //var cliente = ClientesRepository.ObtenerCliente(id);
            //return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getPrecioProducto(int id, int lista)
        {
            decimal precio = ProductosRepository.ObtenerPrecioPorId(id, lista);
            return Json(precio, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Imprimir(int id)
        {
            var repo = new VentasXRepository();
            using (var dt = repo.ObtenerDatos(id))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (var reporte = new Reports.Design.Venta())
                    {
                        reporte.Database.Tables["Venta"].SetDataSource(dt);

                        reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "venta");
                    }
                }
                return new EmptyResult();
            }
        }
        
    }
}