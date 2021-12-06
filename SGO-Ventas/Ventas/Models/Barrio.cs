using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Domicilios = new HashSet<Domicilio>();
        }

        public int Id { get; set; }
        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }

        public virtual Localidade IdLocalidadNavigation { get; set; }
        public virtual ICollection<Domicilio> Domicilios { get; set; }
    }
}
