using ETickets.Models;
using ETickets.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Address = userVM.Address
                };
                var result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "don't match constrains");
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUsreVM usreVM)
        {
            if (ModelState.IsValid) 
            {
              var user= await userManager.FindByNameAsync(usreVM.UserName);
                if (user != null)
                {
                    //check password
                   var check=await userManager.CheckPasswordAsync(user, usreVM.Password);
                    if (check)
                    {
                        //Login
                       await signInManager.SignInAsync(user, usreVM.RememberMe);
                       return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Invalid Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Invalid User Name");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
