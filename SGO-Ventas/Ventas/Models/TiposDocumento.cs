﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
