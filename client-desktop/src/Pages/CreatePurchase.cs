using client_desktop.Product.Entities;
using client_desktop.Product.Requests;
using client_desktop.src.Product.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_desktop.Pages
{
    public partial class CreatePurchase : Form
    {
        public CreatePurchase()
        {
            InitializeComponent();
        }
        float value = 0;

        private async void CreatePurchase_Load(object sender, EventArgs e)
        {
            foreach (ItensPurchase item in ShoppingCart.products)
            {
                productGET request = new productGET();
                Task<object> task = request.GetProduct(item.fk_product_id);
                object result = await task;
                if (result is ProductEntity product)
                {
                    value += product.price;
                    dataGridView1.Rows.Add(product.name, product.price, product.description);
                }
            }
            label1.Text = $"Valor Total: R$ {value}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.products.Count > 0)
            {
                DialogResult result = MessageBox.Show("Você perderá todas as compras no carrinho. Deseja continuar?", "Confirmação", MessageBoxButtons.OKCancel);
                bool confirm = (result == DialogResult.OK);
                if (confirm)
                {
                    ShoppingCart.products.Clear();
                    HOME.ids.Clear();
                    HOME nw = new HOME();
                    nw.Show();
                    Hide();
                }
            } else
            {
                HOME nw = new HOME();
                nw.Show();
                Hide();
            }

        }
    }
}
