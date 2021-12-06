using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Ecompra
    {
        public Ecompra()
        {
            EcomprasDetalles = new HashSet<EcomprasDetalle>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdProveedor { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Importe { get; set; }
        public int? Retirado { get; set; }
        public int? Pagado { get; set; }
        public int IdUsuario { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Proveedore IdProveedorNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<EcomprasDetalle> EcomprasDetalles { get; set; }
    }
}
