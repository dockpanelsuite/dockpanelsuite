using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Dark
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
        public Bitmap DockPane_Option { get; internal set; }
        public Bitmap DockPane_OptionOverflow { get; internal set; }
        public Image InactiveTabHover_Close { get; internal set; }
        public Image LostFocusTabHover_Close { get; internal set; }
        public Image LostFocusTab_Close { get; internal set; }

        public ImageService()
        {
            Dockindicator_PaneDiamond = Resources.Dockindicator_PaneDiamond;
            Dockindicator_PaneDiamond_Fill = Resources.Dockindicator_PaneDiamond_Fill;
            Dockindicator_PaneDiamond_Hotspot = Resources.Dockindicator_PaneDiamond_Hotspot;
            DockIndicator_PaneDiamond_HotspotIndex = Resources.DockIndicator_PaneDiamond_HotspotIndex;
            DockIndicator_PanelBottom = Resources.DockIndicator_PanelBottom;
            DockIndicator_PanelFill = Resources.DockIndicator_PanelFill;
            DockIndicator_PanelLeft = Resources.DockIndicator_PanelLeft;
            DockIndicator_PanelRight = Resources.DockIndicator_PanelRight;
            DockIndicator_PanelTop = Resources.DockIndicator_PanelTop;
            ActiveTabHover_Close = Resources.ActiveTabHover_Close;
            ActiveTab_Close = Resources.ActiveTab_Close;
            DockPane_Close = Resources.DockPane_Close;
            DockPane_Option = Resources.DockPane_Option;
            DockPane_OptionOverflow = Resources.DockPane_OptionOverflow;
            InactiveTabHover_Close = Resources.InactiveTabHover_Close;
            LostFocusTabHover_Close = Resources.LostFocusTabHover_Close;
            LostFocusTab_Close = Resources.LostFocusTab_Close;
        }
    }
}