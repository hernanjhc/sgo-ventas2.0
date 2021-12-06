using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class BancoSucursal
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public int SucursalNro { get; set; }
        public string Sucursal { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdLocalidad { get; set; }
        public int? IdBarrio { get; set; }
        public string Direccion { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
