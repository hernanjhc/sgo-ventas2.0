using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexTiposDocumento : Paginador
    {
        public List<TiposDocumento> TiposDocumento { get; set; }
    }

}