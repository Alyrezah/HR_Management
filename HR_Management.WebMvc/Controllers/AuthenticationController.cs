using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.WebMvc.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {

            var isLoggedIn = await _authenticateService.Login(loginModel);
            if (isLoggedIn.IsSuccess)
            {
                return LocalRedirect("/");
            }

            ModelState.AddModelError("Email", isLoggedIn.ValidationErrors);
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authenticateService.Logout();
            return LocalRedirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            var register = await _authenticateService.Register(registerModel);

            if (register.IsSuccess)
            {
                return RedirectToAction("Login", "Authentication");
            }

            ModelState.AddModelError("", register.ValidationErrors);
            return View(register);
        }
    }
}
