using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class DockPanelColorPalette
    {
        public DockPanelColorPalette(IPaletteFactory factory)
        {
            factory.Initialize(this);
        }

        public AutoHideStripPalette AutoHideStripDefault { get; } = new AutoHideStripPalette();
        public AutoHideStripPalette AutoHideStripHovered { get; } = new AutoHideStripPalette();
        public ButtonPalette OverflowButtonDefault { get; } = new ButtonPalette();
        public HoveredButtonPalette OverflowButtonHovered { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette OverflowButtonPressed { get; } = new HoveredButtonPalette();
        public TabPalette TabSelectedActive { get; } = new TabPalette();
        public TabPalette TabSelectedInactive { get; } = new TabPalette();
        public UnselectedTabPalette TabUnselected { get; } = new UnselectedTabPalette();
        public TabPalette TabUnselectedHovered { get; } = new TabPalette();
        public HoveredButtonPalette TabButtonSelectedActiveHovered { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette TabButtonSelectedActivePressed { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette TabButtonSelectedInactiveHovered { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette TabButtonSelectedInactivePressed { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonHovered { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonPressed { get; } = new HoveredButtonPalette();
        public MainWindowPalette MainWindowActive { get; } = new MainWindowPalette();
        public MainWindowStatusBarPalette MainWindowStatusBarDefault { get; } = new MainWindowStatusBarPalette();
        public ToolWindowCaptionPalette ToolWindowCaptionActive { get; } = new ToolWindowCaptionPalette();
        public ToolWindowCaptionPalette ToolWindowCaptionInactive { get; } = new ToolWindowCaptionPalette();
        public HoveredButtonPalette ToolWindowCaptionButtonActiveHovered { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette ToolWindowCaptionButtonPressed { get; } = new HoveredButtonPalette();
        public HoveredButtonPalette ToolWindowCaptionButtonInactiveHovered { get; } = new HoveredButtonPalette();
        public ToolWindowTabPalette ToolWindowTabSelectedActive { get; } = new ToolWindowTabPalette();
        public ToolWindowTabPalette ToolWindowTabSelectedInactive { get; } = new ToolWindowTabPalette();
        public ToolWindowUnselectedTabPalette ToolWindowTabUnselected { get; } = new ToolWindowUnselectedTabPalette();
        public ToolWindowTabPalette ToolWindowTabUnselectedHovered { get; } = new ToolWindowTabPalette();
        public Color ToolWindowBorder { get; set; }
        public Color ToolWindowSeparator { get; set; }
        public DockTargetPalette DockTarget { get; } = new DockTargetPalette();
        public CommandBarMenuPalette CommandBarMenuDefault { get; } = new CommandBarMenuPalette();
        public CommandBarMenuPopupPalette CommandBarMenuPopupDefault { get; } = new CommandBarMenuPopupPalette();
        public CommandBarMenuPopupDisabledPalette CommandBarMenuPopupDisabled { get; } = new CommandBarMenuPopupDisabledPalette();
        public CommandBarMenuPopupHoveredPalette CommandBarMenuPopupHovered { get; } = new CommandBarMenuPopupHoveredPalette();
        public CommandBarMenuTopLevelHeaderPalette CommandBarMenuTopLevelHeaderHovered { get; } = new CommandBarMenuTopLevelHeaderPalette();
        public CommandBarToolbarPalette CommandBarToolbarDefault { get; } = new CommandBarToolbarPalette();
        public CommandBarToolbarButtonCheckedPalette CommandBarToolbarButtonChecked { get; } = new CommandBarToolbarButtonCheckedPalette();
        public CommandBarToolbarButtonCheckedHoveredPalette CommandBarToolbarButtonCheckedHovered { get; } = new CommandBarToolbarButtonCheckedHoveredPalette();
        public CommandBarToolbarButtonPalette CommandBarToolbarButtonDefault { get; } = new CommandBarToolbarButtonPalette();
        public CommandBarToolbarButtonHoveredPalette CommandBarToolbarButtonHovered { get; } = new CommandBarToolbarButtonHoveredPalette();
        public CommandBarToolbarButtonPressedPalette CommandBarToolbarButtonPressed { get; } = new CommandBarToolbarButtonPressedPalette();
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowHovered { get; } = new CommandBarToolbarOverflowButtonPalette();
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowPressed { get; } = new CommandBarToolbarOverflowButtonPalette();

        public VisualStudioColorTable ColorTable { get; }
    }

    public class CommandBarToolbarOverflowButtonPalette
    {
        public Color Background { get; set; }
        public Color Glyph { get; set; }
    }

    public class CommandBarToolbarButtonPressedPalette
    {
        public Color Arrow { get; set; }
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarButtonHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Separator { get; set; }
    }

    public class CommandBarToolbarButtonPalette
    {
        public Color Arrow { get; set; }
    }

    public class CommandBarToolbarButtonCheckedHoveredPalette
    {
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarButtonCheckedPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Grip { get; set; }
        public Color OverflowButtonBackground { get; set; }
        public Color OverflowButtonGlyph { get; set; }
        public Color Separator { get; set; }
        public Color SeparatorAccent { get; set; }
        public Color Tray { get; set; }
    }

    public class CommandBarMenuTopLevelHeaderPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color ItemBackground { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupDisabledPalette
    {
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupPalette
    {
        public Color Arrow { get; set; }
        public Color BackgroundBottom { get; set; }
        public Color BackgroundTop { get; set; }
        public Color Border { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color IconBackground { get; set; }
        public Color Separator { get; set; }
    }

    public class CommandBarMenuPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public interface IPaletteFactory
    {
        void Initialize(DockPanelColorPalette palette);
    }

    public class DockTargetPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color ButtonBackground { get; set; }
        public Color ButtonBorder { get; set; }
        public Color GlyphBackground { get; set; }
        public Color GlyphArrow { get; set; }
        public Color GlyphBorder { get; set; }
    }

    public class HoveredButtonPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Glyph { get; set; }
    }

    public class ButtonPalette
    {
        public Color Glyph { get; set; }
    }

    public class MainWindowPalette
    {
        public Color Background { get; set; }
    }

    public class MainWindowStatusBarPalette
    {
        public Color Background { get; set; }
        public Color Highlight { get; set; }
        public Color HighlightText { get; set; }
        public Color ResizeGrip { get; set; }
        public Color ResizeGripAccent { get; set; }
        public Color Text { get; set; }
    }

    public class ToolWindowTabPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public class ToolWindowUnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013
        public Color Text { get; set; }
    }

    public class ToolWindowCaptionPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Grip { get; set; }
        public Color Text { get; set; }
    }

    public class TabPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Text { get; set; }
    }

    public class UnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013 only
        public Color Text { get; set; }
    }

    public class AutoHideStripPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }
}
