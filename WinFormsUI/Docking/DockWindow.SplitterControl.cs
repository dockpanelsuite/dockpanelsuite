using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public partial class DockWindow
    {
        internal class DefaultSplitterControl : SplitterBase
        {
            private ISplitterHost _host;

            public DefaultSplitterControl(ISplitterHost host)
            {
                _host = host;
            }

            protected override int SplitterSize
            {
                get { return _host.DockPanel.Theme.Measures.SplitterSize; }
            }

            protected override void StartDrag()
            {
                _host.DockPanel.BeginDrag(_host, ((Control)_host).RectangleToScreen(Bounds));
            }
        }
    }
}
