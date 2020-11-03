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

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await UserMana.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                } else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
