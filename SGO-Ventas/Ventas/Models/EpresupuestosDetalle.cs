using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class EpresupuestosDetalle
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdPresupuesto { get; set; }
        public int? IdArticulo { get; set; }
        public decimal? Importe { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }

        public virtual Earticulo IdArticuloNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Epresupuesto IdPresupuestoNavigation { get; set; }
    }
}
