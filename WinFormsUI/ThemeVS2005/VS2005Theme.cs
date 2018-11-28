using System.Drawing;
using System.Drawing.Drawing2D;
using WeifenLuo.WinFormsUI.ThemeVS2005;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Visual Studio 2005 theme.
    /// </summary>
    public partial class VS2005Theme : ThemeBase
    {
        public VS2005Theme()
        {
            Skin = CreateVisualStudio2005();
            Measures.SplitterSize = 4;
            Extender.AutoHideStripFactory = new VS2005AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2005AutoHideWindowFactory();
            Extender.DockPaneCaptionFactory = new VS2005DockPaneCaptionFactory();
            Extender.DockPaneStripFactory = new VS2005DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2005DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = new VS2005WindowSplitterControlFactory();
            Extender.DockWindowFactory = new VS2005DockWindowFactory();
            Extender.PaneIndicatorFactory = new VS2005PaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new VS2005PanelIndicatorFactory();
            Extender.DockOutlineFactory = new VS2005DockOutlineFactory();
            Extender.DockIndicatorFactory = new VS2005DockIndicatorFactory();
        }

        internal static DockPanelSkin CreateVisualStudio2005()
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

        #region DefaultDockPaneCaptionFactory

        private class VS2005DockPaneCaptionFactory : IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new VS2005DockPaneCaption(pane);
            }
        }

        #endregion

        #region DefaultAutoHideStripFactory

        private class VS2005AutoHideStripFactory : IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new VS2005AutoHideStrip(panel);
            }
        }

        #endregion

        #region DefaultDockPaneTabStripFactory

        private class VS2005DockPaneStripFactory : IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2005DockPaneStrip(pane);
            }
        }
        #endregion
    }
}