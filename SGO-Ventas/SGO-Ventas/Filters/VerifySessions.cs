using SGO_Ventas.Controllers;
using SGO_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Filters
{
    public class VerifySessions : ActionFilterAttribute
    {
        //override, sustituye lo del padre por lo que esccribo yo
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Usuarios)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}