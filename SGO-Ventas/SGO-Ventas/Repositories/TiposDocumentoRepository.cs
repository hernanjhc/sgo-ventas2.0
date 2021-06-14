using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public static class TiposDocumentoRepository
    {
        public static List<TiposDocumento> ObtenerTiposDocumentoPaginado(int pagina, int cantidadRegistrosPagina)
        {
            using (var db = new VentasEntities())
            {
                return db.TiposDocumento.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static int TotalRegistros()
        {
            using (var db = new VentasEntities())
            {
                return db.TiposDocumento.Count();
            }
        }

        public static IEnumerable<TiposDocumento> ObtenerTiposDocumento()
        {
            using (var db = new VentasEntities())
            {
                return db.TiposDocumento.ToList();
            }
        }

        public static TiposDocumento ObtenerTipoDocumento(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.TiposDocumento.FirstOrDefault(td => td.Id == id);
            }
        }

        public static void EliminarTipoDocumento(int id)
        {
            using (var db = new VentasEntities())
            {
                var td = db.TiposDocumento.FirstOrDefault(t => t.Id == id);
                db.TiposDocumento.Remove(td);
                db.SaveChanges();
            }
        }

        public static void InsertarTipoDocumento(TiposDocumento tipoDocumento)
        {
            using (var db = new VentasEntities())
            {
                tipoDocumento.Id = db.TiposDocumento.Any() ? db.TiposDocumento.Max(t => t.Id) + 1 : 1;
                db.TiposDocumento.Add(tipoDocumento);
                db.SaveChanges();
            }
        }

        //public static void ObtenerTipoDocumento(TiposDocumento td)
        //{
        //    using (var db = new VentasEntities())
        //    {
        //        td.Id = db.TiposDocumento.Any() ? db.TiposDocumento.Max(t => t.Id) : 1;
        //        db.TiposDocumento.Add(td);
        //        db.SaveChanges();
        //    }
        //}

        public static void EditarTipoDocumento(TiposDocumento td)
        {
            using (var db = new VentasEntities())
            {
                var t = db.TiposDocumento.FirstOrDefault(tipoDoc => tipoDoc.Id == td.Id);
                t.Descripcion = td.Descripcion;
                db.SaveChanges();

            }
        }

        public static List<SelectListItem> CargarSelectListTiposDocumento()
        {
            using (var db = new VentasEntities())
            {
                var tdoc =
                    (from t in db.TiposDocumento
                     select new SelectListItem
                     {
                         Text = t.Descripcion,
                         Value = t.Id.ToString()
                     });
                return tdoc.ToList();
            }
        }
    }
}