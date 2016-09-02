using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    internal class VS2012BlueDockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2012BlueDockWindow(dockPanel, dockState);
        }
    }
}
