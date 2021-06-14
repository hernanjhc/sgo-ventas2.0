using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using SGO_Ventas.Models;
using SGO_Ventas.Models.ViewModels;
using SGO_Ventas.Repositories;

namespace SGO_Ventas.Controllers
{
    public class MarcasController : Controller
    {
        public ActionResult Index(int pagina = 1, string marca = "")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Marcas> m = new List<Marcas>();
            var MarcasPaginadas = new Models.ViewModels.IndexMarcas();
            if (string.IsNullOrEmpty(marca))
            {
                m = MarcasRepository.ObtenerMarcasPaginado(pagina, registrosPorPágina);
                MarcasPaginadas.TotalDeRegistros = MarcasRepository.TotalRegistros();
            }
            else
            {
                m = MarcasRepository.ObtenerMarcasPaginado(pagina, registrosPorPágina, marca);
                MarcasPaginadas.TotalDeRegistros = MarcasRepository.TotalRegistros(marca);
            }
            MarcasPaginadas.Marcas = m;
            MarcasPaginadas.PaginaActual = pagina;            
            MarcasPaginadas.RegistrosPorPagina = registrosPorPágina;

            return View(MarcasPaginadas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Marcas m = new Marcas();
            //return PartialView("ModalPartial", td);
            return View(m);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Descripcion")] Marcas marca)
        {
            MarcasRepository.InsertarMarca(marca);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var m = MarcasRepository.ObtenerMarca(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Marcas marca)
        {
            MarcasRepository.EditarMarca(marca);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            MarcasRepository.EliminarMarca(id);
            return RedirectToAction("Index");
        }

        public ActionResult Report()
        {
            List<CompraDetalleViewModel> lst =
                new List<CompraDetalleViewModel>();
            
            lst.Add(new CompraDetalleViewModel() { CompraDetalleId=1, ProductoId = 1, Precio = 10  });
            lst.Add(new CompraDetalleViewModel() { CompraDetalleId=1, ProductoId = 2, Precio = 10  });
            lst.Add(new CompraDetalleViewModel() { CompraDetalleId=1, ProductoId = 3, Precio = 10  });

            return View(lst);
        }

        public ActionResult Print()
        {
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();

            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }

            return new ActionAsPdf("Report")
            {
                FileName = "Name.pdf",
                Cookies = cookieCollection
            };
        }
    }
}