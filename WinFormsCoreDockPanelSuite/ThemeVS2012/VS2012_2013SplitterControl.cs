using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2012
{
    [ToolboxItem(false)]
    internal class VS2012_2013SplitterControl : DockPane.SplitterControlBase
    {
        private readonly SolidBrush _horizontalBrush;
        private int SplitterSize { get; }

        public VS2012_2013SplitterControl(DockPane pane)
            : base(pane)
        {
            _horizontalBrush = pane.DockPanel.Theme.PaintingService.GetBrush(pane.DockPanel.Theme.ColorPalette.MainWindowActive.Background);
            SplitterSize = pane.DockPanel.Theme.Measures.SplitterSize;
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
                        e.Graphics.FillRectangle(_horizontalBrush, rect);
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