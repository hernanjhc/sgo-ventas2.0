using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Repositories
{
    public static class ProveedoresRepository
    {
        public static List<Proveedores> ObtenerProveedoresPaginado(int pagina, int cantidadRegistrosPagina)
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static List<Proveedores> ObtenerProveedoresPaginado(int pagina, int cantidadRegistrosPagina, string proveedor)
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores
                    .Where(p => p.RazonSocial.Contains(proveedor))
                    .OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static int TotalRegistros()
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores.Count();
            }
        }

        public static int TotalRegistros(string proveedor)
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores
                    .Where(p => p.RazonSocial.Contains(proveedor))
                    .Count();
            }
        }

        public static IEnumerable<Proveedores> ObtenerProveedores()
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores.ToList();
            }
        }
        public static void GuardarProveedor(Proveedores proveedor)
        {
            using (var db = new VentasEntities())
            {
                proveedor.Id = db.Proveedores.Any() ? db.Proveedores.Max(p => p.Id) + 1 : 1;
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
            }
        }

        public static Proveedores ObtenerProveedor(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Proveedores.FirstOrDefault(p => p.Id == id);
            }
        }

        public static void EditarProveedor(Proveedores proveedor)
        {
            using (var db = new VentasEntities())
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void EliminarProveedor(int id)
        {
            using (var db = new VentasEntities())
            {
                var proveedor = db.Proveedores.FirstOrDefault(p => p.Id == id);
                db.Proveedores.Remove(proveedor);
                db.SaveChanges();
            }
        }

        public static List<SelectListItem> CargarSelectListProveedores()
        {
            using (var db = new VentasEntities())
            {
                var p =
                    (from t in db.Proveedores
                     select new SelectListItem
                     {
                         Text = t.RazonSocial,
                         Value = t.Id.ToString()
                     });
                return p.ToList();
            }
        }

        public static int ObtenerIdProveedor(string proveedor)
        {
            using (var db = new VentasEntities())
            {
                int idProveedor = 0;
                if (!db.Proveedores.Any(p => p.RazonSocial.ToLower().Trim() == proveedor.ToLower().Trim()))
                {
                    Proveedores p = new Proveedores();
                    p.RazonSocial = proveedor;
                    p.IdTipoDocumento = 1;
                    p.NroDocumento = 1;
                    GuardarProveedor(p);
                }
                idProveedor = db.Proveedores.FirstOrDefault(p => p.RazonSocial.ToLower().Trim() == proveedor.ToLower().Trim()).Id;

                return idProveedor;
            }
        }
    }
}