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
    }
}
