using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop
{
    internal class user
    {
        private string name;
        private string email;
        private string password;
        private string adress;
        private float money;
    }
}
public static class UserContext
{
    public static string UserInfo { get; set; }
}
