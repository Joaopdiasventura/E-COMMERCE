using client_desktop.Models;
using client_desktop.Pages;
using client_desktop.src.User.Entities;
using client_desktop.user.Requests;
using client_desktop.User.Entities;
using client_desktop.User.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_desktop
{
    public partial class HOME : Form
    {
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

         private async void HOME_Load(object sender, EventArgs e)
        {
            if (File.Exists("user.json"))
            {
                string savedJson = File.ReadAllText("user.json");
                TokenEntity Token = JsonConvert.DeserializeObject<TokenEntity>(savedJson);
                userGET request = new userGET();
                Task<object> task = request.Decode(Token.token);
                object result = await task;
                if (result is UserEntity savedUser)
                {
                    UserStatic.email = savedUser.email;
                    UserStatic.name = savedUser.name;
                    UserStatic.password = savedUser.password;
                    UserStatic.adress = savedUser.adress;
                    UserStatic.money = savedUser.money;
                    label1.Text = $"Olá {UserStatic.name}";
                    return;
                }
                Msg message = (Msg)result;
                string msg = message.msg;
                MessageBox.Show(msg, "ERRO AO VERIFICAR SE REGISTRAR");
            }
            else
            {
                label1.Text = "Faça login para adicionar um produto no carrinho";
                button3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World");
        }
    }
}
