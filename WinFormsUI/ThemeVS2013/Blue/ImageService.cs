using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2013.Blue
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

        public ImageService(DockPanelColorPalette palette)
        {
            this.palette = palette;
            Dockindicator_PaneDiamond = Resources.Dockindicator_PaneDiamond;
            Dockindicator_PaneDiamond_Fill = Resources.Dockindicator_PaneDiamond_Fill;
            Dockindicator_PaneDiamond_Hotspot = Resources.Dockindicator_PaneDiamond_Hotspot;
            DockIndicator_PaneDiamond_HotspotIndex = Resources.DockIndicator_PaneDiamond_HotspotIndex;
            DockIndicator_PanelBottom = Resources.DockIndicator_PanelBottom;
            DockIndicator_PanelFill = Resources.DockIndicator_PanelFill;
            DockIndicator_PanelLeft = Resources.DockIndicator_PanelLeft;
            DockIndicator_PanelRight = Resources.DockIndicator_PanelRight;
            DockIndicator_PanelTop = Resources.DockIndicator_PanelTop;

            ActiveTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedActiveHovered.Glyph, palette.TabButtonSelectedActiveHovered.Background, palette.TabButtonSelectedActiveHovered.Border);
            ActiveTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedActive.Glyph, palette.TabSelectedActive.Background);
            InactiveTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonUnselectedTabHovered.Glyph, palette.TabUnselectedHovered.Background);
            InactiveTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, palette.TabButtonUnselectedTabHoveredButtonHovered.Background, palette.TabButtonUnselectedTabHoveredButtonHovered.Border);
            LostFocusTabHover_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedInactiveHovered.Glyph, palette.TabButtonSelectedInactiveHovered.Background, palette.TabButtonSelectedInactiveHovered.Border);
            LostFocusTab_Close = ImageServiceHelper.GetImage(Resources.MaskTabClose, palette.TabButtonSelectedInactive.Glyph, palette.TabSelectedInactive.Background);

            DockPane_List = ImageServiceHelper.GetImage(Resources.MaskTabList, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_List = ImageServiceHelper.GetImage(Resources.MaskTabList, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);
            DockPane_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, palette.OverflowButtonDefault.Glyph, palette.MainWindowActive.Background);
            DockPaneHover_OptionOverflow = ImageServiceHelper.GetImage(Resources.MaskTabOverflow, palette.OverflowButtonHovered.Glyph, palette.OverflowButtonHovered.Background, palette.OverflowButtonHovered.Border);

            DockPane_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonInactive.Glyph, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonActive.Glyph, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Close = ImageServiceHelper.GetImage(Resources.MaskToolWindowClose, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonInactive.Glyph, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonActive.Glyph, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Dock = ImageServiceHelper.GetImage(Resources.MaskToolWindowDock, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonInactive.Glyph, palette.ToolWindowCaptionInactive.Background);
            DockPaneActive_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonActive.Glyph, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonInactiveHovered.Glyph, palette.ToolWindowCaptionButtonInactiveHovered.Background, palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneActiveHover_Option = ImageServiceHelper.GetImage(Resources.MaskToolWindowOption, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPane_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionButtonActive.Glyph, palette.ToolWindowCaptionActive.Background);
            DockPaneHover_AutoHide = ImageServiceHelper.GetImage(Resources.MaskToolWindowAutoHide, palette.ToolWindowCaptionButtonActiveHovered.Glyph, palette.ToolWindowCaptionButtonActiveHovered.Background, palette.ToolWindowCaptionButtonActiveHovered.Border);
        }
    }
}