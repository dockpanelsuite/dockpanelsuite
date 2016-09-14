using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    internal class VS2010DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
    {
        public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
        {
            return new VS2010DockPaneStrip(pane);
        }
    }
}
