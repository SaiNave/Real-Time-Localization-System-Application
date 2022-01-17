using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
    
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread Client1 = new Thread(new ThreadStart(client_1));
            Client1.Start();

            Thread Client2 = new Thread(new ThreadStart(client_2));
            Client2.Start();

            Thread Client3 = new Thread(new ThreadStart(client_3));
            Client3.Start();

            Thread Client4 = new Thread(new ThreadStart(client_4));
            Client4.Start();

            Thread Client5 = new Thread(new ThreadStart(client_5));
            Client5.Start();

            Thread Client6 = new Thread(new ThreadStart(client_6));
            Client6.Start();

            Thread Client7 = new Thread(new ThreadStart(client_7));
            Client7.Start();

            Thread Client8 = new Thread(new ThreadStart(client_8));
            Client8.Start();

        }

        static void client_1()
        {
            StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_1.txt");
            string line;

            

            while ((line = file.ReadLine()) != null)
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect("127.0.0.1", 1001);

                Console.WriteLine(line);
                Byte[] data = Encoding.ASCII.GetBytes(line);

                Console.WriteLine("thread1");
                //Console.WriteLine("Transmitting....");
                udpClient.Send(data, data.Length);
                System.Threading.Thread.Sleep(10);

                udpClient.Close();
            }
        }

        static void client_2()
        {
            StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_2.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect("127.0.0.1", 1002);

                Console.WriteLine(line);
                Byte[] data = Encoding.ASCII.GetBytes(line);

                Console.WriteLine("thread2");
                udpClient.Send(data, data.Length);
                System.Threading.Thread.Sleep(10);

                udpClient.Close();
            }
        }

        static void client_3()
        {
            StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_3.txt");
            string line;
           
            while ((line = file.ReadLine()) != null)
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect("127.0.0.1", 1003);

                Console.WriteLine(line);
                Byte[] data = Encoding.ASCII.GetBytes(line);

                Console.WriteLine("thread3");
                udpClient.Send(data, data.Length);
                System.Threading.Thread.Sleep(10);

                udpClient.Close();
            }
        }

            static void client_4()
            {
                StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_4.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Connect("127.0.0.1", 1004);

                    Console.WriteLine(line);
                    Byte[] data = Encoding.ASCII.GetBytes(line);

                    Console.WriteLine("thread4");
                    udpClient.Send(data, data.Length);
                    System.Threading.Thread.Sleep(10);

                    udpClient.Close();
                }
            }

            static void client_5()
            {
                StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_5.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Connect("127.0.0.1", 1005);

                    Console.WriteLine(line);
                    Byte[] data = Encoding.ASCII.GetBytes(line);

                     Console.WriteLine("thread5");
                    udpClient.Send(data, data.Length);
                    System.Threading.Thread.Sleep(10);

                    udpClient.Close();
                }
            }

            static void client_6()
            {
                StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_6.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Connect("127.0.0.1", 1006);

                    Console.WriteLine(line);
                    Byte[] data = Encoding.ASCII.GetBytes(line);

                    Console.WriteLine("thread6");
                    udpClient.Send(data, data.Length);
                    System.Threading.Thread.Sleep(10);

                    udpClient.Close();
                }
            }

            static void client_7()
            {
                StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_7.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Connect("127.0.0.1", 1007);

                    Console.WriteLine(line);
                    Byte[] data = Encoding.ASCII.GetBytes(line);

                    Console.WriteLine("thread7");
                    udpClient.Send(data, data.Length);
                    System.Threading.Thread.Sleep(10);

                    udpClient.Close();
                }
            }

            static void client_8()
            {
                StreamReader file = new StreamReader(@"C:\Users\saira\Documents\Visual Studio 2017\Projects\Working Folder\Working_Folder_UDP\Clients\Multi_Clients\ConsoleApp1\ConsoleApp1\file24_8.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Connect("127.0.0.1", 1008);

                    Console.WriteLine(line);
                    Byte[] data = Encoding.ASCII.GetBytes(line);

                    Console.WriteLine("thread8");
                    udpClient.Send(data, data.Length);
                    System.Threading.Thread.Sleep(10);

                    udpClient.Close();
                }
            }
    }
}

