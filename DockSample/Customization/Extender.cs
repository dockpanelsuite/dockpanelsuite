using System;
using System.Drawing;
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

        public static void SetSchema(DockPanel dockPanel, Extender.Schema schema)
        {
            if (schema == Extender.Schema.VS2005)
            {
                dockPanel.Extender.AutoHideStripFactory = null;
                dockPanel.Extender.DockPaneCaptionFactory = null;
                dockPanel.Extender.DockPaneStripFactory = null;
                dockPanel.SkinStyle = Style.VisualStudio2005;
            }
            else if (schema == Extender.Schema.VS2003)
            {
                dockPanel.Extender.DockPaneCaptionFactory = new VS2003DockPaneCaptionFactory();
                dockPanel.Extender.AutoHideStripFactory = new VS2003AutoHideStripFactory();
                dockPanel.Extender.DockPaneStripFactory = new VS2003DockPaneStripFactory();
                dockPanel.SkinStyle = Style.VisualStudio2005;
            }
            else if (schema == Schema.VS2012Light)
            {
                dockPanel.Extender.DockPaneCaptionFactory = new VS2012LightDockPaneCaptionFactory();
                dockPanel.Extender.AutoHideStripFactory = new VS2012LightAutoHideStripFactory();
                dockPanel.Extender.DockPaneStripFactory = new VS2012LightDockPaneStripFactory();
                dockPanel.SkinStyle = Style.VisualStudio2012Light;
            }
        }
    }
}
