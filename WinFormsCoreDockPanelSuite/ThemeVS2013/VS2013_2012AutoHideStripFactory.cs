

using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2013
{
    internal class VS2013_2012AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
    {
        public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
        {
            return new VS2013_2012AutoHideStrip(panel);
        }
    }
}
