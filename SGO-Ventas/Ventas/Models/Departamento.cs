using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Domicilios = new HashSet<Domicilio>();
            Localidades = new HashSet<Localidade>();
        }

        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Domicilio> Domicilios { get; set; }
        public virtual ICollection<Localidade> Localidades { get; set; }
    }
}
