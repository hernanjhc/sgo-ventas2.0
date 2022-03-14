using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class VentasX
    {
        public VentasX()
        {
            VentasXdetalles = new HashSet<VentasXdetalle>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoPago { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual TiposPago IdTipoPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<VentasXdetalle> VentasXdetalles { get; set; }
    }
}
