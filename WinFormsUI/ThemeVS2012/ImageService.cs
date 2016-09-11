using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    public class ImageService : IImageService
    {
        public Bitmap Dockindicator_PaneDiamond { get; internal set; }
        public Bitmap Dockindicator_PaneDiamond_Fill { get; internal set; }
        public Bitmap Dockindicator_PaneDiamond_Hotspot { get; internal set; }
        public Bitmap DockIndicator_PaneDiamond_HotspotIndex { get; internal set; }
        public Image DockIndicator_PanelBottom { get; internal set; }
        public Image DockIndicator_PanelFill { get; internal set; }
        public Image DockIndicator_PanelLeft { get; internal set; }
        public Image DockIndicator_PanelRight { get; internal set; }
        public Image DockIndicator_PanelTop { get; internal set; }
        public Bitmap DockPane_Close { get; internal set; }
        public Bitmap DockPane_List { get; internal set; }
        public Bitmap DockPane_Dock { get; internal set; }
        public Bitmap DockPaneActive_AutoHide { get; internal set; }
        public Bitmap DockPane_Option { get; internal set; }
        public Bitmap DockPane_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActive_Close { get; }
        public Bitmap DockPaneActive_Dock { get; }
        public Bitmap DockPaneActive_Option { get; }
        public Bitmap DockPaneHover_Close { get; internal set; }
        public Bitmap DockPaneHover_List { get; internal set; }
        public Bitmap DockPaneHover_Dock { get; internal set; }
        public Bitmap DockPaneActiveHover_AutoHide { get; internal set; }
        public Bitmap DockPaneHover_Option { get; internal set; }
        public Bitmap DockPaneHover_OptionOverflow { get; internal set; }
        public Bitmap DockPanePress_Close { get; internal set; }
        public Bitmap DockPanePress_List { get; internal set; }
        public Bitmap DockPanePress_Dock { get; internal set; }
        public Bitmap DockPanePress_AutoHide { get; internal set; }
        public Bitmap DockPanePress_Option { get; internal set; }
        public Bitmap DockPanePress_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActiveHover_Close { get; }
        public Bitmap DockPaneActiveHover_Dock { get; }
        public Bitmap DockPaneActiveHover_Option { get; }
        public Image TabHoverActive_Close { get; internal set; }
        public Image TabActive_Close { get; internal set; }
        public Image TabInactive_Close { get; internal set; }
        public Image TabHoverInactive_Close { get; internal set; }
        public Image TabHoverLostFocus_Close { get; internal set; }
        public Image TabLostFocus_Close { get; internal set; }
        public Image TabPressActive_Close { get; }
        public Image TabPressInactive_Close { get; }
        public Image TabPressLostFocus_Close { get; }

        readonly DockPanelColorPalette _palette;

        public ImageService(ThemeBase theme)
        {
            _palette = theme.ColorPalette;
            Dockindicator_PaneDiamond_Hotspot = Resources.Dockindicator_PaneDiamond_Hotspot;
            DockIndicator_PaneDiamond_HotspotIndex = Resources.DockIndicator_PaneDiamond_HotspotIndex;

            var arrow = _palette.DockTarget.GlyphArrow;
            var outerBorder = _palette.DockTarget.Border;
            var separator = _palette.DockTarget.ButtonBorder;
            var innerBorder = _palette.DockTarget.Background;
            var background = _palette.DockTarget.ButtonBackground;
            var window = _palette.DockTarget.GlyphBorder;
            var core = _palette.DockTarget.GlyphBackground;
            var drawCore = core.ToArgb() != background.ToArgb();

            using (var layerArrow = ImageServiceHelper.GetLayerImage(arrow, 32, theme.PaintingService))
            using (var layerWindow = ImageServiceHelper.GetLayerImage(window, 32, theme.PaintingService))
            using (var layerCore = drawCore ? ImageServiceHelper.GetLayerImage(core, 32, theme.PaintingService) : null)
            using (var layerBorder = ImageServiceHelper.GetBackground(innerBorder, outerBorder, 40, theme.PaintingService))
            using (var bottom = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowBottom,
                layerArrow,
                Resources.MaskWindowBottom,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreBottom,
                layerCore,
                separator))
            using (var center = ImageServiceHelper.GetDockIcon(
                null,
                null,
                Resources.MaskWindowCenter,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreCenter,
                layerCore,
                separator))
            using (var left = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowLeft,
                layerArrow,
                Resources.MaskWindowLeft,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreLeft,
                layerCore,
                separator))
            using (var right = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowRight,
                layerArrow,
                Resources.MaskWindowRight,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreRight,
                layerCore,
                separator))
            using (var top = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowTop,
                layerArrow,
                Resources.MaskWindowTop,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreTop,
                layerCore,
                separator))
            {
                DockIndicator_PanelBottom = ImageServiceHelper.GetDockImage(bottom, layerBorder);
                DockIndicator_PanelFill = ImageServiceHelper.GetDockImage(center, layerBorder);
                DockIndicator_PanelLeft = ImageServiceHelper.GetDockImage(left, layerBorder);
                DockIndicator_PanelRight = ImageServiceHelper.GetDockImage(right, layerBorder);
                DockIndicator_PanelTop = ImageServiceHelper.GetDockImage(top, layerBorder);

                using (var five = ImageServiceHelper.GetFiveBackground(Resources.MaskDockFive, innerBorder, outerBorder, theme.PaintingService))
                {
                    Dockindicator_PaneDiamond = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
                    Dockindicator_PaneDiamond_Fill = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
                }
            }

            TabActive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabSelectedActive.Button, _palette.TabSelectedActive.Background);
            TabInactive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabUnselectedHovered.Button, _palette.TabUnselectedHovered.Background);
            TabLostFocus_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabSelectedInactive.Button, _palette.TabSelectedInactive.Background);
            TabHoverActive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonSelectedActiveHovered.Glyph, _palette.TabButtonSelectedActiveHovered.Background, _palette.TabButtonSelectedActiveHovered.Border);
            TabHoverInactive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, _palette.TabButtonUnselectedTabHoveredButtonHovered.Background, _palette.TabButtonUnselectedTabHoveredButtonHovered.Border);
            TabHoverLostFocus_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonSelectedInactiveHovered.Glyph, _palette.TabButtonSelectedInactiveHovered.Background, _palette.TabButtonSelectedInactiveHovered.Border);

            TabPressActive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonSelectedActivePressed.Glyph, _palette.TabButtonSelectedActivePressed.Background, _palette.TabButtonSelectedActivePressed.Border);
            TabPressInactive_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonUnselectedTabHoveredButtonPressed.Glyph, _palette.TabButtonUnselectedTabHoveredButtonPressed.Background, _palette.TabButtonUnselectedTabHoveredButtonPressed.Border);
            TabPressLostFocus_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, _palette.TabButtonSelectedInactivePressed.Glyph, _palette.TabButtonSelectedInactivePressed.Background, _palette.TabButtonSelectedInactivePressed.Border);

            DockPane_List = ImageServiceHelper.GetImage(Resources.MaskTabList, _palette.OverflowButtonDefault.Glyph, _palette.MainWindowActive.Background);
            DockPane_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, _palette.OverflowButtonDefault.Glyph, _palette.MainWindowActive.Background);

            DockPaneHover_List = ImageServiceHelper.GetImage(Resources.MaskTabList, _palette.OverflowButtonHovered.Glyph, _palette.OverflowButtonHovered.Background, _palette.OverflowButtonHovered.Border);
            DockPaneHover_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, _palette.OverflowButtonHovered.Glyph, _palette.OverflowButtonHovered.Background, _palette.OverflowButtonHovered.Border);

            DockPanePress_List = ImageServiceHelper.GetImage(Resources.MaskTabList, _palette.OverflowButtonPressed.Glyph, _palette.OverflowButtonPressed.Background, _palette.OverflowButtonPressed.Border);
            DockPanePress_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, _palette.OverflowButtonPressed.Glyph, _palette.OverflowButtonPressed.Background, _palette.OverflowButtonPressed.Border);

            DockPane_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);
            DockPane_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);
            DockPane_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);

            DockPaneActive_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);

            DockPaneHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);

            DockPaneActiveHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);

            DockPanePress_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
        }
    }
}