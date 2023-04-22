using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Data;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Controllers
{
    public class EaterPostController : Controller
    {
        private readonly AccountDbContext _db;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EaterPost obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.EaterPosts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
