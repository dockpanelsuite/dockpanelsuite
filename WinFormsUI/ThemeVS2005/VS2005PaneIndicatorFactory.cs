using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanel;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    public class VS2005PaneIndicatorFactory : IPaneIndicatorFactory
    {
        public IPaneIndicator CreatePaneIndicator(ThemeBase theme)
        {
            return new VS2005PaneIndicator();
        }
    }
}
