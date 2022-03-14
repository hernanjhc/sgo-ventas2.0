using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compras = new HashSet<Compra>();
            VentasXes = new HashSet<VentasX>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string NombreCompleto { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<VentasX> VentasXes { get; set; }
    }
}
