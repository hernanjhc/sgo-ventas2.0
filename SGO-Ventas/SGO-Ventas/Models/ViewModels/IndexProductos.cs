using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexProductos : Paginador
    {
        public List<Productos> Productos { get; set; }
    }
}