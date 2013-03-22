using System;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.Docking.Skins;

namespace DockSample.Customization
{
    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012LightTheme : ThemeBase
    {
        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public override void Apply(DockPanel dockPanel)
        {
            if (dockPanel == null)
            {
                throw new NullReferenceException("dockPanel");
            }
            
            Measures.SplitterSize = 6;
            dockPanel.Extender.DockPaneCaptionFactory = new VS2012LightDockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new VS2012LightAutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = new VS2012LightAutoHideWindowFactory();
            dockPanel.Extender.DockPaneStripFactory = new VS2012LightDockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = new VS2012LightDockPaneSplitterControlFactory();
            dockPanel.Extender.DockWindowFactory = new VS2012LightDockWindowFactory();
            dockPanel.SkinStyle = Style.VisualStudio2012Light;
        }

        private class VS2012LightAutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
        {
            public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
            {
                return new VS2012LightAutoHideWindowControl(panel);
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
    }
}