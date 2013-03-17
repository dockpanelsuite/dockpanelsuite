using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.Docking.Skins;

namespace DockSample.Customization
{
    public class Extender
    {
        public enum Schema
        {
            VS2005,
            VS2003,
            VS2012Light
        }

        private class VS2003DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2003DockPaneStrip(pane);
            }
        }

        private class VS2003AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new VS2003AutoHideStrip(panel);
            }
        }

        private class VS2003DockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new VS2003DockPaneCaption(pane);
            }
        }

        private class VS2012LightDockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
        {
            public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
            {
                return new VS2012LightSplitterControl(pane);
            }
        }

        private class VS2012LightDockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2012LightDockPaneStrip(pane);
            }
        }

        private class VS2012LightAutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new VS2012LightAutoHideStrip(panel);
            }
        }

        private class VS2012LightDockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new VS2012LightDockPaneCaption(pane);
            }
        }

        private class VS2012LightDockWindowFactory : DockPanelExtender.IDockWindowFactory
        {
            public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
            {
                return new VS2012LightDockWindow(dockPanel, dockState);
            }
        }

        public static void SetSchema(DockPanel dockPanel, Schema schema)
        {
            if (schema == Schema.VS2005)
            {
                Measures.SplitterSize = 4;
                dockPanel.Extender.AutoHideStripFactory = null;
                dockPanel.Extender.DockPaneCaptionFactory = null;
                dockPanel.Extender.DockPaneStripFactory = null;
                dockPanel.Extender.DockPaneSplitterControlFactory = null;
                dockPanel.Extender.DockWindowFactory = null;
                dockPanel.SkinStyle = Style.VisualStudio2005;
            }
            else if (schema == Schema.VS2003)
            {
                Measures.SplitterSize = 4;
                dockPanel.Extender.DockPaneCaptionFactory = new VS2003DockPaneCaptionFactory();
                dockPanel.Extender.AutoHideStripFactory = new VS2003AutoHideStripFactory();
                dockPanel.Extender.DockPaneStripFactory = new VS2003DockPaneStripFactory();
                dockPanel.Extender.DockPaneSplitterControlFactory = null;
                dockPanel.Extender.DockWindowFactory = null;
                dockPanel.SkinStyle = Style.VisualStudio2005;
            }
            else if (schema == Schema.VS2012Light)
            {
                Measures.SplitterSize = 6;
                dockPanel.Extender.DockPaneCaptionFactory = new VS2012LightDockPaneCaptionFactory();
                dockPanel.Extender.AutoHideStripFactory = new VS2012LightAutoHideStripFactory();
                dockPanel.Extender.DockPaneStripFactory = new VS2012LightDockPaneStripFactory();
                dockPanel.Extender.DockPaneSplitterControlFactory = new VS2012LightDockPaneSplitterControlFactory();
                dockPanel.Extender.DockWindowFactory = new VS2012LightDockWindowFactory();
                dockPanel.SkinStyle = Style.VisualStudio2012Light;
            }
        }
    }
}
