﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace DecentralizedFileSharing
{
    class FileTransfer
    {
        public string Name;
        public int Size;
        public string Content;

        public void Send(string fName)
        {
            FileTransfer fileTransfer = new FileTransfer();
            fileTransfer.Name = "TestFile";
            fileTransfer.Content = System.Convert.ToBase64String(File.ReadAllBytes("c:\\data\\test.html"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(fileTransfer.GetType());
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 40399);
            Stream stream = client.GetStream();
            x.Serialize(stream, fileTransfer);
            client.Close();
        }

        public void Receive()
        {
            TcpListener list;
            Int32 port1 = 40399;
            list = new TcpListener(port1);
            list.Start();
            TcpClient client = list.AcceptTcpClient();
            Console.WriteLine("Client trying to connect");
            Stream stream = client.GetStream();
            XmlSerializer mySerializer = new XmlSerializer(typeof(FileTransfer));
            FileTransfer myObject = (FileTransfer)mySerializer.Deserialize(stream);
            Console.WriteLine("name: " + myObject.Name);
            list.Stop();
            client.Close();
        }
    }




}