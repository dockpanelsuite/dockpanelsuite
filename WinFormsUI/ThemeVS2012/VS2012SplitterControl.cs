using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012SplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _horizontalBrush;
        private readonly SolidBrush _backgroundBrush;
        private readonly Color[] _verticalSurroundColors;

        public VS2012SplitterControl(DockPane pane)
            : base(pane)
        {
            _horizontalBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Skin.ColorPalette.TabSelectedInactive.Background);
            _backgroundBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Skin.ColorPalette.MainWindowActive.Background);
            this._verticalSurroundColors = new[]
                                               {
                                                   pane.DockPanel.Skin.ColorPalette.TabSelectedInactive.Background
                                               };
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
                        e.Graphics.FillRectangle(_backgroundBrush, rect.X, rect.Y, rect.Width, rect.Height);
                        using (var path = new GraphicsPath())
                        {
                            path.AddRectangle(rect);
                            using (var brush = new PathGradientBrush(path)
                                {
                                    CenterColor = _horizontalBrush.Color, SurroundColors = _verticalSurroundColors
                                })
                            {
                                e.Graphics.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                                         Measures.SplitterSize / 3, rect.Height);
                            }
                        }
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                        rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }
}