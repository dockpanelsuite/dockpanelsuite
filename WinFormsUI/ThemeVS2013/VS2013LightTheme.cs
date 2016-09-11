using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;
    using ThemeVS2013;
    using ThemeVS2013.Light;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013LightTheme : ThemeBase
    {
        public VS2013LightTheme()
        {
            ColorPalette = new DockPanelColorPalette();
            Skin = CreateVisualStudio2013Light();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
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
            Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            Extender.DockPaneFactory = new VS2013DockPaneFactory();
            Extender.DockPaneCaptionFactory = new VS2013DockPaneCaptionFactory();
            Extender.DockPaneStripFactory = new VS2013DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2013DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = new VS2013WindowSplitterControlFactory();
            Extender.DockWindowFactory = new VS2012DockWindowFactory();
            Extender.PaneIndicatorFactory = new VS2012PaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new VS2012PanelIndicatorFactory();
            Extender.DockOutlineFactory = new VS2012DockOutlineFactory();
            Extender.DockIndicatorFactory = new VS2012DockIndicatorFactory();
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

        public DockPanelSkin CreateVisualStudio2013Light()
        {
            var skin = new DockPanelSkin();

            ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FF444444");

            ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FF0E70C0");

            ColorPalette.OverflowButtonDefault.Glyph = ColorTranslator.FromHtml("#FF717171");
            ColorPalette.OverflowButtonHovered.Background = ColorTranslator.FromHtml("#FFC9DEF5");
            ColorPalette.OverflowButtonHovered.Border = ColorTranslator.FromHtml("#FFC9DEF5");
            ColorPalette.OverflowButtonHovered.Glyph = ColorTranslator.FromHtml("#FF007ACC");

            ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FFCCCEDB");
            ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FF6D6D70");
            ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FF717171");

            ColorPalette.TabUnselected.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FF1E1E1E");

            ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabButtonSelectedActive.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabButtonSelectedActiveHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabButtonSelectedActiveHovered.Border = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabButtonSelectedActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabButtonSelectedInactive.Glyph = ColorTranslator.FromHtml("#FF6D6D70");
            ColorPalette.TabButtonSelectedInactiveHovered.Background = ColorTranslator.FromHtml("#FFE6E7ED");
            ColorPalette.TabButtonSelectedInactiveHovered.Border = ColorTranslator.FromHtml("#FFE6E7ED");
            ColorPalette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF717171");

            ColorPalette.TabButtonUnselectedTabHovered.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FFEFEFF2");
            ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF007ACC");

            ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.ToolWindowCaptionActive.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FF59A8DE");
            ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            ColorPalette.ToolWindowCaptionInactive.Border = ColorTranslator.FromHtml("#FFCCCEDB");
            ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FF1E1E1E");
            ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF999999");
            ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FF444444");

            ColorPalette.ToolWindowCaptionButtonActive.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowCaptionButtonInactive.Glyph = ColorTranslator.FromHtml("#FF1E1E1E");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslator.FromHtml("#FFF7F7F9");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslator.FromHtml("#FFF7F7F9");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF717171");

            ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FFF5F5F5");
            ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FFF5F5F5");
            ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF0E70C0");

            ColorPalette.ToolWindowTabUnselected.Background = ColorTranslator.FromHtml("#FFEEEEF2");
            ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FF444444");

            ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FFC9DEF5");
            ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FF1E1E1E");

            return skin;
        }
    }
}
