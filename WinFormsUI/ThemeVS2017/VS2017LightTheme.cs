namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2017;

    /// <summary>
    /// Visual Studio 2017 Light theme.
    /// </summary>
    public class VS2017LightTheme : VS2017ThemeBase
    {
        public VS2017LightTheme()
            : base(Decompress(Resources.vs2017light_vstheme))
        {
        }
    }
}
