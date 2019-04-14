using System;
using System.Drawing;
using System.Windows.Forms;
using TaskOrganizer;

namespace ServerTaskOrganizer
{
    public partial class HostTaskOrganizer : Form
    {
        public HostTaskOrganizer()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            butStarttHost.BackColor = Color.Green;
            butStopHost.BackColor = Color.Red;
            if(!IP.GetLocalIPAddress(ref richTeBoxIPandPort) ||
                !Host.StartHost(ref butStarttHost, butStopHost, textBoxStatus))
            {
                Application.Exit();
            }
        }
        
        private void butStopHost_Click(object sender, EventArgs e)//кнопка зупинити хост
        {
            Host.StopHost(ref butStarttHost, butStopHost, textBoxStatus);
        }

        private void butStartHost_Click(object sender, EventArgs e)//кнопка запустити хост
        {
            if(IP.GetLocalIPAddress(ref richTeBoxIPandPort))
                Host.StartHost(ref butStarttHost, butStopHost, textBoxStatus);
        }

        private void HostTaskOrganizer_FormClosing(object sender, FormClosingEventArgs e)//якщо закриваємо вікно то зупиняємо хост
        {
            Host.StopHost(ref butStarttHost, butStopHost, textBoxStatus);
        }

        private void butSaveConnectDatabaseName_Click(object sender, EventArgs e)//зберігаємо налаштування підключення до БД
        {
            ConfigConnectDatabase configConnectDatabase = new ConfigConnectDatabase(textBoxServerName.Text, teBoxDatabeseName.Text, texBoxTableName.Text);
            Database.SaveConfigConnectDatabase(configConnectDatabase);
        }
    }
}
