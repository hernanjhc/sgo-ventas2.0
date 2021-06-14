using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexMarcas : Paginador
    {
        public List<Marcas> Marcas { get; set; }
    }
}