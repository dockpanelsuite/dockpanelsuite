using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Blue
{
    internal class VS2012BlueSplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _horizontalBrush;
        private int _splitterSize;

        public VS2012BlueSplitterControl(DockPane pane)
            : base(pane)
        {
            _horizontalBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background);
            _splitterSize = pane.DockPanel.Theme.Measures.SplitterSize;
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
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                                 _splitterSize, rect.Height);
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                                 rect.Width, _splitterSize);
                    }
                    break;
            }
        }
    }
}