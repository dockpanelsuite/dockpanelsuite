using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;
    using ThemeVS2013;
    using ThemeVS2012.Blue;

    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012BlueTheme : ThemeBase
    {
        public VS2012BlueTheme()
        {
            ColorPalette = new DockPanelColorPalette();
            Skin = CreateVisualStudio2012Blue();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Extender.DockPaneCaptionFactory = new VS2012DockPaneCaptionFactory();
            Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2012DockPaneStripFactory();
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

        public DockPanelSkin CreateVisualStudio2012Blue()
        {
            var skin = new DockPanelSkin();

            ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FF293955");
            ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FF465A7D");
            ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FF293955");
            ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF9BA7B7");
            ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.OverflowButtonDefault.Glyph = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.OverflowButtonHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.OverflowButtonHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.OverflowButtonHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FFFFF0D0");
            ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FF75633D");
            ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#3D5277");// TODO: from theme .FromHtml("#FF4D6082");
            ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.TabButtonSelectedActive.Glyph = ColorTranslator.FromHtml("#FF75633D");
            ColorPalette.TabButtonSelectedActiveHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.TabButtonSelectedActiveHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.TabButtonSelectedActiveHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.TabButtonSelectedInactive.Glyph = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.TabButtonSelectedInactiveHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.TabButtonSelectedInactiveHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.TabButtonUnselectedTabHovered.Glyph = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FF293955");
            ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF293955");

            ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FFFFF0D0");
            ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FF75633D");
            ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FFFFF0D0");
            ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FF4D6082");
            ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF4D6082");
            ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowCaptionButtonActive.Glyph = ColorTranslator.FromHtml("#FF75633D");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.ToolWindowCaptionButtonInactive.Glyph = ColorTranslator.FromHtml("#FFCED4DD");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslator.FromHtml("#FFFFFCF4");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslator.FromHtml("#FFE5C365");
            ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowTabSelectedActive.Separator = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FFFFFFFF");
            ColorPalette.ToolWindowTabSelectedInactive.Separator = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF000000");

            ColorPalette.ToolWindowTabUnselected.Separator = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.ToolWindowTabUnselectedHovered.Separator = ColorTranslator.FromHtml("#FF4B5C74");
            ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            return skin;
        }
    }
}