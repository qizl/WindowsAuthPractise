using WinOSUtils;

namespace WinHostsHandler
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(1000);

                try
                {
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