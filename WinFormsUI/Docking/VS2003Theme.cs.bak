using System;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Visual Studio 2003 theme.
    /// </summary>
    public class VS2003Theme : ThemeBase
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

            Measures.SplitterSize = 4;
            dockPanel.Extender.DockPaneCaptionFactory = new VS2003DockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new VS2003AutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = null;
            dockPanel.Extender.DockPaneStripFactory = new VS2003DockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = null;
            dockPanel.Extender.DockWindowSplitterControlFactory = null;
            dockPanel.Extender.DockWindowFactory = null;
            dockPanel.Extender.PaneIndicatorFactory = null;
            dockPanel.Extender.PanelIndicatorFactory = null;
            dockPanel.Extender.DockOutlineFactory = null;
            dockPanel.Skin = VS2005Theme.CreateVisualStudio2005();
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
    }
}