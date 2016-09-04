using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2013
{
    internal class VS2013AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2013AutoHideWindowControl(panel);
        }
    }
}
