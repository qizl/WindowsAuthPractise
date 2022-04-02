using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHostsHandler.Extensions;
using WinHostsHandler.Models;
using WinOSUtils;

namespace WinHostsHandler
{
    public partial class FormMain : Form
    {
        private Operations _operation = Operations.Disabled;

        public FormMain(Operations operations = Operations.Disabled)
        {
            InitializeComponent();

            _operation = operations;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (this._operation == Operations.Enabled)
                    this.Invoke(() => { this.lblMessage.Text = "正在移除Chrome更新限制..."; });
                else
                    this.Invoke(() => { this.lblMessage.Text = "正在禁用Chrome更新..."; });
                Thread.Sleep(1000);

                try
                {
                    if (this._operation == Operations.Enabled)
                        HostsHelper.RemoveChromeDomains();
                    else
                        HostsHelper.DisableChromeDomains();

                    this.Invoke(() => { this.lblMessage.Text = "处理完成！"; });
                }
                catch
                {
                    this.Invoke(() => { this.lblMessage.Text = "处理失败！"; });
                }

                Thread.Sleep(1000);
                this.Invoke(() => { this.Close(); });
            });
        }
    }
}
