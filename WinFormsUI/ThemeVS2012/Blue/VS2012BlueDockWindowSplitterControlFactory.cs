using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Blue
{
    internal class VS2012BlueDockWindowSplitterControlFactory : DockPanelExtender.IDockWindowSplitterControlFactory
    {
        public SplitterBase CreateSplitterControl()
        {
            return new VS2012BlueDockWindow.VS2012BlueDockWindowSplitterControl();
        }
    }
}
