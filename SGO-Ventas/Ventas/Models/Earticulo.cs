using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Earticulo
    {
        public Earticulo()
        {
            EcomprasDetalles = new HashSet<EcomprasDetalle>();
            EpresupuestosDetalles = new HashSet<EpresupuestosDetalle>();
            EremitosDetalles = new HashSet<EremitosDetalle>();
            EventasDetalles = new HashSet<EventasDetalle>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string CodBarra { get; set; }
        public string Descripcion { get; set; }
        public int? IdMarca { get; set; }
        public int? IdRubro { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdUnidad { get; set; }
        public decimal? CostoInicial { get; set; }
        public decimal? Descuento1 { get; set; }
        public decimal? DescuentoPorc1 { get; set; }
        public decimal? Descuento2 { get; set; }
        public decimal? DescuentoPorc2 { get; set; }
        public decimal? Descuento3 { get; set; }
        public decimal? DescuentoPorc3 { get; set; }
        public decimal Costo { get; set; }
        public decimal? Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal? PrecioL1 { get; set; }
        public decimal? PrecioPorcL1 { get; set; }
        public decimal? PrecioL2 { get; set; }
        public decimal? PrecioPorcL2 { get; set; }
        public decimal? PrecioL3 { get; set; }
        public decimal? PrecioPorcL3 { get; set; }
        public decimal? Iva { get; set; }
        public string Observaciones { get; set; }
        public int? Estado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Emarca IdMarcaNavigation { get; set; }
        public virtual Proveedore IdProveedorNavigation { get; set; }
        public virtual Erubro IdRubroNavigation { get; set; }
        public virtual Unidade IdUnidadNavigation { get; set; }
        public virtual ICollection<EcomprasDetalle> EcomprasDetalles { get; set; }
        public virtual ICollection<EpresupuestosDetalle> EpresupuestosDetalles { get; set; }
        public virtual ICollection<EremitosDetalle> EremitosDetalles { get; set; }
        public virtual ICollection<EventasDetalle> EventasDetalles { get; set; }
    }
}
