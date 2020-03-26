using System.Drawing;
using System.Drawing.Drawing2D;

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
    }
}