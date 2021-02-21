using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
//using Vanara.PInvoke;
using System.Diagnostics;

namespace WeifenLuo.WinFormsUI.Docking
{
    partial class DockPanel
    {
        #region IHitTest
        public interface IHitTest
        {
            DockStyle HitTest(Point pt);
            DockStyle Status { get; set; }
        }

        public interface IPaneIndicator : IHitTest
        {
            Point Location { get; set; }
            bool Visible { get; set; }
            int Left { get; }
            int Top { get; }
            int Right { get; }
            int Bottom { get; }
            Rectangle ClientRectangle { get; }
            int Width { get; }
            int Height { get; }
            GraphicsPath DisplayingGraphicsPath { get; }
        }

        public interface IPanelIndicator : IHitTest
        {
            Point Location { get; set; }
            bool Visible { get; set; }
            Rectangle Bounds { get; }
            int Width { get; }
            int Height { get; }
        }

        public struct HotSpotIndex
        {
            public HotSpotIndex(int x, int y, DockStyle dockStyle)
            {
                m_x = x;
                m_y = y;
                m_dockStyle = dockStyle;
            }

            private int m_x;
            public int X
            {
                get { return m_x; }
            }

            private int m_y;
            public int Y
            {
                get { return m_y; }
            }

            private DockStyle m_dockStyle;
            public DockStyle DockStyle
            {
                get { return m_dockStyle; }
            }
        }

        #endregion

        public sealed class DockDragHandler : DragHandler
        {
            public class DockIndicator : DragForm
            {
                #region consts
                private int _PanelIndicatorMargin = 10;
                #endregion

                private DockDragHandler m_dragHandler;

                public DockIndicator(DockDragHandler dragHandler)
                {
                    m_dragHandler = dragHandler;
                    Controls.AddRange(new[] {
                        (Control)PaneDiamond,
                        (Control)PanelLeft,
                        (Control)PanelRight,
                        (Control)PanelTop,
                        (Control)PanelBottom,
                        (Control)PanelFill
                        });
                    Region = new Region(Rectangle.Empty);
                }

                private IPaneIndicator m_paneDiamond = null;
                private IPaneIndicator PaneDiamond
                {
                    get
                    {
                        if (m_paneDiamond == null)
                            m_paneDiamond = m_dragHandler.DockPanel.Theme.Extender.PaneIndicatorFactory.CreatePaneIndicator(m_dragHandler.DockPanel.Theme);

                        return m_paneDiamond;
                    }
                }

                private IPanelIndicator m_panelLeft = null;
                private IPanelIndicator PanelLeft
                {
                    get
                    {
                        if (m_panelLeft == null)
                            m_panelLeft = m_dragHandler.DockPanel.Theme.Extender.PanelIndicatorFactory.CreatePanelIndicator(DockStyle.Left, m_dragHandler.DockPanel.Theme);

                        return m_panelLeft;
                    }
                }

                private IPanelIndicator m_panelRight = null;
                private IPanelIndicator PanelRight
                {
                    get
                    {
                        if (m_panelRight == null)
                            m_panelRight = m_dragHandler.DockPanel.Theme.Extender.PanelIndicatorFactory.CreatePanelIndicator(DockStyle.Right, m_dragHandler.DockPanel.Theme);

                        return m_panelRight;
                    }
                }

                private IPanelIndicator m_panelTop = null;
                private IPanelIndicator PanelTop
                {
                    get
                    {
                        if (m_panelTop == null)
                            m_panelTop = m_dragHandler.DockPanel.Theme.Extender.PanelIndicatorFactory.CreatePanelIndicator(DockStyle.Top, m_dragHandler.DockPanel.Theme);

                        return m_panelTop;
                    }
                }

                private IPanelIndicator m_panelBottom = null;
                private IPanelIndicator PanelBottom
                {
                    get
                    {
                        if (m_panelBottom == null)
                            m_panelBottom = m_dragHandler.DockPanel.Theme.Extender.PanelIndicatorFactory.CreatePanelIndicator(DockStyle.Bottom, m_dragHandler.DockPanel.Theme);

                        return m_panelBottom;
                    }
                }

