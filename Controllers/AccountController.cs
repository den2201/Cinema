using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
  
    public class AccountController : Controller
    {
        [HttpGet]
 
        public IActionResult Login()
        {
            var model = new LoginModel
            {
                Login = "test",
                Password = "test"
            };
            return View(model);
        }

        [HttpPost] 
        public IActionResult Login([FromForm]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                return View("LoginResult",model.Login);
            }
           return View(model);
        }
    }
}
