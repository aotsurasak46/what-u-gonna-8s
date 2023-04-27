﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
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
                        foreach(var obj in post)
                        {
                            int? eachid = obj.PosterId;
                            var eachUser = _db.Accounts.FirstOrDefault(user => user.Id == eachid);
                            obj.Poster = eachUser;
                        }
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
        public IActionResult OrderSubmit(int postId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Accounts.FirstOrDefault(u => u.Id == userId);
            EaterPostAccount epa = new EaterPostAccount();
            //Post Id ของ EaterPost
            var post = _db.EaterPost.FirstOrDefault(u => u.Id == postId);
            if (post != null)
            {
                epa.EaterPostId = post.Id;
                epa.EaterPost = post;
                if (post.Description == null)
                {
                    post.Description = " ";
                }
                //Id ของคนกด order
                epa.BuyerId = user.Id;
                epa.Buyer = user;

                _db.EaterPostAccounts.Add(epa);
                _db.SaveChanges();

                post.Status = false;

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
    }
}
