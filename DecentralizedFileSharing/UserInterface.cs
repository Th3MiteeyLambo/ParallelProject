using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    public partial class UserInterface : Form
    {
        public Socket Handler;
        private Socket listener;
        public int port = 55000;
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "registry.csv";
        private static string dlPath = "C:" + Path.DirectorySeparatorChar + "download" + Path.DirectorySeparatorChar;
        public String ipNew = "";
        public int portNew;
        public TcpListener tcplistener;

        public UserInterface()
        {
            InitializeComponent();
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    String masterNode = "127.0.1.1 11000,";
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(masterNode);
                    tw.Close();
                    var reader = new StreamReader(File.OpenRead(path));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] hostArray = line.Split(',');
                        ipNew = hostArray[0];
                        portNew = Int32.Parse(hostArray[1]);
                    }
                }
                else if (File.Exists(path))
                {
                    var reader = new StreamReader(File.OpenRead(path));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] hostArray = line.Split(',');
                        ipNew = hostArray[0];
                        portNew = Int32.Parse(hostArray[1]);
                    }
                }

                if (!File.Exists(dlPath))
                {
                    File.Create(dlPath);
                }


                PingPong.sendPing(portNew, ipNew);

                PingPong.hearPing(port);
                serverstart();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an issue in the UI_load method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                
            }
        }

        //public startConnection()
        //{

        //}

        //public void StartListening()
        //{
        //    // Establish the locel endpoint for the socket
        //    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, portNew);

        //    // Create a TCP/IP socket
        //    listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    try
        //    {
        //        // Bind the socket to the local endpoint and listen
        //        listener.Blocking = false;
        //        listener.Bind(localEndPoint);
        //        listener.Listen(100);

        //        // Start an asynchronous socket to listen for connections
        //        performListen(listener); // changed by corsiKa
        //    }
        //    catch (Exception e)
        //    {
        //        //invokeStatusUpdate(0, e.Message);
        //    }
        //}

        //private void performListen(Socket listener)
        //{
        //    //listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        //}

        //public void CloseNode(bool acceptMoreConnections)
        //{
        //    try
        //    {
        //        if (Handler != null)
        //        {
        //            Handler.Shutdown(SocketShutdown.Both);
        //            Handler.Close();
        //            Handler.Dispose();
        //            Handler = null;
        //        }
        //        // changed by corsiKa
        //        if (acceptMoreConnections)
        //            performListen(listener);
        //    }
        //    catch (Exception e)
        //    {
        //        //invokeStatusUpdate(0, e.Message);
        //    }
        //}

        private void reconnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fileListBox.Items.Clear();

                String newSearch = searchTxt.Text;

                //NOTE we need to edit this to ask each node on our registry for the search item
                if (!File.Exists(path))
                {
                    File.Create(path);
                    String masterNode = "127.0.1.1 11000,";
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(masterNode);
                    tw.Close();
                    var reader = new StreamReader(File.OpenRead(path));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        //var values = line.Split(',');
                        //String host = values[0];
                        String[] hostArray = line.Split(',');
                        ipNew = hostArray[0];
                        portNew = Int32.Parse(hostArray[1]);

                        // Create a TcpClient.
                        // Note, for this client to work you need to have a TcpServer 
                        // connected to the same address as specified by the server, port
                        // combination.
                        TcpClient client = new TcpClient(ipNew, portNew);

                        // Translate the passed message into ASCII and store it as a Byte array.
                        Byte[] data = System.Text.Encoding.ASCII.GetBytes(newSearch);

                        // Get a client stream for reading and writing.
                        //  Stream stream = client.GetStream();

                        NetworkStream stream = client.GetStream();

                        // Send the message to the connected TcpServer. 
                        stream.Write(data, 0, data.Length);

                        Console.WriteLine("Sent: {0}", newSearch);

                        // Receive the TcpServer.response.

                        // Buffer to store the response bytes.
                        data = new Byte[256];

                        // String to store the response ASCII representation.
                        String responseData = String.Empty;

                        // Read the first batch of the TcpServer response bytes.
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine("Received: {0}", responseData);


                        if (responseData.Substring(0, 1) == "*")
                        {
                            fileListBox.Items.Add(responseData.Substring(1) + ":" + ipNew);

                        }

                        // Close everything.
                        //
                        stream.Close();
                        client.Close();


                    }
                }
                else if (File.Exists(path))
                {
                    var reader = new StreamReader(File.OpenRead(path));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] hostArray = line.Split(',');
                        ipNew = hostArray[0];
                        portNew = Int32.Parse(hostArray[1]);

                        // Create a TcpClient.
                        // Note, for this client to work you need to have a TcpServer 
                        // connected to the same address as specified by the server, port
                        // combination.
                        TcpClient client = new TcpClient(ipNew, portNew);

                        // Translate the passed message into ASCII and store it as a Byte array.
                        Byte[] data = System.Text.Encoding.ASCII.GetBytes(newSearch);

                        // Get a client stream for reading and writing.
                        //  Stream stream = client.GetStream();

                        NetworkStream stream = client.GetStream();

                        // Send the message to the connected TcpServer. 
                        stream.Write(data, 0, data.Length);

                        Console.WriteLine("Sent: {0}", newSearch);

                        // Receive the TcpServer.response.

                        // Buffer to store the response bytes.
                        data = new Byte[256];

                        // String to store the response ASCII representation.
                        String responseData = String.Empty;

                        // Read the first batch of the TcpServer response bytes.
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine("Received: {0}", responseData);


                        if (responseData.Substring(0, 1) == "*")
                        {
                            fileListBox.Items.Add(responseData.Substring(1) + ":" + ipNew);

                        }

                        // Close everything.
                        stream.Close();
                        client.Close();
                    }
                }
            }                
            catch(Exception ex)
            {
                MessageBox.Show("There was an issue in the searchBtn_click method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                
            }

}

        private void downloadBtn_Click(object sender, EventArgs e)
        {

        }

        private void peerBtn_Click(object sender, EventArgs e)
        {

        }

        private void serverstart()
        {
            tcplistener = new TcpListener(IPAddress.Any, 49151);
            Thread listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            try
            { 
            this.tcplistener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcplistener.AcceptTcpClient();


                // here was first an message that send hello client
                //
                ///////////////////////////////////////////////////

                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));

                clientThread.Start(client);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue in the ListenForClients method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }

        private void HandleClientComm(object client)
        {
            try
            {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();

                byte[] message = new byte[4096];
                int bytesRead;

                while (true)
                {
                    bytesRead = 0;

                    try
                    {
                        //blocks until a client sends a message
                        bytesRead = clientStream.Read(message, 0, 4096);
                    }
                    catch
                    {
                        //a socket error has occured
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        break;
                    }

                    //message has successfully been received
                    ASCIIEncoding encoder = new ASCIIEncoding();

                    String bufferincmessage = encoder.GetString(message, 0, bytesRead);


                    //if (System.Text.RegularExpressions.Regex.IsMatch(bufferincmessage, Properties.Settings.Default.REQLogin, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    //{
                    //    bufferincmessageresult = bufferincmessage.Split('^');
                    //    nickname_Cl = bufferincmessageresult[1];
                    //    password_Cl = bufferincmessageresult[2];
                    //    getuserdata_db();
                    //    login();

                    //    byte[] buffer = encoder.GetBytes(inlogmessage);

                    //    clientStream.Write(buffer, 0, buffer.Length);
                    //    clientStream.Flush();
                    //}


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an issue in the HandleClientComm method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                
            }
}
    }
}
