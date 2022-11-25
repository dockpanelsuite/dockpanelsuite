
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2015
{
    internal class VS2015_2013DockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
    {
        public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
        {
            return new VS2015_2013DockPaneCaption(pane);
        }
    }
}
