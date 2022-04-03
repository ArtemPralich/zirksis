using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{
    public class Server
    {
        private string _name = "";

        private int _localPort { get; set; }

        private string _remoteAddress { get; set; }

        private int _remotePort { get; set; }

        private string _filePath { get; set; }

        public Server(int localPort, string remoteAddress, int remotePort, string name, string filePath)
        {
            _localPort = localPort;
            _remoteAddress = remoteAddress;
            _remotePort = remotePort;
            _name = name;
            _filePath = filePath;

            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start();

            //Task receiveTask1 = new Task(this.ReceiveMessage);
            //receiveTask1.Start();
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
                    Console.WriteLine(this._name + " received: " +  message);
                    int countWords = this.FindInFile(message);
                    if (countWords != -1)
                    {
                        this.SendMessage(this._name + " found: " +  countWords);
                    }
                    else
                    {
                        this.SendMessage("Error in " + this._name);
                    }
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

        public void SendMessage(string message)
        {
            UdpClient sender = new UdpClient();
            try
            {
                //while (true)
                {
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, _remoteAddress, _remotePort);

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

        public int FindInFile(string message)
        {
            int countWord = 0;
            try
            {
                string text = "";
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    text = reader.ReadToEnd();
                }
                var words = text.Split(' ', '.', ',', ';', ':');

                foreach (var word in words)
                {
                    if (word == message) countWord++;
                }

            }
            catch
            {
                return -1;
            }

            return countWord;
        }
    }
}
