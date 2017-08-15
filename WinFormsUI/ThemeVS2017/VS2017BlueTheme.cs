namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2017;

    /// <summary>
    /// Visual Studio 2017 Light theme.
    /// </summary>
    public class VS2017BlueTheme : VS2017ThemeBase
    {
        public VS2017BlueTheme()
            : base(Decompress(Resources.vs2017blue_vstheme))
        {
        }
    }
}
