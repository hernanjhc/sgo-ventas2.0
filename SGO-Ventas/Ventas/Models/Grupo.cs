using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            GruposItemsMenus = new HashSet<GruposItemsMenu>();
            GruposUsuarios = new HashSet<GruposUsuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte Estado { get; set; }

        public virtual ICollection<GruposItemsMenu> GruposItemsMenus { get; set; }
        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; }
    }
}
