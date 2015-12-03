using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SsaPredavanje.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        [ScaffoldColumn(false)]
        public DateTimeOffset CreationDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}