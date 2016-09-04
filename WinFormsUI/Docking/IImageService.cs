using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    public interface IImageService
    {
        Image ActiveTabHover_Close { get; }
        Image ActiveTab_Close { get; }
        Bitmap Dockindicator_PaneDiamond { get; }
        Bitmap Dockindicator_PaneDiamond_Fill { get; }
        Bitmap Dockindicator_PaneDiamond_Hotspot { get; }
        Bitmap DockIndicator_PaneDiamond_HotspotIndex { get; }
        Image DockIndicator_PanelBottom { get; }
        Image DockIndicator_PanelFill { get; }
        Image DockIndicator_PanelLeft { get; }
        Image DockIndicator_PanelRight { get; }
        Image DockIndicator_PanelTop { get; }
        Bitmap DockPane_Close { get; }
        Bitmap DockPane_List { get; }
        Bitmap DockPane_Dock { get; }
        Bitmap DockPane_AutoHide { get; }
        Bitmap DockPane_Option { get; }
        Bitmap DockPane_OptionOverflow { get; }
        Bitmap DockPaneActive_Close { get; }
        Bitmap DockPaneActive_Dock { get; }
        Bitmap DockPaneActive_Option { get; }
        Bitmap DockPaneHover_Close { get; }
        Bitmap DockPaneHover_List { get; }
        Bitmap DockPaneHover_Dock { get; }
        Bitmap DockPaneHover_AutoHide { get; }
        Bitmap DockPaneHover_Option { get; }
        Bitmap DockPaneHover_OptionOverflow { get; }
        Bitmap DockPaneActiveHover_Close { get; }
        Bitmap DockPaneActiveHover_Dock { get; }
        Bitmap DockPaneActiveHover_Option { get; }
        Image InactiveTab_Close { get; }
        Image InactiveTabHover_Close { get; }
        Image LostFocusTabHover_Close { get; }
        Image LostFocusTab_Close { get; }
    }
}