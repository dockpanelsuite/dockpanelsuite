using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanel;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    public class VS2005AutoHideWindowFactory : IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2005AutoHideWindowControl(panel);
        }

        [ToolboxItem(false)]
        private class VS2005AutoHideWindowControl : AutoHideWindowControl
        {
            public VS2005AutoHideWindowControl(DockPanel dockPanel) : base(dockPanel)
            {
            }

            protected override void OnLayout(LayoutEventArgs levent)
            {
                DockPadding.All = 0;
                if (DockState == DockState.DockLeftAutoHide)
                {
                    DockPadding.Right = 2;
                    m_splitter.Dock = DockStyle.Right;
                }
                else if (DockState == DockState.DockRightAutoHide)
                {
                    DockPadding.Left = 2;
                    m_splitter.Dock = DockStyle.Left;
                }
                else if (DockState == DockState.DockTopAutoHide)
                {
                    DockPadding.Bottom = 2;
                    m_splitter.Dock = DockStyle.Bottom;
                }
                else if (DockState == DockState.DockBottomAutoHide)
                {
                    DockPadding.Top = 2;
                    m_splitter.Dock = DockStyle.Top;
                }

                Rectangle rectDisplaying = DisplayingRectangle;
                Rectangle rectHidden = new Rectangle(-rectDisplaying.Width, rectDisplaying.Y, rectDisplaying.Width, rectDisplaying.Height);
                foreach (Control c in Controls)
                {
                    DockPane pane = c as DockPane;
                    if (pane == null)
                        continue;


                    if (pane == ActivePane)
                        pane.Bounds = rectDisplaying;
                    else
                        pane.Bounds = rectHidden;
                }

                base.OnLayout(levent);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                // Draw the border
                Graphics g = e.Graphics;

                if (DockState == DockState.DockBottomAutoHide)
                    g.DrawLine(SystemPens.ControlLightLight, 0, 1, ClientRectangle.Right, 1);
                else if (DockState == DockState.DockRightAutoHide)
                    g.DrawLine(SystemPens.ControlLightLight, 1, 0, 1, ClientRectangle.Bottom);
                else if (DockState == DockState.DockTopAutoHide)
                {
                    g.DrawLine(SystemPens.ControlDark, 0, ClientRectangle.Height - 2, ClientRectangle.Right, ClientRectangle.Height - 2);
                    g.DrawLine(SystemPens.ControlDarkDark, 0, ClientRectangle.Height - 1, ClientRectangle.Right, ClientRectangle.Height - 1);
                }
                else if (DockState == DockState.DockLeftAutoHide)
                {
                    g.DrawLine(SystemPens.ControlDark, ClientRectangle.Width - 2, 0, ClientRectangle.Width - 2, ClientRectangle.Bottom);
                    g.DrawLine(SystemPens.ControlDarkDark, ClientRectangle.Width - 1, 0, ClientRectangle.Width - 1, ClientRectangle.Bottom);
                }

                base.OnPaint(e);
            }
        }
    }
}
