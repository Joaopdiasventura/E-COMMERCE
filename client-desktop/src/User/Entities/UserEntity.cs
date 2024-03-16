using client_desktop.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.User.Entities
{
    public class UserEntity
    {
        public string email;
        public string name;
        public string password;
        public string adress;
        public float money;
    }

    public class UserStatic
    {
        public static string email;
        public static string name;
        public static string password;
        public static string adress;
        public static float money;
        public static ProductEntity[] shoppingCart;
    }
}
