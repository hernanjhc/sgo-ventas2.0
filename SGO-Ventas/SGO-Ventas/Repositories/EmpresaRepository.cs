using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Repositories
{
    public class EmpresaRepository
    {
        public static IEnumerable<Empresa> ObtenerEmpresas()
        {
            using (var db = new VentasEntities())
            {
                return db.Empresa.ToList();
            }
        }

        public static void GuardarEmpresa(Empresa empresa)
        {
            using (var db = new VentasEntities())
            {
                empresa.Id = db.Empresa.Any() ? db.Empresa.Max(e => e.Id) + 1 : 1;
                db.Empresa.Add(empresa);
                db.SaveChanges();
            }
        }

        public static Empresa ObtenerEmpresa(int id)
        {
            using (var db = new VentasEntities())
            {
                return db.Empresa.FirstOrDefault(e => e.Id == id);
            }
        }

        public static void EditarEmpresa(Empresa empresa)
        {
            using (var db = new VentasEntities())
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}