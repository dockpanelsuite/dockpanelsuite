using System.ComponentModel;
using System.Drawing;
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

        [ToolboxItem(false)]
        private class VS2005PanelIndicator : PictureBox, IPanelIndicator
        {
            private static Image _imagePanelLeft = Resources.DockIndicator_PanelLeft;
            private static Image _imagePanelRight = Resources.DockIndicator_PanelRight;
            private static Image _imagePanelTop = Resources.DockIndicator_PanelTop;
            private static Image _imagePanelBottom = Resources.DockIndicator_PanelBottom;
            private static Image _imagePanelFill = Resources.DockIndicator_PanelFill;
            private static Image _imagePanelLeftActive = Resources.DockIndicator_PanelLeft_Active;
            private static Image _imagePanelRightActive = Resources.DockIndicator_PanelRight_Active;
            private static Image _imagePanelTopActive = Resources.DockIndicator_PanelTop_Active;
            private static Image _imagePanelBottomActive = Resources.DockIndicator_PanelBottom_Active;
            private static Image _imagePanelFillActive = Resources.DockIndicator_PanelFill_Active;

            public VS2005PanelIndicator(DockStyle dockStyle)
            {
                m_dockStyle = dockStyle;
                SizeMode = PictureBoxSizeMode.AutoSize;
                Image = ImageInactive;
            }

            private DockStyle m_dockStyle;
            private DockStyle DockStyle
            {
                get { return m_dockStyle; }
            }

            private DockStyle m_status;
            public DockStyle Status
            {
                get { return m_status; }
                set
                {
                    if (value != DockStyle && value != DockStyle.None)
                        throw new InvalidEnumArgumentException();

                    if (m_status == value)
                        return;

                    m_status = value;
                    IsActivated = (m_status != DockStyle.None);
                }
            }

            private Image ImageInactive
            {
                get
                {
                    if (DockStyle == DockStyle.Left)
                        return _imagePanelLeft;
                    else if (DockStyle == DockStyle.Right)
                        return _imagePanelRight;
                    else if (DockStyle == DockStyle.Top)
                        return _imagePanelTop;
                    else if (DockStyle == DockStyle.Bottom)
                        return _imagePanelBottom;
                    else if (DockStyle == DockStyle.Fill)
                        return _imagePanelFill;
                    else
                        return null;
                }
            }

            private Image ImageActive
            {
                get
                {
                    if (DockStyle == DockStyle.Left)
                        return _imagePanelLeftActive;
                    else if (DockStyle == DockStyle.Right)
                        return _imagePanelRightActive;
                    else if (DockStyle == DockStyle.Top)
                        return _imagePanelTopActive;
                    else if (DockStyle == DockStyle.Bottom)
                        return _imagePanelBottomActive;
                    else if (DockStyle == DockStyle.Fill)
                        return _imagePanelFillActive;
                    else
                        return null;
                }
            }

            private bool m_isActivated = false;
            private bool IsActivated
            {
                get { return m_isActivated; }
                set
                {
                    m_isActivated = value;
                    Image = IsActivated ? ImageActive : ImageInactive;
                }
            }

            public DockStyle HitTest(Point pt)
            {
                return this.Visible && ClientRectangle.Contains(PointToClient(pt)) ? DockStyle : DockStyle.None;
            }
        }
    }
}
