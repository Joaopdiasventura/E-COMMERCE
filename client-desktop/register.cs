using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static client_desktop.user;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client_desktop
{
    public partial class register : Form
    {
        bool verifiedAddress = false;
        public register()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (verifiedAddress == false)
            {
                MessageBox.Show("Verifique seu CEP antes de se registrar");
                return;
            }
            if (name.Text.Trim().Length == 7 && email.Text.Trim().Length == 7 && password.Text.Trim().Length == 0 && adress.Text.Trim().Length == 0 && numberAdress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Preeencha todos os campos", "Erro ao realizar o registro");
                return;
            }
            try
            {
                HttpClient client = new HttpClient();
                {
                    string url = "http://localhost:3000/user/register";

                    var data = new Dictionary<string, string>
                    {
                        { "name", name.Text }, 
                        { "email", email.Text },
                        { "password", password.Text },
                        { "adress", adress.Text + numberAdress.Text }
                    };

                    HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(data));

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        if (jsonResponse.StartsWith("{\"name\":"))
                        {
                            UserContext.UserInfo = jsonResponse;

                            MessageBox.Show("Registro realizado com sucesso!");
                            verifiedAddress = false;
                            Form1 nt = new Form1();
                            nt.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar o registro. Status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "ERRO AO REALIZAR O REGISTRO");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cep = adress.Text;
            if (cep != null && cep.Trim().Length == 8)
            {
                FindCep(cep);
            }
            else
            {
                MessageBox.Show("Adicione um CEP válido antes de verificá-lo");
            }
        }

        private async void FindCep(string cep)
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync($"http://localhost:3000/adress/find/{cep}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    string[] data = JsonConvert.DeserializeObject<string[]>(jsonResponse);

                    this.response.Text = data[0] + " - " + data[2];
                    verifiedAddress = true;
                }
                else
                {
                    MessageBox.Show("Erro ao realizar o registro. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO AO REALIZAR O REGISTRO");
            }
        }
    }
}
