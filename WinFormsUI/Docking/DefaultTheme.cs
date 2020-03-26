using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class DefaultTheme : ThemeBase
    {
        internal DefaultTheme()
        {
            Extender.AutoHideStripFactory = new DefaultAutoHideStripFactory();
            Extender.AutoHideWindowFactory = new DefaultAutoHideWindowFactory();
            Extender.WindowSplitterControlFactory = new DefaultWindowSplitterControlFactory();
            Extender.DockWindowFactory = new DefaultDockWindowFactory();
            Extender.DockPaneSplitterControlFactory = new DefaultDockPaneSplitterControlFactory();
            Extender.DockPaneCaptionFactory = new DefaultDockPaneCaptionFactory();
            Extender.DockPaneStripFactory = new DefaultDockPaneStripFactory();
            Extender.DockIndicatorFactory = new DefaultDockIndicatorFactory();
            Extender.DockOutlineFactory = new DefaultDockOutlineFactory();
            Extender.PaneIndicatorFactory = new DefaultPaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new DefaultPanelIndicatorFactory();
        }

        private class DefaultAutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new DefaultAutoHideStripBase(panel);
            }

            internal class DefaultAutoHideStripBase : AutoHideStripBase
            {
                public DefaultAutoHideStripBase(DockPanel panel)
                    : base(panel)
                {
                }

                protected override Rectangle GetTabBounds(Tab tab)
                {
                    return Rectangle.Empty;
                }

                protected override IDockContent HitTest(Point point)
                {
                    return null;
                }

                protected internal override int MeasureHeight()
                {
                    return 0;
                }
            }

        }

        private class DefaultAutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
        {
            public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
            {
                return new DefaultAutoHideWindowControl(panel);
            }

            private class DefaultAutoHideWindowControl : DockPanel.AutoHideWindowControl
            {
                public DefaultAutoHideWindowControl(DockPanel dockPanel) : base(dockPanel)
                {
                }
            }
        }

        private class DefaultWindowSplitterControlFactory : DockPanelExtender.IWindowSplitterControlFactory
        {
            public SplitterBase CreateSplitterControl(ISplitterHost host)
            {
                return new SplitterBase();
            }
        }

        private class DefaultDockWindowFactory : DockPanelExtender.IDockWindowFactory
        {
            public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
            {
                return new DockWindow(dockPanel, dockState);
            }
        }

        private class DefaultDockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
        {
            public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
            {
                return new DockPane.SplitterControlBase(pane);
            }
        }

        private class DefaultDockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new DefaultDockPaneCaption(pane);
            }

            private class DefaultDockPaneCaption : DockPaneCaptionBase
            {
                public DefaultDockPaneCaption(DockPane pane) : base(pane)
                {
                }

                protected internal override int MeasureHeight()
                {
                    return 0;
                }
            }
        }

        private class DefaultDockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new DefaultDockPaneStrip(pane);
            }

            private class DefaultDockPaneStrip : DockPaneStripBase
            {
                public DefaultDockPaneStrip(DockPane pane) : base(pane)
                {
                }

                public override GraphicsPath GetOutline(int index)
                {
                    return new GraphicsPath();
                }

                protected override Rectangle GetTabBounds(Tab tab)
                {
                    return Rectangle.Empty;
                }

                protected internal override void EnsureTabVisible(IDockContent content)
                {
                }

                protected internal override int HitTest(Point point)
                {
                    return -1;
                }

                protected internal override int MeasureHeight()
                {
                    return 0;
                }
            }
        }

        private class DefaultDockIndicatorFactory : DockPanelExtender.IDockIndicatorFactory
        {
            public DockPanel.DockDragHandler.DockIndicator CreateDockIndicator(DockPanel.DockDragHandler dockDragHandler)
            {
                return new DockPanel.DockDragHandler.DockIndicator(dockDragHandler);
            }
        }

        private class DefaultDockOutlineFactory : DockPanelExtender.IDockOutlineFactory
        {
            public DockOutlineBase CreateDockOutline()
            {
                return new DefaultDockOutline();
            }

            private class DefaultDockOutline : DockOutlineBase
            {
                protected override void OnClose()
                {
                }

                protected override void OnShow()
                {
                }
            }
        }

        private class DefaultPaneIndicatorFactory : DockPanelExtender.IPaneIndicatorFactory
        {
            public DockPanel.IPaneIndicator CreatePaneIndicator(ThemeBase theme)
            {
                return new DefaultPaneIndicator(theme);
            }

            private class DefaultPaneIndicator : DockPanel.IPaneIndicator
            {
                private ThemeBase theme;

                public DefaultPaneIndicator(ThemeBase theme)
                {
                    this.theme = theme;
                }

                public Point Location { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
                public bool Visible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

                public int Left => throw new System.NotImplementedException();

                public int Top => throw new System.NotImplementedException();

                public int Right => throw new System.NotImplementedException();

                public int Bottom => throw new System.NotImplementedException();

                public Rectangle ClientRectangle => throw new System.NotImplementedException();

                public int Width => throw new System.NotImplementedException();

                public int Height => throw new System.NotImplementedException();

                public GraphicsPath DisplayingGraphicsPath => throw new System.NotImplementedException();

                public DockStyle Status { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

                public DockStyle HitTest(Point pt)
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        private class DefaultPanelIndicatorFactory : DockPanelExtender.IPanelIndicatorFactory
        {
            public DockPanel.IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme)
            {
                return new DefaultPanelIndicator(style, theme);
            }

            private class DefaultPanelIndicator : DockPanel.IPanelIndicator
            {
                private DockStyle style;
                private ThemeBase theme;

                public DefaultPanelIndicator(DockStyle style, ThemeBase theme)
                {
                    this.style = style;
                    this.theme = theme;
                }

                public Point Location { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
                public bool Visible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

                public Rectangle Bounds => throw new System.NotImplementedException();

                public int Width => throw new System.NotImplementedException();

                public int Height => throw new System.NotImplementedException();

                public DockStyle Status { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

                public DockStyle HitTest(Point pt)
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}