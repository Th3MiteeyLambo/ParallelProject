using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    public partial class UserInterface : Form
    {
        public Socket Handler;
        private Socket listener;
        public int port = 53565;

        public UserInterface()
        {
            InitializeComponent();
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }

        public void StartListening()
        {
            // Establish the locel endpoint for the socket
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, port);

            // Create a TCP/IP socket
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Bind the socket to the local endpoint and listen
                listener.Blocking = false;
                listener.Bind(localEndPoint);
                listener.Listen(100);

                // Start an asynchronous socket to listen for connections
                performListen(listener); // changed by corsiKa
            }
            catch (Exception e)
            {
                //invokeStatusUpdate(0, e.Message);
            }
        }

        private void performListen(Socket listener)
        {
            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }

        public void CloseNode(bool acceptMoreConnections)
        {
            try
            {
                if (Handler != null)
                {
                    Handler.Shutdown(SocketShutdown.Both);
                    Handler.Close();
                    Handler.Dispose();
                    Handler = null;
                }
                // changed by corsiKa
                if (acceptMoreConnections)
                    performListen(listener);
            }
            catch (Exception e)
            {
                //invokeStatusUpdate(0, e.Message);
            }
        }
    }
}
