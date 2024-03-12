using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace client_desktop
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private async void home_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:3000/product";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);

                    Product[] data = JsonConvert.DeserializeObject<Product[]>(jsonResponse);

                    for (int i = 0; i < data.Length; i++)
                    {
                        Console.WriteLine(data[i]);
                        dataGridView1.Rows.Add(data[i].name, data[i].description, data[i].price);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO AO RECEBER OS PRODUTOS");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addProd nt = new addProd();
            nt.Show();
            this.Hide();
        }
    }
}
