using System.Diagnostics;

namespace WinAuthAgent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //获取当前登录的Windows用户的标识 
            System.Security.Principal.WindowsIdentity wid = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(wid);

            // 判断当前用户是否是管理员 
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                var adminFormsPath = Path.Combine(Environment.CurrentDirectory, $"{nameof(WinHostsHandler)}.exe");
                Process.Start(adminFormsPath);
            }
            else // 用管理员用户运行 
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    UseShellExecute = true,
                    Verb = "runas",
                };
                Process.Start(startInfo);
                Application.Exit();
            }
        }
    }
}