using System;
using System.Windows.Forms;
using System.Xml.Linq;
using client_desktop.src.Product;
using client_desktop.User.Entities;

namespace client_desktop.Pages
{
    public partial class CreateProduct : Form
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            float price;
            int qnt;
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || !float.TryParse(txtPrice.Text, out price) || !int.TryParse(textBox1.Text, out qnt))
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.", "Erro ao Criar Produto");
                return;
            }

            ProductService productService = new ProductService();
            string result = productService.CreateProduct(name, price, description, UserStatic.email, qnt);

            if (result == "Produto criado com sucesso!")
            {
                MessageBox.Show(result, "Sucesso");
                HOME nw = new HOME();
                nw.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(result, "Erro");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HOME nw = new HOME();
            nw.Show();
            Hide();
        }
    }
}
