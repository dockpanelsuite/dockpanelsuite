namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    using Docking;
    using ThemeVS2012;
    using ThemeVS2013;

    /// <summary>
    /// Visual Studio 2010 theme base.
    /// </summary>
    public abstract class VS2010ThemeBase : ThemeBase
    {
        public VS2010ThemeBase(byte[] resources)
        {
            ColorPalette = new DockPanelColorPalette(new VS2010PaletteFactory(resources));
            Skin = new DockPanelSkin();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Measures.DockPadding = 6;
            ShowAutoHideContentOnHover = true;
            Extender.DockPaneCaptionFactory = new VS2010DockPaneCaptionFactory();
            Extender.AutoHideStripFactory = new VS2010AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2010AutoHideWindowFactory();
            Extender.DockPaneStripFactory = new VS2010DockPaneStripFactory();
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
    }
}