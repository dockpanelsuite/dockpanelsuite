using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Blue
{
    public class VS2012BlueWindowSplitterControl : SplitterBase
    {
        private SolidBrush _horizontalBrush;
        private readonly ISplitterHost _host;

        public VS2012BlueWindowSplitterControl(ISplitterHost host)
        {
            _host = host;
        }

        protected override int SplitterSize
        {
            get { return Measures.SplitterSize; }
        }

        protected override void StartDrag()
        {
            _host.DockPanel.BeginDrag(_host, ((Control)_host).RectangleToScreen(Bounds));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = ClientRectangle;

            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            if (_horizontalBrush == null)
            {
                _horizontalBrush = _host.DockPanel.Theme.PaintingService.GetBrush(_host.DockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background);
            }

            if (_host.IsDockWindow)
            {
                switch (Dock)
                {
                    case DockStyle.Right:
                    case DockStyle.Left:
                        {
                            e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y, Measures.SplitterSize, rect.Height);
                        }
                        break;
                    case DockStyle.Bottom:
                    case DockStyle.Top:
                        {
                            e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                                     rect.Width, Measures.SplitterSize);
                        }
                        break;
                }

                return;
            }

            switch (_host.DockState)
            {
                case DockState.DockRightAutoHide:
                case DockState.DockLeftAutoHide:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y, Measures.SplitterSize, rect.Height);
                    }
                    break;
                case DockState.DockBottomAutoHide:
                case DockState.DockTopAutoHide:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y, rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }
}
