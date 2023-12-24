using Upgrading.Models;
using Upgrading.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Upgrading.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _usermanager = usermanager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            LoginVM loginVM = new()
            {
                RedirectUrl = returnUrl,
            };
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.
                     PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.RedirectUrl))
                    {
                        if(User.IsInRole(SD.Role_Admin))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("StudentIndex", "Student");
                        }
                        
                    }
                    else
                    {
                        return LocalRedirect(loginVM.RedirectUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attept.");
                    TempData["error"] = $"{result.Succeeded}";
                }
            }

            return View(loginVM);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user= new()
                {
                    UserName=registerVM.Email,
                    Email=registerVM.Email,
                    StudentName=registerVM.Name,
                    StudentSurname=registerVM.Surname,
                    EmailConfirmed=true,
                    NormalizedEmail=registerVM.Email,
                   
                };
                var result = await _usermanager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
              
                     await _usermanager.AddToRoleAsync(user, SD.Role_Student);
            

                    await _signinManager.SignInAsync(user, isPersistent: false);
                    if (string.IsNullOrEmpty(registerVM.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(registerVM.RedirectUrl);
                    }

                }
                else
                {
                    TempData["error"] = "Invalid student number try again with vaild student number.";
                }

            }
           
            return View();
        }
    }
}
