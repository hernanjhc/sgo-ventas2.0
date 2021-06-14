using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class CompraViewModel
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public int TipoPagoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int UsuarioId { get; set; }
        public IEnumerable<CompraDetalleViewModel> ListaDeCompraDetalleViewModel { get; set; }
    }
}