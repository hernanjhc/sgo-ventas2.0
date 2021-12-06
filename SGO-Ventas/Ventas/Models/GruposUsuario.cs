﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class GruposUsuario
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
