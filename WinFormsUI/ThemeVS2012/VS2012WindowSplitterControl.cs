using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    public class VS2012WindowSplitterControl : SplitterBase
    {
        private readonly SolidBrush _horizontalBrush;
        private readonly SolidBrush _backgroundBrush;
        private readonly Color[] _verticalSurroundColors;
        private readonly ISplitterHost _host;

        public VS2012WindowSplitterControl(ISplitterHost host)
        {
            _host = host;
            _horizontalBrush = host.DockPanel.Theme.PaintingService.GetBrush(host.DockPanel.Theme.Skin.ColorPalette.TabSelectedInactive.Background);
            _backgroundBrush = host.DockPanel.Theme.PaintingService.GetBrush(host.DockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background);
            _verticalSurroundColors = new[]{
                                                   host.DockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background
                                               };
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

            switch (_host.DockState)
            {
                case DockState.DockRightAutoHide:
                case DockState.DockLeftAutoHide:
                    {
                        e.Graphics.FillRectangle(_backgroundBrush, rect.X, rect.Y, rect.Width, rect.Height);
                        using (var path = new GraphicsPath())
                        {
                            path.AddRectangle(rect);
                            using (var brush = new PathGradientBrush(path)
                            {
                                // TODO: fix this color.
                                CenterColor = _horizontalBrush.Color,
                                SurroundColors = _verticalSurroundColors
                            })
                            {
                                e.Graphics.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                                         Measures.SplitterSize / 3, rect.Height);
                            }
                        }
                    }
                    break;
                case DockState.DockBottomAutoHide:
                case DockState.DockTopAutoHide:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                        rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }

}
