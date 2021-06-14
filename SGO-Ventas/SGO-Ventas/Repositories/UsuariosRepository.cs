using SGO_Ventas.Lib;
using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Repositories
{
    public class UsuariosRepository
    {

        public static Usuarios VerificarUsuario(string nombre, string pass)
        {
            using (var db = new VentasEntities())
            {
                string pasw = Encrypt.GetSHA256(pass);

                var existeUsuario = from u in db.Usuarios
                                    where
                                        u.Nombre == nombre &&
                                        u.Password == pasw
                                    select u;
                return existeUsuario.FirstOrDefault();
            }
        }

        public static List<Usuarios> ObtenerUsuariosPaginado(int pagina, int cantidadRegistrosPagina)
        {
            using (var db = new VentasEntities())
            {
                return db.Usuarios.Where(u => u.Estado == 1).OrderBy(u => u.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPagina)
                    .Take(cantidadRegistrosPagina).ToList();
            }
        }

        public static int TotalRegistros()
        {
            using (var db = new VentasEntities())
            {
                return db.Usuarios.Count();
            }
        }

        public static void EliminarUsuario(int id)
        {
            using (var db = new VentasEntities())
            {
                var usuario = db.Usuarios.FirstOrDefault(c => c.Id == id);
                usuario.Estado = 0;
                db.SaveChanges();
            }
        }

        public static void GuardarUsuario(Usuarios usuario)
        {
            using (var db = new VentasEntities())
            {
                usuario.Id = db.Usuarios.Any() ? db.Usuarios.Max(c => c.Id) + 1 : 1;
                usuario.FechaAlta = DateTime.Today;
                usuario.Estado = 1;
                usuario.Password = Encrypt.GetSHA256(usuario.Password);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }
    }
}