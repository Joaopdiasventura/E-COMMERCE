using client_desktop.Models;
using client_desktop.User.Entities;
using client_desktop.user.Requests;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using client_desktop.src.User.Entities;

namespace client_desktop.Pages
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (emailInput.Text.Trim() == "" || passwordInput.Text.Trim() == "")
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS ANTES DE SE REGISTRAR", "ERRO AO SE REGISTRAR");
                return;
            }
            userPOST request = new userPOST();
            Task<object> task = request.Login(emailInput.Text, passwordInput.Text);
            object result = await task;
            if (result is TokenEntity user)
            {
                string filePath = "user.json";
                string json = JsonConvert.SerializeObject(user);
                File.WriteAllText(filePath, json);
                HOME nw = new HOME();
                nw.Show();
                Hide();
                return;
            }
            Msg message = (Msg)result;
            string msg = message.msg;
            MessageBox.Show(msg, "ERRO AO VERIFICAR SE REGISTRAR");
        }
    }
}
