using System;
using System.Windows.Forms;

namespace ServerTaskOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!IP.GetLocalIPAddress(ref richTextBox1) ||
                !Host.StartHost(ref butStarttHost, butStopHost, textBoxStatus))
            {
                Application.Exit();
            }
        }
        
        private void butStopHost_Click(object sender, EventArgs e)
        {
            Port.ClosePort();
            Host.StopHost(ref butStarttHost, butStopHost, textBoxStatus);
        }

        private void butStartHost_Click(object sender, EventArgs e)
        {
            if(IP.GetLocalIPAddress(ref richTextBox1))
                Host.StartHost(ref butStarttHost, butStopHost, textBoxStatus);
        }
    }
}
