using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class UnidadesRepository
    {
        public static IEnumerable<Unidades> ObtenerUnidades()
        {
            using (var db = new VentasEntities())
            {
                return db.Unidades.ToList();
            }
        }
        public static List<Unidades> ObtenerUnidadesPaginado(int pagina, int cantidadRegistrosPagina, string unidad = "")
        {
            using (var db = new VentasEntities())
            {
                List<Unidades> u = db.Unidades.ToList();
                if (!string.IsNullOrEmpty(unidad))
                {
                    u = u.Where(un => un.Descripcion.ToUpper().Contains(unidad.ToUpper())).ToList();
                }
                u.OrderBy(ud => ud.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
                return u;
            }
        }

        public static int TotalRegistros(string unidad = "")
        {
            using (var db = new VentasEntities())
            {
                List<Unidades> u = db.Unidades.ToList();
                if (!string.IsNullOrEmpty(unidad))
                {
                    u = u.Where(un => un.Descripcion.ToUpper().Contains(unidad.ToUpper())).ToList();
                }
                return u.Count();
            }
        }

        public static Unidades ObtenerUnidad(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Unidades.FirstOrDefault(u => u.Id == id);
            }
        }

        public static void EliminarUnidad(int id)
        {
            using (var db = new VentasEntities())
            {
                var unidad = db.Unidades.FirstOrDefault(u => u.Id == id);
                db.Unidades.Remove(unidad);
                db.SaveChanges();
            }
        }

        public static void InsertarUnidad(Unidades unidad)
        {
            using (var db = new VentasEntities())
            {
                unidad.Id = db.Unidades.Any() ? db.Unidades.Max(u => u.Id) + 1 : 1;
                db.Unidades.Add(unidad);
                db.SaveChanges();
            }
        }

        public static void EditarUnidad(Unidades unidad)
        {
            using (var db = new VentasEntities())
            {
                var un = db.Unidades.FirstOrDefault(u => u.Id == unidad.Id);
                un.Descripcion = unidad.Descripcion;
                db.SaveChanges();

            }
        }

        public static List<SelectListItem> CargarSelectListUnidades()
        {
            using (var db = new VentasEntities())
            {
                var unidades =
                    (from t in db.Unidades
                     select new SelectListItem
                     {
                         Text = t.Descripcion,
                         Value = t.Id.ToString()
                     });
                return unidades.ToList();
            }
        }

        public static int ObtenerIdUnidad(string unidad)
        {
            using (var db = new VentasEntities())
            {
                int idUnidad = 0;
                if (!db.Unidades.Any(u => u.Descripcion.ToLower().Trim() == unidad.ToLower().Trim()))
                {
                    Unidades u = new Unidades();
                    u.Descripcion = unidad;
                    InsertarUnidad(u);
                }
                idUnidad = db.Unidades.FirstOrDefault(u => u.Descripcion.ToLower().Trim() == unidad.ToLower().Trim()).Id;

                return idUnidad;
            }
        }
    }
}