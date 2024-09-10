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

        Boolean isCepVerifi = false;
        string cep = "";

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<object> resultTask = request.FindAdress(cepInput.Text);
            object result = await resultTask;
            if (result is Adress adress)
            {
                cepLabel.Text = $"{adress.street} - {adress.neighborhood} - {adress.city}";
                isCepVerifi = true;
                cep = cepInput.Text;
                return;
            }
            Msg message = (Msg)result;
            string msg = message.msg;
            MessageBox.Show(msg, "ERRO AO VERIFICAR O CEP");
        }

        private void button2_Click(object sender, EventArgs e)
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
            string task = request.Register(emailInput.Text, nameInput.Text, passwordInput.Text, (cep + numberInput.Text));
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
