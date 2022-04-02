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
            //��ȡ��ǰ��¼��Windows�û��ı�ʶ 
            System.Security.Principal.WindowsIdentity wid = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(wid);

            // �жϵ�ǰ�û��Ƿ��ǹ���Ա 
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                var adminFormsPath = Path.Combine(Environment.CurrentDirectory, $"{nameof(WinHostsHandler)}.exe");
                Process.Start(adminFormsPath);
            }
            else // �ù���Ա�û����� 
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