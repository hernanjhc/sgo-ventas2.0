using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Compra
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }

        public virtual Proveedore IdProveedorNavigation { get; set; }
        public virtual TiposPago IdTipoPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
