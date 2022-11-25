

using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2012
{
    internal class VS2012_2013DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2012_2013SplitterControl(pane);
        }
    }
}
