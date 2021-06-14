using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexProveedores : Paginador
    {
        public List<Proveedores> Proveedores { get; set; }
    }
}