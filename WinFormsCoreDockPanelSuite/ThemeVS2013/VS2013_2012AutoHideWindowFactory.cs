

using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2013
{
    internal class VS2013_2012AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2013_2012AutoHideWindowControl(panel);
        }
    }
}
