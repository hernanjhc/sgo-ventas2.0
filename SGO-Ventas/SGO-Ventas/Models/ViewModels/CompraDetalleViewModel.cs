using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class CompraDetalleViewModel
    {
        public int CompraDetalleId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
    }
}