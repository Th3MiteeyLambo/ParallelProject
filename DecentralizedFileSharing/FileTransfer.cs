﻿using System;
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
        public int transferPort = 55112;
        public string newFileName = "";
        TcpClient tcpClient;
        TcpListener tcpListener;

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

        public void Receive(string fileName)
        {
            try
            {
                newFileName = fileName;
                //alSockets = new ArrayList();

                tcpListener = new TcpListener(IPAddress.Any, transferPort);
                Thread listen = new Thread(new ThreadStart(ListenerThread));
                listen.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the FileTransfer.Receive method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }

        public void ListenerThread()
        {
            try
            {
                this.tcpListener.Start();


                while (true)
                {
                    TcpClient tcpClient = this.tcpListener.AcceptTcpClient();

                    Thread thdHandler = new Thread(new ParameterizedThreadStart(HandlerThread));
                    thdHandler.Start(tcpClient);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the FT:ListenerThread method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }

        }
        public void HandlerThread(object client)
        {
            try
            {
                TcpClient tcpClient = (TcpClient)client;

                NetworkStream networkStream = tcpClient.GetStream();

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

                Byte[] newBA = ToByteArray(ms);
                File.WriteAllBytes(dlPath + newFileName, newBA);
                networkStream.Close();





            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the FileTransfer.HandlerThread method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }

        }


        public static byte[] ToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

    }




}
