using Microsoft.AspNetCore.Mvc;
using SceptrumProject.Domain.SecurityAccount;
using SceptrumProject.Web.ViewModels;
using System.Threading.Tasks;

namespace SceptrumProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _auth;

        public AccountController(IAuthenticate auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            var result = await _auth.RegisterUser(model.Email, model.Password);
            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            var result = await _auth.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _auth.Logout();
            return Redirect("/Account/Login");
        }

    }
}
