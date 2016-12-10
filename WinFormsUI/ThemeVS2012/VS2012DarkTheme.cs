namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;

    /// <summary>
    /// Visual Studio 2012 Dark theme.
    /// </summary>
    public class VS2012DarkTheme : VS2012ThemeBase
    {
        public VS2012DarkTheme()
            :base(Decompress(Resources.vs2012dark_vstheme), null, null)
        {
        }
    }
}