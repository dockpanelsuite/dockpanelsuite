
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2012
{
    internal class VS2012AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
    {
        public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
        {
            return new VS2012AutoHideStrip(panel);
        }
    }
}
