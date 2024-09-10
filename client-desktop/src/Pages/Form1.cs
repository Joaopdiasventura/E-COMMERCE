using client_desktop.Pages;
using client_desktop.Product.Entities;
using client_desktop.src.Product;
using client_desktop.src.Product.Entities;
using client_desktop.user.service;
using client_desktop.User.Entities;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace client_desktop
{
    public partial class HOME : Form

    {
        public static List<ProductEntity> products = new List<ProductEntity>();
        public static List<int> ids = new List<int>();

        public HOME()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login nw = new Login();
            nw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register nw = new Register();
            nw.Show();
            Hide();
        }

         private void HOME_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            GetProducts();
            GetUser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                object idCellValue = dataGridView1.Rows[rowIndex].Cells["id"].Value;
                dataGridView1.ClearSelection();

                if (idCellValue != null && int.TryParse(idCellValue.ToString(), out int id))
                {
                    ShoppingCart.products.Add(products.Find((prod) => prod.id == id));
                    products.RemoveAll(prod => prod.id == id);
                    ids.Add(id);

                    dataGridView1.Rows.Clear();
                    string lastName = "";
                    float lastPrice = 0;

                    foreach (var product in products)
                    {
                        string name = product.name;
                        float price = product.price;
                        int Id = product.id;

                        if (lastName != name && lastPrice != price && product.fk_purchase_id == null)
                        {
                            dataGridView1.Rows.Add(Id, name, price);
                            lastName = name;
                            lastPrice = price;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("SELECIONE UM PRODUTO");
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            CreateProduct nw = new CreateProduct();
            nw.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreatePurchase nw = new CreatePurchase();
            nw.Show();
            Hide();
        }

        private void GetUser()
        {
            if (File.Exists("user.json"))
            {
                string savedJson = File.ReadAllText("user.json");
                UserEntity savedUser = JsonConvert.DeserializeObject<UserEntity>(savedJson);

                if (savedUser != null && !string.IsNullOrEmpty(savedUser.email))
                {
                    UserService userService = new UserService();
                    UserEntity user = userService.findByEmail(savedUser.email);

                    if (user != null)
                    {
                        UserStatic.email = user.email;
                        UserStatic.name = user.name;
                        UserStatic.password = user.password;
                        UserStatic.adress = user.adress;
                        UserStatic.money = user.money;

                        label1.Text = $"Olá {UserStatic.name}, R$ {UserStatic.money}";
                        button3.Visible = true;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado. Faça login novamente.", "Erro ao carregar usuário");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao ler os dados do usuário. Faça login novamente.", "Erro");
                }
            }
            else
            {
                label1.Text = "Faça login para adicionar um produto no carrinho";
                button3.Visible = false;
            }
        }


        private void GetProducts()
        {
            ProductService service = new ProductService();
            List<ProductEntity> result = service.GetProducts();
            string lastName = "";
            float lastPrice = 0;

            foreach (var product in result)
            {
                string name = product.name;
                float price = product.price;
                int id = product.id;
                products.Add(product);

                if (lastName != name && lastPrice != price && product.fk_purchase_id == null)
                {
                    dataGridView1.Rows.Add(id, name, price);
                    lastName = name;
                    lastPrice = price;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CreateProduct nw = new CreateProduct();
            nw.Show();
            Hide();
        }
    }
}
