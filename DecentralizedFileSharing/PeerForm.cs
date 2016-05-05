using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    public partial class PeerForm : Form
    {
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "registry.csv";

        public PeerForm()
        {
            InitializeComponent();

            //Checks to make sure the registry file exists
            if(!File.Exists(path))
            {
                peerLstBox.Items.Add("There are currently no connected peers.");
            }
            //try-catch for IO exception
            try
            {
                //Creates a file reader
                var reader = new StreamReader(File.OpenRead(path));
                //Loops through the file reader
                while (!reader.EndOfStream)
                {
                    //Adds the line to the peerLstBox
                    peerLstBox.Items.Add(reader.ReadLine());
                }
            }
            catch (Exception ex)
            {
                //Message for error dialog
                MessageBox.Show("There was an issue in reading the registry file.\n" + ex.Message, "P2P App", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                peerLstBox.Items.Add("There was an error.");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void peerLstBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
