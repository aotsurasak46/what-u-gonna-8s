using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using what_u_gonna_eat.Data;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Controllers;

public class AccountController : Controller
{
    private readonly AccountDbContext _db;

    public AccountController(AccountDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Login() { return View(); }

	public IActionResult Register() { return View(); }

	[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Account obj) 
    {
        var user = _db.Accounts.FirstOrDefault(u => u.Username == obj.Username);
        if (ModelState.IsValid)
        {
            if (user == null) 
            {
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(nameof(Account.Username), "Username is already taken.");
            }
            
        }
        return View(obj);
    }

    [HttpPost]
    public IActionResult Login(Account obj) {

        var user = _db.Accounts.FirstOrDefault(u => u.Username == obj.Username);
        if (user != null)
        {
            if (user.Password == obj.Password)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(nameof(Account.Password), "Incorrect password.");
            }
        }
        else
        {
            ModelState.AddModelError(nameof(Account.Username), "Invalid username or password.");
        }
        
        return View(obj);

    }


}   
