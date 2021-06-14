using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class MovimientoStockViewModel
    {
        public int IdProducto { get; set; }
        public int Operaciones { get; set; }
        public int TotalOperaciones { get; set; }

        public decimal MovimientoStock { get; set; }
        public decimal TotalMovimientoStock { get; set; }

        public IEnumerable<MovimientoStockViewModel> ListaDeMOvimientoStock { get; set; }
    }
}