namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015BlueTheme : VS2015ThemeBase
    {
        public VS2015BlueTheme()
            : base(Decompress(Resources.vs2015blue_vstheme))
        {
        }
    }
}
