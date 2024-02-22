using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieFlix.Models
{
    public class Openion
    {
        public Nullable<int> userId { get; set; }
        public Nullable<int> movieId { get; set; }
        public string op { get; set; }
    }
}