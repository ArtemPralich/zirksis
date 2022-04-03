using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public class Client
    {
        private string _name = "";

        private int _localPort { get; set; }

        private string _remoteAddress { get; set; }

        public Client(int localPort, string remoteAddress, string name)
        {
            _localPort = localPort;
            _remoteAddress = remoteAddress;
            _name = name;

            Task receiveTask = new Task(this.ReceiveMessage);
            receiveTask.Start();
        }

        public void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(_localPort);
            IPEndPoint remoteIp = null;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine(this._name + " received: " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        public void SendMessage(string message, int remotePort)
        {
            UdpClient sender = new UdpClient();
            try
            {
                //while (true)
                {
                    Console.WriteLine(message);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, _remoteAddress, remotePort);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }
    }
}
