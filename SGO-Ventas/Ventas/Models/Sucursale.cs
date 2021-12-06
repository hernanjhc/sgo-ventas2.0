using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Models
{
    public partial class Sucursale
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdBanco { get; set; }
        public string Sucursal { get; set; }
        public int? Numero { get; set; }
        public int? IdDomicilio { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public byte Estado { get; set; }

        public virtual Banco IdBancoNavigation { get; set; }
    }
}
