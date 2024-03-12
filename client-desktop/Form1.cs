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

namespace client_desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register nt = new register();
            nt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login nt = new login();
            nt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home nt = new home();
            nt.Show();
            this.Hide();
        }
    }
}
