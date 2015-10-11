using System;

namespace WeifenLuo.WinFormsUI.Docking
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

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
            dockPanel.Skin = CreateVisualStudio2003();
        }

        internal static DockPanelSkin CreateVisualStudio2003()
        {
            DockPanelSkin skin = new DockPanelSkin();

            skin.AutoHideStripSkin.DockStripGradient.StartColor = SystemColors.ControlLight;
            skin.AutoHideStripSkin.DockStripGradient.EndColor = SystemColors.ControlLight;
            skin.AutoHideStripSkin.TabGradient.TextColor = SystemColors.ControlDarkDark;

            skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.StartColor = SystemColors.Control;
            skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.EndColor = SystemColors.Control;
            skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = SystemColors.ControlLightLight;
            skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = SystemColors.ControlLightLight;
            skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.StartColor = SystemColors.ControlLight;
            skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.EndColor = SystemColors.ControlLight;

            skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.StartColor = SystemColors.ControlLight;
            skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.EndColor = SystemColors.ControlLight;

            skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.StartColor = SystemColors.Control;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.EndColor = SystemColors.Control;

            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.StartColor = Color.Transparent;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.EndColor = Color.Transparent;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.TextColor = SystemColors.ControlDarkDark;

            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor = SystemColors.GradientActiveCaption;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor = SystemColors.ActiveCaption;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor = SystemColors.ActiveCaptionText;

            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor = SystemColors.GradientInactiveCaption;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor = SystemColors.InactiveCaption;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor = SystemColors.InactiveCaptionText;

            return skin;
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