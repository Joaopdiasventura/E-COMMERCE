using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Security.Policy;

namespace client_desktop
{
    public partial class addProd : Form
    {
        public addProd()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            user User = JsonConvert.DeserializeObject<user>(UserContext.UserInfo);
            HttpClient client = new HttpClient();
            string url = "http://localhost:3000/product";
            try
            {
                var data = new Dictionary<string, string >
                    {
                        { "name", textBox1.Text },
                        { "description", textBox2.Text },
                        { "price", textBox3.Text},
                        { "quantity", textBox4.Text},
                        { "fk_user_email", User.email }
                    }; 
                HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(data));

                if (response.IsSuccessStatusCode)
                {
                    home nt = new home();
                    nt.Show();
                    this.Hide();
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "ERRO AO ADICIONAR PRODUTO");
            }
        }
    }
}
