using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class UsuariosItemsMenu
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdItemMenu { get; set; }

        public virtual ItemsMenu IdItemMenuNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
