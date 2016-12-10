namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;

    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012LightTheme : VS2012ThemeBase
    {
        public VS2012LightTheme()
            : base(Decompress(Resources.vs2012light_vstheme), null, null)
        {
        }
    }
}