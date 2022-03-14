using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Compras = new HashSet<Compra>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoDocumento { get; set; }
        public decimal NroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Observaciones { get; set; }

        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
