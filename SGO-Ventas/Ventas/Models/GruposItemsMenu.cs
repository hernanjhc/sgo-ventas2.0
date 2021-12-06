using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class GruposItemsMenu
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdItemMenu { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual ItemsMenu IdItemMenuNavigation { get; set; }
    }
}
