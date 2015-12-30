using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.ThemeVS2005Multithreading;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2005MultithreadingPanelIndicator : PictureBox, DockPanel.IPanelIndicator
    {
        private Image _imagePanelLeft;
        private Image _imagePanelRight;
        private Image _imagePanelTop;
        private Image _imagePanelBottom;
        private Image _imagePanelFill;
        private Image _imagePanelLeftActive;
        private Image _imagePanelRightActive;
        private Image _imagePanelTopActive;
        private Image _imagePanelBottomActive;
        private Image _imagePanelFillActive;

        public VS2005MultithreadingPanelIndicator(DockStyle dockStyle)
        {
            lock (typeof(Resources))
            {
                _imagePanelLeft = (Image)Resources.DockIndicator_PanelLeft.Clone();
                _imagePanelRight = (Image)Resources.DockIndicator_PanelRight.Clone();
                _imagePanelTop = (Image)Resources.DockIndicator_PanelTop.Clone();
                _imagePanelBottom = (Image)Resources.DockIndicator_PanelBottom.Clone();
                _imagePanelFill = (Image)Resources.DockIndicator_PanelFill.Clone();
                _imagePanelLeftActive = (Image)Resources.DockIndicator_PanelLeft_Active.Clone();
                _imagePanelRightActive = (Image)Resources.DockIndicator_PanelRight_Active.Clone();
                _imagePanelTopActive = (Image)Resources.DockIndicator_PanelTop_Active.Clone();
                _imagePanelBottomActive = (Image)Resources.DockIndicator_PanelBottom_Active.Clone();
                _imagePanelFillActive = (Image)Resources.DockIndicator_PanelFill_Active.Clone();
            }

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
