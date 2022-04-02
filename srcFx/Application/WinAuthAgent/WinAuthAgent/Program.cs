using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WinAuthAgent
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //获取当前登录的Windows用户的标识 
            System.Security.Principal.WindowsIdentity wid = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(wid);

            // 判断当前用户是否是管理员 
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                var adminFormsPath = Path.Combine(Application.StartupPath, $"{nameof(WinHostsHandler)}.exe");
                Process.Start(adminFormsPath, args.Length > 0 ? args[0] : String.Empty);
            }
            else // 用管理员用户运行 
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    Arguments = args.Length > 0 ? args[0] : String.Empty,
                    UseShellExecute = true,
                    Verb = "runas",
                };
                Process.Start(startInfo);
                Application.Exit();
            }
        }
    }
}
