using kartvizit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Controllers
{
    [Authorize(Roles = "adminrole")]
    public class AdminSectionController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminSectionController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user==null)
            {
                ViewBag.ErrorMessage = $"{id} User Id li kullanıcı yoktur.";
                return View("NotFound");
            }


            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                AdSoyad = user.AdSoyad,
                Kurum = user.Kurum,
                Bolum = user.Bolum,
                Unvan = user.Unvan,
                Telefon = user.Telefon
                //Roles=userRoles
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"{model.Id} User Id li kullanıcı yoktur.";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.AdSoyad = model.AdSoyad;
                user.Kurum = model.Kurum;
                user.Bolum = model.Bolum;
                user.Unvan = model.Unvan;
                user.Telefon = model.Telefon;


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
