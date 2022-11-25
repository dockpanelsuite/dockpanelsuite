
using WinFormsCoreDockPanelSuite.Docking;

namespace WinFormsCoreDockPanelSuite.ThemeVS2015
{
    internal class VS2015_2013WindowSplitterControlFactory : DockPanelExtender.IWindowSplitterControlFactory
    {
        public SplitterBase CreateSplitterControl(ISplitterHost host)
        {
            return new VS2015_2013WindowSplitterControl(host);
        }
    }
}
