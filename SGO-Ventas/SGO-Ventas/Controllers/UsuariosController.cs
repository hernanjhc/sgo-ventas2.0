using SGO_Ventas.Models;
using SGO_Ventas.Repositories;
using System.Web.Mvc;

namespace SGO_Ventas.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index(int pagina = 1)
        {
            int registrosPorPágina = Lib.Configuration.RegistroPorPagina();
            var p = UsuariosRepository.ObtenerUsuariosPaginado(pagina, registrosPorPágina);

            var UsuariosPaginados = new Models.ViewModels.IndexUsuarios();
            UsuariosPaginados.Usuarios = p;
            UsuariosPaginados.PaginaActual = pagina;
            UsuariosPaginados.TotalDeRegistros = UsuariosRepository.TotalRegistros();
            UsuariosPaginados.RegistrosPorPagina = registrosPorPágina;

            return View(UsuariosPaginados);
        }

        public ActionResult Create()
        {
            Usuarios u = new Usuarios();
            return View(u);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,EMail,Password,NombreCompleto")] Usuarios usuario)
        {
            UsuariosRepository.GuardarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UsuariosRepository.EliminarUsuario(id);
            return RedirectToAction("Index");
        }
    }
}