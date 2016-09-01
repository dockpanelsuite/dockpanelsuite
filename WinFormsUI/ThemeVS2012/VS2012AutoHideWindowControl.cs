using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012AutoHideWindowControl : DockPanel.AutoHideWindowControl
    {
        private class VS2012AutoHideWindowSplitterControl : SplitterBase
        {
            private readonly SolidBrush _horizontalBrush;
            private readonly SolidBrush _backgroundBrush;
            private readonly Color[] _verticalSurroundColors;

            public VS2012AutoHideWindowSplitterControl(DockPanel.AutoHideWindowControl autoHideWindow)
            {
                AutoHideWindow = autoHideWindow;
                _horizontalBrush = autoHideWindow.DockPanel.Theme.PaintingService.GetBrush(autoHideWindow.DockPanel.Skin.ColorPalette.TabSelectedInactive.Background);
                _backgroundBrush = autoHideWindow.DockPanel.Theme.PaintingService.GetBrush(autoHideWindow.DockPanel.Skin.ColorPalette.MainWindowActive.Background);
                _verticalSurroundColors = new[]
                                                   {
                                                   autoHideWindow.DockPanel.Skin.ColorPalette.TabSelectedInactive.Background
                                               };
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

                Rectangle rect = ClientRectangle;

                if (rect.Width <= 0 || rect.Height <= 0)
                    return;

                switch (AutoHideWindow.DockState)
                {
                    case DockState.DockRightAutoHide:
                    case DockState.DockLeftAutoHide:
                        {
                            e.Graphics.FillRectangle(_backgroundBrush, rect.X, rect.Y, rect.Width, rect.Height);
                            using (var path = new GraphicsPath())
                            {
                                path.AddRectangle(rect);
                                using (var brush = new PathGradientBrush(path)
                                    {
                                        // TODO: fix this color.
                                        CenterColor = _horizontalBrush.Color, SurroundColors = _verticalSurroundColors
                                    })
                                {
                                    e.Graphics.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                                             Measures.SplitterSize / 3, rect.Height);
                                }
                            }
                        }
                        break;
                    case DockState.DockBottomAutoHide:
                    case DockState.DockTopAutoHide:
                        {
                            e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                            rect.Width, Measures.SplitterSize);
                        }
                        break;
                }
            }
        }

        public VS2012AutoHideWindowControl(DockPanel dockPanel) : base(dockPanel)
        {
            m_splitter = new VS2012AutoHideWindowSplitterControl(this);
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