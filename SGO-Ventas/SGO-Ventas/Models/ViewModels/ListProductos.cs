using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class ListProductos
    {
        public string Código { get; set; }
        public string Descripción { get; set; }
        public string Marca { get; set; }
        public string Rubro { get; set; }
        public string Proveedor { get; set; }
        public string Unidad { get; set; }
        public decimal? Stock { get; set; }
        public decimal? StockMínimo { get; set; }
    }
}