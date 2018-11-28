using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ToolboxItem(false)]
    internal class VS2012AutoHideStrip : AutoHideStripBase
    {
        private class TabVS2012 : Tab
        {
            internal TabVS2012(IDockContent content)
                : base(content)
            {
            }

            /// <summary>
            /// X for this <see href="TabVS2012"/> inside the logical strip rectangle.
            /// </summary>
            public int TabX { get; set; }

            /// <summary>
            /// Width of this <see href="TabVS2012"/>.
            /// </summary>
            public int TabWidth { get; set; }

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
            BackColor = DockPanel.Theme.ColorPalette.MainWindowActive.Background;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
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

        private GraphicsPath GetTabOutline(TabVS2012 tab, bool rtlTransform)
        {
            DockState dockState = tab.Content.DockHandler.DockState;
            Rectangle rectTab = GetTabRectangle(tab);
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

            //Set no rotate for drawing icon and text
            Matrix matrixRotate = g.Transform;
            g.Transform = MatrixIdentity;

            Color borderColor;
            Color backgroundColor;
            Color textColor;
            if (tab.IsMouseOver)
            {
                borderColor = DockPanel.Theme.ColorPalette.AutoHideStripHovered.Border;
                backgroundColor = DockPanel.Theme.ColorPalette.AutoHideStripHovered.Background;
                textColor = DockPanel.Theme.ColorPalette.AutoHideStripHovered.Text;
            }
            else
            {
                borderColor = DockPanel.Theme.ColorPalette.AutoHideStripDefault.Border;
                backgroundColor = DockPanel.Theme.ColorPalette.AutoHideStripDefault.Background;
                textColor = DockPanel.Theme.ColorPalette.AutoHideStripDefault.Text;
            }

            g.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(backgroundColor), rectTabOrigin);

            Rectangle rectBorder = GetBorderRectangle(rectTabOrigin, dockState, TextRenderer.MeasureText(tab.Content.DockHandler.TabText, TextFont).Width);
            g.FillRectangle(DockPanel.Theme.PaintingService.GetBrush(borderColor), rectBorder);

            // Draw the text
            Rectangle rectText = GetTextRectangle(rectTabOrigin, dockState);

            if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
                g.DrawString(content.DockHandler.TabText, TextFont, DockPanel.Theme.PaintingService.GetBrush(textColor), rectText, StringFormatTabVertical);
            else
                g.DrawString(content.DockHandler.TabText, TextFont, DockPanel.Theme.PaintingService.GetBrush(textColor), rectText, StringFormatTabHorizontal);

            // Set rotate back
            g.Transform = matrixRotate;
        }

        private Rectangle GetBorderRectangle(Rectangle tab, DockState state, int width)
        {
            var result = new Rectangle(tab.Location, tab.Size);
            if (state == DockState.DockLeftAutoHide)
            {
                result.Height = width;
                result.Width = DockPanel.Theme.Measures.AutoHideTabLineWidth;
                result.Y += TextGapLeft;
                return result;
            }

            if (state == DockState.DockRightAutoHide)
            {
                result.Height = width;
                result.Width = DockPanel.Theme.Measures.AutoHideTabLineWidth;
                result.X += tab.Width - result.Width;
                result.Y += TextGapLeft;
                return result;
            }

            if (state == DockState.DockBottomAutoHide)
            {
                result.Width = width;
                result.Height = DockPanel.Theme.Measures.AutoHideTabLineWidth;
                result.X += TextGapLeft;
                result.Y += tab.Height - result.Height;
                return result;
            }

            if (state == DockState.DockTopAutoHide)
            {
                result.Width = width;
                result.Height = DockPanel.Theme.Measures.AutoHideTabLineWidth;
                result.X += TextGapLeft;
                return result;
            }

            return Rectangle.Empty;
        }

        public Rectangle GetLogicalTabStripRectangle(DockState state)
        {
            var rectStrip = GetTabStripRectangle(state);
            var location = rectStrip.Location;
            if (state == DockState.DockLeftAutoHide || state == DockState.DockRightAutoHide)
            {
                return new Rectangle(0, 0, rectStrip.Height, rectStrip.Width);
            }

            return new Rectangle(0, 0, rectStrip.Width, rectStrip.Height);
        }

        private Rectangle GetTabRectangle(TabVS2012 tab)
        {
            var state = tab.Content.DockHandler.DockState;
            var rectStrip = GetTabStripRectangle(state);
            var location = rectStrip.Location;
            if (state == DockState.DockLeftAutoHide || state == DockState.DockRightAutoHide)
            {
                location.Y += tab.TabX;
                return new Rectangle(location.X, location.Y, rectStrip.Width, tab.TabWidth);
            }

            location.X += tab.TabX;
            return new Rectangle(location.X, location.Y, tab.TabWidth, rectStrip.Height);
        }

        private Rectangle GetTextRectangle(Rectangle tab, DockState state)
        {
            var result = new Rectangle(tab.Location, tab.Size);
            if (state == DockState.DockLeftAutoHide)
            {
                result.X += TextGapBottom;
                result.Y += TextGapLeft;
                result.Height -= TextGapLeft + TextGapRight;
                result.Width -= TextGapBottom;
                return result;
            }

            if (state == DockState.DockRightAutoHide)
            {
                result.Y += TextGapLeft;
                result.Height -= TextGapLeft + TextGapRight;
                result.Width -= TextGapBottom;
                return result;
            }
            
            if (state == DockState.DockBottomAutoHide)
            {
                result.X += TextGapLeft;
                result.Width -= TextGapLeft + TextGapRight;
                result.Height -= TextGapBottom;
                return result;
            }

            if (state == DockState.DockTopAutoHide)
            {
                result.X += TextGapLeft;
                result.Y += TextGapBottom;
                result.Width -= TextGapLeft + TextGapRight;
                result.Height -= TextGapBottom;
                return result;
            }

            return Rectangle.Empty;
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
            GraphicsPath path = GetTabOutline((TabVS2012)tab, true);
            RectangleF bounds = path.GetBounds();
            return new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
        }

        protected Tab TabHitTest(Point ptMouse)
        {
            foreach (DockState state in DockStates)
            {
                Rectangle rectTabStrip = GetTabStripRectangle(state);
                if (!rectTabStrip.Contains(ptMouse))
                    continue;

                foreach (Pane pane in GetPanes(state))
                {
                    foreach (TabVS2012 tab in pane.AutoHideTabs)
                    {
                        GraphicsPath path = GetTabOutline(tab, true);
                        if (path.IsVisible(ptMouse))
                            return tab;
                    }
                }
            }

            return null;
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
