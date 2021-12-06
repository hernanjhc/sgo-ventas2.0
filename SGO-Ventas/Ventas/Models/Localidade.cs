using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Localidade
    {
        public Localidade()
        {
            Barrios = new HashSet<Barrio>();
            Domicilios = new HashSet<Domicilio>();
        }

        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Barrio> Barrios { get; set; }
        public virtual ICollection<Domicilio> Domicilios { get; set; }
    }
}
