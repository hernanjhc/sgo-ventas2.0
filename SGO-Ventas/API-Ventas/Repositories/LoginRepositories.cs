using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Ventas.Repositories
{
    public static class LoginRepositories
    {

        public static bool ControlLogin(Login login)
        {
            using (var db = new SGOVentasContext())
            {
                return db.Usuarios.Any(u => u.Nombre == login.user && u.Password == login.key);
            }
        }
    }
}
