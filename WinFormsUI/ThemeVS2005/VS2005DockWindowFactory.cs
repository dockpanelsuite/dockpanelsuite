using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    internal class VS2005DockWindowFactory : IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2005DockWindow(dockPanel, dockState);
        }

        /// <summary>
        /// Dock window of Visual Studio 2005 theme.
        /// </summary>
        [ToolboxItem(false)]
        private class VS2005DockWindow : DockWindow
        {
            internal VS2005DockWindow(DockPanel dockPanel, DockState dockState) : base(dockPanel, dockState)
            {
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                // if DockWindow is document, draw the border
                if (DockState == DockState.Document)
                    e.Graphics.DrawRectangle(SystemPens.ControlDark, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

                base.OnPaint(e);
            }
        }
    }
}