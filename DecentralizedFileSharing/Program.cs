using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecentralizedFileSharing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Search search = new Search();

            //search.peerAdd("test", "1234");
            //search.peerRemove("test");

            //UpdateRegistry test = new UpdateRegistry();

            //test.add("1234", "port");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserInterface());
        }
    }
}
