using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Emarca
    {
        public Emarca()
        {
            Earticulos = new HashSet<Earticulo>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Marca { get; set; }
        public string Observaciones { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Earticulo> Earticulos { get; set; }
    }
}
