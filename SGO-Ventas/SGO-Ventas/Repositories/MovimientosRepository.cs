using SGO_Ventas.Models;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Reports.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Repositories
{
    public class MovimientosRepository
    {
        public DataTable ObtenerListado(bool esVenta, DateTime fecha)
        {
            Empresa empresa = EmpresaRepository.ObtenerEmpresas().FirstOrDefault();
            var listado = new DsImpresiones.MovimientosStockDataTable();
            var movimientos = MovimientosStockPorDia(esVenta, fecha);
            string operacion = String.Format("Productos {0}", esVenta ? "Vendidos" : "Comprados" );
            foreach (var item in movimientos)
            {
                string producto = ProductosRepository.ObtenerProducto(item.IdProducto).Descripcion;
                listado.AddMovimientosStockRow(
                    empresa.RazonSocial, empresa.Documento, empresa.Domicilio, empresa.Email, empresa.Telefono,
                    fecha.ToString(), operacion, producto, item.Operaciones.ToString(), item.TotalOperaciones.ToString(),
                    item.MovimientoStock.ToString(), item.TotalMovimientoStock.ToString());
            }
            return listado;
        }

        public static IEnumerable<MovimientoStockViewModel> MovimientosStockPorDia(bool esVenta, DateTime fecha)
        {
            using (var db = new VentasEntities()) 
            {
                DateTime desde = fecha.Date;
                DateTime hasta = fecha.AddDays(1).Date;
                IEnumerable<Movimientos> movimientos = null;
                if (esVenta)
                {
                    movimientos = db.Movimientos.Where(m => m.Fecha >= desde && m.Fecha < hasta && m.IdVenta > 0).ToList();
                }
                else
                {
                    movimientos = db.Movimientos.Where(m => m.Fecha >= desde && m.Fecha < hasta && m.IdVenta > 0).ToList();
                }

                var result = from row in movimientos
                             group row by row.IdProducto into g
                             select new MovimientoStockViewModel
                             {
                                 IdProducto = g.Key,
                                 Operaciones = g.Count(),
                                 MovimientoStock = g.Sum(s => s.Cantidad)
                             };
                foreach (var item in result)
                {
                    item.TotalOperaciones += item.Operaciones;
                    item.TotalMovimientoStock += item.MovimientoStock;
                }
                return result;
            }
        }

    }
}