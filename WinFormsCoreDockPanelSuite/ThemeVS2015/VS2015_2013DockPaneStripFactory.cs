
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2015
{
    public class VS2015_2013DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
    {
        public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
        {
            return new VS2015_2013DockPaneStrip(pane);
        }
    }
}
