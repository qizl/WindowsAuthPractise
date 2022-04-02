using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinOSUtils.Tests
{
    [TestClass]
    public class HostsHelperTest
    {
        [TestMethod]
        public void DisableChromeDomains()
        {
            HostsHelper.DisableChromeDomains();
        }

        [TestMethod]
        public void RemoveChromeDomains()
        {
            HostsHelper.RemoveChromeDomains();
        }
    }
}
