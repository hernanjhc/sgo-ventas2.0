using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class MovimientosCaja
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdVenta { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCompra { get; set; }
        public int? IdProveedor { get; set; }
        public decimal? Ingreso { get; set; }
        public decimal? Egreso { get; set; }
        public string Descripcion { get; set; }
        public int? Contrasiento { get; set; }
    }
}
