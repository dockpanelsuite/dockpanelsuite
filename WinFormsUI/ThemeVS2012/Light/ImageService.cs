using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Light
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
            DockPane_List = Resources.DockPane_List;
            DockPane_Dock = Resources.DockPane_Dock;
            DockPane_AutoHide = Resources.DockPane_AutoHide;
            DockPane_Option = Resources.DockPane_Option;
            DockPane_OptionOverflow = Resources.DockPane_OptionOverflow;
            DockPaneActive_Close = Resources.DockPaneActive_Close;
            DockPaneActive_Dock = Resources.DockPaneActive_Dock;
            DockPaneActive_Option = Resources.DockPaneActive_Option;
            DockPaneHover_Close = Resources.DockPaneHover_Close;
            DockPaneHover_List = Resources.DockPaneHover_List;
            DockPaneHover_Dock = Resources.DockPaneHover_Dock;
            DockPaneHover_AutoHide = Resources.DockPaneHover_AutoHide;
            DockPaneHover_Option = Resources.DockPaneHover_Option;
            DockPaneHover_OptionOverflow = Resources.DockPaneHover_OptionOverflow;
            DockPaneActiveHover_Close = Resources.DockPaneActiveHover_Close;
            DockPaneActiveHover_Dock = Resources.DockPaneActiveHover_Dock;
            DockPaneActiveHover_Option = Resources.DockPaneActiveHover_Option;
            InactiveTabHover_Close = Resources.InactiveTabHover_Close;
            LostFocusTabHover_Close = Resources.LostFocusTabHover_Close;
            LostFocusTab_Close = Resources.LostFocusTab_Close;
        }
    }
}