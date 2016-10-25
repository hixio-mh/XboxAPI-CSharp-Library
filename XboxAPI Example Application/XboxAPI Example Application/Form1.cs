using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using XboxAPI;

namespace XboxAPI_Example_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("credentials.txt"))
            {
                textBox1.Text = File.ReadAllText("credentials.txt");
                XAPI.SetXboxAPIKey(textBox1.Text);
            }
                
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var resp = await XAPI.GetMyProfile();
            MessageBox.Show($"Profile for gamertag: {resp.GamerTag}\n\nName: {resp.FirstName} {resp.LastName}\nEmail: {resp.Email}\nCountry: {resp.HomeAddressInfo.Country}");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var resp = await XAPI.GetMyAccountXuid();
            MessageBox.Show($"Xuid: {resp.XUID}\nGamerTag1: {resp.GamerTag1}\nGamerTag2: {resp.GamerTag2}");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var resp = await XAPI.GetMyMessages();
            foreach (var message in resp)
                MessageBox.Show($"Message from: {message.Header.Sender}\nSummary: {message.Summary}");
        }
    }
}
