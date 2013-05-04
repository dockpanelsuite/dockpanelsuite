using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012LightAutoHideWindowControl : DockPanel.AutoHideWindowControl
    {
        private class VS2012LightAutoHideWindowSplitterControl : SplitterBase
        {
            public VS2012LightAutoHideWindowSplitterControl(DockPanel.AutoHideWindowControl autoHideWindow)
            {
                AutoHideWindow = autoHideWindow;
            }

            private DockPanel.AutoHideWindowControl AutoHideWindow { get; set; }

            protected override int SplitterSize
            {
                get { return Measures.SplitterSize; }
            }

            protected override void StartDrag()
            {
                AutoHideWindow.DockPanel.BeginDrag(AutoHideWindow, AutoHideWindow.RectangleToScreen(Bounds));
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;
                Rectangle rect = ClientRectangle;

                if (AutoHideWindow.DockState == DockState.DockLeftAutoHide || AutoHideWindow.DockState == DockState.DockRightAutoHide)
                {
                    var path = new GraphicsPath();
                    path.AddRectangle(rect);
                    var brush = new PathGradientBrush(path) { CenterColor = Color.FromArgb(0xFF, 204, 206, 219), SurroundColors = new[] { SystemColors.Control } };
                    g.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                        Measures.SplitterSize / 3, rect.Height);}
                else
                    if (AutoHideWindow.DockState == DockState.DockTopAutoHide || AutoHideWindow.DockState == DockState.DockBottomAutoHide)
                    {
                        var brush = new SolidBrush(Color.FromArgb(0xFF, 204, 206, 219));
                        g.FillRectangle(brush, rect.X, rect.Y,
                            rect.Width, Measures.SplitterSize);}
            }
        }

        public VS2012LightAutoHideWindowControl(DockPanel dockPanel) : base(dockPanel)
        {
            m_splitter = new VS2012LightAutoHideWindowSplitterControl(this);
            Controls.Add(m_splitter);
        }

        protected override Rectangle DisplayingRectangle
        {
            get
            {
                Rectangle rect = ClientRectangle;

                // exclude the border and the splitter
                if (DockState == DockState.DockBottomAutoHide)
                {
                    rect.Y += Measures.SplitterSize;
                    rect.Height -= Measures.SplitterSize;
                }
                else if (DockState == DockState.DockRightAutoHide)
                {
                    rect.X += Measures.SplitterSize;
                    rect.Width -= Measures.SplitterSize;
                }
                else if (DockState == DockState.DockTopAutoHide)
                    rect.Height -= Measures.SplitterSize;
                else if (DockState == DockState.DockLeftAutoHide)
                    rect.Width -= Measures.SplitterSize;

                return rect;
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            DockPadding.All = 0;
            if (DockState == DockState.DockLeftAutoHide)
            {
                //DockPadding.Right = 2;
                m_splitter.Dock = DockStyle.Right;
            }
            else if (DockState == DockState.DockRightAutoHide)
            {
                //DockPadding.Left = 2;
                m_splitter.Dock = DockStyle.Left;
            }
            else if (DockState == DockState.DockTopAutoHide)
            {
                //DockPadding.Bottom = 2;
                m_splitter.Dock = DockStyle.Bottom;
            }
            else if (DockState == DockState.DockBottomAutoHide)
            {
                //DockPadding.Top = 2;
                m_splitter.Dock = DockStyle.Top;
            }

            Rectangle rectDisplaying = DisplayingRectangle;
            Rectangle rectHidden = new Rectangle(-rectDisplaying.Width, rectDisplaying.Y, rectDisplaying.Width, rectDisplaying.Height);
            foreach (Control c in Controls)
            {
                DockPane pane = c as DockPane;
                if (pane == null)
                    continue;


                if (pane == ActivePane)
                    pane.Bounds = rectDisplaying;
                else
                    pane.Bounds = rectHidden;
            }

            base.OnLayout(levent);
        }
    }
}