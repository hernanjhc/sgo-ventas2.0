using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGO_Ventas.Lib
{
    public class Configuration
    {
        public static int RegistroPorPagina()
        {
            int rpp = 10;
            var key = ConfigurationManager.AppSettings["RegistrosPorPagina"];
            if (!String.IsNullOrEmpty(key))
            {
                rpp = Convert.ToInt32(key);
            }
            return rpp;
        }
    }
}