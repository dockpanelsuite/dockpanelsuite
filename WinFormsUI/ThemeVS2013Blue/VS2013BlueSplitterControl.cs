using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2013BlueSplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _brush;

        public VS2013BlueSplitterControl(DockPane pane)
            : base(pane)
        {
            _brush = new SolidBrush(pane.DockPanel.Skin.AutoHideStripSkin.DockStripBackground.StartColor);
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
                        e.Graphics.FillRectangle(_brush, rect.X, rect.Y,
                                                         Measures.SplitterSize, rect.Height);
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        e.Graphics.FillRectangle(_brush, rect.X, rect.Y, rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }
}