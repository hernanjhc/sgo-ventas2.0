using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Banco
    {
        public Banco()
        {
            Sucursales = new HashSet<Sucursale>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Sucursale> Sucursales { get; set; }
    }
}
