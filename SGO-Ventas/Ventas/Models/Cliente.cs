using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Epresupuestos = new HashSet<Epresupuesto>();
            Eremitos = new HashSet<Eremito>();
            Eventa = new HashSet<Eventa>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoDocumento { get; set; }
        public decimal NroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdDomicilio { get; set; }
        public byte Estado { get; set; }

        public virtual Domicilio IdDomicilioNavigation { get; set; }
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Epresupuesto> Epresupuestos { get; set; }
        public virtual ICollection<Eremito> Eremitos { get; set; }
        public virtual ICollection<Eventa> Eventa { get; set; }
    }
}
