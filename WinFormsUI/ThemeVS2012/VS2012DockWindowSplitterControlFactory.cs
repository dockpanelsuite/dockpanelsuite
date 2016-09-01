using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    internal class VS2012DockWindowSplitterControlFactory : DockPanelExtender.IDockWindowSplitterControlFactory
    {
        public SplitterBase CreateSplitterControl()
        {
            return new VS2012DockWindow.VS2012DockWindowSplitterControl();
        }
    }
}
