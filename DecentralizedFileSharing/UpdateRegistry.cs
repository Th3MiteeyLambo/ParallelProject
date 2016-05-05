using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    public class UpdateRegistry
    {
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "registry.csv";
        private static string dirFolder = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar; 

        public Boolean add(string ip, string port, string udpPort)
        {
            try {
                string add = ip + "," + port + "," + udpPort + System.Environment.NewLine;
                if (!File.Exists(dirFolder))
                {
                    System.IO.Directory.CreateDirectory(dirFolder);
                }

                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                File.AppendAllText(path, add);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an issue in the UpdateRegistry.add method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
        
        }

        public Boolean delete(string ip, string port)
        {
            string tempPath = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "temp.csv";
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(tempPath);
                }
                using (FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(fs))
                {

                    if (File.Exists(path))
                    {
                        foreach (string line in File.ReadLines(path))
                        {
                            if (!line.Contains(ip + "," + port))
                            {
                                sw.WriteLine(line);
                                System.Diagnostics.Debug.WriteLine("Doesn't contain key");
                            }
                        }
                    }

                }
                if (File.Exists(tempPath))
                {
                    File.Delete(path);
                    File.Move(tempPath, path);
                }

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an issue in the UpdateRegistry.delete method" + ex.Message, "P2P App",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
        }
    }
}