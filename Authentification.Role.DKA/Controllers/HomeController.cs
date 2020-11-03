using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authentification.Role.DKA.Models;
using Microsoft.AspNetCore.Authorization;

namespace Authentification.Role.DKA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new Dictionary<string, object> { ["Placeholder"] = "Placehoder" });

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
