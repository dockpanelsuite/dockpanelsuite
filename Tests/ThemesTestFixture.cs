using NUnit.Framework;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class ThemesTestFixture
    {
        #region VS2012
        [Test]
        public void CreateVisualStudio2012Blue()
        {
            var ColorPalette = new VS2012BlueTheme().ColorPalette;
            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF465A7D"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF9BA7B7"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFF0D0"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#3D5277"));// TODO: from theme .FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF4B5C74"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FFFFF0D0"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FFFFF0D0"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowSeparator, ColorTranslator.FromHtml("#FF4B5C74"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF000000"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF4B5C74"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
        }

        [Test]
        public void CreateVisualStudio2012Dark()
        {
            var ColorPalette = new VS2012DarkTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFD0D0D0"));
            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0097FB"));
            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF46464A"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFD0D0D0"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowSeparator, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0097FB"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0097FB"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFD0D0D0"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF55AAFF"));
        }

        [Test]
        public void CreateVisualStudio2012Light()
        {
            var ColorPalette = new VS2012LightTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FFEFEFF2"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FFEFEFF2"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FF717171"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFFEFEFE"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFFEFEFE"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FF1E1E1E"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FFEFEFF2"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FFEFEFF2"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FF1E1E1E"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF999999"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFF6F6F6"));
            AssertColor(ColorPalette.ToolWindowSeparator, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFF6F6F6"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FFFEFEFE"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF007ACC"));
        }
        #endregion

        #region VS2013
        [Test]
        public void CreateVisualStudio2013Blue()
        {
            var ColorPalette = new VS2013BlueTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF465A7D"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF9BA7B7"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FF364E6F"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF5B7199"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FF8E9BBC"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF4B5C74"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
        }

        [Test]
        public void CreateVisualStudio2013Dark()
        {
            var ColorPalette = new VS2013DarkTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF46464A"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF55AAFF"));
        }

        [Test]
        public void CreateVisualStudio2013Light()
        {
            var ColorPalette = new VS2013LightTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FF717171"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FF1E1E1E"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FF1E1E1E"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF999999"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFF5F5F5"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFF5F5F5"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF1E1E1E"));
        }
        #endregion

        #region VS2015
        [Test]
        public void CreateVisualStudio2015Blue()
        {
            var ColorPalette = new VS2015BlueTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF465A7D"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF9BA7B7"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FF364E6F"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF5B7199"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF293955"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FF8E9BBC"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FF75633D"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FFFFF29D"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFCED4DD"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFFFFCF4"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFE5C365"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF000000"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FF4D6082"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF5B7199"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));
        }

        [Test]
        public void CreateVisualStudio2015Dark()
        {
            var ColorPalette = new VS2015DarkTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FF555555"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FF3F3F46"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FFF1F1F1"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF46464A"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FF393939"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FFF1F1F1"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FF252526"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0097FB"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FF2D2D30"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FFD0D0D0"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF3E3E40"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF55AAFF"));
        }

        [Test]
        public void CreateVisualStudio2015Light()
        {
            var ColorPalette = new VS2015LightTheme().ColorPalette;

            AssertColor(ColorPalette.AutoHideStripDefault.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.AutoHideStripDefault.Border, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.AutoHideStripDefault.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.AutoHideStripHovered.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.AutoHideStripHovered.Border, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.AutoHideStripHovered.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.OverflowButtonDefault.Glyph, ColorTranslator.FromHtml("#FF717171"));
            AssertColor(ColorPalette.OverflowButtonHovered.Background, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.OverflowButtonHovered.Border, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.OverflowButtonHovered.Glyph, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.TabSelectedActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.TabSelectedActive.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabSelectedActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabSelectedInactive.Background, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.TabSelectedInactive.Button, ColorTranslator.FromHtml("#FF6D6D70"));
            AssertColor(ColorPalette.TabSelectedInactive.Text, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabUnselected.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.TabUnselected.Text, ColorTranslator.FromHtml("#FF1E1E1E"));

            AssertColor(ColorPalette.TabUnselectedHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabUnselectedHovered.Button, ColorTranslator.FromHtml("#FFD0E6F5"));
            AssertColor(ColorPalette.TabUnselectedHovered.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Background, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Border, ColorTranslator.FromHtml("#FF1C97EA"));
            AssertColor(ColorPalette.TabButtonSelectedActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Background, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Border, ColorTranslator.FromHtml("#FFE6E7ED"));
            AssertColor(ColorPalette.TabButtonSelectedInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.MainWindowActive.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.MainWindowStatusBarDefault.Background, ColorTranslator.FromHtml("#FF007ACC"));

            AssertColor(ColorPalette.ToolWindowCaptionActive.Background, ColorTranslator.FromHtml("#FF007ACC"));
            AssertColor(ColorPalette.ToolWindowBorder, ColorTranslator.FromHtml("#FFCCCEDB"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Button, ColorTranslator.FromHtml("#FFFFFFFF"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Grip, ColorTranslator.FromHtml("#FF59A8DE"));
            AssertColor(ColorPalette.ToolWindowCaptionActive.Text, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionInactive.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Button, ColorTranslator.FromHtml("#FF1E1E1E"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Grip, ColorTranslator.FromHtml("#FF999999"));
            AssertColor(ColorPalette.ToolWindowCaptionInactive.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Background, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Border, ColorTranslator.FromHtml("#FF52B0EF"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonActiveHovered.Glyph, ColorTranslator.FromHtml("#FFFFFFFF"));

            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Background, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Border, ColorTranslator.FromHtml("#FFF7F7F9"));
            AssertColor(ColorPalette.ToolWindowCaptionButtonInactiveHovered.Glyph, ColorTranslator.FromHtml("#FF717171"));

            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Background, ColorTranslator.FromHtml("#FFF5F5F5"));
            AssertColor(ColorPalette.ToolWindowTabSelectedActive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Background, ColorTranslator.FromHtml("#FFF5F5F5"));
            AssertColor(ColorPalette.ToolWindowTabSelectedInactive.Text, ColorTranslator.FromHtml("#FF0E70C0"));

            AssertColor(ColorPalette.ToolWindowTabUnselected.Background, ColorTranslator.FromHtml("#FFEEEEF2"));
            AssertColor(ColorPalette.ToolWindowTabUnselected.Text, ColorTranslator.FromHtml("#FF444444"));

            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Background, ColorTranslator.FromHtml("#FFC9DEF5"));
            AssertColor(ColorPalette.ToolWindowTabUnselectedHovered.Text, ColorTranslator.FromHtml("#FF1E1E1E"));
        }

        #endregion

        private static void AssertColor(Color left, Color right)
        {
            Assert.AreEqual(left.ToArgb(), right.ToArgb(), $"expected {ColorTranslator.ToHtml(right)}, but {ColorTranslator.ToHtml(left)}");
        }

        [Test]
        public void ToolStripTest()
        {
            var stripSystem = new ContextMenuStrip();
            stripSystem.RenderMode = ToolStripRenderMode.System;

            var stripProfessional = new ContextMenuStrip();
            stripProfessional.RenderMode = ToolStripRenderMode.Professional;

            var stripManager = new ContextMenuStrip();
            stripManager.RenderMode = ToolStripRenderMode.ManagerRenderMode;

            var renderder = new CustomRenderer();
            var stripCustom = new ContextMenuStrip();
            stripCustom.Renderer = renderder;

            Assert.AreEqual(ToolStripRenderMode.System, stripSystem.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Professional, stripProfessional.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.ManagerRenderMode, stripManager.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Custom, stripCustom.RenderMode);
            Assert.AreEqual(renderder, stripCustom.Renderer);

            var theme = new VS2012BlueTheme();
            theme.ApplyTo(stripManager);
            theme.ApplyTo(stripProfessional);
            theme.ApplyTo(stripSystem);
            theme.ApplyTo(stripCustom);

            Assert.AreEqual(ToolStripRenderMode.Custom, stripSystem.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Custom, stripProfessional.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Custom, stripManager.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Custom, stripCustom.RenderMode);

            theme.CleanUp(null);
            Assert.AreEqual(ToolStripRenderMode.System, stripSystem.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Professional, stripProfessional.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.ManagerRenderMode, stripManager.RenderMode);
            Assert.AreEqual(ToolStripRenderMode.Custom, stripCustom.RenderMode);
            Assert.AreEqual(renderder, stripCustom.Renderer);
        }

        public class CustomRenderer : ToolStripProfessionalRenderer
        { }
    }
}
