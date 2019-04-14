using System;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ServerTaskOrganizer
{
    static class Port
    {
        static internal int port = -1;
        static internal int ReturnPort()//шукаємо вільний порт
        {
            IPGlobalProperties igp = IPGlobalProperties.GetIPGlobalProperties();
            System.Net.IPEndPoint[] tinfo = igp.GetActiveTcpListeners();
            bool OK = false;
            for (int i = 1000; i<65534; i++)//почнемо шукати ще не активні порти починаючи з 1000
            {
                OK = true;
                foreach (System.Net.IPEndPoint tcpi in tinfo)
                {
                    if (tcpi.Port == i) OK = false;
                }
                if (OK) return i;
            }
            return -1;
        }

        static internal bool OpenPort()//відкриваємо порт на вхід в брандмауері
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
                ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\netsh.exe")
                {
                    Arguments = String.Format(parameters, rulename, direction, action, protocol, localport)
                };
                var process = Process.Start(info);//створимо правило в брандмауері для нашого порта
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error open port!");
                return false;
            }
            return true;
        }

        static internal bool ClosePort()//видаляємо правило для порта
        {
            try
            {
                string parameters = "advfirewall firewall delete rule name=\"{0}\"";
                string rulename = $"Custom TCP rule for ServicesTaskOrganizer port {port}";
                ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\netsh.exe")
                {
                    Arguments = String.Format(parameters, rulename)
                };
                var process = Process.Start(info);//видалимо правило в брандмауері для нашого порта (для безпеки)
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error close port!");
                return false;
            }
            return true;
        }
    }
}
