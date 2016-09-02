using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012.Blue
{
    internal class VS2012BlueDockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2012BlueSplitterControl(pane);
        }
    }
}
