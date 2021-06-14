using SGO_Ventas.Models;
using SGO_Ventas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Repositories
{
    public class ComprasRepository
    {
        public static List<Compras> ObtenerComprasPaginado(int pagina, int cantidadRegistrosPagina)
        {
            using (var db = new VentasEntities())
            {
                return db.Compras.OrderBy(v => v.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static int TotalRegistros()
        {
            using (var db = new VentasEntities())
            {
                return db.Compras.Count();
            }
        }

        public static IEnumerable<Compras> ObtenerCompras()
        {
            using (var db = new VentasEntities())
            {
                return db.Compras.ToList();
            }
        }

        public static void GuardarCompra(CompraViewModel nuevaCompra)
        {
            using (var db = new VentasEntities())
            {
                Compras compra = new Compras();
                var idCompra = db.Compras.Any() ? db.Compras.Max(v => v.Id) + 1 : 1;
                compra.Id = idCompra;
                compra.IdProveedor = nuevaCompra.ProveedorId;
                compra.IdTipoPago = nuevaCompra.TipoPagoId;
                compra.Fecha = DateTime.Now;
                compra.Total = nuevaCompra.Total;
                compra.IdUsuario = 1;
                db.Compras.Add(compra);
                db.SaveChanges();

                decimal controlTotal = 0;
                foreach (var item in nuevaCompra.ListaDeCompraDetalleViewModel)
                {
                    ComprasDetalle compraDetalle = new ComprasDetalle();
                    var idCompraDetalle = db.ComprasDetalle.Any() ? db.ComprasDetalle.Max(cd => cd.Id) + 1 : 1;
                    compraDetalle.Id = idCompraDetalle;
                    compraDetalle.IdCompra = idCompra;
                    compraDetalle.IdProducto = item.ProductoId;
                    compraDetalle.Precio = item.Precio;
                    compraDetalle.Cantidad = item.Cantidad;
                    compraDetalle.Descuento = item.Descuento;
                    compraDetalle.Importe = item.Importe;
                    controlTotal += item.Importe;
                    db.ComprasDetalle.Add(compraDetalle);
                    db.SaveChanges();

                    //registra movimiento de stock
                    Movimientos movimientos = new Movimientos();
                    movimientos.Id = db.Movimientos.Any() ? db.Movimientos.Max(vd => vd.Id) + 1 : 1;
                    movimientos.IdProducto = item.ProductoId;
                    movimientos.Cantidad = item.Cantidad;
                    movimientos.Fecha = DateTime.Now;
                    movimientos.IdCompra = idCompra;
                    movimientos.IdProveedor = nuevaCompra.ProveedorId;
                    movimientos.DescuentaStock = 0; //0 incrementa  1 - descuenta stock
                    db.Movimientos.Add(movimientos);
                    db.SaveChanges();

                    //Actualiza stock
                    var producto = db.Productos.Find(item.ProductoId);
                    producto.Stock = producto.Stock + item.Cantidad;
                    db.SaveChanges();
                }

                //No llega el decimal desde la vista al controlador, por eso este cálculo.
                var ve = db.Compras.Find(idCompra);
                ve.Total = controlTotal;
                db.SaveChanges();

                //registra movimientos de caja
                MovimientosCaja caja = new MovimientosCaja();
                caja.Id = db.MovimientosCaja.Any() ? db.MovimientosCaja.Max(c => c.Id) + 1 : 1;
                caja.Fecha = DateTime.Now;
                caja.IdCompra = idCompra;
                caja.idProveedor = nuevaCompra.ProveedorId;
                caja.Egreso = controlTotal;
                caja.Descripcion = "Compra registrada en el Sistema";
                db.MovimientosCaja.Add(caja);
                db.SaveChanges();
            }
        }
    }
}