                private IPanelIndicator m_panelFill = null;
                private IPanelIndicator PanelFill
                {
                    get
                    {
                        if (m_panelFill == null)
                            m_panelFill = m_dragHandler.DockPanel.Theme.Extender.PanelIndicatorFactory.CreatePanelIndicator(DockStyle.Fill, m_dragHandler.DockPanel.Theme);

                        return m_panelFill;
                    }
                }

                private bool m_fullPanelEdge = false;
                public bool FullPanelEdge
                {
                    get { return m_fullPanelEdge; }
                    set
                    {
                        if (m_fullPanelEdge == value)
                            return;

                        m_fullPanelEdge = value;
                        RefreshChanges();
                    }
                }

                public DockDragHandler DragHandler
                {
                    get { return m_dragHandler; }
                }

                public DockPanel DockPanel
                {
                    get { return DragHandler.DockPanel; }
                }

                private DockPane m_dockPane = null;
                public DockPane DockPane
                {
                    get { return m_dockPane; }
                    internal set
                    {
                        if (m_dockPane == value)
                            return;

                        DockPane oldDisplayingPane = DisplayingPane;
                        m_dockPane = value;
                        if (oldDisplayingPane != DisplayingPane)
                            RefreshChanges();
                    }
                }

                private IHitTest m_hitTest = null;
                private IHitTest HitTestResult
                {
                    get { return m_hitTest; }
                    set
                    {
                        if (m_hitTest == value)
                            return;

                        if (m_hitTest != null)
                            m_hitTest.Status = DockStyle.None;

                        m_hitTest = value;
                    }
                }

                private DockPane DisplayingPane
                {
                    get { return ShouldPaneDiamondVisible() ? DockPane : null; }
                }

                private void RefreshChanges()
                {
                    if (PatchController.EnablePerScreenDpi == true)
                    {
                        //SHCore.PROCESS_DPI_AWARENESS value;
                        //if (SHCore.GetProcessDpiAwareness(Process.GetCurrentProcess().Handle, out value) == HRESULT.S_OK)
                        //{
                        //    if (value == SHCore.PROCESS_DPI_AWARENESS.PROCESS_SYSTEM_DPI_AWARE)
                        //    {
                                var allScreens = Screen.AllScreens;
                                var mousePos = Control.MousePosition;
                                foreach (var screen in allScreens)
                                {
                                    if (screen.Bounds.Contains(mousePos))
                                    {
                                        Bounds = screen.Bounds;
                                    }
                                }
                        //    }
                        //}
                    }

                    Region region = new Region(Rectangle.Empty);
                    Rectangle rectDockArea = FullPanelEdge ? DockPanel.DockArea : DockPanel.DocumentWindowBounds;

                    rectDockArea = RectangleToClient(DockPanel.RectangleToScreen(rectDockArea));
                    if (ShouldPanelIndicatorVisible(DockState.DockLeft))
                    {
                        PanelLeft.Location = new Point(rectDockArea.X + _PanelIndicatorMargin, rectDockArea.Y + (rectDockArea.Height - PanelRight.Height) / 2);
                        PanelLeft.Visible = true;
                        region.Union(PanelLeft.Bounds);
                    }
                    else
                        PanelLeft.Visible = false;

                    if (ShouldPanelIndicatorVisible(DockState.DockRight))
                    {
                        PanelRight.Location = new Point(rectDockArea.X + rectDockArea.Width - PanelRight.Width - _PanelIndicatorMargin, rectDockArea.Y + (rectDockArea.Height - PanelRight.Height) / 2);
                        PanelRight.Visible = true;
                        region.Union(PanelRight.Bounds);
                    }
                    else
                        PanelRight.Visible = false;

                    if (ShouldPanelIndicatorVisible(DockState.DockTop))
                    {
                        PanelTop.Location = new Point(rectDockArea.X + (rectDockArea.Width - PanelTop.Width) / 2, rectDockArea.Y + _PanelIndicatorMargin);
                        PanelTop.Visible = true;
                        region.Union(PanelTop.Bounds);
                    }
                    else
                        PanelTop.Visible = false;

                    if (ShouldPanelIndicatorVisible(DockState.DockBottom))
                    {
                        PanelBottom.Location = new Point(rectDockArea.X + (rectDockArea.Width - PanelBottom.Width) / 2, rectDockArea.Y + rectDockArea.Height - PanelBottom.Height - _PanelIndicatorMargin);
                        PanelBottom.Visible = true;
                        region.Union(PanelBottom.Bounds);
                    }
                    else
                        PanelBottom.Visible = false;

                    if (ShouldPanelIndicatorVisible(DockState.Document))
                    {
                        Rectangle rectDocumentWindow = RectangleToClient(DockPanel.RectangleToScreen(DockPanel.DocumentWindowBounds));
                        PanelFill.Location = new Point(rectDocumentWindow.X + (rectDocumentWindow.Width - PanelFill.Width) / 2, rectDocumentWindow.Y + (rectDocumentWindow.Height - PanelFill.Height) / 2);
                        PanelFill.Visible = true;
                        region.Union(PanelFill.Bounds);
                    }
                    else
                        PanelFill.Visible = false;

                    if (ShouldPaneDiamondVisible())
                    {
                        Rectangle rect = RectangleToClient(DockPane.RectangleToScreen(DockPane.ClientRectangle));
                        PaneDiamond.Location = new Point(rect.Left + (rect.Width - PaneDiamond.Width) / 2, rect.Top + (rect.Height - PaneDiamond.Height) / 2);
                        PaneDiamond.Visible = true;
                        using (GraphicsPath graphicsPath = PaneDiamond.DisplayingGraphicsPath.Clone() as GraphicsPath)
                        {
                            Point[] pts =
                                {
                                    new Point(PaneDiamond.Left, PaneDiamond.Top),
                                    new Point(PaneDiamond.Right, PaneDiamond.Top),
                                    new Point(PaneDiamond.Left, PaneDiamond.Bottom)
                                };
                            using (Matrix matrix = new Matrix(PaneDiamond.ClientRectangle, pts))
                            {
                                graphicsPath.Transform(matrix);
                            }

                            region.Union(graphicsPath);
                        }
                    }
                    else
                        PaneDiamond.Visible = false;

                    Region = region;
                }

