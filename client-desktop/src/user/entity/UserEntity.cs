using client_desktop.Product.Entities;

namespace client_desktop.User.Entities
{
    public class UserEntity
    {
        public string email;
        public string name;
        public string password;
        public float money;
        public bool isAdm;
    }

    public class UserStatic
    {
        public static string email;
        public static string name;
        public static string password;
        public static float money;
        public static ProductEntity[] shoppingCart;
    }
}
