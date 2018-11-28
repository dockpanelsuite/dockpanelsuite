using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Dock window base class.
    /// </summary>
    [ToolboxItem(false)]
    public partial class DockWindow : Panel, INestedPanesContainer, ISplitterHost
    {
        private DockPanel m_dockPanel;
        private DockState m_dockState;
        private SplitterBase m_splitter;
        private NestedPaneCollection m_nestedPanes;

        protected internal DockWindow(DockPanel dockPanel, DockState dockState)
        {
            m_nestedPanes = new NestedPaneCollection(this);
            m_dockPanel = dockPanel;
            m_dockState = dockState;
            Visible = false;

            SuspendLayout();

            if (DockState == DockState.DockLeft || DockState == DockState.DockRight ||
                DockState == DockState.DockTop || DockState == DockState.DockBottom)
            {
                m_splitter = DockPanel.Theme.Extender.WindowSplitterControlFactory.CreateSplitterControl(this);
                Controls.Add(m_splitter);
            }

            if (DockState == DockState.DockLeft)
            {
                Dock = DockStyle.Left;
                m_splitter.Dock = DockStyle.Right;
            }
            else if (DockState == DockState.DockRight)
            {
                Dock = DockStyle.Right;
                m_splitter.Dock = DockStyle.Left;
            }
            else if (DockState == DockState.DockTop)
            {
                Dock = DockStyle.Top;
                m_splitter.Dock = DockStyle.Bottom;
            }
            else if (DockState == DockState.DockBottom)
            {
                Dock = DockStyle.Bottom;
                m_splitter.Dock = DockStyle.Top;
            }
            else if (DockState == DockState.Document)
            {
                Dock = DockStyle.Fill;
            }

            ResumeLayout();
        }

        public bool IsDockWindow
        {
            get { return true; }
        }

        public VisibleNestedPaneCollection VisibleNestedPanes
        {
            get	{	return NestedPanes.VisibleNestedPanes;	}
        }

        public NestedPaneCollection NestedPanes
        {
            get	{	return m_nestedPanes;	}
        }

        public DockPanel DockPanel
        {
            get	{	return m_dockPanel;	}
        }

        public DockState DockState
        {
            get	{	return m_dockState;	}
        }

        public bool IsFloat
        {
            get	{	return DockState == DockState.Float;	}
        }

        internal DockPane DefaultPane
        {
            get	{	return VisibleNestedPanes.Count == 0 ? null : VisibleNestedPanes[0];	}
        }

        public virtual Rectangle DisplayingRectangle
        {
            get
            {
                Rectangle rect = ClientRectangle;
                // if DockWindow is document, exclude the border
                if (DockState == DockState.Document)
                {
                    rect.X += 1;
                    rect.Y += 1;
                    rect.Width -= 2;
                    rect.Height -= 2;
                }
                // exclude the splitter
                else if (DockState == DockState.DockLeft)
                    rect.Width -= DockPanel.Theme.Measures.SplitterSize;
                else if (DockState == DockState.DockRight)
                {
                    rect.X += DockPanel.Theme.Measures.SplitterSize;
                    rect.Width -= DockPanel.Theme.Measures.SplitterSize;
                }
                else if (DockState == DockState.DockTop)
                    rect.Height -= DockPanel.Theme.Measures.SplitterSize;
                else if (DockState == DockState.DockBottom)
                {
                    rect.Y += DockPanel.Theme.Measures.SplitterSize;
                    rect.Height -= DockPanel.Theme.Measures.SplitterSize;
                }

                return rect;
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            VisibleNestedPanes.Refresh();
            if (VisibleNestedPanes.Count == 0)
            {
                if (Visible)
                    Visible = false;
            }
            else if (!Visible)
            {
                Visible = true;
                VisibleNestedPanes.Refresh();
            }

            base.OnLayout (levent);
        }

        #region ISplitterDragSource Members

        void ISplitterDragSource.BeginDrag(Rectangle rectSplitter)
        {
        }

        void ISplitterDragSource.EndDrag()
        {
        }

        bool ISplitterDragSource.IsVertical
        {
            get { return (DockState == DockState.DockLeft || DockState == DockState.DockRight); }
        }

        Rectangle ISplitterDragSource.DragLimitBounds
        {
            get
            {
                Rectangle rectLimit = DockPanel.DockArea;
                Point location;
                if ((Control.ModifierKeys & Keys.Shift) == 0)
                    location = Location;
                else
                    location = DockPanel.DockArea.Location;

                if (((ISplitterDragSource)this).IsVertical)
                {
                    rectLimit.X += MeasurePane.MinSize;
                    rectLimit.Width -= 2 * MeasurePane.MinSize;
                    rectLimit.Y = location.Y;
                    if ((Control.ModifierKeys & Keys.Shift) == 0)
                        rectLimit.Height = Height;
                }
                else
                {
                    rectLimit.Y += MeasurePane.MinSize;
                    rectLimit.Height -= 2 * MeasurePane.MinSize;
                    rectLimit.X = location.X;
                    if ((Control.ModifierKeys & Keys.Shift) == 0)
                        rectLimit.Width = Width;
                }

                return DockPanel.RectangleToScreen(rectLimit);
            }
        }

        void ISplitterDragSource.MoveSplitter(int offset)
        {
            if ((Control.ModifierKeys & Keys.Shift) != 0)
                SendToBack();

            Rectangle rectDockArea = DockPanel.DockArea;
            if (DockState == DockState.DockLeft && rectDockArea.Width > 0)
            {
                if (DockPanel.DockLeftPortion > 1)
                    DockPanel.DockLeftPortion = Width + offset;
                else
                    DockPanel.DockLeftPortion += ((double)offset) / (double)rectDockArea.Width;
            }
            else if (DockState == DockState.DockRight && rectDockArea.Width > 0)
            {
                if (DockPanel.DockRightPortion > 1)
                    DockPanel.DockRightPortion = Width - offset;
                else
                    DockPanel.DockRightPortion -= ((double)offset) / (double)rectDockArea.Width;
            }
            else if (DockState == DockState.DockBottom && rectDockArea.Height > 0)
            {
                if (DockPanel.DockBottomPortion > 1)
                    DockPanel.DockBottomPortion = Height - offset;
                else
                    DockPanel.DockBottomPortion -= ((double)offset) / (double)rectDockArea.Height;
            }
            else if (DockState == DockState.DockTop && rectDockArea.Height > 0)
            {
                if (DockPanel.DockTopPortion > 1)
                    DockPanel.DockTopPortion = Height + offset;
                else
                    DockPanel.DockTopPortion += ((double)offset) / (double)rectDockArea.Height;
            }
        }

        #region IDragSource Members

        Control IDragSource.DragControl
        {
            get { return this; }
        }

        #endregion
        #endregion
    }
}
