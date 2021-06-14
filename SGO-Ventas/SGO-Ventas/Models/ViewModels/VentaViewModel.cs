using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class VentaViewModel
    {
        public int VentaId { get; set; }
        public int TipoPagoId { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<VentaDetalleViewModel> ListaDeVentaDetalleViewModel { get; set; }
    }
}