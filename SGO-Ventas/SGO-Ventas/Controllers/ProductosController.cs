using FileHelpers;
using LinqToExcel;
using SGO_Ventas.Models;
using SGO_Ventas.Models.FileHelpers;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class ProductosController : Controller
    {
        public ActionResult Index(int pagina = 1, string producto = "")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Productos> p = new List<Productos>();
            var productosPaginados = new Models.ViewModels.IndexProductos();

            if (string.IsNullOrEmpty(producto))
            {
                p = ProductosRepository.ObtenerProductosPaginado(pagina, registrosPorPágina);
                productosPaginados.TotalDeRegistros = ProductosRepository.TotalRegistros();
            }
            else
            {
                p = ProductosRepository.ObtenerProductosPaginado(pagina, registrosPorPágina, producto);
                productosPaginados.TotalDeRegistros = ProductosRepository.TotalRegistros(producto);
            }
            productosPaginados.Productos = p;
            productosPaginados.PaginaActual = pagina;
            productosPaginados.RegistrosPorPagina = registrosPorPágina;

            ViewBag.Marcas = MarcasRepository.ObtenerMarcas();
            ViewBag.Rubros = RubrosRepository.ObtenerRubros();
            ViewBag.Proveedores = ProveedoresRepository.ObtenerProveedores();
            ViewBag.Unidades = UnidadesRepository.ObtenerUnidades();
            return View(productosPaginados);
        }

        [HttpGet]
        public ActionResult ProductosVendidosPorDia()
        {
            var repo = new MovimientosRepository();
            bool esVenta = true;
            DateTime fecha = DateTime.Now;
            using (var dt = repo.ObtenerListado(esVenta, fecha))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (var reporte = new Reports.Design.MovimientosStock())
                    {
                        reporte.Database.Tables["MovimientosStock"].SetDataSource(dt);
                        reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "productos-vendidos-dia");
                        return new EmptyResult();
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult ExportarProductos(bool? descargar)
        {
            var repo = new ProductosRepository();
            bool stockMinimo = false;
            using (var dt = repo.ObtenerListado(stockMinimo))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (var reporte = new Reports.Design.ListadoProductos())
                    {
                        reporte.Database.Tables["Productos"].SetDataSource(dt);
                        if (descargar == true)
                        {
                            reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "listado-productos");
                        }
                        else
                        {
                            reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "listado-productos");
                        }
                        return new EmptyResult();
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult ExportarProductosConStockMinimo(bool? descargar)
        {
            var repo = new ProductosRepository();
            bool stockMinimo = true;
            using (var dt = repo.ObtenerListado(stockMinimo))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (var reporte = new Reports.Design.ListadoProductos())
                    {
                        reporte.Database.Tables["Productos"].SetDataSource(dt);
                        if (descargar == true)
                        {
                            reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "listado-productos");
                        }
                        else
                        {
                            reporte.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                                System.Web.HttpContext.Current.Response, true, "listado-productos");
                        }
                        return new EmptyResult();
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Marcas = MarcasRepository.CargarSelectListMarcas();
            ViewBag.Rubros = RubrosRepository.CargarSelectListRubros();
            ViewBag.Proveedores = ProveedoresRepository.CargarSelectListProveedores();
            ViewBag.Unidades = UnidadesRepository.CargarSelectListUnidades();
            Productos producto = new Productos();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CodBarra, Descripcion, IdMarca, IdRubro, IdProveedor, IdUnidad, Costo, PrecioL1, PrecioL2, PrecioL3, Stock, StockMinimo, IVAVenta, Observaciones")] Productos producto)
        {
            ProductosRepository.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Marcas = MarcasRepository.CargarSelectListMarcas();
            ViewBag.Rubros = RubrosRepository.CargarSelectListRubros();
            ViewBag.Proveedores = ProveedoresRepository.CargarSelectListProveedores();
            ViewBag.Unidades = UnidadesRepository.CargarSelectListUnidades();
            Productos producto = ProductosRepository.ObtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, CodBarra, Descripcion, IdMarca, IdRubro, IdProveedor, IdUnidad, Costo, PrecioL1, PrecioL2, PrecioL3, Stock, StockMinimo, IVAVenta, Observaciones")] Productos producto)
        {
            ProductosRepository.EditarProducto(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProductosRepository.EliminarProducto(id);
            return RedirectToAction("Index");
        }

        public ActionResult ImportarDesdeTxt()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ImportarTxt()
        {
            string salida = "";
            int registradosEnBD = 0;
            //var engine = new FixedFileEngine<Customer>();
            //Customer[] result = engine.ReadFile("input.txt");

            //foreach (var detail in result)
            //var engine = new FileHelperEngine<Orders>();
            //var records = engine.ReadFile("Input.txt");
            var engine = new FileHelperEngine<ProductosImport>();
            var productosLeídos = engine.ReadFile(@"C:/Temp/AltaProductos.txt");
            foreach (var item in productosLeídos)
            {
                if (ProductosRepository.GuardarProductoLeidoPorTxt(item)) registradosEnBD++;                
            }
            return Json(String.Format("Ok", DateTime.Now),
                JsonRequestBehavior.AllowGet);
        }

            [HttpGet]
        public JsonResult ExportarTxt()
        {
            var engine = new FileHelperAsyncEngine<ProductosImport>();
            var productos = ProductosRepository.ObtenerProductosFileHelper();
            var destino = VerificarDestino();
            using (engine.BeginWriteFile(destino))
            {
                foreach (ProductosImport cust in productos)
                {
                    engine.WriteNext(cust);
                }
            }
            return Json(String.Format(@"Los Productos se exportaron en C:/Temp/Productos {0:dd-MM-yyyy}.txt", DateTime.Now),
                JsonRequestBehavior.AllowGet);
        }

        private static string VerificarDestino()
        {
            var destino = String.Format(@"C:/Temp/Productos {0:dd-MM-yyyy}.txt", DateTime.Now);
            if (!Directory.Exists("C:/Temp/"))
            {
                System.IO.Directory.CreateDirectory("C:/Temp/");
            }
            return destino;
        }

        public ActionResult Importar()
        {
            IEnumerable<ImportarProductoViewModel> list = new List<ImportarProductoViewModel>();
            IEnumerable<ImportarProductoViewModel> listProcesada = new List<ImportarProductoViewModel>();
            bool importar = Request.Params["method"] == "1";
            string worksheet = Request.Params["worksheet"];

            if (worksheet != null)
            {
                //string fileSrc = Server.MapPath(@"C:\Temp\ExcelFile.xls");
                string fileSrc = @"C:\Temp\Produc.xls";

                list = Method2Optimizado(fileSrc, worksheet);
            }

            listProcesada = list;

            if (list != null && importar)
            {
                listProcesada = ProductosRepository.ImportarProductosExcel(list);
            }
            return View(listProcesada);
        }

        public IEnumerable<ImportarProductoViewModel> Method2Optimizado(string fileSrc, string worksheet)
        {
            var excelData = new ExcelQueryFactory(fileSrc);
            excelData.AddMapping("Descripcion", "Descripcion");
            excelData.AddMapping("Marca", "Marca");
            excelData.AddMapping("Rubro", "Rubro");
            excelData.AddMapping("Proveedor", "Proveedor");
            excelData.AddMapping("Unidad", "Unidad");
            excelData.AddMapping("Costo", "Costo");
            excelData.AddMapping("PrecioL1", "Preciol1");
            excelData.AddMapping("PrecioL2", "Preciol2");
            excelData.AddMapping("PrecioL3", "Preciol3");
            excelData.AddMapping("Stock", "Stock");
            excelData.AddMapping("StockMinimo", "StockMinimo");
            excelData.AddMapping("IvaVentas", "IvaVentas");
            excelData.AddMapping("Observaciones", "Observaciones");

            var list = from a in excelData.Worksheet<ImportarProductoViewModel>(worksheet) select a;
            return list.AsEnumerable();
        }



    }
}