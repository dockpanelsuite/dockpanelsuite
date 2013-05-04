using System.Drawing;
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
                g.FillRectangle(SystemBrushes.ScrollBar, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                Measures.SplitterSize / 3, rect.Height);
            else
                if (Alignment == DockAlignment.Top || Alignment == DockAlignment.Bottom)
                    g.FillRectangle(SystemBrushes.ScrollBar, rect.X, rect.Y,
                                    rect.Width, Measures.SplitterSize);
        }
    }
}