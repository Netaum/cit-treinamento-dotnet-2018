using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Treinamento.Presentation.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string completePath = System.IO.Directory.GetParent(path).Parent.Parent.Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", completePath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
