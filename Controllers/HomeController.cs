using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Data;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AccountDbContext _db;

    public HomeController(ILogger<HomeController> logger,AccountDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            // use the user ID to retrieve user information
            var user = _db.Account.FirstOrDefault(u => u.Id == userId);
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
            return RedirectToAction("Login", "Account");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
