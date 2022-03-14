using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Producto
    {
        public Producto()
        {
            VentasXdetalles = new HashSet<VentasXdetalle>();
        }

        public int Id { get; set; }
        public string CodBarra { get; set; }
        public string Descripcion { get; set; }
        public int? IdMarca { get; set; }
        public int? IdRubro { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdUnidad { get; set; }
        public decimal? Costo { get; set; }
        public decimal? PrecioL1 { get; set; }
        public decimal? PrecioL2 { get; set; }
        public decimal? PrecioL3 { get; set; }
        public decimal? Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal? Ivaventa { get; set; }
        public string Observaciones { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual Proveedore IdProveedorNavigation { get; set; }
        public virtual Rubro IdRubroNavigation { get; set; }
        public virtual Unidade IdUnidadNavigation { get; set; }
        public virtual ICollection<VentasXdetalle> VentasXdetalles { get; set; }
    }
}
