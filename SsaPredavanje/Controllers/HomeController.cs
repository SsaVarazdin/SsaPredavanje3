using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SsaPredavanje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SsaPredavanje.Controllers
{
    public class HomeController : Controller
    {
   
        private ApplicationDbContext db { get; set; }

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel();

            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);
                model.DisplayName = user.DisplayName;
                model.Handle = user.Handle;
                model.UsersIFollow = db.Users.Where(x => x.Followers.Select(t => t.Id).Contains(userId));
                model.Followers = user.Followers.Count;
                model.Tweets = db.Tweets.Where(t => t.User.Id != userId).OrderByDescending(x => x.CreationDate);
                //model.Following = db.Users.Select(u => u.Id).Count(x => x == user.Id);
                var numberOfFollowings = 0;
                var isFollowing = false;
                foreach (var userx in db.Users.ToList())
                {
                    isFollowing = userx.Followers.Select(x => x.Id).ToList().Contains(userId);
                    if (isFollowing)
                    {
                        numberOfFollowings += 1;
                    }
                }
                model.Following = numberOfFollowings;
                model.TweetsCount = db.Tweets.Count(x => x.User.Id == userId);
                //model.Users = db.Users.Where(u => u.Id != userId && !user.Followers.Select(x => x.Id).Contains(userId)).ToList();
                model.Users = db.Users.Where(u => u.Id != userId && !u.Followers.Select(x => x.Id).Contains(userId));
            }

            return View(model);
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}