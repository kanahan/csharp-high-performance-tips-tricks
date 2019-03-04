using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace Test27_Async_Port
{
    class Program
    {
        static List<int> openedPorts = new List<int>();

        static void ScanPort(Socket socket, int port)
        {
            Console.Write(port + ",");
            string host = "127.0.0.1";
            try
            {
                socket.Connect(host, port);
                openedPorts.Add(port);
            }
            catch (Exception)
            {

            }
        }

        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            List<Thread> t = new List<Thread>();

            for (int i = 1; i <= 600; i++)
            {
                int range = 20;
                int start = i * range - (range - 1);
                int max = i * range;

                Thread t1 = new Thread(() => {
                    for (int port = start; port <= max; port++)
                    {
                        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                        {
                            ScanPort(socket, port);
                        }
                    }
                });
                t1.Start();
                t.Add(t1);
            }

            Console.WriteLine(t.Count);
            foreach(var t1 in t)
            {
                t1.Join();
            }

            Console.WriteLine("");
            Console.Write("Opened Ports: ");
            foreach (var port in openedPorts) Console.Write("{0},", port);
            Console.WriteLine("");

            double elapsedTime = watch.Elapsed.TotalMilliseconds;
            watch.Stop();
            Console.WriteLine("{0,-40}\t{1,15:n} ms", "Scan", elapsedTime);
        }
    }
}
