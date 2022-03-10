using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Models;
using Ventas.Models.ViewModels;

namespace Ventas.Repositories
{
    public class MarcasRepository
    {
        public static List<Emarca> GetEmarcas()
        {
            List<Emarca> marcas = new List<Emarca>();
            using (var db = new VentasContext())
            {
                marcas = db.Emarcas.ToList();
            }
            return marcas;
        }

        internal static bool EliminarMarca(int id)
        {
            try
            {
                using (var db = new VentasContext())
                {
                    var marca = db.Emarcas.Find(id);
                    db.Emarcas.Remove(marca);
                    db.SaveChanges();
            }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //public static List<MarcasViewModels> GetMarcasViewModels()
        //{
        //    List<MarcasViewModels> marcas = new List<MarcasViewModels>();
        //    using (var db = new VentasContext())
        //    {
        //        marcas = db.Emarcas.ToList();
        //    }
        //    return marcas;
        //}

    }
}
