using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SsaPredavanje.Models;

namespace SsaPredavanje.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string userId)
        {
           
            //Get current user's Id
            var id = User.Identity.GetUserId();
            if (userId == id)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = db.Users.Find(id);
            //Check if model state is valid
            if (ModelState.IsValid)
            {
                var userToFollow = db.Users.Find(userId);
                userToFollow.Followers.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }


            //Redirect to home (refresh)

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unfollow(string userId)
        {

            //Get current user's Id
            var id = User.Identity.GetUserId();
            if (userId == id)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = db.Users.Find(id);
            //Check if model state is valid
            if (ModelState.IsValid)
            {
                var userToUnFollow = db.Users.Find(userId);
                userToUnFollow.Followers.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }


            //Redirect to home (refresh)

            return RedirectToAction("Index", "Home");
        }
    }
}