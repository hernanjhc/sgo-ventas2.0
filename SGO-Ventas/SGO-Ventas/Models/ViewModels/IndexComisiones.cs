using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexComisiones : Paginador
    {
        public List<Comisiones> Comisiones { get; set; }
    }
}