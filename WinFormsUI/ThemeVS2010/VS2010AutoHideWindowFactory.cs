using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    internal class VS2010AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2010AutoHideWindowControl(panel);
        }
    }
}
