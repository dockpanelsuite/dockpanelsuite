using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2013
{
    internal class VS2013DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2013DockWindow(dockPanel, dockState);
        }
    }
}
