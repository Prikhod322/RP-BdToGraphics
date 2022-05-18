using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication15.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login{ get; set; }
        public string Email { get; set; }
        public string HashPass { get; set; }

        public User()
        {
            ID = 0;
            Login = Email = HashPass = string.Empty;
        }
    }
}
