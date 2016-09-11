using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace WeifenLuo.WinFormsUI.Docking
{
    #region DockPanelSkin classes
    /// <summary>
    /// The skin to use when displaying the DockPanel.
    /// The skin allows custom gradient color schemes to be used when drawing the
    /// DockStrips and Tabs.
    /// </summary>
    [TypeConverter(typeof(DockPanelSkinConverter))]
    public class DockPanelSkin
    {
        private AutoHideStripSkin m_autoHideStripSkin = new AutoHideStripSkin();
        private DockPaneStripSkin m_dockPaneStripSkin = new DockPaneStripSkin();

        /// <summary>
        /// The skin used to display the auto hide strips and tabs.
        /// </summary>
        public AutoHideStripSkin AutoHideStripSkin
        {
            get { return m_autoHideStripSkin; }
            set { m_autoHideStripSkin = value; }
        }

        /// <summary>
        /// The skin used to display the Document and ToolWindow style DockStrips and Tabs.
        /// </summary>
        public DockPaneStripSkin DockPaneStripSkin
        {
            get { return m_dockPaneStripSkin; }
            set { m_dockPaneStripSkin = value; }
        }
    }

    public class DockPanelColorPalette
    {
        private const string Env = "Environment";
        private XDocument xml;

        public DockPanelColorPalette(byte[] file)
        {
            if (file == null)
            {
                return;
            }

            xml = XDocument.Load(new StreamReader(new MemoryStream(file)));
            AutoHideStripDefault.Background = ColorTranslatorFromHtml("AutoHideTabBackgroundBegin");
            AutoHideStripDefault.Border = ColorTranslatorFromHtml("AutoHideTabBorder");
            AutoHideStripDefault.Text = ColorTranslatorFromHtml("AutoHideTabText");

            AutoHideStripHovered.Background = ColorTranslatorFromHtml("AutoHideTabMouseOverBackgroundBegin");
            AutoHideStripHovered.Border = ColorTranslatorFromHtml("AutoHideTabMouseOverBorder");
            AutoHideStripHovered.Text = ColorTranslatorFromHtml("AutoHideTabMouseOverText");

            OverflowButtonDefault.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonGlyph");

            OverflowButtonHovered.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBackground");
            OverflowButtonHovered.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverBorder");
            OverflowButtonHovered.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseOverGlyph");

            OverflowButtonPressed.Background = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBackground");
            OverflowButtonPressed.Border = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownBorder");
            OverflowButtonPressed.Glyph = ColorTranslatorFromHtml("DocWellOverflowButtonMouseDownGlyph");

            TabSelectedActive.Background = ColorTranslatorFromHtml("FileTabSelectedBorder");
            TabSelectedActive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedActiveGlyph");
            TabSelectedActive.Text = ColorTranslatorFromHtml("FileTabSelectedText");

            TabSelectedInactive.Background = ColorTranslatorFromHtml("FileTabInactiveBorder");
            TabSelectedInactive.Button = ColorTranslatorFromHtml("FileTabButtonSelectedInactiveGlyph");
            TabSelectedInactive.Text = ColorTranslatorFromHtml("FileTabInactiveText");

            TabUnselected.Text = ColorTranslatorFromHtml("FileTabText");
            TabUnselected.Background = ColorTranslatorFromHtml("FileTabBackground");

            TabUnselectedHovered.Background = ColorTranslatorFromHtml("FileTabHotBorder");
            TabUnselectedHovered.Button = ColorTranslatorFromHtml("FileTabHotGlyph");
            TabUnselectedHovered.Text = ColorTranslatorFromHtml("FileTabHotText");

            TabButtonSelectedActiveHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActive");
            TabButtonSelectedActiveHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActiveBorder");
            TabButtonSelectedActiveHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverSelectedActiveGlyph");

            TabButtonSelectedActivePressed.Background = ColorTranslatorFromHtml("FileTabButtonDownSelectedActive");
            TabButtonSelectedActivePressed.Border = ColorTranslatorFromHtml("FileTabButtonDownSelectedActiveBorder");
            TabButtonSelectedActivePressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownSelectedActiveGlyph");

            TabButtonSelectedInactiveHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactive");
            TabButtonSelectedInactiveHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactiveBorder");
            TabButtonSelectedInactiveHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverSelectedInactiveGlyph");

            TabButtonSelectedInactivePressed.Background = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactive");
            TabButtonSelectedInactivePressed.Border = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactiveBorder");
            TabButtonSelectedInactivePressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownSelectedInactiveGlyph");

            TabButtonUnselectedTabHoveredButtonHovered.Background = ColorTranslatorFromHtml("FileTabButtonHoverInactive");
            TabButtonUnselectedTabHoveredButtonHovered.Border = ColorTranslatorFromHtml("FileTabButtonHoverInactiveBorder");
            TabButtonUnselectedTabHoveredButtonHovered.Glyph = ColorTranslatorFromHtml("FileTabButtonHoverInactiveGlyph");

            TabButtonUnselectedTabHoveredButtonPressed.Background = ColorTranslatorFromHtml("FileTabButtonDownInactive");
            TabButtonUnselectedTabHoveredButtonPressed.Border = ColorTranslatorFromHtml("FileTabButtonDownInactiveBorder");
            TabButtonUnselectedTabHoveredButtonPressed.Glyph = ColorTranslatorFromHtml("FileTabButtonDownInactiveGlyph");

            MainWindowActive.Background = ColorTranslatorFromHtml("EnvironmentBackground");
            MainWindowStatusBarDefault.Background = ColorTranslatorFromHtml("StatusBarDefault");

            ToolWindowCaptionActive.Background = ColorTranslatorFromHtml("TitleBarActiveBorder");
            ToolWindowCaptionActive.Button = ColorTranslatorFromHtml("ToolWindowButtonActiveGlyph");
            ToolWindowCaptionActive.Grip = ColorTranslatorFromHtml("TitleBarDragHandleActive");
            ToolWindowCaptionActive.Text = ColorTranslatorFromHtml("TitleBarActiveText");

            ToolWindowCaptionInactive.Background = ColorTranslatorFromHtml("TitleBarInactive");
            ToolWindowCaptionInactive.Button = ColorTranslatorFromHtml("ToolWindowButtonInactiveGlyph");
            ToolWindowCaptionInactive.Grip = ColorTranslatorFromHtml("TitleBarDragHandle");
            ToolWindowCaptionInactive.Text = ColorTranslatorFromHtml("TitleBarInactiveText");

            ToolWindowCaptionButtonActiveHovered.Background = ColorTranslatorFromHtml("ToolWindowButtonHoverActive");
            ToolWindowCaptionButtonActiveHovered.Border = ColorTranslatorFromHtml("ToolWindowButtonHoverActiveBorder");
            ToolWindowCaptionButtonActiveHovered.Glyph = ColorTranslatorFromHtml("ToolWindowButtonHoverActiveGlyph");

            ToolWindowCaptionButtonPressed.Background = ColorTranslatorFromHtml("ToolWindowButtonDown");
            ToolWindowCaptionButtonPressed.Border = ColorTranslatorFromHtml("ToolWindowButtonDownBorder");
            ToolWindowCaptionButtonPressed.Glyph = ColorTranslatorFromHtml("ToolWindowButtonDownActiveGlyph");

            ToolWindowCaptionButtonInactiveHovered.Background = ColorTranslatorFromHtml("ToolWindowButtonHoverInactive");
            ToolWindowCaptionButtonInactiveHovered.Border = ColorTranslatorFromHtml("ToolWindowButtonHoverInactiveBorder");
            ToolWindowCaptionButtonInactiveHovered.Glyph = ColorTranslatorFromHtml("ToolWindowButtonHoverInactiveGlyph");

            ToolWindowTabSelectedActive.Background = ColorTranslatorFromHtml("ToolWindowTabSelectedTab");
            ToolWindowTabSelectedActive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedActiveText");

            ToolWindowTabSelectedInactive.Background = ToolWindowTabSelectedActive.Background;
            ToolWindowTabSelectedInactive.Text = ColorTranslatorFromHtml("ToolWindowTabSelectedText");

            ToolWindowTabUnselected.Text = ColorTranslatorFromHtml("ToolWindowTabText");
            ToolWindowTabUnselected.Background = ColorTranslatorFromHtml("ToolWindowTabGradientBegin");

            ToolWindowTabUnselectedHovered.Background = ColorTranslatorFromHtml("ToolWindowTabMouseOverBackgroundBegin");
            ToolWindowTabUnselectedHovered.Text = ColorTranslatorFromHtml("ToolWindowTabMouseOverText");

            ToolWindowSeparator = ColorTranslatorFromHtml("ToolWindowTabSeparator");
            ToolWindowBorder = ColorTranslatorFromHtml("ToolWindowBorder");

            DockTarget.Background = ColorTranslatorFromHtml("DockTargetBackground");
            DockTarget.Border = ColorTranslatorFromHtml("DockTargetBorder");
            DockTarget.ButtonBackground = ColorTranslatorFromHtml("DockTargetButtonBackgroundBegin");
            DockTarget.ButtonBorder = ColorTranslatorFromHtml("DockTargetButtonBorder");
            DockTarget.GlyphBackground = ColorTranslatorFromHtml("DockTargetGlyphBackgroundBegin");
            DockTarget.GlyphArrow = ColorTranslatorFromHtml("DockTargetGlyphArrow");
            DockTarget.GlyphBorder = ColorTranslatorFromHtml("DockTargetGlyphBorder");
        }

        private Color ColorTranslatorFromHtml(string name)
        {
            var color = xml.Root.Element("Theme")
                .Elements("Category").FirstOrDefault(item => item.Attribute("Name").Value == Env)?
                .Elements("Color").FirstOrDefault(item => item.Attribute("Name").Value == name)?
                .Element("Background").Attribute("Source").Value;
            if (color == null)
            {
                return Color.Transparent;
            }

            return ColorTranslator.FromHtml($"#{color}");
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
        public Color ToolWindowBorder { get; }
        public Color ToolWindowSeparator { get; }
        public DockTargetPalette DockTarget { get; } = new DockTargetPalette();
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

    /// <summary>
    /// The skin used to display the auto hide strip and tabs.
    /// </summary>
    [TypeConverter(typeof(AutoHideStripConverter))]
    public class AutoHideStripSkin
    {
        private DockPanelGradient m_dockStripGradient = new DockPanelGradient();
        private TabGradient m_TabGradient = new TabGradient();
        private DockStripBackground m_DockStripBackground = new DockStripBackground();
        
        private Font m_textFont = SystemFonts.MenuFont;

        /// <summary>
        /// The gradient color skin for the DockStrips.
        /// </summary>
        public DockPanelGradient DockStripGradient
        {
            get { return m_dockStripGradient; }
            set { m_dockStripGradient = value; }
        }

        /// <summary>
        /// The gradient color skin for the Tabs.
        /// </summary>
        public TabGradient TabGradient
        {
            get { return m_TabGradient; }
            set { m_TabGradient = value; }
        }

        /// <summary>
        /// The gradient color skin for the Tabs.
        /// </summary>
        public DockStripBackground DockStripBackground
        {
            get { return m_DockStripBackground; }
            set { m_DockStripBackground = value; }
        }

        /// <summary>
        /// Font used in AutoHideStrip elements.
        /// </summary>
        [DefaultValue(typeof(SystemFonts), "MenuFont")]
        public Font TextFont
        {
            get { return m_textFont; }
            set { m_textFont = value; }
        }
    }

    /// <summary>
    /// The skin used to display the document and tool strips and tabs.
    /// </summary>
    [TypeConverter(typeof(DockPaneStripConverter))]
    public class DockPaneStripSkin
    {
        private DockPaneStripGradient m_DocumentGradient = new DockPaneStripGradient();
        private DockPaneStripToolWindowGradient m_ToolWindowGradient = new DockPaneStripToolWindowGradient();
        private Font m_textFont = SystemFonts.MenuFont;

        /// <summary>
        /// The skin used to display the Document style DockPane strip and tab.
        /// </summary>
        public DockPaneStripGradient DocumentGradient
        {
            get { return m_DocumentGradient; }
            set { m_DocumentGradient = value; }
        }

        /// <summary>
        /// The skin used to display the ToolWindow style DockPane strip and tab.
        /// </summary>
        public DockPaneStripToolWindowGradient ToolWindowGradient
        {
            get { return m_ToolWindowGradient; }
            set { m_ToolWindowGradient = value; }
        }

        /// <summary>
        /// Font used in DockPaneStrip elements.
        /// </summary>
        [DefaultValue(typeof(SystemFonts), "MenuFont")]
        public Font TextFont
        {
            get { return m_textFont; }
            set { m_textFont = value; }
        }
    }

    /// <summary>
    /// The skin used to display the DockPane ToolWindow strip and tab.
    /// </summary>
    [TypeConverter(typeof(DockPaneStripGradientConverter))]
    public class DockPaneStripToolWindowGradient : DockPaneStripGradient
    {
        private TabGradient m_activeCaptionGradient = new TabGradient();
        private TabGradient m_inactiveCaptionGradient = new TabGradient();

        /// <summary>
        /// The skin used to display the active ToolWindow caption.
        /// </summary>
        public TabGradient ActiveCaptionGradient
        {
            get { return m_activeCaptionGradient; }
            set { m_activeCaptionGradient = value; }
        }

        /// <summary>
        /// The skin used to display the inactive ToolWindow caption.
        /// </summary>
        public TabGradient InactiveCaptionGradient
        {
            get { return m_inactiveCaptionGradient; }
            set { m_inactiveCaptionGradient = value; }
        }
    }

    /// <summary>
    /// The skin used to display the DockPane strip and tab.
    /// </summary>
    [TypeConverter(typeof(DockPaneStripGradientConverter))]
    public class DockPaneStripGradient
    {
        private DockPanelGradient m_dockStripGradient = new DockPanelGradient();
        private TabGradient m_activeTabGradient = new TabGradient();
        private TabGradient m_inactiveTabGradient = new TabGradient();
        private TabGradient m_hoverTabGradient = new TabGradient();
        

        /// <summary>
        /// The gradient color skin for the DockStrip.
        /// </summary>
        public DockPanelGradient DockStripGradient
        {
            get { return m_dockStripGradient; }
            set { m_dockStripGradient = value; }
        }

        /// <summary>
        /// The skin used to display the active DockPane tabs.
        /// </summary>
        public TabGradient ActiveTabGradient
        {
            get { return m_activeTabGradient; }
            set { m_activeTabGradient = value; }
        }

        public TabGradient HoverTabGradient
        {
            get { return m_hoverTabGradient; }
            set { m_hoverTabGradient = value; }
        }

        /// <summary>
        /// The skin used to display the inactive DockPane tabs.
        /// </summary>
        public TabGradient InactiveTabGradient
        {
            get { return m_inactiveTabGradient; }
            set { m_inactiveTabGradient = value; }
        }
    }

    /// <summary>
    /// The skin used to display the dock pane tab
    /// </summary>
    [TypeConverter(typeof(DockPaneTabGradientConverter))]
    public class TabGradient : DockPanelGradient
    {
        private Color m_textColor = SystemColors.ControlText;

        /// <summary>
        /// The text color.
        /// </summary>
        [DefaultValue(typeof(SystemColors), "ControlText")]
        public Color TextColor
        {
            get { return m_textColor; }
            set { m_textColor = value; }
        }
    }

        /// <summary>
    /// The skin used to display the dock pane tab
    /// </summary>
    [TypeConverter(typeof(DockPaneTabGradientConverter))]
    public class DockStripBackground
    {
        private Color m_startColor = SystemColors.Control;
        private Color m_endColor = SystemColors.Control;
        //private LinearGradientMode m_linearGradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// The beginning gradient color.
        /// </summary>
        [DefaultValue(typeof(SystemColors), "Control")]
        public Color StartColor
        {
            get { return m_startColor; }
            set { m_startColor = value; }
        }

        /// <summary>
        /// The ending gradient color.
        /// </summary>
        [DefaultValue(typeof(SystemColors), "Control")]
        public Color EndColor
        {
            get { return m_endColor; }
            set { m_endColor = value; }
        }
    }
    

    /// <summary>
    /// The gradient color skin.
    /// </summary>
    [TypeConverter(typeof(DockPanelGradientConverter))]
    public class DockPanelGradient
    {
        private Color m_startColor = SystemColors.Control;
        private Color m_endColor = SystemColors.Control;
        private LinearGradientMode m_linearGradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// The beginning gradient color.
        /// </summary>
        [DefaultValue(typeof(SystemColors), "Control")]
        public Color StartColor
        {
            get { return m_startColor; }
            set { m_startColor = value; }
        }

        /// <summary>
        /// The ending gradient color.
        /// </summary>
        [DefaultValue(typeof(SystemColors), "Control")]
        public Color EndColor
        {
            get { return m_endColor; }
            set { m_endColor = value; }
        }

        /// <summary>
        /// The gradient mode to display the colors.
        /// </summary>
        [DefaultValue(LinearGradientMode.Horizontal)]
        public LinearGradientMode LinearGradientMode
        {
            get { return m_linearGradientMode; }
            set { m_linearGradientMode = value; }
        }
    }

    #endregion

    #region Converters
    public class DockPanelSkinConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DockPanelSkin))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is DockPanelSkin)
            {
                return "DockPanelSkin";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class DockPanelGradientConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DockPanelGradient))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is DockPanelGradient)
            {
                return "DockPanelGradient";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class AutoHideStripConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(AutoHideStripSkin))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is AutoHideStripSkin)
            {
                return "AutoHideStripSkin";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class DockPaneStripConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DockPaneStripSkin))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is DockPaneStripSkin)
            {
                return "DockPaneStripSkin";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class DockPaneStripGradientConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DockPaneStripGradient))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is DockPaneStripGradient)
            {
                return "DockPaneStripGradient";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class DockPaneTabGradientConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(TabGradient))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            TabGradient val = value as TabGradient;
            if (destinationType == typeof(String) && val != null)
            {
                return "DockPaneTabGradient";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    #endregion
}
