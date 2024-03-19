using System.Collections.Generic;
using client_desktop.User.Entities;

namespace client_desktop.src.Product.Entities
{
    internal class ShoppingCart
    {
        static public string fk_user_email = UserStatic.email;
        static public List<ItensPurchase> products = new List<ItensPurchase>();
    }
}

public class ItensPurchase
{
    public int fk_product_id;
    public ItensPurchase(int id)
    {
        fk_product_id = id;
    }
}