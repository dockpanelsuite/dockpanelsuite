using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012LightSplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _horizontalBrush;
        private readonly Color[] _verticalSurroundColors;


        public VS2012LightSplitterControl(DockPane pane)
            : base(pane)
        {
            _horizontalBrush = new SolidBrush(pane.DockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor);
            this._verticalSurroundColors = new[]
                                               {
                                                   pane.DockPanel.Skin.DockPaneStripSkin.DocumentGradient
                                                       .InactiveTabGradient.StartColor
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
                        using (var path = new GraphicsPath())
                        {
                            path.AddRectangle(rect);
                            using (var brush = new PathGradientBrush(path)
                                {
                                    CenterColor = this._horizontalBrush.Color, SurroundColors = _verticalSurroundColors
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