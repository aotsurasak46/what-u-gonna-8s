using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using what_u_gonna_eat.Data;
using Azure.Identity;

namespace what_u_gonna_eat.Controllers
{
	public class ProfileController : Controller
	{

        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                // use the user ID to retrieve user information
                var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    ViewBag.Id = user.Id;
                    ViewBag.Username = user.Username;
                    ViewBag.Email = user.Email;
                }
                return View(user);
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
        }
    }
}
