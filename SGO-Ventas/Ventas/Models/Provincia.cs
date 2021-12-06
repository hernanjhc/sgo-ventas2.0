using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Departamentos = new HashSet<Departamento>();
            Domicilios = new HashSet<Domicilio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<Domicilio> Domicilios { get; set; }
    }
}
