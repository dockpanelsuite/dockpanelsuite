using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.ThemeVS2012;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012AutoHideWindowControl : DockPanel.AutoHideWindowControl
    {
        public VS2012AutoHideWindowControl(DockPanel dockPanel) : base(dockPanel)
        {
        }

        protected override Rectangle DisplayingRectangle
        {
            get
            {
                Rectangle rect = ClientRectangle;

                // exclude the border and the splitter
                if (DockState == DockState.DockBottomAutoHide)
                {
                    rect.Y += DockPanel.Theme.Measures.AutoHideSplitterSize;
                    rect.Height -= DockPanel.Theme.Measures.AutoHideSplitterSize;
                }
                else if (DockState == DockState.DockRightAutoHide)
                {
                    rect.X += DockPanel.Theme.Measures.AutoHideSplitterSize;
                    rect.Width -= DockPanel.Theme.Measures.AutoHideSplitterSize;
                }
                else if (DockState == DockState.DockTopAutoHide)
                    rect.Height -= DockPanel.Theme.Measures.AutoHideSplitterSize;
                else if (DockState == DockState.DockLeftAutoHide)
                    rect.Width -= DockPanel.Theme.Measures.AutoHideSplitterSize;

                return rect;
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            DockPadding.All = 0;
            if (DockState == DockState.DockLeftAutoHide)
            {
                //DockPadding.Right = 2;
                m_splitter.Dock = DockStyle.Right;
            }
            else if (DockState == DockState.DockRightAutoHide)
            {
                //DockPadding.Left = 2;
                m_splitter.Dock = DockStyle.Left;
            }
            else if (DockState == DockState.DockTopAutoHide)
            {
                //DockPadding.Bottom = 2;
                m_splitter.Dock = DockStyle.Bottom;
            }
            else if (DockState == DockState.DockBottomAutoHide)
            {
                //DockPadding.Top = 2;
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
    }
}