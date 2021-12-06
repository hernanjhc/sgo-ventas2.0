using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ecompras = new HashSet<Ecompra>();
            Epresupuestos = new HashSet<Epresupuesto>();
            Eremitos = new HashSet<Eremito>();
            Eventa = new HashSet<Eventa>();
            GruposUsuarios = new HashSet<GruposUsuario>();
            UsuariosItemsMenus = new HashSet<UsuariosItemsMenu>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string NombreCompleto { get; set; }

        public virtual ICollection<Ecompra> Ecompras { get; set; }
        public virtual ICollection<Epresupuesto> Epresupuestos { get; set; }
        public virtual ICollection<Eremito> Eremitos { get; set; }
        public virtual ICollection<Eventa> Eventa { get; set; }
        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; }
        public virtual ICollection<UsuariosItemsMenu> UsuariosItemsMenus { get; set; }
    }
}
