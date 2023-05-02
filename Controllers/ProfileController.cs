using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using what_u_gonna_eat.Data;
using Azure.Identity;
using what_u_gonna_eat.ViewModels;
using Microsoft.EntityFrameworkCore;
using what_u_gonna_eat.Models;

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
            //Check User
            var userId =  HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                // use the user ID to retrieve user information
                var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    var vm = new ProfileViewModel();
                    vm.account = user;
                    vm.deliverposts = _db.DeliverPosts.Include(dpt => dpt.Poster).ToList();
                    vm.deliverposts.Reverse();
                    vm.eaterposts = _db.EaterPost.Include(ept => ept.Poster).ToList();
                    vm.eaterposts.Reverse();
                    vm.eaterpostaccounts = _db.EaterPostAccounts.Include(p => p.EaterPost).Include(e=> e.Buyer).ToList();
                    vm.eaterpostaccounts.Reverse();
                    vm.orders = _db.Orders.Include(dp => dp.DeliverPost).Include(o => o.Orderer).ToList();
                    vm.orders.Reverse();
                    return View(vm);
                }
                return RedirectToAction(nameof(AccountController.Login), "Account");

            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }

        }

        public IActionResult Edit()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {   
            
            if(account != null)
            {
                _db.Accounts.Update(account);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }
    }
}
