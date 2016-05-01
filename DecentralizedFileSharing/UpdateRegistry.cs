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

        public static Boolean add(string ip, string port)
        {

            string add = ip + ": " +port + "," + System.Environment.NewLine;

            File.AppendAllText(path, add);

            return true;
        }

        public static void delete()
        {

        }
    }
}