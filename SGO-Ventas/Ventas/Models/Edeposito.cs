using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Edeposito
    {
        public int Id { get; set; }
        public int? IdEmpresa { get; set; }
        public string Deposito { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdLocalidad { get; set; }
        public int? IdBarrio { get; set; }
        public string Direccion { get; set; }
        public int? IdEncargado { get; set; }
    }
}
