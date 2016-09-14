using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2010
{
    internal class VS2010DockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
    {
        public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
        {
            return new VS2010DockPaneCaption(pane);
        }
    }
}
