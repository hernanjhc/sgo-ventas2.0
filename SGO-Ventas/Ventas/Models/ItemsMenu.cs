using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class ItemsMenu
    {
        public ItemsMenu()
        {
            GruposItemsMenus = new HashSet<GruposItemsMenu>();
            UsuariosItemsMenus = new HashSet<UsuariosItemsMenu>();
        }

        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<GruposItemsMenu> GruposItemsMenus { get; set; }
        public virtual ICollection<UsuariosItemsMenu> UsuariosItemsMenus { get; set; }
    }
}
