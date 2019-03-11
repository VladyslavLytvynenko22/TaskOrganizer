using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.IO.Ports;
//using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using WCF_TaskOrganizer;

namespace ServerTaskOrganizer
{
    public partial class Form1 : Form
    {
        private ServiceHost host;
        private WCF_TaskOrganizer.WCF_TaskOrganizer task;
        private int port;
        private string Ip;
        public Form1()
        {
            InitializeComponent();
        }

        private int ReturnPort()//шукаємо вільний порт
        {
            IPGlobalProperties igp = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tinfo = igp.GetActiveTcpConnections();
            int i = 1000;//почнемо шукати порт з 1000
            foreach (TcpConnectionInformation tcpi in tinfo)
            {
                if (tcpi.LocalEndPoint.Port != i)//якщо мій порт не співпадає з тим який вже використовується
                {
                    return i;//повертаємо цей порт
                }i++;
            }
            return 0;
        }
        
        private void OpenPort()//відкриваємо порт на вхід в брандмауері
        {
            try
            {
                string parameters = @"advfirewall firewall add rule " +
                                     "name=\"{0}\" " +
                                     "dir={1} " +
                                     "action={2} " +
                                     "protocol={3} " +
                                     "localport={4}";
                 string rulename = $"Custom TCP rule for ServicesTaskOrganizer port {port}";
                 string direction = "in";
                 string action = "allow";
                 string protocol = "TCP";
                 int localport = port;
                 ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\netsh.exe");
                 info.Arguments = String.Format(parameters, rulename, direction, action, protocol, localport);
                 var process = Process.Start(info);//створимо правило в брандмауері для нашого порта
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
        }

        private void ClosePort()
        {
            try
            {
                string parameters = "advfirewall firewall delete rule name=\"{0}\"";
                string rulename = $"Custom TCP rule for ServicesTaskOrganizer port {port}";
                ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\netsh.exe");
                info.Arguments = String.Format(parameters, rulename);
                var process = Process.Start(info);//видалимо правило в брандмауері для нашого порта (для безпеки)
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
        }//видаляємо правило для порта

        public void GetLocalIPAddress()// шукаємо вільний порт і IP адрес
        {
            try
            {
                port = Convert.ToInt32(ReturnPort());//шукаэмо вільний порт
                richTextBox1.Clear();
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)//нашы IP
                    {
                        Ip = ip.ToString();//запоминаємо IP
                        richTextBox1.Text += $"{ip.ToString()}:{port}\n";//показуэмо доступні IP
                    }
                }
            }
            catch (Exception ex){MessageBox.Show(ex.ToString());}
        }
        
        private void StartHost()//запускання хосту
        {
            try
            {
                OpenPort();//відкриваємо порт в правилах брандмауера
                Uri baseAddress = new Uri($"http://{Ip}:{port}/");
                host = new ServiceHost(typeof(WCF_TaskOrganizer.WCF_TaskOrganizer), baseAddress);
                host.Open();//запускаємо хост
                butStarttHost.Enabled = false;
                butStopHost.Enabled = true;
                this.TextStatus.Text += "Host started...\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
        }

        private void StopHost()//зупинення хосту
        {
            try
            {
                ClosePort();//видаляэмо правило з брандмауера
                host.Close();
                butStopHost.Enabled = false;
                butStarttHost.Enabled = true;
                this.TextStatus.Text += "Host stoped...\n";
            }
            catch (Exception ex){MessageBox.Show(ex.ToString());}
        }//зупинення хосту

       /* private void CreateFile()
        {
            try
            {
                FileStream fstream = new FileStream(@"C:\SomeDir\noname\note.txt", FileMode.Create);

                byte[] array = System.Text.Encoding.Default.GetBytes("text");
                fstream.Write(array, 0, array.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error create file config for database");

            }
        }

        private void OpenFile()
        {
            try
            {
                FileStream fstream = File.OpenRead(@"C:\SomeDir\noname\note.txt");

                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                
            }
            catch (Exception ex)
            {
                CreateFile();
            }
        }*/
        private void StartConnectToDb()
        {
            try
            {
                //OpenFile();
                task = new WCF_TaskOrganizer.WCF_TaskOrganizer();
                if (!task.ConnectToDb()) Application.Exit();
                this.TextStatus.Text += "Database connected...\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
        }//підключення до бази данних

        private void StopConnectToDb()
        {
            task.DisconnectFromDb();
        }//відключення від бази данних

        private void Form1_Load(object sender, EventArgs e)
        {
            GetLocalIPAddress();//беремо IP та вільний порт
            StartHost();//запускаємо 
            StartConnectToDb();
        }
        
        private void butStopHost_Click(object sender, EventArgs e)
        {
            ClosePort();
            StopConnectToDb();
            StopHost();
        }

        private void butStartHost_Click(object sender, EventArgs e)
        {
            GetLocalIPAddress();
            StartHost();
            StartConnectToDb();
        }
    }
}
