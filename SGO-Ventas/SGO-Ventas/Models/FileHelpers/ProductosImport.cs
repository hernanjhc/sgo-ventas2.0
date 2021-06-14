using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace SGO_Ventas.Models.FileHelpers
{
    [DelimitedRecord("\t")]
    public class ProductosImport
    {
        public int Id;

        public string CodBarra;

        public string Descripcion;

        public string Marca;

        public string Rubro;

        public string Proveedor;

        public string Unidad;

        public decimal Costo;

        public decimal PrecioL1;

        public decimal PrecioL2;

        public decimal PrecioL3;

        public decimal Stock;

        public decimal StockMinimo;

        public decimal IvaVentas;

        public string Observaciones;

    }
}