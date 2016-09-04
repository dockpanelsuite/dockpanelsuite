using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using WeifenLuo.WinFormsUI.ThemeVS2012;
    using WeifenLuo.WinFormsUI.ThemeVS2013;
    using WeifenLuo.WinFormsUI.ThemeVS2013.Blue;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013BlueTheme : ThemeBase
    {
        public VS2013BlueTheme()
        {
            Skin = CreateVisualStudio2013Blue();
            PaintingService = new PaintingService();
            ImageService = new ImageService();
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
            Extender.AutoHideWindowFactory = new VS2013AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2013DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2013DockPaneSplitterControlFactory();
            Extender.DockWindowSplitterControlFactory = new VS2013DockWindowSplitterControlFactory();
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

        public static DockPanelSkin CreateVisualStudio2013Blue()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.MainWindowActive.Background = ColorTranslator.FromHtml("#FF293955");
            skin.ColorPalette.MainWindowStatusBarDefault.Background = ColorTranslator.FromHtml("#FF007ACC");

            skin.ColorPalette.AutoHideStripDefault.Background = ColorTranslator.FromHtml("#FF293955");
            skin.ColorPalette.AutoHideStripDefault.Border = ColorTranslator.FromHtml("#FF465A7D");
            skin.ColorPalette.AutoHideStripDefault.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.AutoHideStripHovered.Background = ColorTranslator.FromHtml("#FF293955");
            skin.ColorPalette.AutoHideStripHovered.Border = ColorTranslator.FromHtml("#FF9BA7B7");
            skin.ColorPalette.AutoHideStripHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabSelectedActive.Background = ColorTranslator.FromHtml("#FFFFF29D");
            skin.ColorPalette.TabSelectedActive.Button = ColorTranslator.FromHtml("#FF75633D");
            skin.ColorPalette.TabSelectedActive.Text = ColorTranslator.FromHtml("#FF000000");

            skin.ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FF4D6082");
            skin.ColorPalette.TabSelectedInactive.Button = ColorTranslator.FromHtml("#FFCED4DD");
            skin.ColorPalette.TabSelectedInactive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabUnselected.Background = ColorTranslator.FromHtml("#FF364E6F");
            skin.ColorPalette.TabUnselected.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.TabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF5B7199");
            skin.ColorPalette.TabUnselectedHovered.Button = ColorTranslator.FromHtml("#FFCED4DD");
            skin.ColorPalette.TabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowCaptionActive.Background = ColorTranslator.FromHtml("#FFFFF29D");
            skin.ColorPalette.ToolWindowCaptionActive.Border = ColorTranslator.FromHtml("#FF8E9BBC");
            skin.ColorPalette.ToolWindowCaptionActive.Button = ColorTranslator.FromHtml("#FF75633D");
            skin.ColorPalette.ToolWindowCaptionActive.Grip = ColorTranslator.FromHtml("#FFFFF29D");
            skin.ColorPalette.ToolWindowCaptionActive.Text = ColorTranslator.FromHtml("#FF000000");

            skin.ColorPalette.ToolWindowCaptionInactive.Background = ColorTranslator.FromHtml("#FF4D6082");
            skin.ColorPalette.ToolWindowCaptionInactive.Border = ColorTranslator.FromHtml("#FF8E9BBC");
            skin.ColorPalette.ToolWindowCaptionInactive.Button = ColorTranslator.FromHtml("#FFCED4DD");
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = ColorTranslator.FromHtml("#FF4D6082");
            skin.ColorPalette.ToolWindowCaptionInactive.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = ColorTranslator.FromHtml("#FF000000");

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = ColorTranslator.FromHtml("#FFFFFFFF");
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = ColorTranslator.FromHtml("#FF000000");

            skin.ColorPalette.ToolWindowTabUnselected.Background = ColorTranslator.FromHtml("#FF4D6082");
            skin.ColorPalette.ToolWindowTabUnselected.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = ColorTranslator.FromHtml("#FF4B5C74");
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = ColorTranslator.FromHtml("#FFFFFFFF");

            return skin;
        }
    }
}