                private bool ShouldPanelIndicatorVisible(DockState dockState)
                {
                    if (!Visible)
                        return false;

                    if (DockPanel.DockWindows[dockState].Visible)
                        return false;

                    return DragHandler.DragSource.IsDockStateValid(dockState);
                }

                private bool ShouldPaneDiamondVisible()
                {
                    if (DockPane == null)
                        return false;

                    if (!DockPanel.AllowEndUserNestedDocking)
                        return false;

                    return DragHandler.DragSource.CanDockTo(DockPane);
                }

                public override void Show(bool bActivate)
                {
                    base.Show(bActivate);
                    if (PatchController.EnablePerScreenDpi != true)
                    {
                        Bounds = SystemInformation.VirtualScreen;
                    }

                    RefreshChanges();
                }

                public void TestDrop()
                {
                    Point pt = Control.MousePosition;
                    DockPane = DockHelper.PaneAtPoint(pt, DockPanel);

                    if (TestDrop(PanelLeft, pt) != DockStyle.None)
                        HitTestResult = PanelLeft;
                    else if (TestDrop(PanelRight, pt) != DockStyle.None)
                        HitTestResult = PanelRight;
                    else if (TestDrop(PanelTop, pt) != DockStyle.None)
                        HitTestResult = PanelTop;
                    else if (TestDrop(PanelBottom, pt) != DockStyle.None)
                        HitTestResult = PanelBottom;
                    else if (TestDrop(PanelFill, pt) != DockStyle.None)
                        HitTestResult = PanelFill;
                    else if (TestDrop(PaneDiamond, pt) != DockStyle.None)
                        HitTestResult = PaneDiamond;
                    else
                        HitTestResult = null;

                    if (HitTestResult != null)
                    {
                        if (HitTestResult is IPaneIndicator)
                            DragHandler.Outline.Show(DockPane, HitTestResult.Status);
                        else
                            DragHandler.Outline.Show(DockPanel, HitTestResult.Status, FullPanelEdge);
                    }
                }

                private static DockStyle TestDrop(IHitTest hitTest, Point pt)
                {
                    return hitTest.Status = hitTest.HitTest(pt);
                }
            }

            public DockDragHandler(DockPanel panel)
                : base(panel)
            {
            }

            public new IDockDragSource DragSource
            {
                get { return base.DragSource as IDockDragSource; }
                set { base.DragSource = value; }
            }

