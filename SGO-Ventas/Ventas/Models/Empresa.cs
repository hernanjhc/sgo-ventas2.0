using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Earticulos = new HashSet<Earticulo>();
            Ecompras = new HashSet<Ecompra>();
            EcomprasDetalles = new HashSet<EcomprasDetalle>();
            Emarcas = new HashSet<Emarca>();
            Epresupuestos = new HashSet<Epresupuesto>();
            EpresupuestosDetalles = new HashSet<EpresupuestosDetalle>();
            Eremitos = new HashSet<Eremito>();
            EremitosDetalles = new HashSet<EremitosDetalle>();
            Erubros = new HashSet<Erubro>();
            Eventa = new HashSet<Eventa>();
            EventasDetalles = new HashSet<EventasDetalle>();
        }

        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoDoc { get; set; }
        public decimal NroDoc { get; set; }
        public int? IdDomicilio { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Presupuesto { get; set; }
        public int Venta { get; set; }
        public int Remito { get; set; }
        public int NotaDebito { get; set; }
        public int NotaCredito { get; set; }
        public int Compra { get; set; }

        public virtual Domicilio IdDomicilioNavigation { get; set; }
        public virtual TiposDocumento IdTipoDocNavigation { get; set; }
        public virtual ICollection<Earticulo> Earticulos { get; set; }
        public virtual ICollection<Ecompra> Ecompras { get; set; }
        public virtual ICollection<EcomprasDetalle> EcomprasDetalles { get; set; }
        public virtual ICollection<Emarca> Emarcas { get; set; }
        public virtual ICollection<Epresupuesto> Epresupuestos { get; set; }
        public virtual ICollection<EpresupuestosDetalle> EpresupuestosDetalles { get; set; }
        public virtual ICollection<Eremito> Eremitos { get; set; }
        public virtual ICollection<EremitosDetalle> EremitosDetalles { get; set; }
        public virtual ICollection<Erubro> Erubros { get; set; }
        public virtual ICollection<Eventa> Eventa { get; set; }
        public virtual ICollection<EventasDetalle> EventasDetalles { get; set; }
    }
}
