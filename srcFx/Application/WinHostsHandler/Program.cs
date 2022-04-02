using System;
using System.Windows.Forms;
using WinHostsHandler.Models;

namespace WinHostsHandler
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var operation = Operations.Disabled;
            if (args.Length > 0)
                operation = args[0] == "1" ? Operations.Enabled : Operations.Disabled;

            Application.Run(new FormMain(operation));
        }
    }
}
