using Microsoft.AspNetCore.Mvc;
using MovieStoreMVC.Models.DTO;
using MovieStoreMVC.Repositories.Abstract;

namespace MovieStoreMVC.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService= authService;
        }

        /*We will create a user with admin rights, after that we are going to comment this method because 
         we need only one user in this application & if you need other users you can implement this registration Method with views */
        /* public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Name = "Badri Aran",
                Password = "Admin@123",
                PasswordConfirm = "Admin@123",
                Role = "Admin"
            };
            //if you want to register with user, change role="User"
            var result= await authService.RegisterAsync(model);

            return Ok(result.Message); 
        }*/
        
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Couldnot logged in...";
                return RedirectToAction(nameof(Login)); 
            }          

        }
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
