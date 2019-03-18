using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace ServerTaskOrganizer
{
    static class Host
    {
        static internal ServiceHost host;
        static internal bool StartHost(ref Button butStarttHost, Button butStopHost, RichTextBox textBoxStatus)//запускання хосту
        {
            if (!Port.OpenPort())//відкриваємо порт в правилах брандмауера
                return false;
            Uri baseAddress = new Uri($"http://{IP.ip}:{Port.port}/");
            host = new ServiceHost(typeof(WCF_TaskOrganizer.WCF_TaskOrganizer), baseAddress);

            try
            {
                host.Open();//запускаємо хост
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error start host!");
                return false;
            }
            butStarttHost.Enabled = false;
            butStopHost.Enabled = true;
            textBoxStatus.Text += "Host started...\n";

            return true;
        }

        static internal bool StopHost(ref Button butStarttHost, Button butStopHost, RichTextBox textBoxStatus)//зупинення хосту
        {
            if (!Port.ClosePort())//видаляэмо правило з брандмауера
                return false;
            try
            {
                host.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error close host!");
                return false;
            }

            butStopHost.Enabled = false;
            butStarttHost.Enabled = true;
            textBoxStatus.Text += "Host stoped...\n";

            return true;
        }
    }
}
