using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizedFileSharing
{
    public static class PingPong
    {
        private static byte[] ping = Encoding.ASCII.GetBytes("ping");
        private static byte[] pong = Encoding.ASCII.GetBytes("pong");
        private static Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static Socket hearSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

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
            catch(SocketException se)
            {
                Console.WriteLine("Something went wrong with the socket");
                Console.WriteLine(se.StackTrace);
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong with ping");
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
        }

        public static bool sendPong()
        {
            return true;
        }

        //Mostly copied from Stack Overflow, haven't figured out how it works yet.
        public static bool hearPong(int port)
        {
            byte[] data = null;

            IPEndPoint server = new IPEndPoint(IPAddress.Any, port);
            hearSocket.Bind(server);

            Console.Write("Waiting for client");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            int recv = hearSocket.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            return true;
        }
    }
}
