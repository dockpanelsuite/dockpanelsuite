

using WinFormsCoreDockPanelSuite.Docking;

using static WinFormsCoreDockPanelSuite.Docking.DockPanel.DockDragHandler;
using static WinFormsCoreDockPanelSuite.Docking.DockPanelExtender;

namespace WinFormsCoreDockPanelSuite.ThemeVS2003
{
    public class VS2003DockIndicatorFactory : IDockIndicatorFactory
    {
        public DockIndicator CreateDockIndicator(DockPanel.DockDragHandler dockDragHandler)
        {
            return new DockIndicator(dockDragHandler);
        }
    }
}
