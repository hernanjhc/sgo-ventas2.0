using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int Id { get; set; }
        public int IdBarrio { get; set; }
        public int IdLocalidad { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }

        public virtual Barrio IdBarrioNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Localidade IdLocalidadNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
