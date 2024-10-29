using client_desktop.Models;
using client_desktop.user.service;
using client_desktop.User.Entities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace client_desktop.Pages
{
    public partial class Register : Form
    {

        readonly UserService request = new UserService();
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nameInput.Text.Trim() == "" || emailInput.Text.Trim() == "" || passwordInput.Text.Trim() == "")
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS ANTES DE SE REGISTRAR", "ERRO AO SE REGISTRAR");
                return;
            }
            string task = request.Register(emailInput.Text, nameInput.Text, passwordInput.Text);
            if (task != null)
            {
                MessageBox.Show(task, "Boa");
                string filePath = "user.json";
                string json = JsonConvert.SerializeObject( new { email = emailInput.Text } );
                File.WriteAllText(filePath, json);
                HOME nw = new HOME();
                nw.Show();
                Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HOME nw = new HOME();
            nw.Show();
            Hide();
        }
    }
}
