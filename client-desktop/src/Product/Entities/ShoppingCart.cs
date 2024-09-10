using System.Collections.Generic;
using client_desktop.Product.Entities;
using client_desktop.src.Product.Entities;
using client_desktop.User.Entities;

namespace client_desktop.src.Product.Entities
{
    public class ShoppingCart
    {
        static public string fk_user_email = UserStatic.email;
        static public List<ProductEntity> products = new List<ProductEntity>();
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

public class PurchaseRequest
{
    public string fk_user_email = UserStatic.email;
    public List<ProductEntity> products = ShoppingCart.products;
}