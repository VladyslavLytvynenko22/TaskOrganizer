using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerTaskOrganizer
{
    static class IP
    {
        static internal string ip = null;
        static public bool GetLocalIPAddress(ref RichTextBox richTextBox1)// шукаємо вільний порт і IP адрес
        {
            try
            {
                Port.port = Convert.ToInt32(Port.ReturnPort());//шукаэмо вільний порт
                if (Port.port < 0) throw new ArgumentException("Port cannot be less than zero!");
                richTextBox1.Clear();
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var i in host.AddressList)
                {
                    if (i.AddressFamily == AddressFamily.InterNetwork)//наші IP
                    {
                        ip = i.ToString();//запоминаємо IP
                        richTextBox1.Text += $"{i.ToString()}:{Port.port}\n";//показуємо доступні IP
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
