using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2012;

namespace WeifenLuo.WinFormsUI.ThemeVS2013.Dark
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
            Dockindicator_PaneDiamond_Hotspot = ThemeVS2012.Resources.Dockindicator_PaneDiamond_Hotspot;
            DockIndicator_PaneDiamond_HotspotIndex = ThemeVS2012.Resources.DockIndicator_PaneDiamond_HotspotIndex;

            var arrow = ColorTranslator.FromHtml("#FFF1F1F1");
            var outerBorder = ColorTranslator.FromHtml("#FF3F3F46");
            var innerBorder = ColorTranslator.FromHtml("#FF757575"); //?
            var background = ColorTranslator.FromHtml("#FF252526");
            var window = ColorTranslator.FromHtml("#FF007ACC");

            var layerArrow = ImageServiceHelper.GetLayerImage(arrow, 32, theme.PaintingService);
            var layerWindow = ImageServiceHelper.GetLayerImage(window, 32, theme.PaintingService);
            var layerBorder = ImageServiceHelper.GetBackground(innerBorder, outerBorder, 40, theme.PaintingService);

            var bottom = ImageServiceHelper.GetDockIcon(
                ThemeVS2012.Resources.MaskArrowBottom,
                layerArrow,
                ThemeVS2012.Resources.MaskWindowBottom,
                layerWindow,
                ThemeVS2012.Resources.MaskDock,
                background,
                theme.PaintingService);
            var center = ImageServiceHelper.GetDockIcon(
                null,
                null,
                ThemeVS2012.Resources.MaskWindowCenter,
                layerWindow,
                ThemeVS2012.Resources.MaskDock,
                background,
                theme.PaintingService);
            var left = ImageServiceHelper.GetDockIcon(
                ThemeVS2012.Resources.MaskArrowLeft,
                layerArrow,
                ThemeVS2012.Resources.MaskWindowLeft,
                layerWindow,
                ThemeVS2012.Resources.MaskDock,
                background,
                theme.PaintingService);
            var right = ImageServiceHelper.GetDockIcon(
                ThemeVS2012.Resources.MaskArrowRight,
                layerArrow,
                ThemeVS2012.Resources.MaskWindowRight,
                layerWindow,
                ThemeVS2012.Resources.MaskDock,
                background,
                theme.PaintingService);
            var top = ImageServiceHelper.GetDockIcon(
                ThemeVS2012.Resources.MaskArrowTop,
                layerArrow,
                ThemeVS2012.Resources.MaskWindowTop,
                layerWindow,
                ThemeVS2012.Resources.MaskDock,
                background,
                theme.PaintingService);
            DockIndicator_PanelBottom = ImageServiceHelper.GetDockImage(bottom, layerBorder);
            DockIndicator_PanelFill = ImageServiceHelper.GetDockImage(center, layerBorder);
            DockIndicator_PanelLeft = ImageServiceHelper.GetDockImage(left, layerBorder);
            DockIndicator_PanelRight = ImageServiceHelper.GetDockImage(right, layerBorder);
            DockIndicator_PanelTop = ImageServiceHelper.GetDockImage(top, layerBorder);
            var mask = ThemeVS2012.Resources.MaskDockFive;
            var five = ImageServiceHelper.GetFiveBackground(mask, innerBorder, outerBorder, theme.PaintingService);
            Dockindicator_PaneDiamond = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
            Dockindicator_PaneDiamond_Fill = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);

            ActiveTabHover_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabButtonSelectedActiveHovered.Glyph, palette.TabButtonSelectedActiveHovered.Background, palette.TabButtonSelectedActiveHovered.Border);
            ActiveTab_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabSelectedActive.Button, palette.TabSelectedActive.Background);
            InactiveTab_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabUnselectedHovered.Button, palette.TabUnselectedHovered.Background);
            InactiveTabHover_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, palette.TabButtonUnselectedTabHoveredButtonHovered.Background, palette.TabButtonUnselectedTabHoveredButtonHovered.Border);
            LostFocusTabHover_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabButtonSelectedInactiveHovered.Glyph, palette.TabButtonSelectedInactiveHovered.Background, palette.TabButtonSelectedInactiveHovered.Border);
            LostFocusTab_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabClose, palette.TabSelectedInactive.Button, palette.TabSelectedInactive.Background);

            DockPane_List = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabList, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_List = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabList, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);
            DockPane_OptionOverflow = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabOverflow, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_OptionOverflow = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskTabOverflow, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);

            DockPane_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowClose, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowClose, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Close = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Dock = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowDock, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Dock = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowDock, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Dock = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Dock = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Option = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowOption, palette.ToolWindowCaptionInactive.Button, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Option = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowOption, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Option = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Option = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_AutoHide = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionActive.Button, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_AutoHide = ImageServiceHelper.GetImage(ThemeVS2012.Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
        }
    }
}