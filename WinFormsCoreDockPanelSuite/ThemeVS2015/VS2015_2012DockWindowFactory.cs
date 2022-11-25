
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2015
{
    internal class VS2015_2012DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2015_2012DockWindow(dockPanel, dockState);
        }
    }
}
