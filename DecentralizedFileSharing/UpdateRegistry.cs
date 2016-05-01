using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DecentralizedFileSharing
{
    class UpdateRegistry
    {
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "registry.csv";

        public Boolean add(string ip, string port)
        {

            string add = ip + ":" +port + "," + System.Environment.NewLine;

            File.AppendAllText(path, add);

            return true;
        }

        public Boolean delete(string ip, string port)
        {
            string tempPath = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "temp.csv";

            using (FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            {

                if (File.Exists(path))
                {
                    foreach (string line in File.ReadLines(path))
                    {
                        if (!line.Contains(ip + ":" + port))
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
    }
}