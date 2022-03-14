using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }
        public int? IdVenta { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCompra { get; set; }
        public int? IdProveedor { get; set; }
        public decimal Cantidad { get; set; }
        public int DescuentaStock { get; set; }
    }
}
