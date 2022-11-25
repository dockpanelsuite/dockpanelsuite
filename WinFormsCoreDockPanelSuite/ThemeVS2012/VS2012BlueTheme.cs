using System.Drawing;

namespace WinFormsCoreDockPanelSuite.ThemeVS2012
{


    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012BlueTheme : VS2012ThemeBase
    {
        public VS2012BlueTheme()
            : base(Decompress(Resources.vs2012blue_vstheme), new VS2012_2013DockPaneSplitterControlFactory(), new VS2012_2013WindowSplitterControlFactory())
        {
            ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#FF3D5277");// TODO: from theme .FromHtml("#FF4D6082");
        }
    }
}