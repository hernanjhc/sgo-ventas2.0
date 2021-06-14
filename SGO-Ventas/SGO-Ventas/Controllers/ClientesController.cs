using System.Collections.Generic;
using System.Web.Mvc;
using SGO_Ventas.Models;
using SGO_Ventas.Repositories;

namespace SGO_Ventas.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index(int pagina = 1, string cliente = "")
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            List<Clientes> c = new List<Clientes>();
            var ClientesPaginados = new Models.ViewModels.IndexClientes();

            if (string.IsNullOrEmpty(cliente))
            {
                c = ClientesRepository.ObtenerClientesPaginado(pagina, registrosPorPágina);
                ClientesPaginados.TotalDeRegistros = ClientesRepository.TotalRegistros();
            }
            else
            {
                c = ClientesRepository.ObtenerClientesPaginado(pagina, registrosPorPágina, cliente);
                ClientesPaginados.TotalDeRegistros = ClientesRepository.TotalRegistros(cliente);
            }
            ClientesPaginados.Clientes = c;
            ClientesPaginados.PaginaActual = pagina;
            ClientesPaginados.RegistrosPorPagina = registrosPorPágina;

            ViewBag.TiposDocumento = TiposDocumentoRepository.ObtenerTiposDocumento();
            return View(ClientesPaginados);
        }

        public ActionResult Create()
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            ViewBag.Comisiones = ComisionesRepository.CargarSelectListComisiones();
            Clientes p = new Clientes();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones,IdComision")] Clientes cliente)
        {
            ClientesRepository.GuardarCliente(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TiposDocumento = TiposDocumentoRepository.CargarSelectListTiposDocumento();
            ViewBag.Comisiones = ComisionesRepository.CargarSelectListComisiones();
            var p = ClientesRepository.ObtenerCliente(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,IdTipoDocumento,NroDocumento,Direccion,Telefono,EMail,Observaciones,IdComision")] Clientes cliente)
        {
            ClientesRepository.EditarCliente(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ClientesRepository.EliminarCliente(id);
            return RedirectToAction("Index");
        }
    }
}