using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SsaPredavanje.Models
{
    public class HomeViewModel
    {
        public string Handle { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
        public int TweetsCount { get; set; }
        public IEnumerable<ApplicationUser> UsersIFollow { get; set; }
    }
}