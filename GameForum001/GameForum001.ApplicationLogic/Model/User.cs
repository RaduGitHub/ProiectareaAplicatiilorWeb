using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Model
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } 
        public double Score { get; set; }
    }
}
