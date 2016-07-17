using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary> Docking utility class </summary>
    static class DockUtils
    {
        /// <summary> Check whether the specified object contains a DockContent with ToolBar style </summary>
        public static bool ContainsToolBar(IDockDragSource checkObject)
        {
            if (checkObject == null)
                return false;

            if (checkObject is DockPane)
            {
                foreach (DockContent content in (checkObject as DockPane).Contents)
                {
                    if ((content.DockAreas&DockAreas.ToolBar) != 0) return true;
                }
            }
            else
            if (checkObject is FloatWindow)
            {
                foreach (DockPane pane in (checkObject as FloatWindow).NestedPanes)
                {
                    foreach (DockContent content in pane.Contents)
                    {
                        if ((content.DockAreas&DockAreas.ToolBar) != 0) return true;
                    }
                }
            }
            return false;
        }

        /// <summary> Search the ToolStrip owner of the specified DockContent </summary>
        public static ToolStrip FindToolStrip(DockContent dockContent)
        {
            foreach (ToolStripPanel toolStripPanel in dockContent.DockPanel.ToolStripPanels)
            {
                foreach (ToolStrip toolStrip in toolStripPanel.Controls)
                {
                    foreach (ToolStripItem toolStripItem in toolStrip.Items)
                    {
                        if (toolStripItem is ToolStripContainerPanel && (toolStripItem as ToolStripContainerPanel).Content == dockContent)
                        {
                            return toolStrip;
                        }
                    }
                }
            }
            return null;
        }
        
        /// <summary> Creates a new ToolStrip for the specified DockContent </summary>
        public static ToolStrip MakeToolStrip(ToolStripPanel ownerPanel, DockContent dockContent, Point location, bool perfomLayout)
        {
            DockState dockState = GetDockStatePanel(ownerPanel);
            if (perfomLayout) ownerPanel.SuspendLayout();
            
            DockToolStrip toolStrip = new DockToolStrip(ownerPanel, dockContent);
            toolStrip.Location = location;
            
            FloatWindow floatWindow = dockContent.Pane.FloatWindow;
            floatWindow.Location = new Point(5000, 5000);
            floatWindow.Visible = false;

            dockContent.DockHandler.SetDockState(dockState, true);
            ownerPanel.Controls.Add(toolStrip);

            if (perfomLayout) 
            {
                dockContent.ActivateDockPanelForm();
                ownerPanel.ResumeLayout(true);
            }
            return toolStrip;
        }
        
        /// <summary> Returns the ToolStripPanel for the specified IDockDragSource </summary>
        public static ToolStripPanel ShouldToolStripPanelVisible(IDockDragSource checkObject, out DockContent currentContent)
        {
            currentContent = null;
            
            if (ContainsToolBar(checkObject) && checkObject is FloatWindow)
            {
                FloatWindow floatWindow = (FloatWindow)checkObject;
                if ((currentContent = GetFirstContent(floatWindow)) == null) return null;

                DockPanel dockPanel = floatWindow.DockPanel;
                Point point = dockPanel.PointToClient(Control.MousePosition);
                Rectangle rect = dockPanel.DockArea;
                if (!rect.Contains(point)) return null;
                
                int splitterSize = 3 * Measures.SplitterSize;
                Rectangle rectDock = new Rectangle(rect.Left + splitterSize, rect.Top + splitterSize, rect.Width - 2 * splitterSize, rect.Height - 2 * splitterSize);

                if ((currentContent.DockAreas&DockAreas.DockLeft) != 0)
                {
                    ToolStripPanel toolStripPanel = dockPanel.GetToolStripPanel(DockStyle.Left);
                    if (toolStripPanel.Bounds.Contains(point) || (toolStripPanel.Bounds.Width == 0 && point.X < rectDock.Left)) return toolStripPanel;
                }
                if ((currentContent.DockAreas&DockAreas.DockRight) != 0)
                {
                    ToolStripPanel toolStripPanel = dockPanel.GetToolStripPanel(DockStyle.Right);
                    if (toolStripPanel.Bounds.Contains(point) || (toolStripPanel.Bounds.Width == 0 && point.X > rectDock.Right)) return toolStripPanel;
                }
                if ((currentContent.DockAreas&DockAreas.DockTop) != 0)
                {
                    ToolStripPanel toolStripPanel = dockPanel.GetToolStripPanel(DockStyle.Top);
                    if (toolStripPanel.Bounds.Contains(point) || (toolStripPanel.Bounds.Height == 0 && point.Y < rectDock.Top)) return toolStripPanel;
                }
                if ((currentContent.DockAreas&DockAreas.DockBottom) != 0)
                {
                    ToolStripPanel toolStripPanel = dockPanel.GetToolStripPanel(DockStyle.Bottom);
                    if (toolStripPanel.Bounds.Contains(point) || (toolStripPanel.Bounds.Height == 0 && point.Y > rectDock.Bottom)) return toolStripPanel;
                }
            }
            return null;
        }
        /// <summary> Returns the ToolStripPanel for the specified IDockDragSource </summary>
        public static ToolStripPanel ShouldToolStripPanelVisible(IDockDragSource checkObject)
        {
            DockContent currentContent;
            return ShouldToolStripPanelVisible(checkObject, out currentContent);
        }

        /// <summary> Returns the first DockContent contained in the specified FloatWindow </summary>
        private static DockContent GetFirstContent(FloatWindow floatWindow)
        {
            foreach (DockPane pane in floatWindow.NestedPanes)
            {
                foreach (DockContent content in pane.Contents)
                {
                    return content;
                }
            }
            return null;
        }

        /// <summary> Returns the DockState for the specified ToolStripPanel </summary>
        private static DockState GetDockStatePanel(ToolStripPanel toolStripPanel)
        {
            switch (toolStripPanel.Dock)
            {
                case DockStyle.Left:    return DockState.DockLeft;
                case DockStyle.Top:     return DockState.DockTop;
                case DockStyle.Right:   return DockState.DockRight;
                case DockStyle.Bottom:  return DockState.DockBottom;
            }
            return DockState.Unknown;
        }
    }
}
