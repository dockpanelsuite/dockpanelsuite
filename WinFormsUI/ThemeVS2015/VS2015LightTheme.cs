namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015LightTheme : VS2015ThemeBase
    {
        public VS2015LightTheme()
            : base(Decompress(Resources.vs2015light_vstheme))
        {
        }
    }
}
