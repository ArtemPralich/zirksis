using System;
using System.Threading.Tasks;
using Servers;

namespace zirksis_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(8001, "127.0.0.1", "client");
            Server server1 = new Server(8002, "127.0.0.1", 8001, "server1", "C:\\study\\zirksis\\zirksis-2\\zirksis-2\\server1.txt");
            Server server2 = new Server(8003, "127.0.0.1", 8001, "server2", "C:\\study\\zirksis\\zirksis-2\\zirksis-2\\server2.txt");
            Server server3 = new Server(8004, "127.0.0.1", 8001, "server3", "C:\\study\\zirksis\\zirksis-2\\zirksis-2\\server3.txt");

            
            client.SendMessage("qwe", 8002);
            client.SendMessage("asd", 8003);
            client.SendMessage("zxc", 8004);

            
        }
    }
}
