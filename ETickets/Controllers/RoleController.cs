using ETickets.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(roleVM.Name);
               await roleManager.CreateAsync(role);
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
