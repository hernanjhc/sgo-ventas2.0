using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            Clientes = new HashSet<Cliente>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
