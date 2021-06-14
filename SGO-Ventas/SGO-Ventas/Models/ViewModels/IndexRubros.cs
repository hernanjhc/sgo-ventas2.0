using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexRubros : Paginador
    {
        public List<Rubros> Rubros { get; set; }
    }
}