            private DockOutlineBase m_outline;
            public DockOutlineBase Outline
            {
                get { return m_outline; }
                private set { m_outline = value; }
            }

            private DockIndicator m_indicator;
            private DockIndicator Indicator
            {
                get { return m_indicator; }
                set { m_indicator = value; }
            }

            private Rectangle m_floatOutlineBounds;
            private Rectangle FloatOutlineBounds
            {
                get { return m_floatOutlineBounds; }
                set { m_floatOutlineBounds = value; }
            }

            public void BeginDrag(IDockDragSource dragSource)
            {
                DragSource = dragSource;

                if (!BeginDrag())
                {
                    DragSource = null;
                    return;
                }

                Outline = DockPanel.Theme.Extender.DockOutlineFactory.CreateDockOutline();
                Indicator = DockPanel.Theme.Extender.DockIndicatorFactory.CreateDockIndicator(this);
                Indicator.Show(false);

                FloatOutlineBounds = DragSource.BeginDrag(StartMousePosition);
            }

            protected override void OnDragging()
            {
                TestDrop();
            }

            protected override void OnEndDrag(bool abort)
            {
                DockPanel.SuspendLayout(true);

                Outline.Close();
                Indicator.Close();

                EndDrag(abort);

                // Queue a request to layout all children controls
                DockPanel.PerformMdiClientLayout();

                DockPanel.ResumeLayout(true, true);

                DragSource.EndDrag();

                DragSource = null;

                // Fire notification
                DockPanel.OnDocumentDragged();
            }

            private void TestDrop()
            {
                Outline.FlagTestDrop = false;

                Indicator.FullPanelEdge = ((Control.ModifierKeys & Keys.Shift) != 0);

                if ((Control.ModifierKeys & Keys.Control) == 0)
                {
                    Indicator.TestDrop();

                    if (!Outline.FlagTestDrop)
                    {
                        DockPane pane = DockHelper.PaneAtPoint(Control.MousePosition, DockPanel);
                        if (pane != null && DragSource.IsDockStateValid(pane.DockState))
                            pane.TestDrop(DragSource, Outline);
                    }

                    if (!Outline.FlagTestDrop && DragSource.IsDockStateValid(DockState.Float))
                    {
                        FloatWindow floatWindow = DockHelper.FloatWindowAtPoint(Control.MousePosition, DockPanel);
                        if (floatWindow != null)
                            floatWindow.TestDrop(DragSource, Outline);
                    }
                }
                else
                    Indicator.DockPane = DockHelper.PaneAtPoint(Control.MousePosition, DockPanel);

                if (!Outline.FlagTestDrop)
                {
                    if (DragSource.IsDockStateValid(DockState.Float))
                    {
                        Rectangle rect = FloatOutlineBounds;
                        rect.Offset(Control.MousePosition.X - StartMousePosition.X, Control.MousePosition.Y - StartMousePosition.Y);
                        Outline.Show(rect);
                    }
                }

                if (!Outline.FlagTestDrop)
                {
                    Cursor.Current = Cursors.No;
                    Outline.Show();
                }
                else
                    Cursor.Current = DragControl.Cursor;
            }

            private void EndDrag(bool abort)
            {
                if (abort)
                    return;

                if (!Outline.FloatWindowBounds.IsEmpty)
                    DragSource.FloatAt(Outline.FloatWindowBounds);
                else if (Outline.DockTo is DockPane)
                {
                    DockPane pane = Outline.DockTo as DockPane;
                    DragSource.DockTo(pane, Outline.Dock, Outline.ContentIndex);
                }
                else if (Outline.DockTo is DockPanel)
                {
                    DockPanel panel = Outline.DockTo as DockPanel;
                    panel.UpdateDockWindowZOrder(Outline.Dock, Outline.FlagFullEdge);
                    DragSource.DockTo(panel, Outline.Dock);
                }
            }
        }

        private DockDragHandler m_dockDragHandler = null;
        private DockDragHandler GetDockDragHandler()
        {
            if (m_dockDragHandler == null)
                m_dockDragHandler = new DockDragHandler(this);
            return m_dockDragHandler;
        }

        internal void BeginDrag(IDockDragSource dragSource)
        {
            GetDockDragHandler().BeginDrag(dragSource);
        }
    }
}
