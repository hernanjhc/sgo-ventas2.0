using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class ImportarProductoViewModel
    {
        public string CodBarra { get; set; }

        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Rubro { get; set; }
        public string Proveedor { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioL1 { get; set; }
        public decimal PrecioL2 { get; set; }
        public decimal PrecioL3 { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal IvaVentas { get; set; }
        public string Observaciones { get; set; }
    }
}