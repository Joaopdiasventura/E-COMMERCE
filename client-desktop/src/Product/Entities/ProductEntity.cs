using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.Product.Entities
{
    public class ProductEntity
    {
        public int id;
        public string name;
        public string description;
        public float price;
        public string fk_user_email;
    }
}
