namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    using Docking;
    using static Docking.DockPanelExtender;

    /// <summary>
    /// Visual Studio 2012 theme base.
    /// </summary>
    public abstract class VS2012ThemeBase : ThemeBase
    {
        public VS2012ThemeBase(byte[] resources, IDockPaneSplitterControlFactory splitterFactory, IWindowSplitterControlFactory windowsSplitterFactory)
        {
            ColorPalette = new DockPanelColorPalette(new VS2012PaletteFactory(resources));
            Skin = new DockPanelSkin();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
            ToolStripRenderer = new VisualStudioToolStripRenderer(ColorPalette);
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Measures.DockPadding = 6;
            ShowAutoHideContentOnHover = false;
            Extender.DockPaneCaptionFactory = new VS2012DockPaneCaptionFactory();
            Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2012DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = splitterFactory ?? new VS2012DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = windowsSplitterFactory ?? new VS2012WindowSplitterControlFactory();
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
    }
}