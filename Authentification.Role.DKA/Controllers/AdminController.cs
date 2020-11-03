using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentification.Role.DKA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentification.Role.DKA.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> UserMana;

        public AdminController(UserManager<ApplicationUser> _UserMana)
        {
            UserMana = _UserMana;
        }
        public ViewResult Index() => View(UserMana.Users);
    }
}
