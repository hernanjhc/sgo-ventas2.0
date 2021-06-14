using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SGO_Ventas.Models;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Reports.DataSet;
using SGO_Ventas.Repositories;

namespace SGO_Ventas.Repositories
{
    public class VentasXRepository
    {
        public static List<VentasX> ObtenerVentasXPaginado(int pagina, int cantidadRegistrosPagina)
        {
            using (var db = new VentasEntities())
            {
                return db.VentasX.OrderByDescending(v => v.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static int TotalRegistros()
        {
            using (var db = new VentasEntities())
            {
                return db.VentasX.Count();
            }
        }

        public static IEnumerable<VentasX> ObtenerVentasX()
        {
            using (var db = new VentasEntities())
            {
                return db.VentasX.ToList();
            }
        }

        public static void GuardarVenta(VentaViewModel nuevaVenta)
        {
            using (var db = new VentasEntities())
            {
                VentasX venta = new VentasX();
                var idVenta = db.VentasX.Any() ? db.VentasX.Max(v => v.Id) + 1 : 1;
                venta.Id = idVenta;
                venta.IdCliente = nuevaVenta.ClienteId;
                venta.IdTipoPago = nuevaVenta.TipoPagoId;
                venta.Fecha = DateTime.Now;
                venta.Total = nuevaVenta.Total;
                venta.IdUsuario = 1;
                db.VentasX.Add(venta);
                db.SaveChanges();

                decimal controlTotal = 0;
                foreach (var item in nuevaVenta.ListaDeVentaDetalleViewModel)
                {
                    VentasXDetalles ventaDetalle = new VentasXDetalles();
                    var idVentaDetalle = db.VentasXDetalles.Any() ? db.VentasXDetalles.Max(vd => vd.Id) + 1 : 1;
                    ventaDetalle.Id = idVentaDetalle;
                    ventaDetalle.IdVenta = idVenta;
                    ventaDetalle.IdProducto = item.ProductoId;
                    ventaDetalle.Precio = item.Precio;
                    ventaDetalle.Cantidad = item.Cantidad;
                    ventaDetalle.Descuento = item.Descuento;
                    ventaDetalle.Importe = item.Importe;
                    controlTotal += item.Importe;
                    db.VentasXDetalles.Add(ventaDetalle);
                    db.SaveChanges();

                    //registra movimiento de stock
                    Movimientos movimientos = new Movimientos();
                    movimientos.Id = db.Movimientos.Any() ? db.Movimientos.Max(vd => vd.Id) + 1 : 1;
                    movimientos.IdProducto = item.ProductoId;
                    movimientos.Cantidad = item.Cantidad;
                    movimientos.Fecha = DateTime.Now;
                    movimientos.IdVenta = idVenta;
                    movimientos.IdCliente = nuevaVenta.ClienteId;
                    movimientos.DescuentaStock = 1; //es venta si descuenta stock
                    db.Movimientos.Add(movimientos);
                    db.SaveChanges();

                    //Actualiza stock
                    var producto = db.Productos.Find(item.ProductoId);
                    producto.Stock = producto.Stock - item.Cantidad;
                    db.SaveChanges();
                }

                //No llega el decimal desde la vista al controlador, por eso este cálculo.
                var ve = db.VentasX.Find(idVenta);
                ve.Total = controlTotal;
                db.SaveChanges();

                //registra movimientos de caja
                MovimientosCaja caja = new MovimientosCaja();
                caja.Id = db.MovimientosCaja.Any() ? db.MovimientosCaja.Max(c => c.Id) + 1 : 1;
                caja.Fecha = DateTime.Now;
                caja.IdVenta = idVenta;
                caja.IdCliente = nuevaVenta.ClienteId;
                caja.Ingreso = controlTotal;
                caja.Descripcion = "Venta registrada en el Sistema";
                db.MovimientosCaja.Add(caja);
                db.SaveChanges();
            }
        }

        public static VentasX ObtenerVenta(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.VentasX.FirstOrDefault(v => v.Id == id);
            }
        }

        public static IEnumerable<VentasXDetalles> ObtenerItemsVenta(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.VentasXDetalles.Where(v => v.IdVenta == id).ToList();
            }
        }
        public DataTable ObtenerDatos(int idVenta)
        {
            VentasX venta = ObtenerVenta(idVenta);
            IEnumerable<VentasXDetalles> items = ObtenerItemsVenta(idVenta);

            Empresa empresa = EmpresaRepository.ObtenerEmpresas().FirstOrDefault();
            Clientes cliente = ClientesRepository.ObtenerCliente(Convert.ToInt32(venta.IdCliente));
            string documento = String.Format("{0} - {1}", TiposDocumentoRepository.ObtenerTipoDocumento(Convert.ToInt32(cliente.IdTipoDocumento)).Descripcion, 
                cliente.NroDocumento.ToString());

            string maxVenta = idVenta.ToString();
            string fecha = venta.Fecha.ToString();

            var listado = new DsImpresiones.VentaDataTable();
            foreach (var item in items)
            {
                var producto = ProductosRepository.ObtenerProducto(item.IdProducto);
                string unidad = UnidadesRepository.ObtenerUnidad(Convert.ToInt32(producto.IdUnidad)).Descripcion;
                listado.AddVentaRow(
                    empresa.RazonSocial, empresa.Documento, empresa.Domicilio, empresa.Email, empresa.Telefono,
                    cliente.RazonSocial, documento, cliente.Direccion,
                    maxVenta, fecha,
                    producto.Descripcion, item.Cantidad.ToString(), unidad, item.Precio.ToString(), item.Descuento.ToString(), item.Importe.ToString(), venta.Total.ToString()
                    );
            }
            return listado;
        }
        public DataTable ObtenerDatos(VentaViewModel venta)
        {
            Empresa empresa = EmpresaRepository.ObtenerEmpresas().FirstOrDefault();
            Clientes cliente = ClientesRepository.ObtenerCliente(venta.ClienteId);
            string documento = TiposDocumentoRepository.ObtenerTipoDocumento(Convert.ToInt32(cliente.IdTipoDocumento)).Descripcion
                + " - " + cliente.NroDocumento;
            string maxVenta = MaxVenta().ToString();
            string fecha = DateTime.Now.ToString();
            var listado = new DsImpresiones.VentaDataTable();
            foreach (var item in venta.ListaDeVentaDetalleViewModel)
            {
                var producto = ProductosRepository.ObtenerProducto(item.ProductoId);
                string unidad = UnidadesRepository.ObtenerUnidad(Convert.ToInt32(producto.IdUnidad)).Descripcion;
                listado.AddVentaRow(
                    empresa.RazonSocial, empresa.Documento, empresa.Domicilio, empresa.Email, empresa.Telefono,
                    cliente.RazonSocial, documento, cliente.Direccion,
                    maxVenta, fecha, 
                    producto.Descripcion, item.Cantidad.ToString(), unidad, item.Precio.ToString(), item.Descuento.ToString(), item.Importe.ToString(), venta.Total.ToString()
                    );
            }
            return listado;
        }

        public int MaxVenta()
        {
            using (var db = new VentasEntities())
            {
                return db.VentasX.Max(v => v.Id);
            }
        }
    }
}