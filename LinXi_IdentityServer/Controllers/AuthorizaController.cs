using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_IdentityServer.Controllers
{
    public class AuthorizaController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}