using AspProjectZust.Entities.Entity;
using AspProjectZust.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AspProjectZust.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private CustomIdentityDbContext _customIdenityDbContext;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, CustomIdentityDbContext customIdenityDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _customIdenityDbContext = customIdenityDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var signIn = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (signIn.Succeeded)
                {
                    var user = _customIdenityDbContext.Users.SingleOrDefault(i => i.UserName == loginViewModel.Username);
                    if (user != null)
                    {
                        user.IsOnline = true;
                        _customIdenityDbContext.Update(user);
                        await _customIdenityDbContext.SaveChangesAsync();
                    }
                    return RedirectToAction("NewsFeed", "Home");
                }
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid && registerViewModel.IsAcceptThePrivacy)
            {
                var user = new CustomIdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Name,
                    City = registerViewModel.City
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("User"))
                    {
                        var role = new CustomIdentityRole
                        {
                            Name = "User",
                        };
                        var result2 = await _roleManager.CreateAsync(role);
                        if (!result2.Succeeded)
                        {
                            ModelState.AddModelError("", "Error");
                            return View(registerViewModel);
                        }
                    }

                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            user.IsOnline = false;
            _customIdenityDbContext.Update(user);
            await _customIdenityDbContext.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
