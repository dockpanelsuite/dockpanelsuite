
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2015
{
    internal class VS2015_2013DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2015_2013SplitterControl(pane);
        }
    }
}
