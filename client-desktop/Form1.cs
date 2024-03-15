using client_desktop.Pages;
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

        private void HOME_Load(object sender, EventArgs e)
        {
            if (File.Exists("user.json"))
            {
                string savedJson = File.ReadAllText("user.json");
                UserEntity savedUser = JsonConvert.DeserializeObject<UserEntity>(savedJson);

                UserStatic.email = savedUser.email;
                UserStatic.name = savedUser.name;
                UserStatic.password = savedUser.password;
                UserStatic.adress = savedUser.adress;
                UserStatic.money = savedUser.money;
                label1.Text = UserStatic.name + " " + UserStatic.email;
            }
        }
    }
}
