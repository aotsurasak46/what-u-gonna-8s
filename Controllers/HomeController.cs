using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using what_u_gonna_eat.Data;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Controllers;

public class HomeController : Controller
{
    private readonly AccountDbContext _logger;

    public HomeController(AccountDbContext logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        // Get the user from the database using the userId
        var user = _logger.Account.FirstOrDefault(u => u.Id == userId);

        // Pass the user information to the view
        ViewData["UserName"] = user.Username;

        return View();
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
