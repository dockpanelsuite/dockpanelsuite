using System;
using System.Windows.Forms;
using WinFormsCoreDockPanelSuite.Docking;

namespace NetCoreDockSample
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            labelAppVersion.Text = typeof(MainForm).Assembly.GetName().Version.ToString();
            labelLibVersion.Text = typeof(DockPanel).Assembly.GetName().Version.ToString();
        }
    }
}