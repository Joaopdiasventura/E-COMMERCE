using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace client_desktop
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (email.Text.Trim().Length == 7 && password.Text.Trim().Length == 0)
            {
                MessageBox.Show("Preeencha todos os campos", "Erro ao realizar o login");
                return;
            }
            try
            {
                HttpClient client = new HttpClient();
                {
                    string url = "http://localhost:3000/user/login";

                    var data = new Dictionary<string, string>
                    {
                        { "email", email.Text },
                        { "password", password.Text }
                    };

                    HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(data));

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        if (jsonResponse.StartsWith("{\"name\":"))
                        {
                            UserContext.UserInfo = jsonResponse;

                            MessageBox.Show("Login realizado com sucesso!");
                            home nt = new home();
                            nt.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar o login. Status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "ERRO AO REALIZAR O REGISTRO");
            }
        }
    }
}
