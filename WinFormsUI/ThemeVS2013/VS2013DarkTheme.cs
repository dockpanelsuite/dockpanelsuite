using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using WeifenLuo.WinFormsUI.ThemeVS2012;
    using WeifenLuo.WinFormsUI.ThemeVS2013;
    using WeifenLuo.WinFormsUI.ThemeVS2013.Dark;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013DarkTheme : ThemeBase
    {
        public VS2013DarkTheme()
        {
            Skin = CreateVisualStudio2013Dark();
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

        public static DockPanelSkin CreateVisualStudio2013Dark()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FF3F3F46");
            skin.ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            skin.ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FF0097FB");

            skin.ColorPalette.OverflowButtonDefault.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");
            skin.ColorPalette.OverflowButtonHovered.Background = ColorTranslator.FromHtml("#FF3E3E40");
            skin.ColorPalette.OverflowButtonHovered.Border = ColorTranslator.FromHtml("#FF3E3E40");
            skin.ColorPalette.OverflowButtonHovered.Glyph = ColorTranslator.FromHtml("#FF007ACC");

            skin.ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FF3F3F46");
            skin.ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FF6D6D70");
            skin.ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FFF1F1F1");

            skin.ColorPalette.TabUnselected.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FFF1F1F1");

            skin.ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabButtonSelectedActive.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Border = ColorTranslator.FromHtml("#FF1C97EA");
            skin.ColorPalette.TabButtonSelectedActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabButtonSelectedInactive.Glyph = ColorTranslator.FromHtml("#FF6D6D70");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Background = ColorTranslator.FromHtml("#FF555555");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Border = ColorTranslator.FromHtml("#FF555555");
            skin.ColorPalette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");

            skin.ColorPalette.TabButtonUnselectedTabHovered.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF007ACC");

            skin.ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            skin.ColorPalette.ToolWindowCaptionActive.Border = ColorTranslator.FromHtml("#FF3F3F46");
            skin.ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FF59A8DE");
            skin.ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.ToolWindowCaptionInactive.Border = ColorTranslator.FromHtml("#FF3F3F46");
            skin.ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FFF1F1F1");
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF46464A");
            skin.ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            skin.ColorPalette.ToolWindowCaptionButtonActive.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            skin.ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionButtonInactive.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslator.FromHtml("#FF393939");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslator.FromHtml("#FF393939");
            skin.ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FF252526");
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF0097FB");

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FF252526");
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF0097FB");

            skin.ColorPalette.ToolWindowTabUnselected.Background = ColorTranslator.FromHtml("#FF2D2D30");
            skin.ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF3E3E40");
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FF55AAFF");

            return skin;
        }
    }
}
