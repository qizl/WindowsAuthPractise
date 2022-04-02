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
                    this.Invoke(() => { this.lblMessage.Text = "������ɣ�"; });
                }
                catch
                {
                    this.Invoke(() => { this.lblMessage.Text = "����ʧ�ܣ�"; });
                }

                Thread.Sleep(1000);
                this.Invoke(() => { this.Close(); });
            });
        }
    }
}