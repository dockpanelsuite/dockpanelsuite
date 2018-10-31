using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanel;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    public class VS2005PanelIndicatorFactory : IPanelIndicatorFactory
    {
        public IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme)
        {
            return new VS2005PanelIndicator(style);
        }
    }
}
