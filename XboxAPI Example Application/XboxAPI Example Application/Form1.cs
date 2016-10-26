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
            MessageBox.Show("This application is intended to demonstrate basic functionality of XboxAPI C# Library.\n\n-swiftyspiffy");

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var resp = await XAPI.GetMyAccountProfile();
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

        private async void button5_Click(object sender, EventArgs e)
        {
            var resp = await XAPI.GetMyConversations();
            foreach (var conversation in resp)
                MessageBox.Show($"Conversation with: {conversation.SenderGamerTag}\n Last Message: {conversation.LastMessage.MessageText}");
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
                var resp = await XAPI.GetXuidFromGamertag(textBox2.Text);
                MessageBox.Show($"Gamertag: {resp.GamerTag1}\nXuid: {resp.XUID}");
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
                MessageBox.Show($"Gmaertag from XUID '{textBox3.Text}' is:\n{await XAPI.GetGamertagFromXuid(textBox3.Text)}");
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Length > 0)
            {
                var resp = await XAPI.GetProfileFromXuid(textBox4.Text);
                MessageBox.Show($"Gamertag: {resp.GamerTag}\nGamerscore: {resp.Gamerscore}\nAccount Tier: {resp.AccountTier}\nXbox One Rep: {resp.XboxOneRep}\nTenure Level: {resp.TenureLevel}");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if(textBox5.Text.Length > 0)
            {
                var resp = await XAPI.GetGamercardFromXuid(textBox5.Text);
                MessageBox.Show($"Gamertag: {resp.GamerTag}\nName: {resp.Name}\nLocation: {resp.Location}\nBio: {resp.Bio}\nMotto: {resp.Motto}");
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            if(textBox6.Text.Length > 0)
            {
                var resp = await XAPI.GetPresenceFromXuid(textBox6.Text);
                MessageBox.Show($"XUID: {resp.XUID}\nState: {resp.State}\nLast Seen on: {resp.LastSeen.DeviceType}\nTitle Id: {resp.LastSeen.TitleId}\n TitleName: {resp.LastSeen.TitleName}\nTimeStamp: {resp.LastSeen.TimeStamp}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XAPI.SetXboxAPIKey(textBox1.Text);
        }
    }
}
