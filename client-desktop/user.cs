using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop
{
    internal class user
    {
        public string name;
        public string email;
        public string password;
        public string adress;
        public float money;
    }
}
public static class UserContext
{
    public static string UserInfo { get; set; }
}
