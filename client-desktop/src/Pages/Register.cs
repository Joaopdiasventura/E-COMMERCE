using client_desktop.Models;
using client_desktop.src.User.Entities;
using client_desktop.user.Requests;
using client_desktop.User.Entities;
using client_desktop.User.Requests;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_desktop.Pages
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        Boolean isCepVerifi = false;
        string cep = "";

        private async void button1_Click(object sender, EventArgs e)
        {
            userGET request = new userGET();
            Task<object> resultTask = request.FindAdress(cepInput.Text);
            object result = await resultTask;
            if (result is Adress)
            {
                Adress adress = (Adress)result;
                cepLabel.Text = $"{adress.street} - {adress.neighborhood} - {adress.city}";
                isCepVerifi = true;
                cep = cepInput.Text;
                return;
            }
            Msg message = (Msg)result;
            string msg = message.msg;
            MessageBox.Show(msg, "ERRO AO VERIFICAR O CEP");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!isCepVerifi)
            {
                MessageBox.Show("VERIFIQUE SEU CEP ANTES DE SE REGISTRAR", "ERRO AO SE REGISTRAR");
                return;
            }
            if (nameInput.Text.Trim() == "" || emailInput.Text.Trim() == "" || passwordInput.Text.Trim() == "" || numberInput.Text.Trim() == "")
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS ANTES DE SE REGISTRAR", "ERRO AO SE REGISTRAR");
                return;
            }
            userPOST request = new userPOST();
            Task<object> task = request.Register(emailInput.Text, nameInput.Text, passwordInput.Text, (cep + numberInput.Text));
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

        private void button3_Click(object sender, EventArgs e)
        {
            HOME nw = new HOME();
            nw.Show();
            Hide();
        }
    }
}
