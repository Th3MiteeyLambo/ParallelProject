using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    public static class PingPong
    {
        private static byte[] ping = Encoding.ASCII.GetBytes("ping");
        private static byte[] pong = Encoding.ASCII.GetBytes("pong");
        private static Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static Socket hearSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "registry.csv";
        //public UpdateRegistry update = new UpdateRegistry();

        public static bool sendPing(int port, string ip)
        {
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            try
            {
                sendSocket.SendTo(ping, endPoint);
                Console.WriteLine("No Socket Errors");
                return true;
            }
            catch (SocketException se)
            {
                Console.WriteLine("Something went wrong with the socket");
                Console.WriteLine(se.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with ping");
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        public static bool sendPing(int port, string ip, string forwardip, int forwardport)
        {
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            byte[] ping2 = Encoding.ASCII.GetBytes("ping," + forwardip + "," + forwardport);
            try
            {
                sendSocket.SendTo(ping2, endPoint);
                Console.WriteLine("No Socket Errors");
                return true;
            }
            catch (SocketException se)
            {
                Console.WriteLine("Something went wrong with the socket");
                Console.WriteLine(se.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with ping");
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        public static bool sendPong(int port, string ip)
        {
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            try
            {
                sendSocket.SendTo(pong, endPoint);
                Console.WriteLine("No Socket Errors");
                return true;
            }
            catch (SocketException se)
            {
                Console.WriteLine("Something went wrong with the socket");
                Console.WriteLine(se.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with pong");
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        //Mostly copied from Stack Overflow, haven't figured out how it works yet.


        public static bool hearPing(int port)
        {
            try
            {
                byte[] data = null;

                IPEndPoint server = new IPEndPoint(IPAddress.Any, port);
                hearSocket.Bind(server);
                Console.Write("Waiting");
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender);
                int recv = hearSocket.ReceiveFrom(data, ref Remote);
                Console.WriteLine("Message received from {0}:", Remote.ToString());
                string recvData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(recvData);
                String[] newHost = Remote.ToString().Split(':');

                if (Encoding.ASCII.GetString(data, 0, recv).Contains("ping,"))
                {
                    string[] array = recvData.Split(',');
                    sendPong(Int32.Parse(array[2]), array[1]);
                    return true;
                }
                else if (Encoding.ASCII.GetString(data, 0, recv).Contains("ping"))
                {
                    sendPong(Int32.Parse(newHost[1]), newHost[0]);

                    try
                    {
                        var reader = new StreamReader(File.OpenRead(path));
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] array = line.Split(',');
                            sendPing(Int32.Parse(array[1]), array[0], newHost[0], Int32.Parse(newHost[1]));
                        }

                    }
                    catch
                    {
                        return false;
                    }
                    return true;
                }
                else if (Encoding.ASCII.GetString(data, 0, recv) == "pong")
                {
                    UpdateRegistry update = new UpdateRegistry();
                    update.add(newHost[0], newHost[1]);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the PingPong.hearPing method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
        }

    }
}