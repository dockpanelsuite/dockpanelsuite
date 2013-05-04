using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012LightSplitterControl : DockPane.SplitterControlBase
    {
        public VS2012LightSplitterControl(DockPane pane)
            : base(pane)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            if (Alignment == DockAlignment.Left || Alignment == DockAlignment.Right)
            {
                var path = new GraphicsPath();
                path.AddRectangle(rect);
                var brush = new PathGradientBrush(path) { CenterColor = Color.FromArgb(0xFF, 204, 206, 219), SurroundColors = new[] { SystemColors.Control } };

                g.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                Measures.SplitterSize / 3, rect.Height);}
            else
                if (Alignment == DockAlignment.Top || Alignment == DockAlignment.Bottom)
                {
                    var brush = new SolidBrush(Color.FromArgb(0xFF, 204, 206, 219));
                    g.FillRectangle(brush, rect.X, rect.Y,
                                    rect.Width, Measures.SplitterSize);}
        }
    }
}