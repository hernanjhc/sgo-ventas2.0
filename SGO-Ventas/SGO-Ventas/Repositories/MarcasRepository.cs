using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public class MarcasRepository
    {
        public static List<Marcas> ObtenerMarcasPaginado(int pagina, int cantidadRegistrosPagina, string marca = "")
        {
            using (var db = new VentasEntities())
            {
                List<Marcas> marcas = new List<Marcas>();
                marcas = db.Marcas.ToList();
                if (!string.IsNullOrEmpty(marca))
                {
                    marcas = marcas.Where(m => m.Descripcion.ToUpper().Contains(marca.ToUpper())).ToList();
                }
                marcas.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
                return marcas;
            }
        }

        public static int TotalRegistros(string marca = "")
        {
            using (var db = new VentasEntities())
            {
                List<Marcas> marcas = new List<Marcas>();
                marcas = db.Marcas.ToList();
                if (!string.IsNullOrEmpty(marca))
                {
                    marcas = marcas.Where(m => m.Descripcion.ToUpper().Contains(marca.ToUpper())).ToList();
                }
                return marcas.Count();
            }
        }

        public static IEnumerable<Marcas> ObtenerMarcas()
        {
            using (var db = new VentasEntities())
            {
                return db.Marcas.ToList();
            }
        }

        public static Marcas ObtenerMarca(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Marcas.FirstOrDefault(m => m.Id == id);
            }
        }

        public static int ObtenerIdMarca(string marca)
        {
            using (var db = new VentasEntities())
            {
                int idMarca = 0;
                if (!db.Marcas.Any(m => m.Descripcion.ToLower().Trim() == marca.ToLower().Trim()))
                {
                    Marcas m = new Marcas();
                    m.Descripcion = marca;
                    InsertarMarca(m);
                }
                idMarca = db.Marcas.FirstOrDefault(m => m.Descripcion.ToLower().Trim() == marca.ToLower().Trim()).Id;

                return idMarca;
            }
        }

        public static void EliminarMarca(int id)
        {
            using (var db = new VentasEntities())
            {
                var m = db.Marcas.FirstOrDefault(t => t.Id == id);
                db.Marcas.Remove(m);
                db.SaveChanges();
            }
        }

        public static void InsertarMarca(Marcas marca)
        {
            using (var db = new VentasEntities())
            {
                marca.Id = db.Marcas.Any() ? db.Marcas.Max(m => m.Id) + 1 : 1;
                db.Marcas.Add(marca);
                db.SaveChanges();
            }
        }

        public static void EditarMarca(Marcas marca)
        {
            using (var db = new VentasEntities())
            {
                var m = db.Marcas.FirstOrDefault(mar => mar.Id == marca.Id);
                m.Descripcion = marca.Descripcion;
                db.SaveChanges();

            }
        }

        public static List<SelectListItem> CargarSelectListMarcas()
        {
            using (var db = new VentasEntities())
            {
                var marcas =
                    (from t in db.Marcas
                     select new SelectListItem
                     {
                         Text = t.Descripcion,
                         Value = t.Id.ToString()
                     });
                return marcas.ToList();
            }
        }
    }
}