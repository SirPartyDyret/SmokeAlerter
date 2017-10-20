using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeAlerter
{
    public class Member
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Member(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
