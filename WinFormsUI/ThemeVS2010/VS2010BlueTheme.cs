using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2010;

    /// <summary>
    /// Visual Studio 2010 Blue theme.
    /// </summary>
    public class VS2010BlueTheme : VS2010ThemeBase
    {
        public VS2010BlueTheme()
            : base(Resources.vs2010blue)
        {
            //ColorPalette.TabSelectedInactive.Background = ColorTranslator.FromHtml("#3D5277");// TODO: from theme .FromHtml("#FF4D6082");
        }
    }
}