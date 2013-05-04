using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012LightSplitterControl : DockPane.SplitterControlBase
    {
        public VS2012LightSplitterControl(DockPane pane)
            : base(pane)
        {
            Brush = new SolidBrush(pane.DockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor);
        }

        private SolidBrush Brush { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            if (Alignment == DockAlignment.Left || Alignment == DockAlignment.Right)
                g.FillRectangle(Brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y, Measures.SplitterSize / 3, rect.Height);
            else if (Alignment == DockAlignment.Top || Alignment == DockAlignment.Bottom)
                    g.FillRectangle(Brush, rect.X, rect.Y, rect.Width, Measures.SplitterSize);
        }
    }
}