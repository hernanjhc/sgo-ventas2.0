using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Models.ViewModels
{
    public class IndexClientes : Paginador
    {
        public List<Clientes> Clientes { get; set; }
    }
}