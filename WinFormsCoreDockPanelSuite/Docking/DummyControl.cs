using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsCoreDockPanelSuite.Docking
{
    [ToolboxItem(false)]
    internal sealed class DummyControl : Control
    {
        public DummyControl()
        {
            SetStyle(ControlStyles.Selectable, false);
            ResetBackColor();
        }

        public override void ResetBackColor()
        {
            BackColor = SystemColors.ControlLight;
        }
    }
}
