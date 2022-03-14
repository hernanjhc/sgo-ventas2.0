using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Documento { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
