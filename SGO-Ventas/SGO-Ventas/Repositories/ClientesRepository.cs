using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGO_Ventas.Models;

namespace SGO_Ventas.Repositories
{
    public class ClientesRepository
    {
        //public static List<Clientes> ObtenerClientesPaginado(int pagina, int cantidadRegistrosPagina)
        //{
        //    using (var db = new VentasEntities())
        //    {
        //        return db.Clientes.OrderBy(u => u.Id)
        //            .Skip((pagina - 1) * cantidadRegistrosPagina)
        //            .Take(cantidadRegistrosPagina).ToList();
        //    }
        //}

        public static List<Clientes> ObtenerClientesPaginado(int pagina, int cantidadRegistrosPagina, string cliente="")
        {
            using (var db = new VentasEntities())
            {
                List<Clientes> c = new List<Clientes>();
                c = db.Clientes.ToList();
                if (!String.IsNullOrEmpty(cliente))
                {
                    c = c.Where(cl => cl.RazonSocial.ToUpper().Contains(cliente.ToUpper())).ToList();
                }
                c = c.OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();

                return c;
            }
        }

        //public static int TotalRegistros()
        //{
        //    using (var db = new VentasEntities())
        //    {
        //        return db.Clientes
        //            .Count();
        //    }

        //}
        public static int TotalRegistros(string cliente="")
        {
            using (var db = new VentasEntities())
            {
                List<Clientes> c = new List<Clientes>();
                c = db.Clientes.ToList();
                if (!String.IsNullOrEmpty(cliente))
                {
                    c = c.Where(cl => cl.RazonSocial.Contains(cliente)).ToList();
                }
                return c.Count();
            }
        }

        public static IEnumerable<Clientes> ObtenerClientes()
        {
            using (var db = new VentasEntities())
            {
                return db.Clientes.ToList();
            }
        }

        public static void GuardarCliente(Clientes cliente)
        {
            using (var db = new VentasEntities())
            {
                cliente.Id = db.Clientes.Any() ? db.Clientes.Max(c => c.Id) + 1 : 1;
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }

        public static Clientes ObtenerCliente(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Clientes.FirstOrDefault(c => c.Id == id);
            }
        }

        public static Clientes ObtenerCliente(decimal? nroDocumento)
        {
            using (var db = new VentasEntities())
            {
                return db.Clientes.FirstOrDefault(c => c.NroDocumento == nroDocumento);
            }
        }

        public static void EditarCliente(Clientes cliente)
        {
            using (var db = new VentasEntities())
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void EliminarCliente(int id)
        {
            using (var db = new VentasEntities())
            {
                var cliente = db.Clientes.FirstOrDefault(c => c.Id == id);
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }

        public static List<SelectListItem> CargarSelectListClientes()
        {
            using (var db = new VentasEntities())
            {
                var p =
                    (from t in db.Clientes
                     select new SelectListItem
                     {
                         Text = t.RazonSocial,
                         Value = t.Id.ToString()
                     });
                return p.ToList();
            }
        }
    }
}