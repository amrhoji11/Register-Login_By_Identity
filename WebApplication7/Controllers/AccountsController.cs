using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models.Data;
using WebApplication7.Models.ViewModel;

namespace WebApplication7.Controllers
{
    public class AccountsController : Controller
    {

        private readonly ApplecationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController (ApplecationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

       

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                UserName=model.Email
                
            };

         var res= await  userManager.CreateAsync(user,model.Password);
            if (res.Succeeded)
            {
                return RedirectToAction("Login");

            }


            return View(model);


        }
        public IActionResult Login()
        { 
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
          var res= await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
            if (res.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View(model);

        }
    }
}
