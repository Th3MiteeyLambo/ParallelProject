using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Threading;

namespace DecentralizedFileSharing
{
    class FileTransfer
    {
        public string Name;
        public int Size;
        public string Content;
        public ArrayList alSockets;
        private static string dlPath = "C:" + Path.DirectorySeparatorChar + "download" + Path.DirectorySeparatorChar;
        public int transferPort = 55111;

        public void Send(string fName, int port)
        {
            try
            {


                byte[] file = File.ReadAllBytes(dlPath + fName);
                byte[] fileBuffer = new byte[file.Length];
                TcpClient clientSocket = new TcpClient("127.0.0.1", port);
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Write(file.ToArray(), 0, fileBuffer.GetLength(0));
                networkStream.Close();
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the FileTransfer.Send method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }

        public void Receive()
        {
            try
            {
                alSockets = new ArrayList();
                Thread thdsListener = new Thread(new ThreadStart(ListenerThread));
                thdsListener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the FileTransfer.Receive method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }

        public void ListenerThread()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, transferPort);

            tcpListener.Start();
            while (true)
            {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {

                    tcpListener.Stop();
                    var thdstHandler = new ParameterizedThreadStart(HandlerThread);

                    Thread thdHandler = new Thread(thdstHandler);
                    thdHandler.Start(handlerSocket);
                }
            }

        }
        public void HandlerThread(object state)
        {
            try
            {
                using (Socket handlerSocket = (Socket)state)
                using (NetworkStream networkStream = new NetworkStream(handlerSocket))
                {
                    int thisRead = 0;
                    int blockSize = 1024;
                    Byte[] dataByte = new Byte[blockSize];
                    var ms = new MemoryStream();

                    while (true)
                    {
                        thisRead = networkStream.Read(dataByte, 0, blockSize);
                        if (thisRead == 0) break;
                        ms.Write(dataByte, 0, thisRead);
                    }
                    //File.WriteAllBytes(filedir, ms.ToArray());
                    networkStream.Close();
                    handlerSocket.Close();



                }
            }
            catch (Exception ex)
            {

            }

        }

        public static class Convert2
        {
            public static byte[] ToByteArray(Stream stream)
            {
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                for (int totalBytesCopied = 0; totalBytesCopied < stream.Length; )
                    totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
                return buffer;
            }
        }
    }




}
