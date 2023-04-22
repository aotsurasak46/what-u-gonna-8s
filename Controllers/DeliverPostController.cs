using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Models;
using what_u_gonna_eat.Data;
using System.Diagnostics;

namespace what_u_gonna_eat.Controllers
{
    public class DeliverPostController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DeliverPostController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
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

                IEnumerable<Account> posts = _db.Accounts;
                return View(posts);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DeliverPost deliverpost)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
