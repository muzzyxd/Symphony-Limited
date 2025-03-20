using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.ViewModels;

namespace Symphony_Limited.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // assign role based on selection
                if (!await roleManager.RoleExistsAsync(model.Role))
                {
                    await roleManager.CreateAsync(new IdentityRole(model.Role));
                }

                await userManager.AddToRoleAsync(user, model.Role);
                await signInManager.SignInAsync(user, isPersistent: false);

                return model.Role switch
                {
                    "Admin" => RedirectToAction("AdminIndex", "Dashboard"),
                    "Faculty" => RedirectToAction("Index", "Home"),
                    _ => RedirectToAction("Index", "Home")
                };
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        //    var result = await userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        // Ensure the role exists (should already exist from startup)
        //        var roleExists = await roleManager.RoleExistsAsync(model.Role);
        //        if (roleExists)
        //        {
        //            await userManager.AddToRoleAsync(user, model.Role);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Selected role does not exist.");
        //            return View(model);
        //        }

        //        await signInManager.SignInAsync(user, isPersistent: false);

        //        return model.Role switch
        //        {
        //            "Admin" => RedirectToAction("Index", "Admin"),
        //            "Employee" => RedirectToAction("Index", "Employee"),
        //            _ => RedirectToAction("Index", "Home")
        //        };
        //    }

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }

        //    return View(model);
        //}

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("AdminIndex", "Dashboard");
                    }
                    else if (roles.Contains("Faculty"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
