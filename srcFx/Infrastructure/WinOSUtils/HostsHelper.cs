using System;
using System.IO;
using System.Linq;

namespace WinOSUtils
{
    public class HostsHelper
    {
        /// <summary>
        /// Hosts文件路径
        /// </summary>
        private static readonly string hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");

        /// <summary>
        /// 禁用Chrome域名
        /// </summary>
        public static void DisableChromeDomains()
        {
            var chromeDomains = new string[] {
                "clients2.google.com",
                "update.googleapis.com",
                "redirector.gvt1.com"
            };
            var localhost = "127.0.0.1";

            var hostsLines = File.ReadAllLines(hostsPath).ToList();
            foreach (var domain in chromeDomains)
            {
                var line = hostsLines.Where(m => !m.StartsWith("#")).FirstOrDefault(m => m.Contains(domain));
                if (line != null) hostsLines.Remove(line);
                hostsLines.Add($"{localhost}  {domain}");
            }
            File.WriteAllLines(hostsPath, hostsLines);
        }

        /// <summary>
        /// 移除Chrome域名
        /// </summary>
        public static void RemoveChromeDomains()
        {
            var chromeDomains = new string[] {
                "clients2.google.com",
                "update.googleapis.com",
                "redirector.gvt1.com"
            };

            var hostsLines = File.ReadAllLines(hostsPath).ToList();
            foreach (var domain in chromeDomains)
            {
                var line = hostsLines.Where(m => !m.StartsWith("#")).FirstOrDefault(m => m.Contains(domain));
                if (line != null) hostsLines.Remove(line);
            }
            File.WriteAllLines(hostsPath, hostsLines);
        }
    }
}
