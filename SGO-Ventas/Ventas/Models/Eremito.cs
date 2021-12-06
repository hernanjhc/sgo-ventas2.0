using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Eremito
    {
        public Eremito()
        {
            EremitosDetalles = new HashSet<EremitosDetalle>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdVenta { get; set; }
        public string EntregaNombre { get; set; }
        public string RecibeNombre { get; set; }
        public int? RecibeTipoDocumento { get; set; }
        public decimal? RecibeNroDocumento { get; set; }
        public int? IdUsuario { get; set; }
        public int? Estado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Eventa IdVentaNavigation { get; set; }
        public virtual ICollection<EremitosDetalle> EremitosDetalles { get; set; }
    }
}
