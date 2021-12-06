using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Eventa
    {
        public Eventa()
        {
            Eremitos = new HashSet<Eremito>();
            EventasDetalles = new HashSet<EventasDetalle>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
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
        public virtual ICollection<Eremito> Eremitos { get; set; }
        public virtual ICollection<EventasDetalle> EventasDetalles { get; set; }
    }
}
