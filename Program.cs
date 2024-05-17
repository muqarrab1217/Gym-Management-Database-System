using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Interface
{
    static class Program
    {
        public static int loginID { get; set; }
        public static int masterloginID { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //loginID = 105;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GYM_MANAGEMENT_SYSTEM());
        }
    }
}
