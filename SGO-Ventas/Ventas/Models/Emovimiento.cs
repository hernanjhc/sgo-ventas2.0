using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Emovimiento
    {
        public int Id { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdVenta { get; set; }
        public int? IdCompra { get; set; }
        public int? IdNotaCredito { get; set; }
        public int? IdNotaDebito { get; set; }
        public int? IdCheque { get; set; }
        public int? IdCuenta { get; set; }
        public string Detalle { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Debito { get; set; }
        public decimal? Saldo { get; set; }
        public string Contrasiento { get; set; }
    }
}
