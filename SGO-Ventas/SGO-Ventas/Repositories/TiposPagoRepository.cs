using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class TiposPagoRepository
    {
        public static List<SelectListItem> CargarSelectListTiposPago()
        {
            using (var db = new VentasEntities())
            {
                var p =
                    (from t in db.TiposPago
                     select new SelectListItem
                     {
                         Text = t.Descripcion,
                         Value = t.Id.ToString()
                     });
                return p.ToList();
            }
        }

        public static IEnumerable<TiposPago> ObtenerTiposPago()
        {
            using (var db = new VentasEntities())
            {
                return db.TiposPago.ToList();
            }
        }
    }
}