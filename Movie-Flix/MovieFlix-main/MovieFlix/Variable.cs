using MovieFlix.Models;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieFlix
{
    public static class Variable
    {
        public static int user_login =0;
        public static int user_Id =0;
        public static string user_name ="";
        public static string purchaseMovieID = "";
        public static string movieName= "";
        public static string moviePrice="";
        public static string movieLink = "";
        public static int watchControll= 0;
        public static string detailesPoster = "";
        public static string moviedeff = "";

        public static string errorLonin = "";
        public static string commentError ="";
        public static string paymentErrorPhn = "";
        public static string paymentErrortx = "";
    }
}