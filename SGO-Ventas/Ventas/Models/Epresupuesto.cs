using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Epresupuesto
    {
        public Epresupuesto()
        {
            EpresupuestosDetalles = new HashSet<EpresupuestosDetalle>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public int? DiasValidez { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? DescuentoPorc { get; set; }
        public decimal? ImporteTotal { get; set; }
        public int? PrecioLista { get; set; }
        public int? IdUsuario { get; set; }
        public int? Estado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<EpresupuestosDetalle> EpresupuestosDetalles { get; set; }
    }
}
