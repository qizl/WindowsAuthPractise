using System;
using System.Windows.Forms;

namespace WinHostsHandler.Extensions
{
    public static class ControlExtensions
    {
        public static object Invoke(this Control control, Action action)
        {
            object r = null;
            try
            {
                if (!control.IsDisposed && control.IsHandleCreated)
                {
                    if (control.InvokeRequired)
                        r = control.Invoke(new EventHandler(delegate { action(); }));
                    else
                        action();
                }
            }
            catch (Exception e) { }
            return r;
        }
    }
}
