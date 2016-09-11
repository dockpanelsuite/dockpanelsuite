using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Blue
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
        public Image ActiveTabHover_Close { get; internal set; }
        public Image ActiveTab_Close { get; internal set; }
        public Bitmap DockPane_Close { get; internal set; }
        public Bitmap DockPane_List { get; internal set; }
        public Bitmap DockPane_Dock { get; internal set; }
        public Bitmap DockPane_AutoHide { get; internal set; }
        public Bitmap DockPane_Option { get; internal set; }
        public Bitmap DockPane_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActive_Close { get; }
        public Bitmap DockPaneActive_Dock { get; }
        public Bitmap DockPaneActive_Option { get; }
        public Bitmap DockPaneHover_Close { get; internal set; }
        public Bitmap DockPaneHover_List { get; internal set; }
        public Bitmap DockPaneHover_Dock { get; internal set; }
        public Bitmap DockPaneHover_AutoHide { get; internal set; }
        public Bitmap DockPaneHover_Option { get; internal set; }
        public Bitmap DockPaneHover_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActiveHover_Close { get; }
        public Bitmap DockPaneActiveHover_Dock { get; }
        public Bitmap DockPaneActiveHover_Option { get; }
        public Image InactiveTab_Close { get; internal set; }
        public Image InactiveTabHover_Close { get; internal set; }
        public Image LostFocusTabHover_Close { get; internal set; }
        public Image LostFocusTab_Close { get; internal set; }

        readonly DockPanelColorPalette palette;

        public ImageService(ThemeBase theme)
        {
            this.palette = theme.ColorPalette;
            Dockindicator_PaneDiamond_Hotspot = Resources.Dockindicator_PaneDiamond_Hotspot;
            DockIndicator_PaneDiamond_HotspotIndex = Resources.DockIndicator_PaneDiamond_HotspotIndex;

            var arrow = ColorTranslator.FromHtml("#FF4B5C74");
            var outerBorder = ColorTranslator.FromHtml("#FF636971"); // ?
            var separator = ColorTranslator.FromHtml("#FF8B919C"); // ?
            var innerBorder = ColorTranslator.FromHtml("#FFFFFFFF");
            var background = ColorTranslator.FromHtml("#FFF5F9FC"); // ?
            var window = ColorTranslator.FromHtml("#FF4B5C74");
            var core = ColorTranslator.FromHtml("#FFFDE8A7");

            var layerArrow = ImageServiceHelper.GetLayerImage(arrow, 32, theme.PaintingService);
            var layerWindow = ImageServiceHelper.GetLayerImage(window, 32, theme.PaintingService);
            var layerCore = ImageServiceHelper.GetLayerImage(core, 32, theme.PaintingService);
            var layerBorder = ImageServiceHelper.GetBackground(innerBorder, outerBorder, 40, theme.PaintingService);

            var bottom = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowBottom,
                layerArrow,
                Resources.MaskWindowBottom,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreBottom,
                layerCore,
                separator);
            var center = ImageServiceHelper.GetDockIcon(
                null,
                null,
                Resources.MaskWindowCenter,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreCenter,
                layerCore,
                separator);
            var left = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowLeft,
                layerArrow,
                Resources.MaskWindowLeft,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreLeft,
                layerCore,
                separator);
            var right = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowRight,
                layerArrow,
                Resources.MaskWindowRight,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreRight,
                layerCore,
                separator);
            var top = ImageServiceHelper.GetDockIcon(
                Resources.MaskArrowTop,
                layerArrow,
                Resources.MaskWindowTop,
                layerWindow,
                Resources.MaskDock,
                background,
                theme.PaintingService,
                Resources.MaskCoreTop,
                layerCore,
                separator);
            DockIndicator_PanelBottom = ImageServiceHelper.GetDockImage(bottom, layerBorder);
            DockIndicator_PanelFill = ImageServiceHelper.GetDockImage(center, layerBorder);
            DockIndicator_PanelLeft = ImageServiceHelper.GetDockImage(left, layerBorder);
            DockIndicator_PanelRight = ImageServiceHelper.GetDockImage(right, layerBorder);
            DockIndicator_PanelTop = ImageServiceHelper.GetDockImage(top, layerBorder);
            var mask = Resources.MaskDockFive;
            var five = ImageServiceHelper.GetFiveBackground(mask, innerBorder, outerBorder, theme.PaintingService);
            Dockindicator_PaneDiamond = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
            Dockindicator_PaneDiamond_Fill = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);

            ActiveTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedActiveHovered.Glyph, palette.TabButtonSelectedActiveHovered.Background, palette.TabButtonSelectedActiveHovered.Border);
            ActiveTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabSelectedActive.Button, palette.TabSelectedActive.Background);
            InactiveTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabUnselectedHovered.Button, palette.TabUnselectedHovered.Background);
            InactiveTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, palette.TabButtonUnselectedTabHoveredButtonHovered.Background, palette.TabButtonUnselectedTabHoveredButtonHovered.Border);
            LostFocusTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedInactiveHovered.Glyph, palette.TabButtonSelectedInactiveHovered.Background, palette.TabButtonSelectedInactiveHovered.Border);
            LostFocusTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabSelectedInactive.Button, palette.TabSelectedInactive.Background);

            DockPane_List = ImageServiceHelper.GetImage(Resources.MaskTabList, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_List = ImageServiceHelper.GetImage(Resources.MaskTabList, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);
            DockPane_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);

            DockPane_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
        }
    }
}