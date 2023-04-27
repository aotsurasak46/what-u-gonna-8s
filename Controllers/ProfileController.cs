﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using what_u_gonna_eat.Data;
using Azure.Identity;
using what_u_gonna_eat.ViewModels;

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
                    vm.deliverposts = _db.DeliverPosts.ToList();
                    vm.eaterposts = _db.EaterPost.ToList();
                    return View(vm);
                }
                return RedirectToAction(nameof(AccountController.Login), "Account");

            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }

        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Accounts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
