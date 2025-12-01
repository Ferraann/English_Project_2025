using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }

        public User(string username, string password, string profile)
        {
            Username = username;
            Password = password;
            Profile = profile;
        }
    }
}