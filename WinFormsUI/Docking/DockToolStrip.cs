using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary> Host manager of a ToolStrip for Docking </summary>
    class DockToolStrip : ToolStrip
    {
        /// <summary> Creates a new DockToolStrip object </summary>
        public DockToolStrip(ToolStripPanel ownerPanel, DockContent dockContent)
        {
            this.DockContent = dockContent;
            this.Items.Add( new ToolStripContainerPanel(dockContent) );
            this.ClientSize = dockContent.Size;
            this.MinimumSize = this.Size;
            
            if (dockContent.Controls.Count == 1)
            {
                m_originalOrientationStyle = this.OrientationStyle;
                OrientationStyle = ownerPanel.Orientation == Orientation.Vertical ? DockStyle.Left : DockStyle.Top;
            }
            Label label = new Label();
            label.Name = "VirtualBnd";
            label.Text = string.Empty;
            label.AutoSize = true;
            label.Location = new Point(this.ClientSize.Width - 3, this.ClientSize.Height - 3);
            label.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            dockContent.Controls.Add(label);
        }
        /// <summary> Reference to the DockContent managed </summary>
        public readonly DockContent DockContent;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (m_beginDrag && Parent is ToolStripPanel)
            {
                ToolStripPanel toolStripPanel = Parent as ToolStripPanel;
                DockPanel dockPanel = DockContent.DockPanel;

                if (dockPanel != null)
                {
                    Point ptMouse = Control.MousePosition;
                    Point pt = dockPanel.PointToClient(ptMouse);

                    Rectangle bounds = toolStripPanel.Bounds;
                    bounds.Inflate(8, 8);
                    if (!bounds.Contains(pt)) dockPanel.BeginDrag(DockContent.Pane.FloatWindow);
                }
            }
            base.OnMouseMove(e);
		}

        /// <summary> Original OrientationStyle value. </summary>
        private readonly DockStyle m_originalOrientationStyle = DockStyle.None;

        protected override void OnBeginDrag(EventArgs e)
        {
            m_beginDrag = true;
            base.OnBeginDrag(e);
        }
        protected override void OnEndDrag(EventArgs e)
        {
            m_beginDrag = false;

            if (Parent is ToolStripPanel)
            {
                ToolStripPanel toolStripPanel = Parent as ToolStripPanel;
                DockPanel dockPanel = DockContent.DockPanel;

                if (dockPanel != null)
                {
                    Point ptMouse = Control.MousePosition;
                    Point pt = dockPanel.PointToClient(ptMouse);

                    bool isStripContained = false;

                    foreach (ToolStripPanel panel in dockPanel.ToolStripPanels)
                    {
                        if (panel.Bounds.Contains(pt))
                        {
                            isStripContained = true;
                            break;
                        }
                    }
                    if (!isStripContained)
                    {
                        for (int i = DockContent.Controls.Count - 1; i >= 0; i--)
                        {
                            Control c = DockContent.Controls[i];
                            if (c is Label && c.Name == "VirtualBnd") { DockContent.Controls.Remove(c); break; }
                        }
                        DockStyle layoutSyle = OrientationStyle;
                        if (m_originalOrientationStyle != DockStyle.None) OrientationStyle = m_originalOrientationStyle;
                        this.Visible = false;
                        this.Items.RemoveAt(0);
                        toolStripPanel.Controls.Remove(this);

                        this.DockContent.DockHandler.SetDockState(DockState.Float, false);
                        DockPane currentPane = this.DockContent.Pane;

                        FloatWindow floatWindow = currentPane.FloatWindow;
                        floatWindow.NestedPanes.Remove(currentPane);
                        floatWindow.Location = ptMouse;
                        if (layoutSyle == DockStyle.Left || layoutSyle == DockStyle.Right)
                            floatWindow.Size = new Size(floatWindow.Height, floatWindow.Width + SystemInformation.ToolWindowCaptionHeight);
                        else
                            floatWindow.Size = new Size(floatWindow.Width, floatWindow.Height + SystemInformation.ToolWindowCaptionHeight);

                        currentPane.FloatWindow = floatWindow;
                        floatWindow.Visible = true;
                    }
                }
            }
            base.OnEndDrag(e);
        }
        private bool m_beginDrag = false;
        
        /// <summary> Gets or sets the OrientationStyle </summary>
        private DockStyle OrientationStyle
        {
            get
            {
                foreach (Control control in DockContent.Controls)
                {
                    if (control is ToolBar)
                    {
                        ToolBar toolbar = control as ToolBar;
                        return toolbar.Dock;
                    }
                    else
                    if (control is ToolStrip)
                    {
                        ToolStrip toolStrip = control as ToolStrip;
                        return toolStrip.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow ?  DockStyle.Left : DockStyle.Top;
                    }
                }
                return DockStyle.None;
            }
            set
            {
                foreach (Control control in DockContent.Controls)
                {
                    if (control is ToolBar)
                    {
                        ToolBar toolbar = control as ToolBar;
                        toolbar.Dock = value;
                    }
                    else
                    if (control is ToolStrip)
                    {
                        ToolStrip toolStrip = control as ToolStrip;
                        toolStrip.LayoutStyle = value == DockStyle.Left || value == DockStyle.Right ? ToolStripLayoutStyle.VerticalStackWithOverflow : ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    }
                }
            }
        }
    }

    /// <summary> Host manager for a ToolStripPanel owner of a DockContent </summary>
    class ToolStripContainerPanel : ToolStripControlHost
    {
        /// <summary> Creates a new ToolStripContainerPanel object </summary>
        public ToolStripContainerPanel(DockContent dockContent) : base(dockContent)
        {
        }
        /// <summary> Returns the DockContent managed </summary>
        public DockContent Content
        {
            get	{ return base.Control as DockContent; }
        }
    }
}
