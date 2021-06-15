using SGO_Ventas.Models;
using SGO_Ventas.Models.FileHelpers;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Reports;
using SGO_Ventas.Reports.DataSet;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class ProductosRepository
    {
        public static List<Productos> ObtenerProductosPaginado(int pagina, int cantidadRegistrosPagina, string producto = "")
        {
            using (var db = new VentasEntities())
            {
                List<Productos> p = new List<Productos>();
                p = db.Productos.ToList();
                if (!string.IsNullOrEmpty(producto))
                {
                    p = p.Where(pr => pr.Descripcion.ToUpper().Contains(producto.ToUpper())).ToList();
                }
                p.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
                return p;
            }
        }

        public static int TotalRegistros(string producto = "")
        {
            using (var db = new VentasEntities())
            {
                List<Productos> p = db.Productos.ToList();
                if (!string.IsNullOrEmpty(producto))
                {
                    p = p.Where(pr => pr.Descripcion.ToUpper().Contains(producto.ToUpper())).ToList();
                }
                return p.Count();
            }
        }

        public static IEnumerable<Productos> ObtenerProductos()
        {
            using (var db = new VentasEntities())
            {
                return db.Productos.ToList();
            }
        }

        public static ProductosImport[] ObtenerProductosFileHelper()
        {
            using (var db = new VentasEntities())
            {
                var prds = db.Productos.ToList();
                foreach (var item in prds)
                {
                    if (item.Costo == null) item.Costo = 0;
                    if (item.PrecioL1 == null) item.PrecioL1 = 0;
                    if (item.PrecioL2 == null) item.PrecioL2 = 0;
                    if (item.PrecioL3 == null) item.PrecioL3 = 0;
                    if (item.Stock == null) item.Stock = 0;
                    if (item.IVAVenta == null) item.IVAVenta = 0;                    
                }
                var prd = from p in prds
                          select new ProductosImport
                          {
                              Id    = p.Id,
                              CodBarra = p.CodBarra,
                              Descripcion = p.Descripcion,
                              Marca = p.Marcas.Descripcion,
                              Rubro = p.Rubros.Descripcion,
                              Proveedor = p.Proveedores.RazonSocial,
                              Unidad = p.Unidades.Descripcion,
                              Costo = p.Costo != null ? Convert.ToDecimal(p.Costo) : 0,
                              PrecioL1 = p.PrecioL1 == null ? 0 : Convert.ToDecimal(p.PrecioL1),
                              PrecioL2 = p.PrecioL2 == null ? 0 : Convert.ToDecimal(p.PrecioL2),
                              PrecioL3 = p.PrecioL3 == null ? 0 : Convert.ToDecimal(p.PrecioL3),
                              Stock = p.Stock == null ? 0 : Convert.ToDecimal(p.Stock),
                              StockMinimo = Convert.ToDecimal(p.StockMinimo),
                              IvaVentas = p.IVAVenta == null ? 0 : Convert.ToDecimal(p.IVAVenta),
                              Observaciones = p.Observaciones == null ? "" : p.Observaciones
                          };
            return prd.ToArray();
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="stockMínimo"></param>
        /// True, devuelve productos cuyo stock mínimo es
        /// inferior a stock real
        /// <returns></returns>
        public DataTable ObtenerListado(bool stockMínimo)
        {
            Empresa empresa = EmpresaRepository.ObtenerEmpresas().FirstOrDefault();
            var listado = new DsImpresiones.ProductosDataTable();
            var productos = ListadoProductos(stockMínimo);
            foreach (var item in productos)
            {
                listado.AddProductosRow(item.Código, item.Descripción, item.Marca, item.Rubro, item.Proveedor, item.Unidad, item.Stock.ToString(), item.StockMínimo.ToString(),
                    empresa.RazonSocial, empresa.Documento, empresa.Domicilio, empresa.Email, empresa.Telefono);
            }
            return listado;
        }

        public List<ListProductos> ListadoProductos(bool stockMínimo)
        {
            using (var db = new VentasEntities())
            {
                var query = from p in db.Productos
                            join m in db.Marcas on p.IdMarca equals m.Id
                            join r in db.Rubros on p.IdRubro equals r.Id
                            join prov in db.Proveedores on p.IdProveedor equals prov.Id
                            join u in db.Unidades on p.IdUnidad equals u.Id
                            select new ListProductos
                            {
                                Código = p.CodBarra,
                                Descripción = p.Descripcion,
                                Marca = m.Descripcion,
                                Rubro = r.Descripcion,
                                Proveedor = prov.RazonSocial,
                                Unidad = u.Descripcion,
                                Stock = p.Stock ?? 0,
                                StockMínimo = p.StockMinimo
                            };
                if (stockMínimo)
                {
                    query = query.Where(p => p.Stock < p.StockMínimo);
                }
                return query.ToList();
            }

        }

        public static void GuardarProducto(Productos producto)
        {
            using (var db = new VentasEntities())
            {
                producto.Id = db.Productos.Any() ? db.Productos.Max(p => p.Id) + 1 : 1;
                db.Productos.Add(producto);
                db.SaveChanges();
            }
        }

        internal static bool GuardarProductoLeidoPorTxt(ProductosImport item)
        {
            bool proceso = true;
            
            Productos producto = new Productos();
            if (!item.CodBarra.Any()) proceso = false;
            producto.CodBarra = item.CodBarra.Any() ? item.CodBarra : "";

            if (!item.Descripcion.Any()) proceso = false;
            producto.Descripcion = item.Descripcion.Any() ? item.Descripcion : "";

            if (!item.Marca.Any()) proceso = false;
            producto.IdMarca = item.Marca.Any() ? MarcasRepository.ObtenerIdMarca(item.Marca) : 0;

            if (!item.Rubro.Any()) proceso = false;
            producto.IdRubro = item.Rubro.Any() ? RubrosRepository.ObtenerIdRubro(item.Rubro) : 0;

            if (!item.Unidad.Any()) proceso = false;
            producto.IdUnidad = item.Unidad.Any() ? UnidadesRepository.ObtenerIdUnidad(item.Unidad) : 0;

            if (!item.Proveedor.Any()) proceso = false;
            producto.IdProveedor = item.Proveedor.Any() ? ProveedoresRepository.ObtenerIdProveedor(item.Proveedor) : 0;

            producto.Costo = item.Costo >= 0 ? item.Costo : 0;
            producto.PrecioL1 = item.PrecioL1 >= 0 ? item.PrecioL1 : 0;
            producto.PrecioL2 = item.PrecioL2 >= 0 ? item.PrecioL2 : 0;
            producto.PrecioL3 = item.PrecioL3 >= 0 ? item.PrecioL3 : 0;
            producto.Stock = item.Stock >= 0 ? item.Stock : 0;
            producto.StockMinimo = item.StockMinimo >= 0 ? item.StockMinimo : 0;
            producto.IVAVenta = item.IvaVentas >= 0 ? item.IvaVentas : 0;
            producto.Observaciones = item.Observaciones.Any() ? item.Observaciones : "";
            if (!proceso) return proceso;
            if (item.Id == 0)
            {
                GuardarProducto(producto);
            }
            if (ExisteIdProducto(item.Id))
            {
                producto.Id = item.Id;
                EditarProducto(producto);
            }
            else
            {
                proceso = false;
            }
            return proceso;
        }

        private static bool ExisteIdProducto(int id)
        {
            using (var db = new VentasEntities())
            {
                var producto = db.Productos.Where(p => p.Id == id) ;
                return producto.Any();
            }
        }

        public static Productos ObtenerProducto(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Productos.FirstOrDefault(p => p.Id == id);
            }
        }

        public static void EditarProducto(Productos producto)
        {
            using (var db = new VentasEntities())
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void EliminarProducto(int id)
        {
            using (var db = new VentasEntities())
            {
                var producto = db.Productos.FirstOrDefault(p => p.Id == id);
                db.Productos.Remove(producto);
                db.SaveChanges();
            }
        }

        public static List<SelectListItem> CargarSelectListProductos()
        {
            using (var db = new VentasEntities())
            {
                var p =
                    (from t in db.Productos
                     select new SelectListItem
                     {
                         Text = t.Descripcion,
                         Value = t.Id.ToString()
                     });
                return p.ToList();
            }
        }

        public static decimal ObtenerPrecioPorId(int id, int lista)
        {
            using (var db = new VentasEntities())
            {
                decimal precio = 0;
                switch (lista)
                {
                    case 1:
                        precio = Convert.ToDecimal(db.Productos.FirstOrDefault(producto => producto.Id == id).PrecioL1);
                        break;
                    case 2:
                        precio = Convert.ToDecimal(db.Productos.FirstOrDefault(producto => producto.Id == id).PrecioL2);
                        break;
                    case 3:
                        precio = Convert.ToDecimal(db.Productos.FirstOrDefault(producto => producto.Id == id).PrecioL3);
                        break;
                }
                return precio;
            }
        }

        internal static IEnumerable<ImportarProductoViewModel> ImportarProductosExcel(IEnumerable<ImportarProductoViewModel> list)
        {
            foreach (var item in list)
            {
                bool _grabarProducto = true;
                if (CódigoBarraExistente(item.CodBarra))
                {
                    item.Observaciones = "Código de Barra existente";
                    _grabarProducto = false;
                }
                if (DescripciónExistente(item.Descripcion))
                {
                    item.Observaciones = "Descripción existente";
                    _grabarProducto = false;
                }
                if (_grabarProducto)
                {
                    Productos p = new Productos();
                    p.IdMarca = MarcasRepository.ObtenerIdMarca(item.Marca);
                    p.IdRubro = RubrosRepository.ObtenerIdRubro(item.Rubro);
                    p.IdProveedor = ProveedoresRepository.ObtenerIdProveedor(item.Proveedor);
                    p.IdUnidad = UnidadesRepository.ObtenerIdUnidad(item.Unidad);
                    p.CodBarra = item.CodBarra;
                    p.Descripcion = item.Descripcion;
                    p.Costo = item.Costo;
                    p.PrecioL1 = item.PrecioL1;
                    p.PrecioL2 = item.PrecioL2;
                    p.PrecioL3 = item.PrecioL3;
                    p.Stock = item.Stock;
                    p.StockMinimo = item.StockMinimo;
                    p.Observaciones = item.Observaciones;

                    GuardarProducto(p);
                }
            }

            return list;
        }

        private static bool DescripciónExistente(string descripcion)
        {
            using (var db = new VentasEntities())
            {
                return db.Productos.Any(p => p.Descripcion == descripcion) ? true : false;
            }
        }

        private static bool CódigoBarraExistente(string codBarra)
        {
            using (var db = new VentasEntities())
            {
                return db.Productos.Any(p => p.CodBarra == codBarra) ? true : false;
            }
        }
    }
}