

using WinFormsCoreDockPanelSuite.Docking;

using static WinFormsCoreDockPanelSuite.Docking.DockPanel.DockDragHandler;
using static WinFormsCoreDockPanelSuite.Docking.DockPanelExtender;

namespace WinFormsCoreDockPanelSuite.ThemeVS2005Multithreading
{
    public class VS2005MultithreadingDockIndicatorFactory : IDockIndicatorFactory
    {
        public DockIndicator CreateDockIndicator(DockPanel.DockDragHandler dockDragHandler)
        {
            return new DockIndicator(dockDragHandler);
        }
    }
}
