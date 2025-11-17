using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StreamReader read = new StreamReader("sess.txt");//change back to data.txt
            try
            {
                string type = read.ReadLine();
                string username = read.ReadLine();
                Console.WriteLine("sgfg"+type);
                read.Close();
                if (type == null || username == null)
                {
                    throw new Exception();
                }
                
                Application.Run(new Pages(type, username));

            }
            catch
            {
                Application.Run(new Auth());
            }
            
            
        }
    }
}
