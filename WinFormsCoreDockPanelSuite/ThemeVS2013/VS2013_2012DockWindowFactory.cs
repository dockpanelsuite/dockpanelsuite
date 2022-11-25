
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2013
{
    internal class VS2013_2012DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2013_2012DockWindow(dockPanel, dockState);
        }
    }
}
