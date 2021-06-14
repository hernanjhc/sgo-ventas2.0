using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySessions());
        }
    }
}
