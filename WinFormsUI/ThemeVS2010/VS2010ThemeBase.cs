namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    using Docking;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
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
        
        public class VS2010PaletteFactory : IPaletteFactory
        {
            private XDocument _xml;

            public VS2010PaletteFactory(byte[] file)
            {
                _xml = XDocument.Load(new StreamReader(new MemoryStream(file)));
            }

            public void Initialize(DockPanelColorPalette palette)
            {
                palette.AutoHideStripDefault.Background = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_BACKGROUND_BEGIN");
                palette.AutoHideStripDefault.Border = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_BORDER");
                palette.AutoHideStripDefault.Text = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_TEXT");

                palette.AutoHideStripHovered.Background = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_MOUSEOVER_BACKGROUND_BEGIN");
                palette.AutoHideStripHovered.Border = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_MOUSEOVER_BORDER");
                palette.AutoHideStripHovered.Text = ColorTranslatorFromHtml("VSCOLOR_AUTOHIDE_TAB_MOUSEOVER_TEXT");

                palette.OverflowButtonDefault.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonGlyph");

                palette.OverflowButtonHovered.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBackground");
                palette.OverflowButtonHovered.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBorder");
                palette.OverflowButtonHovered.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverGlyph");

                palette.OverflowButtonPressed.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBackground");
                palette.OverflowButtonPressed.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBorder");
                palette.OverflowButtonPressed.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownGlyph");

                palette.TabSelectedActive.Background = ColorTranslatorFromHtml("VSCOLOR_FILETAB_SELECTEDBORDER");
                palette.TabSelectedActive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedActiveGlyph");
                palette.TabSelectedActive.Text = ColorTranslatorFromHtml("VSCOLOR_FILETAB_SELECTEDTEXT");

                palette.TabSelectedInactive.Background = ColorTranslatorFromHtml("FileTabInactiveBorder");
                palette.TabSelectedInactive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedInactiveGlyph");
                palette.TabSelectedInactive.Text = ColorTranslatorFromHtml("VSCOLOR_FILETAB_INACTIVE_TEXT");

                palette.TabUnselected.Text = ColorTranslatorFromHtml("VSCOLOR_FILETAB_TEXT");
                palette.TabUnselected.Background = ColorTranslatorFromHtml("FileTabBackground");

                palette.TabUnselectedHovered.Background = ColorTranslatorFromHtml("VSCOLOR_FILETAB_HOT_BORDER");
                palette.TabUnselectedHovered.Button = ColorTranslatorFromHtml("VSCOLOR_FILETAB_HOT_GLYPH");
                palette.TabUnselectedHovered.Text = ColorTranslatorFromHtml("VSCOLOR_FILETAB_HOT_TEXT");

                palette.TabButtonSelectedActiveHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActive");
                palette.TabButtonSelectedActiveHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActiveBorder");
                palette.TabButtonSelectedActiveHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActiveGlyph");

                palette.TabButtonSelectedActivePressed.Background = ColorTranslatorFromHtml("FileTabButtonDownSelectedActive");
                palette.TabButtonSelectedActivePressed.Border = ColorTranslatorFromHtml("FileTabButtonDownSelectedActiveBorder");
                palette.TabButtonSelectedActivePressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownSelectedActiveGlyph");

                palette.TabButtonSelectedInactiveHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactive");
                palette.TabButtonSelectedInactiveHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactiveBorder");
                palette.TabButtonSelectedInactiveHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactiveGlyph");

                palette.TabButtonSelectedInactivePressed.Background = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactive");
                palette.TabButtonSelectedInactivePressed.Border = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactiveBorder");
                palette.TabButtonSelectedInactivePressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactiveGlyph");

                palette.TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverInactive");
                palette.TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverInactiveBorder");
                palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverInactiveGlyph");

                palette.TabButtonUnselectedTabHoveredButtonPressed.Background = ColorTranslatorFromHtml("FileTabButtonDownInactive");
                palette.TabButtonUnselectedTabHoveredButtonPressed.Border = ColorTranslatorFromHtml("FileTabButtonDownInactiveBorder");
                palette.TabButtonUnselectedTabHoveredButtonPressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownInactiveGlyph");

                palette.MainWindowActive.Background = ColorTranslatorFromHtml("VSCOLOR_ENVIRONMENT_BACKGROUND_GRADIENTMIDDLE1");
                palette.MainWindowStatusBarDefault.Background = ColorTranslatorFromHtml("StatusBarDefault");

                palette.ToolWindowCaptionActive.Background = ColorTranslatorFromHtml("TitleBarActiveBorder");
                palette.ToolWindowCaptionActive.Button = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_ACTIVE_GLYPH");
                palette.ToolWindowCaptionActive.Grip = ColorTranslatorFromHtml("TitleBarDragHandleActive");
                palette.ToolWindowCaptionActive.Text = ColorTranslatorFromHtml("TitleBarActiveText");

                palette.ToolWindowCaptionInactive.Background = ColorTranslatorFromHtml("TitleBarInactive");
                palette.ToolWindowCaptionInactive.Button = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_INACTIVE_GLYPH");
                palette.ToolWindowCaptionInactive.Grip = ColorTranslatorFromHtml("TitleBarDragHandle");
                palette.ToolWindowCaptionInactive.Text = ColorTranslatorFromHtml("TitleBarInactiveText");

                palette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslatorFromHtml("ToolWindowButtonHoverActive");
                palette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslatorFromHtml("ToolWindowButtonHoverActiveBorder");
                palette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_HOVER_ACTIVE_GLYPH");

                palette.ToolWindowCaptionButtonPressed.Background = ColorTranslatorFromHtml("ToolWindowButtonDown");
                palette.ToolWindowCaptionButtonPressed.Border = ColorTranslatorFromHtml("ToolWindowButtonDownBorder");
                palette.ToolWindowCaptionButtonPressed.Glyph = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_DOWN_ACTIVE_GLYPH");

                palette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_INACTIVE");
                palette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_INACTIVE_BORDER");
                palette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_BUTTON_HOVER_INACTIVE_GLYPH");

                palette.ToolWindowTabSelectedActive.Background = ColorTranslatorFromHtml("ToolWindowTabSelectedTab");
                palette.ToolWindowTabSelectedActive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedActiveText");

                palette.ToolWindowTabSelectedInactive.Background = palette.ToolWindowTabSelectedActive.Background;
                palette.ToolWindowTabSelectedInactive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedText");

                palette.ToolWindowTabUnselected.Text = ColorTranslatorFromHtml("ToolWindowTabText");
                palette.ToolWindowTabUnselected.Background = ColorTranslatorFromHtml("ToolWindowTabGradientBegin");

                palette.ToolWindowTabUnselectedHovered.Background = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_TAB_MOUSEOVER_BACKGROUND_BEGIN");
                palette.ToolWindowTabUnselectedHovered.Text = ColorTranslatorFromHtml("VSCOLOR_TOOLWINDOW_TAB_MOUSEOVER_TEXT");

                palette.ToolWindowSeparator = ColorTranslatorFromHtml("ToolWindowTabSeparator");
                palette.ToolWindowBorder = ColorTranslatorFromHtml("ToolWindowBorder");

                palette.DockTarget.Background = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_BACKGROUND");
                palette.DockTarget.Border = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_BORDER");
                palette.DockTarget.ButtonBackground = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_BUTTON_BACKGROUND_BEGIN");
                palette.DockTarget.ButtonBorder = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_BUTTON_BORDER");
                palette.DockTarget.GlyphBackground = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_GLYPH_BACKGROUND_BEGIN");
                palette.DockTarget.GlyphArrow = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_GLYPH_ARROW");
                palette.DockTarget.GlyphBorder = ColorTranslatorFromHtml("VSCOLOR_DOCKTARGET_GLYPH_BORDER");
            }

            private Color ColorTranslatorFromHtml(string name)
            {
                var color = _xml.Root.Element("themes").Element("theme")
                    .Elements("color").FirstOrDefault(item => item.Attribute("nativeName").Value == name)?
                    .Attribute("colorValue").Value;
                if (color == null)
                {
                    return Color.Transparent;
                }

                return ColorTranslator.FromHtml($"{color}");
            }
        }
    }
}