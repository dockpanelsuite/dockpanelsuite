using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    internal class VS2010AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
    {
        public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
        {
            return new VS2010AutoHideStrip(panel);
        }
    }
}
