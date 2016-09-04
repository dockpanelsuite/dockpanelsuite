using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    using WeifenLuo.WinFormsUI.ThemeVS2012;

    internal class VS2012DockPaneCaption : DockPaneCaptionBase
    {
        private sealed class InertButton : InertButtonBase
        {
            private Bitmap _hovered;
            private Bitmap _normal;
            private Bitmap _active;
            private Bitmap _hoveredActive;
            private Bitmap _hoveredAutoHide;
            private Bitmap _autoHide;

            public InertButton(VS2012DockPaneCaption dockPaneCaption, Bitmap hovered, Bitmap normal, Bitmap hoveredActive, Bitmap active, Bitmap hoveredAutoHide = null, Bitmap autoHide = null)
            {
                m_dockPaneCaption = dockPaneCaption;
                _hovered = hovered;
                _normal = normal;
                _hoveredActive = hoveredActive;
                _active = active;
                _hoveredAutoHide = hoveredAutoHide ?? hoveredActive;
                _autoHide = autoHide ?? active;
                RefreshChanges();
            }

            private VS2012DockPaneCaption m_dockPaneCaption;
            private VS2012DockPaneCaption DockPaneCaption
            {
                get { return m_dockPaneCaption; }
            }

            public bool IsAutoHide
            {
                get { return DockPaneCaption.DockPane.IsAutoHide; }
            }

            public bool IsActive
            {
                get { return DockPaneCaption.DockPane.IsActivePane; }
            }

            public override Bitmap Image
            {
                get { return IsActive ? IsAutoHide ? _autoHide : _active : _normal; }
            }

            public override Bitmap HoverImage
            {
                get { return IsActive ? IsAutoHide ? _hoveredAutoHide : _hoveredActive : _hovered; }
            }

            protected override void OnRefreshChanges()
            {
                if (DockPaneCaption.DockPane.DockPanel != null)
                {
                    if (DockPaneCaption.TextColor != ForeColor)
                    {
                        ForeColor = DockPaneCaption.TextColor;
                        Invalidate();
                    }
                }
            }
        }

        #region consts
        private const int TextGapTop = 3;
        private const int TextGapBottom = 2;
        private const int TextGapLeft = 2;
        private const int TextGapRight = 3;
        private const int ButtonGapTop = 3;
        private const int ButtonGapBottom = 3;
        private const int ButtonGapBetween = 1;
        private const int ButtonGapLeft = 1;
        private const int ButtonGapRight = 4;
        #endregion

        private InertButton m_buttonClose;
        private InertButton ButtonClose
        {
            get
            {
                if (m_buttonClose == null)
                {
                    m_buttonClose = new InertButton(this, DockPane.DockPanel.Theme.ImageService.DockPaneHover_Close, DockPane.DockPanel.Theme.ImageService.DockPane_Close,
                        DockPane.DockPanel.Theme.ImageService.DockPaneActiveHover_Close, DockPane.DockPanel.Theme.ImageService.DockPaneActive_Close);
                    m_toolTip.SetToolTip(m_buttonClose, ToolTipClose);
                    m_buttonClose.Click += new EventHandler(Close_Click);
                    Controls.Add(m_buttonClose);
                }

                return m_buttonClose;
            }
        }

        private InertButton m_buttonAutoHide;
        private InertButton ButtonAutoHide
        {
            get
            {
                if (m_buttonAutoHide == null)
                {
                    m_buttonAutoHide = new InertButton(this, DockPane.DockPanel.Theme.ImageService.DockPaneHover_Dock, DockPane.DockPanel.Theme.ImageService.DockPane_Dock,
                        DockPane.DockPanel.Theme.ImageService.DockPaneActiveHover_Dock, DockPane.DockPanel.Theme.ImageService.DockPaneActive_Dock,
                        DockPane.DockPanel.Theme.ImageService.DockPaneHover_AutoHide, DockPane.DockPanel.Theme.ImageService.DockPane_AutoHide);
                    m_toolTip.SetToolTip(m_buttonAutoHide, ToolTipAutoHide);
                    m_buttonAutoHide.Click += new EventHandler(AutoHide_Click);
                    Controls.Add(m_buttonAutoHide);
                }

                return m_buttonAutoHide;
            }
        }

        private InertButton m_buttonOptions;
        private InertButton ButtonOptions
        {
            get
            {
                if (m_buttonOptions == null)
                {
                    m_buttonOptions = new InertButton(this, DockPane.DockPanel.Theme.ImageService.DockPaneHover_Option, DockPane.DockPanel.Theme.ImageService.DockPane_Option,
                        DockPane.DockPanel.Theme.ImageService.DockPaneActiveHover_Option, DockPane.DockPanel.Theme.ImageService.DockPaneActive_Option);
                    m_toolTip.SetToolTip(m_buttonOptions, ToolTipOptions);
                    m_buttonOptions.Click += new EventHandler(Options_Click);
                    Controls.Add(m_buttonOptions);
                }
                return m_buttonOptions;
            }
        }

        private IContainer m_components;
        private IContainer Components
        {
            get { return m_components; }
        }

        private ToolTip m_toolTip;

        public VS2012DockPaneCaption(DockPane pane) : base(pane)
        {
            SuspendLayout();

            m_components = new Container();
            m_toolTip = new ToolTip(Components);

            ResumeLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Components.Dispose();
            base.Dispose(disposing);
        }

        public Font TextFont
        {
            get { return DockPane.DockPanel.Theme.Skin.DockPaneStripSkin.TextFont; }
        }

        private static string _toolTipClose;
        private static string ToolTipClose
        {
            get
            {	
                if (_toolTipClose == null)
                    _toolTipClose = Strings.DockPaneCaption_ToolTipClose;
                return _toolTipClose;
            }
        }

        private static string _toolTipOptions;
        private static string ToolTipOptions
        {
            get
            {
                if (_toolTipOptions == null)
                    _toolTipOptions = Strings.DockPaneCaption_ToolTipOptions;

                return _toolTipOptions;
            }
        }

        private static string _toolTipAutoHide;
        private static string ToolTipAutoHide
        {
            get
            {	
                if (_toolTipAutoHide == null)
                    _toolTipAutoHide = Strings.DockPaneCaption_ToolTipAutoHide;
                return _toolTipAutoHide;
            }
        }

        private Color TextColor
        {
            get
            {
                if (DockPane.IsActivePane)
                    return DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionActive.Text;
                else
                    return DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionInactive.Text;
            }
        }

        private static TextFormatFlags _textFormat =
            TextFormatFlags.SingleLine |
            TextFormatFlags.EndEllipsis |
            TextFormatFlags.VerticalCenter;
        private TextFormatFlags TextFormat
        {
            get
            {
                if (RightToLeft == RightToLeft.No)
                    return _textFormat;
                else
                    return _textFormat | TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }
        }

        protected override int MeasureHeight()
        {
            int height = TextFont.Height + TextGapTop + TextGapBottom;

            if (height < ButtonClose.Image.Height + ButtonGapTop + ButtonGapBottom)
                height = ButtonClose.Image.Height + ButtonGapTop + ButtonGapBottom;

            return height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint (e);
            DrawCaption(e.Graphics);
        }

        private void DrawCaption(Graphics g)
        {
            if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0)
                return;

            Rectangle rect = ClientRectangle;
            Color captionColor;

            if (DockPane.IsActivePane)
                captionColor = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionActive.Background;
            else
                captionColor = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionInactive.Background;

            SolidBrush captionBrush = DockPane.DockPanel.Theme.PaintingService.GetBrush(captionColor);
            g.FillRectangle(captionBrush, rect);

            Rectangle rectCaption = rect;

            Rectangle rectCaptionText = rectCaption;
            rectCaptionText.X += TextGapLeft;
            rectCaptionText.Width -= TextGapLeft + TextGapRight;
            rectCaptionText.Width -= ButtonGapLeft + ButtonClose.Width + ButtonGapRight;
            if (ShouldShowAutoHideButton)
                rectCaptionText.Width -= ButtonAutoHide.Width + ButtonGapBetween;
            if (HasTabPageContextMenu)
                rectCaptionText.Width -= ButtonOptions.Width + ButtonGapBetween;
            rectCaptionText.Y += TextGapTop;
            rectCaptionText.Height -= TextGapTop + TextGapBottom;

            Color colorText;
            if (DockPane.IsActivated)
                colorText = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionActive.Text;
            else
                colorText = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionInactive.Text;

            TextRenderer.DrawText(g, DockPane.CaptionText, TextFont, DrawHelper.RtlTransform(this, rectCaptionText), colorText, TextFormat);

            Rectangle rectDotsStrip = rectCaptionText;
            int textLength = (int)g.MeasureString(DockPane.CaptionText, TextFont).Width + TextGapLeft;
            rectDotsStrip.X += textLength;
            rectDotsStrip.Width -= textLength;
            rectDotsStrip.Height = ClientRectangle.Height;

            Color dotsColor;
            if (DockPane.IsActivated)
                dotsColor = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionActive.Grip;
            else
                dotsColor = DockPane.DockPanel.Theme.Skin.ColorPalette.ToolWindowCaptionInactive.Grip;

            DrawDotsStrip(g, rectDotsStrip, dotsColor);
        }

        protected void DrawDotsStrip(Graphics g, Rectangle rectStrip, Color colorDots)
        {
            if (rectStrip.Width <= 0 || rectStrip.Height <= 0)
                return;

            var penDots = DockPane.DockPanel.Theme.PaintingService.GetPen(colorDots, 1);
            penDots.DashStyle = DashStyle.Custom;
            penDots.DashPattern = new float[] { 1, 3 };
            int positionY = rectStrip.Height / 2;

            g.DrawLine(penDots, rectStrip.X + 2, positionY, rectStrip.X + rectStrip.Width - 2, positionY);

            g.DrawLine(penDots, rectStrip.X, positionY - 2, rectStrip.X + rectStrip.Width, positionY - 2);
            g.DrawLine(penDots, rectStrip.X, positionY + 2, rectStrip.X + rectStrip.Width, positionY + 2);
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            SetButtonsPosition();
            base.OnLayout (levent);
        }

        protected override void OnRefreshChanges()
        {
            SetButtons();
            Invalidate();
        }

        private bool CloseButtonEnabled
        {
            get	{	return (DockPane.ActiveContent != null)? DockPane.ActiveContent.DockHandler.CloseButton : false;	}
        }

        /// <summary>
        /// Determines whether the close button is visible on the content
        /// </summary>
        private bool CloseButtonVisible
        {
            get { return (DockPane.ActiveContent != null) ? DockPane.ActiveContent.DockHandler.CloseButtonVisible : false; }
        }

        private bool ShouldShowAutoHideButton
        {
            get	{	return !DockPane.IsFloat;	}
        }

        private void SetButtons()
        {
            ButtonClose.Enabled = CloseButtonEnabled;
            ButtonClose.Visible = CloseButtonVisible;
            ButtonAutoHide.Visible = ShouldShowAutoHideButton;
            ButtonOptions.Visible = HasTabPageContextMenu;
            ButtonClose.RefreshChanges();
            ButtonAutoHide.RefreshChanges();
            ButtonOptions.RefreshChanges();
            
            SetButtonsPosition();
        }

        private void SetButtonsPosition()
        {
            // set the size and location for close and auto-hide buttons
            Rectangle rectCaption = ClientRectangle;
            int buttonWidth = ButtonClose.Image.Width;
            int buttonHeight = ButtonClose.Image.Height;

            Size buttonSize = new Size(buttonWidth, buttonHeight);
            int x = rectCaption.X + rectCaption.Width - ButtonGapRight - m_buttonClose.Width;
            int y = rectCaption.Y + ButtonGapTop;
            Point point = new Point(x, y);
            ButtonClose.Bounds = DrawHelper.RtlTransform(this, new Rectangle(point, buttonSize));

            // If the close button is not visible draw the auto hide button overtop.
            // Otherwise it is drawn to the left of the close button.
            if (CloseButtonVisible)
                point.Offset(-(buttonWidth + ButtonGapBetween), 0);
            
            ButtonAutoHide.Bounds = DrawHelper.RtlTransform(this, new Rectangle(point, buttonSize));
            if (ShouldShowAutoHideButton)
                point.Offset(-(buttonWidth + ButtonGapBetween), 0);
            ButtonOptions.Bounds = DrawHelper.RtlTransform(this, new Rectangle(point, buttonSize));
        }

        private void Close_Click(object sender, EventArgs e)
        {
            DockPane.CloseActiveContent();
        }

        private void AutoHide_Click(object sender, EventArgs e)
        {
            DockPane.DockState = DockHelper.ToggleAutoHideState(DockPane.DockState);
            if (DockHelper.IsDockStateAutoHide(DockPane.DockState))
            {
                DockPane.DockPanel.ActiveAutoHideContent = null;
                DockPane.NestedDockingStatus.NestedPanes.SwitchPaneWithFirstChild(DockPane);
            }
        }

        private void Options_Click(object sender, EventArgs e)
        {
            ShowTabPageContextMenu(PointToClient(Control.MousePosition));
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            PerformLayout();
        }
    }
}
