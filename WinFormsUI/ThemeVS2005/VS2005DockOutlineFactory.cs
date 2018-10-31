using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    public class VS2005DockOutlineFactory : IDockOutlineFactory
    {
        public DockOutlineBase CreateDockOutline()
        {
            return new VS2005DockOutline();
        }
    }
}
