using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        public Color ToolWindowBorder { get; internal set; }
        public Color ToolWindowSeparator { get; internal set; }
        public DockTargetPalette DockTarget { get; } = new DockTargetPalette();
    }

    public interface IPaletteFactory
    {
        void Initialize(DockPanelColorPalette palette);
    }

    public class VS2012PaletteFactory : IPaletteFactory
    {
        private const string Env = "Environment";
        private XDocument _xml;

        public VS2012PaletteFactory(byte[] file)
        {
            _xml = XDocument.Load(new StreamReader(new MemoryStream(file)));
        }

        public void Initialize(DockPanelColorPalette palette)
        {
            palette.AutoHideStripDefault.Background = ColorTranslatorFromHtml("AutoHideTabBackgroundBegin");
            palette.AutoHideStripDefault.Border = ColorTranslatorFromHtml("AutoHideTabBorder");
            palette.AutoHideStripDefault.Text = ColorTranslatorFromHtml("AutoHideTabText");

            palette.AutoHideStripHovered.Background = ColorTranslatorFromHtml("AutoHideTabMouseOverBackgroundBegin");
            palette.AutoHideStripHovered.Border = ColorTranslatorFromHtml("AutoHideTabMouseOverBorder");
            palette.AutoHideStripHovered.Text = ColorTranslatorFromHtml("AutoHideTabMouseOverText");

            palette.OverflowButtonDefault.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonGlyph");

            palette.OverflowButtonHovered.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBackground");
            palette.OverflowButtonHovered.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBorder");
            palette.OverflowButtonHovered.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverGlyph");

            palette.OverflowButtonPressed.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBackground");
            palette.OverflowButtonPressed.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBorder");
            palette.OverflowButtonPressed.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownGlyph");

            palette.TabSelectedActive.Background = ColorTranslatorFromHtml("FileTabSelectedBorder");
            palette.TabSelectedActive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedActiveGlyph");
            palette.TabSelectedActive.Text = ColorTranslatorFromHtml("FileTabSelectedText");

            palette.TabSelectedInactive.Background = ColorTranslatorFromHtml("FileTabInactiveBorder");
            palette.TabSelectedInactive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedInactiveGlyph");
            palette.TabSelectedInactive.Text = ColorTranslatorFromHtml("FileTabInactiveText");

            palette.TabUnselected.Text = ColorTranslatorFromHtml("FileTabText");
            palette.TabUnselected.Background = ColorTranslatorFromHtml("FileTabBackground");

            palette.TabUnselectedHovered.Background = ColorTranslatorFromHtml("FileTabHotBorder");
            palette.TabUnselectedHovered.Button = ColorTranslatorFromHtml("FileTabHotGlyph");
            palette.TabUnselectedHovered.Text = ColorTranslatorFromHtml("FileTabHotText");

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

            palette.MainWindowActive.Background = ColorTranslatorFromHtml("EnvironmentBackground");
            palette.MainWindowStatusBarDefault.Background = ColorTranslatorFromHtml("StatusBarDefault");

            palette.ToolWindowCaptionActive.Background = ColorTranslatorFromHtml("TitleBarActiveBorder");
            palette.ToolWindowCaptionActive.Button = ColorTranslatorFromHtml("ToolWindowButtonActiveGlyph");
            palette.ToolWindowCaptionActive.Grip = ColorTranslatorFromHtml("TitleBarDragHandleActive");
            palette.ToolWindowCaptionActive.Text = ColorTranslatorFromHtml("TitleBarActiveText");

            palette.ToolWindowCaptionInactive.Background = ColorTranslatorFromHtml("TitleBarInactive");
            palette.ToolWindowCaptionInactive.Button = ColorTranslatorFromHtml("ToolWindowButtonInactiveGlyph");
            palette.ToolWindowCaptionInactive.Grip = ColorTranslatorFromHtml("TitleBarDragHandle");
            palette.ToolWindowCaptionInactive.Text = ColorTranslatorFromHtml("TitleBarInactiveText");

            palette.ToolWindowCaptionButtonActiveHovered.Background = ColorTranslatorFromHtml("ToolWindowButtonHoverActive");
            palette.ToolWindowCaptionButtonActiveHovered.Border = ColorTranslatorFromHtml("ToolWindowButtonHoverActiveBorder");
            palette.ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslatorFromHtml("ToolWindowButtonHoverActiveGlyph");

            palette.ToolWindowCaptionButtonPressed.Background = ColorTranslatorFromHtml("ToolWindowButtonDown");
            palette.ToolWindowCaptionButtonPressed.Border = ColorTranslatorFromHtml("ToolWindowButtonDownBorder");
            palette.ToolWindowCaptionButtonPressed.Glyph = ColorTranslatorFromHtml("ToolWindowButtonDownActiveGlyph");

            palette.ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslatorFromHtml("ToolWindowButtonHoverInactive");
            palette.ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslatorFromHtml("ToolWindowButtonHoverInactiveBorder");
            palette.ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslatorFromHtml("ToolWindowButtonHoverInactiveGlyph");

            palette.ToolWindowTabSelectedActive.Background = ColorTranslatorFromHtml("ToolWindowTabSelectedTab");
            palette.ToolWindowTabSelectedActive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedActiveText");

            palette.ToolWindowTabSelectedInactive.Background = palette.ToolWindowTabSelectedActive.Background;
            palette.ToolWindowTabSelectedInactive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedText");

            palette.ToolWindowTabUnselected.Text = ColorTranslatorFromHtml("ToolWindowTabText");
            palette.ToolWindowTabUnselected.Background = ColorTranslatorFromHtml("ToolWindowTabGradientBegin");

            palette.ToolWindowTabUnselectedHovered.Background = ColorTranslatorFromHtml("ToolWindowTabMouseOverBackgroundBegin");
            palette.ToolWindowTabUnselectedHovered.Text = ColorTranslatorFromHtml("ToolWindowTabMouseOverText");

            palette.ToolWindowSeparator = ColorTranslatorFromHtml("ToolWindowTabSeparator");
            palette.ToolWindowBorder = ColorTranslatorFromHtml("ToolWindowBorder");

            palette.DockTarget.Background = ColorTranslatorFromHtml("DockTargetBackground");
            palette.DockTarget.Border = ColorTranslatorFromHtml("DockTargetBorder");
            palette.DockTarget.ButtonBackground = ColorTranslatorFromHtml("DockTargetButtonBackgroundBegin");
            palette.DockTarget.ButtonBorder = ColorTranslatorFromHtml("DockTargetButtonBorder");
            palette.DockTarget.GlyphBackground = ColorTranslatorFromHtml("DockTargetGlyphBackgroundBegin");
            palette.DockTarget.GlyphArrow = ColorTranslatorFromHtml("DockTargetGlyphArrow");
            palette.DockTarget.GlyphBorder = ColorTranslatorFromHtml("DockTargetGlyphBorder");
        }

        private Color ColorTranslatorFromHtml(string name)
        {
            var color = _xml.Root.Element("Theme")
                .Elements("Category").FirstOrDefault(item => item.Attribute("Name").Value == Env)?
                .Elements("Color").FirstOrDefault(item => item.Attribute("Name").Value == name)?
                .Element("Background").Attribute("Source").Value;
            if (color == null)
            {
                return Color.Transparent;
            }

            return ColorTranslator.FromHtml($"#{color}");
        }
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
