using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class ComprasDetalle
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
    }
}
