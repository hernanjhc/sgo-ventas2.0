using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexUsuarios : Paginador
    {
        public List<Usuarios> Usuarios { get; set; }
    }
}