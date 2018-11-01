using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPane;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    internal class VS2005DockPaneSplitterControlFactory : IDockPaneSplitterControlFactory
    {
        public SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2005SplitterControl(pane);
        }
    }
}
