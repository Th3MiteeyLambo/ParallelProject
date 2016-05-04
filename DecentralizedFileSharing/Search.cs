using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DecentralizedFileSharing
{
    class Search
    {
        private static List<peerInfo> list = new List<peerInfo>();
        private static string path = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "files.csv";

        public static string search(string key)
        {
            string found = "";

            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains(key))
                {
                    Console.Write(line);
                    found = line.Substring(0, line.Length - 1);
                }
            }

            return found;
        }

        public static List<peerInfo> buildList()
        {
            string[] info;
            peerInfo peer = null;


            foreach (string line in File.ReadLines(path))
            {
                info = line.Split(' ');

                peer = new peerInfo(info[0], info[1].Substring(0, (info[2].Length - 1)));
                list.Add(peer);
            }

            return list;
        }

        public Boolean peerAdd(string fileName, string IP)
        {
            System.Diagnostics.Debug.WriteLine("Filename: " + fileName + " . IP: " + IP);

            // File.Open(path, FileMode.OpenOrCreate);


            string newPeer = fileName + " " + IP + "," + System.Environment.NewLine;

            File.AppendAllText(path, newPeer);

            return true;

        }

        public Boolean peerRemove(string key)
        {

            string tempPath = "C:" + Path.DirectorySeparatorChar + "dir" + Path.DirectorySeparatorChar + "test.csv";

            using (FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            {

                //File.Open(path, FileMode.OpenOrCreate);

                if (File.Exists(path))
                {
                    foreach (string line in File.ReadLines(path))
                    {
                        if (!line.Contains(key))
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

        public class peerInfo
        {
            private string IP;
            private string fileName;

            public peerInfo(string fileName, string IP)
            {
                this.IP = IP;
                this.fileName = fileName;
            }

            public string toString()
            {
                return "File name: " + fileName + "         IP: " + IP;
            }
        }
    }
}
