using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class TiposPago
    {
        public TiposPago()
        {
            Compras = new HashSet<Compra>();
            VentasXes = new HashSet<VentasX>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<VentasX> VentasXes { get; set; }
    }
}
