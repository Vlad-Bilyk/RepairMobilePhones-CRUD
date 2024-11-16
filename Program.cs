using System;
using System.Windows.Forms;

namespace RepairMobilePhones
{
    internal static class Program
    {
        /// <summary>
        /// Головна точка входу програми
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
