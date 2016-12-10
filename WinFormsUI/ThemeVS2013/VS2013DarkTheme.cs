namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2013;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013DarkTheme : VS2013ThemeBase
    {
        public VS2013DarkTheme()
            : base(Decompress(Resources.vs2013dark_vstheme))
        {
        }
    }
}
