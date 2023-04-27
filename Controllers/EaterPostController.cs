using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Data;
using what_u_gonna_eat.Models;
using what_u_gonna_eat.ViewModels;

namespace what_u_gonna_eat.Controllers
{
    public class EaterPostController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EaterPostController(ApplicationDbContext db)
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
                    if (_db.EaterPost != null)
                    {
                        var post = _db.EaterPost.ToList();
                        EaterPostView vm = new EaterPostView();
                        vm.eaterPosts = post;
                        return View(vm);
                    }
                    else
                    {
                        return View(null);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }


            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EaterPost eaterpost)
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                eaterpost.Status = true;
                eaterpost.PosterId = user.Id;
                eaterpost.Poster = user;
                if(eaterpost.Description == null)
                {
                    eaterpost.Description = "";
                }
                _db.EaterPost.Add(eaterpost);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public IActionResult OrderSubmit(EaterPost eaterpost)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
            EaterPostAccount epa = new EaterPostAccount();
            //Post Id ของ EaterPost
            epa.EaterPostId = eaterpost.Id;
            epa.EaterPost = eaterpost;
            //Id ของคนกด order
            epa.BuyerId = user.Id;
            epa.Buyer = user;

            _db.EaterPostAccounts.Add(epa);
            _db.SaveChanges();

            eaterpost.Status = false;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int postId)
        {
            var post = _db.EaterPost.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                _db.EaterPost.Remove(post);
                _db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
            return RedirectToAction("Index", "Profile");
        }
    }
}
