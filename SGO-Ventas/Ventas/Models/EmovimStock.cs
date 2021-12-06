using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class EmovimStock
    {
        public int Id { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdProveedorOrigen { get; set; }
        public int? IdClienteOrigen { get; set; }
        public int? IdDepositoOrigen { get; set; }
        public int? IdProveedorDestino { get; set; }
        public int? IdClienteDestino { get; set; }
        public int? IdDepositoDestino { get; set; }
        public decimal? Ingreo { get; set; }
        public decimal? Egreso { get; set; }
        public decimal? Stock { get; set; }
        public int? Usuario { get; set; }
    }
}
