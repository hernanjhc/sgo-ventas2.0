using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Ecuenta
    {
        public int Id { get; set; }
        public int? IdEmpresa { get; set; }
        public int? Tipo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdReferencia { get; set; }
        public decimal? SaldoInicial { get; set; }
        public int? Estado { get; set; }
    }
}
