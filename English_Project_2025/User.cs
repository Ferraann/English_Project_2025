using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }

        public User(string name, string surname, string email, string password, string profile)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Profile = profile;
        }
    }
}