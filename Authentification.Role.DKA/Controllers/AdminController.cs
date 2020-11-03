using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Authentification.Role.DKA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentification.Role.DKA.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> UserMana;

        private IUserValidator<ApplicationUser> userValidator;

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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await UserMana.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await UserMana.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            } else
            {
                ModelState.AddModelError("", "Error Not Found");
            }
            return RedirectToAction("Index", UserMana.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await UserMana.FindByIdAsync(id);
            if(user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CreateModel model)
        {
            ApplicationUser user = await UserMana.FindByIdAsync(id);

            if(user != null)
            {
                user.Email = model.Email;
                user.Password
                IdentityResult result = await UserMana.UpdateAsync(user);
            }
        }
    }
}
