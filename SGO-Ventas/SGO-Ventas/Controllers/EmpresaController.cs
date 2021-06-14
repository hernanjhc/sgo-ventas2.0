using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            var e = EmpresaRepository.ObtenerEmpresas();
            return View(e);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "RazonSocial,Documento,Domicilio,EMail,Telefono")] Empresa empresa)
        {
            EmpresaRepository.GuardarEmpresa(empresa);
            return RedirectToAction("Index");
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            var p = EmpresaRepository.ObtenerEmpresa(id);
            return View(p);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,Documento,Domicilio,EMail,Telefono")] Empresa empresa)
        {
            EmpresaRepository.EditarEmpresa(empresa);
            return RedirectToAction("Index");
        }
    }
}
