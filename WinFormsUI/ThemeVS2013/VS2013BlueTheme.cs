namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2013;

    /// <summary>
    /// Visual Studio 2013 Light theme.
    /// </summary>
    public class VS2013BlueTheme : VS2013ThemeBase
    {
        public VS2013BlueTheme()
            : base(Decompress(Resources.vs2013blue_vstheme))
        {
        }
    }
}
