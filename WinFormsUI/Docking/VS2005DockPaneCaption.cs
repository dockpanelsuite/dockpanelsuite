using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
	internal class VS2005DockPaneCaption : DockPaneCaptionBase
	{
        private sealed class InertButton : InertButtonBase
        {
            public InertButton(DockPane dockPane, ImageList imageList)
                : base(imageList)
            {
                m_dockPane = dockPane;
                RefreshChanges();
            }

            private DockPane m_dockPane;
            private DockPane DockPane
            {
                get { return m_dockPane; }
            }

            public bool IsPaneActive
            {
                get { return DockPane.IsActivated; }
            }

            public bool IsAutoHide
            {
                get { return DockPane.IsAutoHide; }
            }

            protected override void OnRefreshChanges()
            {
                if (!IsAutoHide || ImageList.Images.Count == 4)
                {
                    if (IsMouseOver && IsPaneActive)
                        ImageIndex = 0;
                    else if (IsMouseOver && !IsPaneActive)
                        ImageIndex = 1;
                    else if (IsPaneActive)
                        ImageIndex = 2;
                    else
                        ImageIndex = 3;
                }
                else
                {
                    if (IsMouseOver && IsPaneActive)
                        ImageIndex = 4;
                    else if (IsMouseOver && !IsPaneActive)
                        ImageIndex = 5;
                    else if (IsPaneActive)
                        ImageIndex = 6;
                    else
                        ImageIndex = 7;
                }
            }
        }

		#region consts
		private const int _TextGapTop = 2;
		private const int _TextGapBottom = 0;
		private const int _TextGapLeft = 3;
		private const int _TextGapRight = 3;
		private const int _ButtonGapTop = 2;
		private const int _ButtonGapBottom = 1;
		private const int _ButtonGapBetween = 1;
		private const int _ButtonGapLeft = 1;
		private const int _ButtonGapRight = 2;
		#endregion

        private static ImageList _imageListButtonClose;
        private static ImageList ImageListButtonClose
        {
            get
            {
                if (_imageListButtonClose == null)
                {
                    _imageListButtonClose = new ImageList();
                    Bitmap bitmap = Resources.DockPaneCaption_Close2;
                    _imageListButtonClose.ImageSize = bitmap.Size;
                    _imageListButtonClose.TransparentColor = bitmap.GetPixel(0, 0);
                    _imageListButtonClose.Images.Add(Resources.DockPaneCaption_Close0);
                    _imageListButtonClose.Images.Add(Resources.DockPaneCaption_Close1);
                    _imageListButtonClose.Images.Add(bitmap);
                    _imageListButtonClose.Images.Add(Resources.DockPaneCaption_Close3);
                }

                return _imageListButtonClose;
            }
        }

		private InertButton m_buttonClose;
        private InertButton ButtonClose
        {
            get
            {
                if (m_buttonClose == null)
                {
                    m_buttonClose = new InertButton(DockPane, ImageListButtonClose);
                    m_toolTip.SetToolTip(m_buttonClose, ToolTipClose);
                    m_buttonClose.Click += new EventHandler(Close_Click);
                    Controls.Add(m_buttonClose);
                }

                return m_buttonClose;
            }
        }

        private static ImageList _imageListButtonAutoHide;
        private static ImageList ImageListButtonAutoHide
        {
            get
            {
                if (_imageListButtonAutoHide == null)
                {
                    _imageListButtonAutoHide = new ImageList();
                    Bitmap bitmap = Resources.DockPaneCaption_AutoHide2;
                    _imageListButtonAutoHide.ImageSize = bitmap.Size;
                    _imageListButtonAutoHide.TransparentColor = bitmap.GetPixel(0, 0);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide0);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide1);
                    _imageListButtonAutoHide.Images.Add(bitmap);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide3);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide4);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide5);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide6);
                    _imageListButtonAutoHide.Images.Add(Resources.DockPaneCaption_AutoHide7);
                }

                return _imageListButtonAutoHide;
            }
        }

		private InertButton m_buttonAutoHide;
        private InertButton ButtonAutoHide
        {
            get
            {
                if (m_buttonAutoHide == null)
                {
                    m_buttonAutoHide = new InertButton(DockPane, ImageListButtonAutoHide);
                    m_toolTip.SetToolTip(m_buttonAutoHide, ToolTipAutoHide);
                    m_buttonAutoHide.Click += new EventHandler(AutoHide_Click);
                    Controls.Add(m_buttonAutoHide);
                }

                return m_buttonAutoHide;
            }
        }

        private static ImageList _imageListButtonOptions;
        private static ImageList ImageListButtonOptions
        {
            get
            {
                if (_imageListButtonOptions == null)
                {
                    _imageListButtonOptions = new ImageList();
                    Bitmap bitmap = Resources.DockPaneCaption_Options2;
                    _imageListButtonOptions.ImageSize = bitmap.Size;
                    _imageListButtonOptions.TransparentColor = bitmap.GetPixel(0, 0);
                    _imageListButtonOptions.Images.Add(Resources.DockPaneCaption_Options0);
                    _imageListButtonOptions.Images.Add(Resources.DockPaneCaption_Options1);
                    _imageListButtonOptions.Images.Add(bitmap);
                    _imageListButtonOptions.Images.Add(Resources.DockPaneCaption_Options3);
                }

                return _imageListButtonOptions;
            }
        }

        private InertButton m_buttonOptions;
        private InertButton ButtonOptions
        {
            get
            {
                if (m_buttonOptions == null)
                {
                    m_buttonOptions = new InertButton(DockPane, ImageListButtonOptions);
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

		public VS2005DockPaneCaption(DockPane pane) : base(pane)
		{
			SuspendLayout();

			Font = SystemInformation.MenuFont;
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

		private static int TextGapTop
		{
			get	{	return _TextGapTop;	}
		}

		private static int TextGapBottom
		{
			get	{	return _TextGapBottom;	}
		}

		private static int TextGapLeft
		{
			get	{	return _TextGapLeft;	}
		}

		private static int TextGapRight
		{
			get	{	return _TextGapRight;	}
		}

		private static int ButtonGapTop
		{
			get	{	return _ButtonGapTop;	}
		}

		private static int ButtonGapBottom
		{
			get	{	return _ButtonGapBottom;	}
		}

		private static int ButtonGapLeft
		{
			get	{	return _ButtonGapLeft;	}
		}

		private static int ButtonGapRight
		{
			get	{	return _ButtonGapRight;	}
		}

		private static int ButtonGapBetween
		{
			get	{	return _ButtonGapBetween;	}
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

		private static Color ActiveBackColorGradientBegin
		{
			get	{ return Color.FromArgb(59, 128, 237); }
        }
		

        private static Color ActiveBackColorGradientEnd
        {
            get { return Color.FromArgb(49, 106, 197); }
        }

		private static Color InactiveBackColor
		{
            get { return Color.FromArgb(204, 199, 186); }
		}

		private static Color ActiveTextColor
		{
			get	{	return SystemColors.ActiveCaptionText;	}
		}

		private static Color InactiveTextColor
		{
			get	{	return SystemColors.ControlText;	}
		}

		private static Color InactiveBorderColor
		{
			get	{	return SystemColors.GrayText; }
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

		protected internal override int MeasureHeight()
		{
			int height = Font.Height + TextGapTop + TextGapBottom;

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
            if (DockPane.IsActivated)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, ActiveBackColorGradientBegin, ActiveBackColorGradientEnd, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, ClientRectangle);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(InactiveBackColor))
                {
                    g.FillRectangle(brush, ClientRectangle);
                }
            }

			Rectangle rectCaption = ClientRectangle;

			if (!DockPane.IsActivated)
			{
				using (Pen pen = new Pen(InactiveBorderColor))
				{
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y, rectCaption.X + rectCaption.Width - 2, rectCaption.Y);
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y + rectCaption.Height - 1, rectCaption.X + rectCaption.Width - 2, rectCaption.Y + rectCaption.Height - 1);
					g.DrawLine(pen, rectCaption.X, rectCaption.Y + 1, rectCaption.X, rectCaption.Y + rectCaption.Height - 2);
					g.DrawLine(pen, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + 1, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + rectCaption.Height - 2);
				}
			}

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
            TextRenderer.DrawText(g, DockPane.CaptionText, Font, DrawHelper.RtlTransform(this, rectCaptionText), DockPane.IsActivated ? ActiveTextColor : InactiveTextColor, TextFormat);
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

		private bool ShouldShowAutoHideButton
		{
			get	{	return !DockPane.IsFloat;	}
		}

		private void SetButtons()
		{
			ButtonClose.Enabled = CloseButtonEnabled;
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
			int height = rectCaption.Height - ButtonGapTop - ButtonGapBottom;
			if (buttonHeight < height)
			{
				buttonWidth = buttonWidth * (height / buttonHeight);
				buttonHeight = height;
			}
			Size buttonSize = new Size(buttonWidth, buttonHeight);
			int x = rectCaption.X + rectCaption.Width - 1 - ButtonGapRight - m_buttonClose.Width;
			int y = rectCaption.Y + ButtonGapTop;
			Point point = new Point(x, y);
            ButtonClose.Bounds = DrawHelper.RtlTransform(this, new Rectangle(point, buttonSize));
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
            if (!DockPane.IsAutoHide)
                DockPane.ActiveContent.DockHandler.GiveUpFocus();
			DockPane.DockState = DockHelper.ToggleAutoHideState(DockPane.DockState);
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
