using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Repositories;

namespace Ventas.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            var marcas = MarcasRepository.GetEmarcas();
            return View(marcas);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (MarcasRepository.EliminarMarca(id))
                {
                    return Json(new { success = true, mesagge = "Borrado Correctamente" });
                }
            }
            return Json(new { success = false, mesagge = "No se pudo borrar" });
        }
    }
}
