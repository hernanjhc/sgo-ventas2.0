using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class RubrosRepository
    {
        public static List<Rubros> ObtenerRubrosPaginado(int pagina, int cantidadRegistrosPagina, string rubro ="")
        {
            using (var db = new VentasEntities())
            {
                List<Rubros> r = new List<Rubros>();
                r = db.Rubros.ToList();
                if (!string.IsNullOrEmpty(rubro))
                {
                    r = r.Where(rb => rb.Descripcion.ToUpper().Contains(rubro.ToUpper())).ToList();
                }
                r.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
                return r;
            }
        }

        public static int TotalRegistros(string rubro = "")
        {
            using (var db = new VentasEntities())
            {
                List<Rubros> r = new List<Rubros>();
                r = db.Rubros.ToList();
                if (!string.IsNullOrEmpty(rubro))
                {
                    r = r.Where(rb => rb.Descripcion.ToUpper().Contains(rubro.ToUpper())).ToList();
                }
                return r.Count();
            }
        }

        public static IEnumerable<Rubros> ObtenerRubros()
        {
            using (var db = new VentasEntities())
            {
                return db.Rubros.ToList();
            }
        }

        public static Rubros ObtenerRubro(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Rubros.FirstOrDefault(r => r.Id == id);
            }
        }

        public static void EliminarRubro(int id)
        {
            using (var db = new VentasEntities())
            {
                var rubro = db.Rubros.FirstOrDefault(r => r.Id == id);
                db.Rubros.Remove(rubro);
                db.SaveChanges();
            }
        }

        public static void InsertarRubro(Rubros rubro)
        {
            using (var db = new VentasEntities())
            {
                rubro.Id = db.Rubros.Any() ? db.Rubros.Max(r => r.Id) + 1 : 1;
                db.Rubros.Add(rubro);
                db.SaveChanges();
            }
        }

        public static void EditarRubro(Rubros rubro)
        {
            using (var db = new VentasEntities())
            {
                var r = db.Rubros.FirstOrDefault(rub => rub.Id == rubro.Id);
                r.Descripcion = rubro.Descripcion;
                db.SaveChanges();

            }
        }

        public static List<SelectListItem> CargarSelectListRubros()
        {
            using (var db = new VentasEntities())
            {
                var rubros =
                    (from r in db.Rubros
                     select new SelectListItem
                     {
                         Text = r.Descripcion,
                         Value = r.Id.ToString()
                     });
                return rubros.ToList();
            }
        }

        public static int ObtenerIdRubro(string rubro)
        {
            using (var db = new VentasEntities())
            {
                int idRubro = 0;
                if (!db.Rubros.Any(r => r.Descripcion.ToLower().Trim() == rubro.ToLower().Trim()))
                {
                    Rubros r = new Rubros();
                    r.Descripcion = rubro;
                    InsertarRubro(r);
                }
                idRubro = db.Rubros.FirstOrDefault(r => r.Descripcion.ToLower().Trim() == rubro.ToLower().Trim()).Id;

                return idRubro;
            }
        }
    }
}