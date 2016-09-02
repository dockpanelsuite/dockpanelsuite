using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    internal class VS2012BlueAutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2012BlueAutoHideWindowControl(panel);
        }
    }
}
