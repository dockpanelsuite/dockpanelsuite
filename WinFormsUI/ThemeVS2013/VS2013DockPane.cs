using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2013
{
    public class VS2013DockPane : DockPane
    {
        public VS2013DockPane(IDockContent content, DockState visibleState, bool show)
            : base(content, visibleState, show)
        {
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
        public VS2013DockPane(IDockContent content, FloatWindow floatWindow, bool show)
            : base(content, floatWindow, show)
        {
        }

        public VS2013DockPane(IDockContent content, DockPane previousPane, DockAlignment alignment, double proportion, bool show)
            : base(content, previousPane, alignment, proportion, show)
        {
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
        public VS2013DockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
            : base(content, floatWindowBounds, show)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var color = DockPanel.Theme.ColorPalette.ToolWindowBorder;
            e.Graphics.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(color), e.ClipRectangle);
        }

        protected override Rectangle ContentRectangle
        {
            get
            {
                var rect = base.ContentRectangle;
                if (DockState == DockState.Document || Contents.Count == 1)
                {
                    rect.Height--;
                }

                rect.Width -= 2;
                rect.X++;
                return rect;
            }
        }
    }
}
