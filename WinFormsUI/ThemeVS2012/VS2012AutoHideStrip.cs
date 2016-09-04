using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012AutoHideStrip : AutoHideStripBase
    {
        private class TabVS2012 : Tab
        {
            internal TabVS2012(IDockContent content)
                : base(content)
            {
            }

            private int m_tabX = 0;
            public int TabX
            {
                get { return m_tabX; }
                set { m_tabX = value; }
            }

            private int m_tabWidth = 0;
            public int TabWidth
            {
                get { return m_tabWidth; }
                set { m_tabWidth = value; }
            }

            public bool IsMouseOver { get; set; }
        }

        private const int TextGapLeft = 0;
        private const int TextGapRight = 0;
        private const int TextGapBottom = 3;
        private const int TabGapTop = 3;
        private const int TabGapBottom = 8;
        private const int TabGapLeft = 0;
        private const int TabGapBetween = 12;

        #region Customizable Properties
        public Font TextFont
        {
            get { return DockPanel.Theme.Skin.AutoHideStripSkin.TextFont; }
        }

        private static StringFormat _stringFormatTabHorizontal;
        private StringFormat StringFormatTabHorizontal
        {
            get
            {
                if (_stringFormatTabHorizontal == null)
                {
                    _stringFormatTabHorizontal = new StringFormat();
                    _stringFormatTabHorizontal.Alignment = StringAlignment.Near;
                    _stringFormatTabHorizontal.LineAlignment = StringAlignment.Center;
                    _stringFormatTabHorizontal.FormatFlags = StringFormatFlags.NoWrap;
                    _stringFormatTabHorizontal.Trimming = StringTrimming.None;
                }

                if (RightToLeft == RightToLeft.Yes)
                    _stringFormatTabHorizontal.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                else
                    _stringFormatTabHorizontal.FormatFlags &= ~StringFormatFlags.DirectionRightToLeft;

                return _stringFormatTabHorizontal;
            }
        }

        private static StringFormat _stringFormatTabVertical;
        private StringFormat StringFormatTabVertical
        {
            get
            {
                if (_stringFormatTabVertical == null)
                {
                    _stringFormatTabVertical = new StringFormat();
                    _stringFormatTabVertical.Alignment = StringAlignment.Near;
                    _stringFormatTabVertical.LineAlignment = StringAlignment.Center;
                    _stringFormatTabVertical.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionVertical;
                    _stringFormatTabVertical.Trimming = StringTrimming.None;
                }
                if (RightToLeft == RightToLeft.Yes)
                    _stringFormatTabVertical.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                else
                    _stringFormatTabVertical.FormatFlags &= ~StringFormatFlags.DirectionRightToLeft;

                return _stringFormatTabVertical;
            }
        }

        private static Pen PenTabBorder
        {
            get { return SystemPens.GrayText; }
        }
        #endregion

        private static Matrix _matrixIdentity = new Matrix();
        private static Matrix MatrixIdentity
        {
            get { return _matrixIdentity; }
        }

        private static DockState[] _dockStates;
        private static DockState[] DockStates
        {
            get
            {
                if (_dockStates == null)
                {
                    _dockStates = new DockState[4];
                    _dockStates[0] = DockState.DockLeftAutoHide;
                    _dockStates[1] = DockState.DockRightAutoHide;
                    _dockStates[2] = DockState.DockTopAutoHide;
                    _dockStates[3] = DockState.DockBottomAutoHide;
                }
                return _dockStates;
            }
        }

        private static GraphicsPath _graphicsPath;
        internal static GraphicsPath GraphicsPath
        {
            get
            {
                if (_graphicsPath == null)
                    _graphicsPath = new GraphicsPath();

                return _graphicsPath;
            }
        }

        public VS2012AutoHideStrip(DockPanel panel)
            : base(panel)
        {
            SetStyle(ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = SystemColors.ControlLight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(DockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background), ClientRectangle);
            DrawTabStrip(g);
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            CalculateTabs();
            base.OnLayout(levent);
        }

        private void DrawTabStrip(Graphics g)
        {
            DrawTabStrip(g, DockState.DockTopAutoHide);
            DrawTabStrip(g, DockState.DockBottomAutoHide);
            DrawTabStrip(g, DockState.DockLeftAutoHide);
            DrawTabStrip(g, DockState.DockRightAutoHide);
        }

        private void DrawTabStrip(Graphics g, DockState dockState)
        {
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);

            if (rectTabStrip.IsEmpty)
                return;

            Matrix matrixIdentity = g.Transform;
            if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
            {
                Matrix matrixRotated = new Matrix();
                matrixRotated.RotateAt(90, new PointF((float)rectTabStrip.X + (float)rectTabStrip.Height / 2,
                    (float)rectTabStrip.Y + (float)rectTabStrip.Height / 2));
                g.Transform = matrixRotated;
            }

            foreach (Pane pane in GetPanes(dockState))
            {
                foreach (TabVS2012 tab in pane.AutoHideTabs)
                    DrawTab(g, tab);
            }

            g.Transform = matrixIdentity;
        }

        private void CalculateTabs()
        {
            CalculateTabs(DockState.DockTopAutoHide);
            CalculateTabs(DockState.DockBottomAutoHide);
            CalculateTabs(DockState.DockLeftAutoHide);
            CalculateTabs(DockState.DockRightAutoHide);
        }

        private void CalculateTabs(DockState dockState)
        {
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);

            int x = TabGapLeft + rectTabStrip.X;
            foreach (Pane pane in GetPanes(dockState))
            {
                foreach (TabVS2012 tab in pane.AutoHideTabs)
                {
                    int width = TextRenderer.MeasureText(tab.Content.DockHandler.TabText, TextFont).Width +
                        TextGapLeft + TextGapRight;
                    tab.TabX = x;
                    tab.TabWidth = width;
                    x += width + TabGapBetween;
                }
            }
        }

        private Rectangle RtlTransform(Rectangle rect, DockState dockState)
        {
            Rectangle rectTransformed;
            if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
                rectTransformed = rect;
            else
                rectTransformed = DrawHelper.RtlTransform(this, rect);

            return rectTransformed;
        }

        private GraphicsPath GetTabOutline(TabVS2012 tab, bool transformed, bool rtlTransform)
        {
            DockState dockState = tab.Content.DockHandler.DockState;
            Rectangle rectTab = GetTabRectangle(tab, transformed);
            if (rtlTransform)
                rectTab = RtlTransform(rectTab, dockState);

            if (GraphicsPath != null)
            {
                GraphicsPath.Reset();
                GraphicsPath.AddRectangle(rectTab);
            }

            return GraphicsPath;
        }

        private void DrawTab(Graphics g, TabVS2012 tab)
        {
            Rectangle rectTabOrigin = GetTabRectangle(tab);
            if (rectTabOrigin.IsEmpty)
                return;

            DockState dockState = tab.Content.DockHandler.DockState;
            IDockContent content = tab.Content;

            Color borderColor;
            Color backgroundColor;
            if (tab.IsMouseOver)
            {
                borderColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripHovered.Border;
                backgroundColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripHovered.Background;
            }
            else
            {
                borderColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripDefault.Border;
                backgroundColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripDefault.Background;
            }

            g.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(backgroundColor), rectTabOrigin);

            Rectangle rectThickLine = rectTabOrigin;
            rectThickLine.X += TabGapLeft + TextGapLeft;
            rectThickLine.Width = TextRenderer.MeasureText(tab.Content.DockHandler.TabText, TextFont).Width;
            rectThickLine.Height = DockPanel.Theme.Measures.AutoHideTabLineWidth;

            if (dockState == DockState.DockBottomAutoHide || dockState == DockState.DockLeftAutoHide)
                rectThickLine.Y += rectTabOrigin.Height - DockPanel.Theme.Measures.AutoHideTabLineWidth;

            g.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(borderColor), rectThickLine);

            //Set no rotate for drawing icon and text
            Matrix matrixRotate = g.Transform;
            g.Transform = MatrixIdentity;

            // Draw the text
            Rectangle rectText = rectTabOrigin;
            rectText.X += TextGapLeft;
            rectText.Width -= TextGapLeft;
            if (dockState == DockState.DockBottomAutoHide || dockState == DockState.DockLeftAutoHide)
                rectText.Y -= TextGapBottom;
            else
                rectText.Y += TextGapBottom;

            rectText = RtlTransform(GetTransformedRectangle(dockState, rectText), dockState);

            Color textColor;
            if (tab.IsMouseOver)
                textColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripHovered.Text;
            else
                textColor = DockPanel.Theme.Skin.ColorPalette.AutoHideStripDefault.Text;

            if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
                g.DrawString(content.DockHandler.TabText, TextFont, DockPanel.Theme.PaintingService.GetBrush(textColor), rectText, StringFormatTabVertical);
            else
                g.DrawString(content.DockHandler.TabText, TextFont, DockPanel.Theme.PaintingService.GetBrush(textColor), rectText, StringFormatTabHorizontal);

            // Set rotate back
            g.Transform = matrixRotate;
        }

        private Rectangle GetLogicalTabStripRectangle(DockState dockState)
        {
            return GetLogicalTabStripRectangle(dockState, false);
        }

        private Rectangle GetLogicalTabStripRectangle(DockState dockState, bool transformed)
        {
            if (!DockHelper.IsDockStateAutoHide(dockState))
                return Rectangle.Empty;

            int leftPanes = GetPanes(DockState.DockLeftAutoHide).Count;
            int rightPanes = GetPanes(DockState.DockRightAutoHide).Count;
            int topPanes = GetPanes(DockState.DockTopAutoHide).Count;
            int bottomPanes = GetPanes(DockState.DockBottomAutoHide).Count;

            int x, y, width, height;

            height = MeasureHeight();
            if (dockState == DockState.DockLeftAutoHide && leftPanes > 0)
            {
                x = 0;
                y = (topPanes == 0) ? 0 : height;
                width = Height - (topPanes == 0 ? 0 : height) - (bottomPanes == 0 ? 0 : height);
            }
            else if (dockState == DockState.DockRightAutoHide && rightPanes > 0)
            {
                x = Width - height;
                if (leftPanes != 0 && x < height)
                    x = height;
                y = (topPanes == 0) ? 0 : height;
                width = Height - (topPanes == 0 ? 0 : height) - (bottomPanes == 0 ? 0 : height);
            }
            else if (dockState == DockState.DockTopAutoHide && topPanes > 0)
            {
                x = leftPanes == 0 ? 0 : height;
                y = 0;
                width = Width - (leftPanes == 0 ? 0 : height) - (rightPanes == 0 ? 0 : height);
            }
            else if (dockState == DockState.DockBottomAutoHide && bottomPanes > 0)
            {
                x = leftPanes == 0 ? 0 : height;
                y = Height - height;
                if (topPanes != 0 && y < height)
                    y = height;
                width = Width - (leftPanes == 0 ? 0 : height) - (rightPanes == 0 ? 0 : height);
            }
            else
                return Rectangle.Empty;

            if (width == 0 || height == 0)
            {
                return Rectangle.Empty;
            }

            var rect = new Rectangle(x, y, width, height);
            return transformed ? GetTransformedRectangle(dockState, rect) : rect;
        }

        private Rectangle GetTabRectangle(TabVS2012 tab)
        {
            return GetTabRectangle(tab, false);
        }

        private Rectangle GetTabRectangle(TabVS2012 tab, bool transformed)
        {
            DockState dockState = tab.Content.DockHandler.DockState;
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);

            if (rectTabStrip.IsEmpty)
                return Rectangle.Empty;

            int x = tab.TabX;
            int y = rectTabStrip.Y +
                (dockState == DockState.DockTopAutoHide || dockState == DockState.DockRightAutoHide ?
                0 : TabGapTop);
            int width = tab.TabWidth;
            int height = rectTabStrip.Height - TabGapTop;

            if (!transformed)
                return new Rectangle(x, y, width, height);
            else
                return GetTransformedRectangle(dockState, new Rectangle(x, y, width, height));
        }

        private Rectangle GetTransformedRectangle(DockState dockState, Rectangle rect)
        {
            if (dockState != DockState.DockLeftAutoHide && dockState != DockState.DockRightAutoHide)
                return rect;

            PointF[] pts = new PointF[1];
            // the center of the rectangle
            pts[0].X = (float)rect.X + (float)rect.Width / 2;
            pts[0].Y = (float)rect.Y + (float)rect.Height / 2;
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
            using (var matrix = new Matrix())
            {
                matrix.RotateAt(90, new PointF((float)rectTabStrip.X + (float)rectTabStrip.Height / 2,
                                               (float)rectTabStrip.Y + (float)rectTabStrip.Height / 2));
                matrix.TransformPoints(pts);
            }

            return new Rectangle((int)(pts[0].X - (float)rect.Height / 2 + .5F),
                (int)(pts[0].Y - (float)rect.Width / 2 + .5F),
                rect.Height, rect.Width);
        }

        protected override IDockContent HitTest(Point point)
        {
            Tab tab = TabHitTest(point);

            if (tab != null)
                return tab.Content;
            else
                return null;
        }

        protected override Rectangle GetTabBounds(Tab tab)
        {
            GraphicsPath path = GetTabOutline((TabVS2012)tab, true, true);
            RectangleF bounds = path.GetBounds();
            return new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
        }

        protected Tab TabHitTest(Point ptMouse)
        {
            foreach (DockState state in DockStates)
            {
                Rectangle rectTabStrip = GetLogicalTabStripRectangle(state, true);
                if (!rectTabStrip.Contains(ptMouse))
                    continue;

                foreach (Pane pane in GetPanes(state))
                {
                    foreach (TabVS2012 tab in pane.AutoHideTabs)
                    {
                        GraphicsPath path = GetTabOutline(tab, true, true);
                        if (path.IsVisible(ptMouse))
                            return tab;
                    }
                }
            }

            return null;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            // IMPORTANT: do not trigger base handle, as no need to do anything.
        }

        private TabVS2012 lastSelectedTab = null;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var tab = (TabVS2012)TabHitTest(PointToClient(MousePosition));
            if (tab != null)
            {
                tab.IsMouseOver = true;
                Invalidate();
            }

            if (lastSelectedTab != tab)
            {
                if (lastSelectedTab != null)
                {
                    lastSelectedTab.IsMouseOver = false;
                    Invalidate();
                }

                lastSelectedTab = tab;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (lastSelectedTab != null)
                lastSelectedTab.IsMouseOver = false;
            Invalidate();
        }

        protected override int MeasureHeight()
        {
            return 31;
        }

        protected override void OnRefreshChanges()
        {
            CalculateTabs();
            Invalidate();
        }

        protected override AutoHideStripBase.Tab CreateTab(IDockContent content)
        {
            return new TabVS2012(content);
        }
    }
}
