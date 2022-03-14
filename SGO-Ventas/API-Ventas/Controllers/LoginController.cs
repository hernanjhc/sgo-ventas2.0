using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Ventas.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {


        [HttpPost]
        public IActionResult Login(Login login)
        {
            string t="";

            if (login.user == "a" && login.key == "a" )
            {
                t = TokenManagement.BuildToken();
            }
            
            return Ok(t);
        }
    }
}
