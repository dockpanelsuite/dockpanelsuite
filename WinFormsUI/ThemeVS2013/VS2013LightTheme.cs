using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using WeifenLuo.WinFormsUI.ThemeVS2012;
    using WeifenLuo.WinFormsUI.ThemeVS2013;
    using WeifenLuo.WinFormsUI.ThemeVS2013.Light;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013LightTheme : ThemeBase
    {
        public VS2013LightTheme()
        {
            Skin = CreateVisualStudio2013Light();
            ImageService = new ImageService(Skin.ColorPalette);
            PaintingService = new PaintingService();
        }

        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public override void Apply(DockPanel dockPanel)
        {
            if (Extender != null)
            {
                return;
            }

            Extender = new DockPanelExtender(dockPanel);
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Extender.DockPaneCaptionFactory = new VS2013DockPaneCaptionFactory();
            Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2013DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2013DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = new VS2013WindowSplitterControlFactory();
            Extender.DockWindowFactory = new VS2012DockWindowFactory();
            Extender.PaneIndicatorFactory = new VS2012PaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new VS2012PanelIndicatorFactory();
            Extender.DockOutlineFactory = new VS2012DockOutlineFactory();
        }

        public override void CleanUp(DockPanel dockPanel)
        {
            PaintingService.CleanUp();
            base.CleanUp(dockPanel);
        }

        private class VS2013DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2013DockPaneStrip(pane);
            }
        }

        public static DockPanelSkin CreateVisualStudio2013Light()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            skin.ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            skin.ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.OverflowButtonDefault.Glyph = ColorTranslator.FromHtml("#FF717171");
            skin.ColorPalette.OverflowButtonHovered.Background = ColorTranslator.FromHtml("#FFC9DEF5");
            skin.ColorPalette.OverflowButtonHovered.Border = ColorTranslator.FromHtml("#FFC9DEF5");
            skin.ColorPalette.OverflowButtonHovered.Glyph = ColorTranslator.FromHtml("#FF007ACC");

            skin.ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FF6D6D70");
            skin.ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FF717171");

            skin.ColorPalette.TabUnselected.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            skin.ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FF1E1E1E");

            skin.ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabButtonSelectedActive.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Border = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabButtonSelectedInactive.Glyph = ColorTranslator.FromHtml("#FF6D6D70");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Background = ColorTranslator.FromHtml("#FFE6E7ED");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Border = ColorTranslator.FromHtml("#FFE6E7ED");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF717171");

            skin.ColorPalette.TabButtonUnselectedTabHovered.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FFEFEFF2");
            skin.ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF007ACC");

            skin.ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.ToolWindowCaptionActive.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FF59A8DE");
            skin.ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            skin.ColorPalette.ToolWindowCaptionInactive.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            skin.ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FF1E1E1E");
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF999999");
            skin.ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.ToolWindowCaptionButtonActive.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionButtonInactive.Glyph = ColorTranslator.FromHtml("#FF1E1E1E");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslator.FromHtml("#FFF7F7F9");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslator.FromHtml("#FFF7F7F9");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF717171");

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FFF5F5F5");
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FFF5F5F5");
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            skin.ColorPalette.ToolWindowTabUnselected.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            skin.ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FF444444");

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FFC9DEF5");
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FF1E1E1E");

            return skin;
        }
    }
}
