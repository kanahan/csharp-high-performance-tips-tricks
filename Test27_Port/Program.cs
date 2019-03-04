using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Benchmarking;

namespace Test27_Port
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int MAX_PORT = 5;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            const uint NoOfIteration = 1;

            Profiler.Profile("Normal Scan", NoOfIteration, () =>
            {
                List<int> openedPorts = new List<int>();
                for (int port = 1; port < MAX_PORT; port++)
                {
                    Console.Write("*");
                    try
                    {
                        socket.Connect(host, port);
                        openedPorts.Add(port);
                    }
                    catch (Exception)
                    {

                    }
                }
                Console.WriteLine("Opened Ports: ");
                foreach (var port in openedPorts) Console.Write("{0}\t", port);
            });

            if (socket?.Connected ?? false)
            {
                socket?.Disconnect(false);
            }
            socket?.Close();
        }
    }
}
