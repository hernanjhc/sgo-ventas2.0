using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class ComisionesRepository
    {
        public static List<Comisiones> ObtenerComisionesPaginado(int pagina, int cantidadRegistrosPagina, string comision = "")
        {
            using (var db = new VentasEntities())
            {
                List<Comisiones> c = db.Comisiones.ToList();
                if (!String.IsNullOrEmpty(comision))
                {
                    c = c.Where(co => co.RazonSocial.ToUpper().Contains(comision.ToUpper())).ToList();
                }
                c.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();

                return c;
            }
        }

        public static int TotalRegistros(string comision = "")
        {
            using (var db = new VentasEntities())
            {
                if (String.IsNullOrEmpty(comision))
                {
                    return db.Comisiones.Count();
                }
                else
                {
                    return db.Comisiones.Where(c => c.RazonSocial.Contains(comision)).Count();
                }

            }
        }


        public static IEnumerable<Comisiones> ObtenerComisiones()
        {
            using (var db = new VentasEntities())
            {
                return db.Comisiones.ToList();
            }
        }

        public static Comisiones ObtenerComision(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Comisiones.FirstOrDefault(c => c.Id == id);
            }
        }

        public static void EliminarComision(int id)
        {
            using (var db = new VentasEntities())
            {
                var m = db.Comisiones.FirstOrDefault(t => t.Id == id);
                db.Comisiones.Remove(m);
                db.SaveChanges();
            }
        }

        public static void InsertarComision(Comisiones comision)
        {
            using (var db = new VentasEntities())
            {
                comision.Id = db.Comisiones.Any() ? db.Comisiones.Max(m => m.Id) + 1 : 1;
                db.Comisiones.Add(comision);
                db.SaveChanges();
            }
        }

        public static void EditarComision(Comisiones comision)
        {
            using (var db = new VentasEntities())
            {
                db.Entry(comision).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static List<SelectListItem> CargarSelectListComisiones()
        {
            using (var db = new VentasEntities())
            {
                var comisiones =
                    (from t in db.Comisiones
                     select new SelectListItem
                     {
                         Text = t.RazonSocial,
                         Value = t.Id.ToString()
                     });
                return comisiones.ToList();
            }
        }
    }
}