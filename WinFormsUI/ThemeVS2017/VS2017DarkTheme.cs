namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2017;

    /// <summary>
    /// Visual Studio 2017 Light theme.
    /// </summary>
    public class VS2017DarkTheme : VS2017ThemeBase
    {
        public VS2017DarkTheme()
            : base(Decompress(Resources.vs2017dark_vstheme))
        {
        }
    }
}
