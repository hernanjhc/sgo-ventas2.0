using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexCompras : Paginador
    {
        public List<Compras> Compras { get; set; }
    }
}