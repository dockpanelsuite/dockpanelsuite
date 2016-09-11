using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;
    using ThemeVS2012.Dark;

    /// <summary>
    /// Visual Studio 2012 Dark theme.
    /// </summary>
    public class VS2012DarkTheme : ThemeBase
    {
        public VS2012DarkTheme()
        {
            ColorPalette = new DockPanelColorPalette();
            Skin = CreateVisualStudio2012Dark();
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
            Extender.DockPaneCaptionFactory = new VS2012DockPaneCaptionFactory();
            Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2012DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2012DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = new VS2012WindowSplitterControlFactory();
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

        public DockPanelSkin CreateVisualStudio2012Dark()
        {
            var skin = new DockPanelSkin();

            ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FF2D2D30");
            ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FF2D2D30");
            ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FF0097FB");

            ColorPalette.OverflowButtonDefault.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");
            ColorPalette.OverflowButtonHovered.Background = ColorTranslator.FromHtml("#FF3E3E40");
            ColorPalette.OverflowButtonHovered.Border = ColorTranslator.FromHtml("#FF3E3E40");
            ColorPalette.OverflowButtonHovered.Glyph = ColorTranslator.FromHtml("#FF007ACC");

            ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FF6D6D70");
            ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FFF1F1F1");

            ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FFF1F1F1");

            ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabButtonSelectedActive.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabButtonSelectedActiveHovered.Background = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabButtonSelectedActiveHovered.Border = ColorTranslator.FromHtml("#FF1C97EA");
            ColorPalette.TabButtonSelectedActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabButtonSelectedInactive.Glyph = ColorTranslator.FromHtml("#FF6D6D70");
            ColorPalette.TabButtonSelectedInactiveHovered.Background = ColorTranslator.FromHtml("#FF555555");
            ColorPalette.TabButtonSelectedInactiveHovered.Border = ColorTranslator.FromHtml("#FF555555");
            ColorPalette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");

            ColorPalette.TabButtonUnselectedTabHovered.Glyph = ColorTranslator.FromHtml("#FFD0E6F5");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FF2D2D30");
            ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF007ACC");

            ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FF007ACC");
            ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FF59A8DE");
            ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FF2D2D30");
            ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FFF1F1F1");
            ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF46464A");
            ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            ColorPalette.ToolWindowCaptionButtonActive.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslator.FromHtml("#FF52B0EF");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowCaptionButtonInactive.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslator.FromHtml("#FF393939");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslator.FromHtml("#FF393939");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslator.FromHtml("#FFF1F1F1");

            ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FF252526");
            ColorPalette.ToolWindowTabSelectedActive.Separator = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF0097FB");

            ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FF252526");
            ColorPalette.ToolWindowTabSelectedInactive.Separator = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF0097FB");

            ColorPalette.ToolWindowTabUnselected.Separator = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FFD0D0D0");

            ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF3E3E40");
            ColorPalette.ToolWindowTabUnselectedHovered.Separator = ColorTranslator.FromHtml("#FF3F3F46");
            ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FF55AAFF");

            return skin;
        }
    }
}