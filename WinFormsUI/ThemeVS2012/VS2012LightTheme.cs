using System;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;
    using WeifenLuo.WinFormsUI.ThemeVS2012.Light;

    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012LightTheme : ThemeBase
    {
        public VS2012LightTheme()
        {
            Skin = CreateVisualStudio2012Light();
            ImageService = new ImageService();
            PaintingService = new PaintingService();
        }

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
            dockPanel.Extender.DockPaneCaptionFactory = new VS2012DockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            dockPanel.Extender.DockPaneStripFactory = new VS2012DockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = new VS2012DockPaneSplitterControlFactory();
            dockPanel.Extender.DockWindowSplitterControlFactory = new VS2012DockWindowSplitterControlFactory();
            dockPanel.Extender.DockWindowFactory = new VS2012DockWindowFactory();
            dockPanel.Extender.PaneIndicatorFactory = new VS2012PaneIndicatorFactory();
            dockPanel.Extender.PanelIndicatorFactory = new VS2012PanelIndicatorFactory();
            dockPanel.Extender.DockOutlineFactory = new VS2012DockOutlineFactory();
        }

        public override void CleanUp(DockPanel dockPanel)
        {
            PaintingService.CleanUp();
            base.CleanUp(dockPanel);
        }

        public static DockPanelSkin CreateVisualStudio2012Light()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FFEFEFF2");

            skin.ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FFEFEFF2");
            skin.ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FFEFEFF2");
            skin.ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FF6D6D70");
            skin.ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FF717171");

            skin.ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FF1E1E1E");

            skin.ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FF59A8DE");
            skin.ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FFEFEFF2");
            skin.ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FF1E1E1E");
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF999999");
            skin.ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FFF5F5F5");
            skin.ColorPalette.ToolWindowTabSelectedActive.Separator = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FFF6F6F6");
            skin.ColorPalette.ToolWindowTabSelectedInactive.Separator = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.ToolWindowTabUnselected.Separator = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FFFEFEFE");
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Separator = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FF007ACC");

            return skin;
        }
    }
}