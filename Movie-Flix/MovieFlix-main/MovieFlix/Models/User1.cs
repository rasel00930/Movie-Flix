using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieFlix.Models
{
    public class User1
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string passwords { get; set; }
        public string confirmPass { get; set; }
        public string userType { get; set; }
    }
}