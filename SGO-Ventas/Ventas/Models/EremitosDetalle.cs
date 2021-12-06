using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class EremitosDetalle
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdRemito { get; set; }
        public int? IdArticulo { get; set; }
        public int? Cantidad { get; set; }

        public virtual Earticulo IdArticuloNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Eremito IdRemitoNavigation { get; set; }
    }
}
