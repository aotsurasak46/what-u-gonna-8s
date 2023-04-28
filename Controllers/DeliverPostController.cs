using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Models;
using what_u_gonna_eat.Data;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using what_u_gonna_eat.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    if(_db.DeliverPosts != null)
                    {
                        var post = _db.DeliverPosts.ToList();
                        post.Reverse();
                        DeliverPostView vm = new DeliverPostView();
                        vm.deliverPosts = post;
                        vm.account = user;
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

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DeliverPost deliverpost)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u =>u.Id == userId);
            if (user != null)
            {
                deliverpost.Status = true;
                deliverpost.PosterId = user.Id;
                _db.DeliverPosts.Add(deliverpost);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }


        public IActionResult AddOrder(string foodName,string description, int? postId) 
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
            var post = _db.DeliverPosts.FirstOrDefault(u => u.Id == postId);
            if (post.Status)
            {
                Order order = new Order();
                order.Menu = foodName;
                order.Description = description;

                order.DeliverPost = post;
                order.DeliverPostId = post.Id;

                order.Orderer = user;
                order.OrdererId = user.Id;

                post.OpenAmount -= 1;
                if(post.OpenAmount <= 0) {
                    post.Status = false;
                }
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int postId) 
        {
            var post = _db.DeliverPosts.FirstOrDefault(p => p.Id == postId);
            var orders = _db.Orders.ToList();
            
            if (post != null)
            {
                foreach (var o in orders)
                {
                    if (o.DeliverPostId == postId)
                    {
                        _db.Orders.Remove(o);
                        _db.SaveChanges();
                    }
                }
                _db.DeliverPosts.Remove(post);
                _db.SaveChanges();
                return RedirectToAction("Index","Profile");
            }
            return RedirectToAction("Index","Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
