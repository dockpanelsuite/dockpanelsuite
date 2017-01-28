using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012SplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _horizontalBrush;
        private readonly SolidBrush _backgroundBrush;
        private PathGradientBrush _foregroundBrush;
        private readonly Color[] _verticalSurroundColors;
        private int SplitterSize { get; }

        public VS2012SplitterControl(DockPane pane)
            : base(pane)
        {
            _horizontalBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Theme.ColorPalette.TabSelectedInactive.Background);
            _backgroundBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Theme.ColorPalette.MainWindowActive.Background);
            _verticalSurroundColors = new[]
            {
                pane.DockPanel.Theme.ColorPalette.MainWindowActive.Background
            };
            SplitterSize = pane.DockPanel.Theme.Measures.SplitterSize;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            if (Alignment != DockAlignment.Left && Alignment != DockAlignment.Right)
                return;

            MakeForegroundBrush(rect);
        }

        private void MakeForegroundBrush(Rectangle rect)
        {
            _foregroundBrush?.Dispose();
            using (var path = new GraphicsPath())
            {
                path.AddRectangle(rect);
                _foregroundBrush = new PathGradientBrush(path)
                {
                    CenterColor = _horizontalBrush.Color,
                    SurroundColors = _verticalSurroundColors
                };
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                _foregroundBrush?.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            switch (Alignment)
            {
                case DockAlignment.Right:
                case DockAlignment.Left:
                    {
                        Debug.Assert(SplitterSize == rect.Width);

                        if (_foregroundBrush == null)
                            MakeForegroundBrush(rect);

                        e.Graphics.FillRectangle(_backgroundBrush, rect);
                        e.Graphics.FillRectangle(_foregroundBrush, rect.X + SplitterSize / 2 - 1, rect.Y,
                                                    SplitterSize / 3, rect.Height);
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        Debug.Assert(SplitterSize == rect.Height);
                        e.Graphics.FillRectangle(_horizontalBrush, rect);
                    }
                    break;
            }
        }
    }
}