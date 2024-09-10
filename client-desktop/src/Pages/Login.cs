using client_desktop.user.service;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.IO;
using client_desktop.User.Entities;

namespace client_desktop.Pages
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailInput.Text.Trim() == "" || passwordInput.Text.Trim() == "")
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS ANTES DE SE REGISTRAR", "ERRO AO SE REGISTRAR");
                return;
            }

            UserService userService = new UserService();
            UserEntity user = userService.Login(emailInput.Text, passwordInput.Text);

            if (user != null)
            {
                string filePath = "user.json";
                string json = JsonConvert.SerializeObject(new { user.email });
                File.WriteAllText(filePath, json);

                HOME nw = new HOME();
                nw.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos", "ERRO AO FAZER LOGIN");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME nw = new HOME();
            nw.Show();
            Hide();
        }
    }
}
