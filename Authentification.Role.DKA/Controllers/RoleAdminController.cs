using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Authentification.Role.DKA.Controllers
{
    public class RoleAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
