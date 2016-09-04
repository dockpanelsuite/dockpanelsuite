using System.Diagnostics;
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
            get { return _host.IsDockWindow ? _host.DockPanel.Theme.Measures.SplitterSize : _host.DockPanel.Theme.Measures.AutoHideSplitterSize; }
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

            if (_host.IsDockWindow)
            {
                switch (Dock)
                {
                    case DockStyle.Right:
                    case DockStyle.Left:
                        {
                            Debug.Assert(SplitterSize == rect.Width);
                            e.Graphics.FillRectangle(_backgroundBrush, rect);
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
                                    e.Graphics.FillRectangle(brush, rect.X + SplitterSize / 2 - 1, rect.Y,
                                                             SplitterSize / 3, rect.Height);
                                }
                            }
                        }
                        break;
                    case DockStyle.Bottom:
                    case DockStyle.Top:
                        {
                            Debug.Assert(SplitterSize == rect.Height);
                            e.Graphics.FillRectangle(_horizontalBrush, rect);
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
                        Debug.Assert(SplitterSize == rect.Width);
                        e.Graphics.FillRectangle(_backgroundBrush, rect);
                    }
                    break;
                case DockState.DockBottomAutoHide:
                case DockState.DockTopAutoHide:
                    {
                        Debug.Assert(SplitterSize == rect.Height);
                        e.Graphics.FillRectangle(_horizontalBrush, rect);
                    }
                    break;
            }
        }
    }

}
