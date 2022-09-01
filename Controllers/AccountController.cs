using Buraqq.Models;
using Microsoft.AspNetCore.Mvc;


namespace Buraqq.Controllers
{
    public class AccountController : Controller
    {
        private readonly BuraqqContext _context;
        public AccountController (BuraqqContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.RoleId = 3;
            user.AccessToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + DateTime.UtcNow.Ticks;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.UtcNow.AddDays(30);
            Response.Cookies.Append("user-access-token", user.AccessToken, options) ;

            return Redirect("/Home/Index");
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            User dbUser=_context.Users.Where(x=>x.Email.ToLower().Equals(user.Email.ToLower()) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (dbUser == null)
            {
                ViewBag.Error = "User does not exist, Try Again";
                return View();
            }
            CookieOptions options=new CookieOptions();
            options.Expires = DateTime.UtcNow.AddDays(30);
            Response.Cookies.Append("user-access-token", dbUser.AccessToken, options);
            return Redirect("/Home/Index");
        }
        public IActionResult Logout(User user)
        {
            Response.Cookies.Delete("user-access-token");
            return Redirect("/Home/Index");
        }
    }
}
