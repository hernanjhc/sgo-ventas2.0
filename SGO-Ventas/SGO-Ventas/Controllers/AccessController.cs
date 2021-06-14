﻿using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                var usuario = UsuariosRepository.VerificarUsuario(user, password);
                if (usuario != null)
                {
                    //Usuarios oUser = lst.First();
                    Session["User"] = usuario;
                    return Content("1");
                }
                else
                {
                    return Content("Usuario invalido");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult LogOut()
        {
            try
            {
                //Session["User"] = null;
                Session.Abandon();
                return RedirectToAction("Index", "Access");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}