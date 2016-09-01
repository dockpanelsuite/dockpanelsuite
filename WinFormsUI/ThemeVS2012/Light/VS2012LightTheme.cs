using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    using WeifenLuo.WinFormsUI.ThemeVS2012.Light;

    /// <summary>
    /// Visual Studio 2012 Light theme.
    /// </summary>
    public class VS2012LightTheme : ThemeBase
    {
        public VS2012LightTheme()
        {
            Skin = CreateVisualStudio2012Light();
            ImageService = new ImageService();
        }

        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public override void Apply(DockPanel dockPanel)
        {
            if (dockPanel == null)
            {
                throw new NullReferenceException("dockPanel");
            }

            Measures.SplitterSize = 6;
            dockPanel.Extender.DockPaneCaptionFactory = new VS2012LightDockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new VS2012LightAutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = new VS2012LightAutoHideWindowFactory();
            dockPanel.Extender.DockPaneStripFactory = new VS2012LightDockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = new VS2012LightDockPaneSplitterControlFactory();
            dockPanel.Extender.DockWindowSplitterControlFactory = new VS2012LightDockWindowSplitterControlFactory();
            dockPanel.Extender.DockWindowFactory = new VS2012LightDockWindowFactory();
            dockPanel.Extender.PaneIndicatorFactory = new VS2012LightPaneIndicatorFactory();
            dockPanel.Extender.PanelIndicatorFactory = new VS2012LightPanelIndicatorFactory();
            dockPanel.Extender.DockOutlineFactory = new VS2012LightDockOutlineFactory();
        }

        private class VS2012LightDockOutlineFactory : DockPanelExtender.IDockOutlineFactory
        {
            public DockOutlineBase CreateDockOutline()
            {
                return new VS2012LightDockOutline();
            }

            private class VS2012LightDockOutline : DockOutlineBase
            {
                public VS2012LightDockOutline()
                {
                    m_dragForm = new DragForm();
                    SetDragForm(Rectangle.Empty);
                    DragForm.BackColor = Color.FromArgb(0xff, 91, 173, 255);
                    DragForm.Opacity = 0.5;
                    DragForm.Show(false);
                }

                DragForm m_dragForm;
                private DragForm DragForm
                {
                    get { return m_dragForm; }
                }

                protected override void OnShow()
                {
                    CalculateRegion();
                }

                protected override void OnClose()
                {
                    DragForm.Close();
                }

                private void CalculateRegion()
                {
                    if (SameAsOldValue)
                        return;

                    if (!FloatWindowBounds.IsEmpty)
                        SetOutline(FloatWindowBounds);
                    else if (DockTo is DockPanel)
                        SetOutline(DockTo as DockPanel, Dock, (ContentIndex != 0));
                    else if (DockTo is DockPane)
                        SetOutline(DockTo as DockPane, Dock, ContentIndex);
                    else
                        SetOutline();
                }

                private void SetOutline()
                {
                    SetDragForm(Rectangle.Empty);
                }

                private void SetOutline(Rectangle floatWindowBounds)
                {
                    SetDragForm(floatWindowBounds);
                }

                private void SetOutline(DockPanel dockPanel, DockStyle dock, bool fullPanelEdge)
                {
                    Rectangle rect = fullPanelEdge ? dockPanel.DockArea : dockPanel.DocumentWindowBounds;
                    rect.Location = dockPanel.PointToScreen(rect.Location);
                    if (dock == DockStyle.Top)
                    {
                        int height = dockPanel.GetDockWindowSize(DockState.DockTop);
                        rect = new Rectangle(rect.X, rect.Y, rect.Width, height);
                    }
                    else if (dock == DockStyle.Bottom)
                    {
                        int height = dockPanel.GetDockWindowSize(DockState.DockBottom);
                        rect = new Rectangle(rect.X, rect.Bottom - height, rect.Width, height);
                    }
                    else if (dock == DockStyle.Left)
                    {
                        int width = dockPanel.GetDockWindowSize(DockState.DockLeft);
                        rect = new Rectangle(rect.X, rect.Y, width, rect.Height);
                    }
                    else if (dock == DockStyle.Right)
                    {
                        int width = dockPanel.GetDockWindowSize(DockState.DockRight);
                        rect = new Rectangle(rect.Right - width, rect.Y, width, rect.Height);
                    }
                    else if (dock == DockStyle.Fill)
                    {
                        rect = dockPanel.DocumentWindowBounds;
                        rect.Location = dockPanel.PointToScreen(rect.Location);
                    }

                    SetDragForm(rect);
                }

                private void SetOutline(DockPane pane, DockStyle dock, int contentIndex)
                {
                    if (dock != DockStyle.Fill)
                    {
                        Rectangle rect = pane.DisplayingRectangle;
                        if (dock == DockStyle.Right)
                            rect.X += rect.Width / 2;
                        if (dock == DockStyle.Bottom)
                            rect.Y += rect.Height / 2;
                        if (dock == DockStyle.Left || dock == DockStyle.Right)
                            rect.Width -= rect.Width / 2;
                        if (dock == DockStyle.Top || dock == DockStyle.Bottom)
                            rect.Height -= rect.Height / 2;
                        rect.Location = pane.PointToScreen(rect.Location);

                        SetDragForm(rect);
                    }
                    else if (contentIndex == -1)
                    {
                        Rectangle rect = pane.DisplayingRectangle;
                        rect.Location = pane.PointToScreen(rect.Location);
                        SetDragForm(rect);
                    }
                    else
                    {
                        using (GraphicsPath path = pane.TabStripControl.GetOutline(contentIndex))
                        {
                            RectangleF rectF = path.GetBounds();
                            Rectangle rect = new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height);
                            using (Matrix matrix = new Matrix(rect, new Point[] { new Point(0, 0), new Point(rect.Width, 0), new Point(0, rect.Height) }))
                            {
                                path.Transform(matrix);
                            }

                            Region region = new Region(path);
                            SetDragForm(rect, region);
                        }
                    }
                }

                private void SetDragForm(Rectangle rect)
                {
                    DragForm.Bounds = rect;
                    if (rect == Rectangle.Empty)
                    {
                        if (DragForm.Region != null)
                        {
                            DragForm.Region.Dispose();
                        }

                        DragForm.Region = new Region(Rectangle.Empty);
                    }
                    else if (DragForm.Region != null)
                    {
                        DragForm.Region.Dispose();
                        DragForm.Region = null;
                    }
                }

                private void SetDragForm(Rectangle rect, Region region)
                {
                    DragForm.Bounds = rect;
                    if (DragForm.Region != null)
                    {
                        DragForm.Region.Dispose();
                    }

                    DragForm.Region = region;
                }
            }
        }

        private class VS2012LightPanelIndicatorFactory : DockPanelExtender.IPanelIndicatorFactory
        {
            public DockPanel.IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme)
            {
                return new VS2012LightPanelIndicator(style, theme);
            }

            private class VS2012LightPanelIndicator : PictureBox, DockPanel.IPanelIndicator
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

                public VS2012LightPanelIndicator(DockStyle dockStyle, ThemeBase theme)
                {
                    m_dockStyle = dockStyle;
                    SizeMode = PictureBoxSizeMode.AutoSize;
                    Image = ImageInactive;

                    _imagePanelLeft = theme.ImageService.DockIndicator_PanelLeft;
                    _imagePanelRight = theme.ImageService.DockIndicator_PanelRight;
                    _imagePanelTop = theme.ImageService.DockIndicator_PanelTop;
                    _imagePanelBottom = theme.ImageService.DockIndicator_PanelBottom;
                    _imagePanelFill = theme.ImageService.DockIndicator_PanelFill;
                    _imagePanelLeftActive = theme.ImageService.DockIndicator_PanelLeft;
                    _imagePanelRightActive = theme.ImageService.DockIndicator_PanelRight;
                    _imagePanelTopActive = theme.ImageService.DockIndicator_PanelTop;
                    _imagePanelBottomActive = theme.ImageService.DockIndicator_PanelBottom;
                    _imagePanelFillActive = theme.ImageService.DockIndicator_PanelFill;
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

        private class VS2012LightPaneIndicatorFactory : DockPanelExtender.IPaneIndicatorFactory
        {
            public DockPanel.IPaneIndicator CreatePaneIndicator(ThemeBase theme)
            {
                return new VS2012LightPaneIndicator((VS2012LightTheme)theme);
            }

            private class VS2012LightPaneIndicator : PictureBox, DockPanel.IPaneIndicator
            {
                private Bitmap _bitmapPaneDiamond;
                private Bitmap _bitmapPaneDiamondLeft;
                private Bitmap _bitmapPaneDiamondRight;
                private Bitmap _bitmapPaneDiamondTop;
                private Bitmap _bitmapPaneDiamondBottom;
                private Bitmap _bitmapPaneDiamondFill;
                private Bitmap _bitmapPaneDiamondHotSpot;
                private Bitmap _bitmapPaneDiamondHotSpotIndex;

                private static DockPanel.HotSpotIndex[] _hotSpots = new[]
                    {
                        new DockPanel.HotSpotIndex(1, 0, DockStyle.Top),
                        new DockPanel.HotSpotIndex(0, 1, DockStyle.Left),
                        new DockPanel.HotSpotIndex(1, 1, DockStyle.Fill),
                        new DockPanel.HotSpotIndex(2, 1, DockStyle.Right),
                        new DockPanel.HotSpotIndex(1, 2, DockStyle.Bottom)
                    };

                private GraphicsPath _displayingGraphicsPath;

                public VS2012LightPaneIndicator(VS2012LightTheme theme)
                {
                    SizeMode = PictureBoxSizeMode.AutoSize;
                    Image = _bitmapPaneDiamond;
                    Region = new Region(DisplayingGraphicsPath);

                    _bitmapPaneDiamond = theme.ImageService.Dockindicator_PaneDiamond;
                    _bitmapPaneDiamondLeft = theme.ImageService.Dockindicator_PaneDiamond_Fill;
                    _bitmapPaneDiamondRight = theme.ImageService.Dockindicator_PaneDiamond_Fill;
                    _bitmapPaneDiamondTop = theme.ImageService.Dockindicator_PaneDiamond_Fill;
                    _bitmapPaneDiamondBottom = theme.ImageService.Dockindicator_PaneDiamond_Fill;
                    _bitmapPaneDiamondFill = theme.ImageService.Dockindicator_PaneDiamond_Fill;
                    _bitmapPaneDiamondHotSpot = theme.ImageService.Dockindicator_PaneDiamond_Hotspot;
                    _bitmapPaneDiamondHotSpotIndex = theme.ImageService.DockIndicator_PaneDiamond_HotspotIndex;
                    _displayingGraphicsPath = DrawHelper.CalculateGraphicsPathFromBitmap(_bitmapPaneDiamond);

                }

                public GraphicsPath DisplayingGraphicsPath
                {
                    get { return _displayingGraphicsPath; }
                }

                public DockStyle HitTest(Point pt)
                {
                    if (!Visible)
                        return DockStyle.None;

                    pt = PointToClient(pt);
                    if (!ClientRectangle.Contains(pt))
                        return DockStyle.None;

                    for (int i = _hotSpots.GetLowerBound(0); i <= _hotSpots.GetUpperBound(0); i++)
                    {
                        if (_bitmapPaneDiamondHotSpot.GetPixel(pt.X, pt.Y) == _bitmapPaneDiamondHotSpotIndex.GetPixel(_hotSpots[i].X, _hotSpots[i].Y))
                            return _hotSpots[i].DockStyle;
                    }

                    return DockStyle.None;
                }

                private DockStyle m_status = DockStyle.None;

                public DockStyle Status
                {
                    get { return m_status; }
                    set
                    {
                        m_status = value;
                        if (m_status == DockStyle.None)
                            Image = _bitmapPaneDiamond;
                        else if (m_status == DockStyle.Left)
                            Image = _bitmapPaneDiamondLeft;
                        else if (m_status == DockStyle.Right)
                            Image = _bitmapPaneDiamondRight;
                        else if (m_status == DockStyle.Top)
                            Image = _bitmapPaneDiamondTop;
                        else if (m_status == DockStyle.Bottom)
                            Image = _bitmapPaneDiamondBottom;
                        else if (m_status == DockStyle.Fill)
                            Image = _bitmapPaneDiamondFill;
                    }
                }
            }
        }

        private class VS2012LightAutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
        {
            public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
            {
                return new VS2012AutoHideWindowControl(panel);
            }
        }

        private class VS2012LightDockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
        {
            public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
            {
                return new VS2012SplitterControl(pane);
            }
        }

        private class VS2012LightDockWindowSplitterControlFactory : DockPanelExtender.IDockWindowSplitterControlFactory
        {
            public SplitterBase CreateSplitterControl()
            {
                return new VS2012DockWindow.VS2012DockWindowSplitterControl();
            }
        }

        private class VS2012LightDockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2012DockPaneStrip(pane);
            }
        }

        private class VS2012LightAutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new VS2012AutoHideStrip(panel);
            }
        }

        private class VS2012LightDockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new VS2012DockPaneCaption(pane);
            }
        }

        private class VS2012LightDockWindowFactory : DockPanelExtender.IDockWindowFactory
        {
            public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
            {
                return new VS2012DockWindow(dockPanel, dockState);
            }
        }

        public static DockPanelSkin CreateVisualStudio2012Light()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.MainWindowActive.Background = Color.FromArgb(0xFF, 0xEF, 0xEF, 0xF2);

            skin.ColorPalette.AutoHideStripDefault.Background = Color.FromArgb(0xFF, 0xEF, 0xEF, 0xF2);
            skin.ColorPalette.AutoHideStripDefault.Border = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.AutoHideStripDefault.Text = Color.FromArgb(0xFF, 0x44, 0x44, 0x44);

            skin.ColorPalette.AutoHideStripHovered.Background = Color.FromArgb(0xFF, 0xEF, 0xEF, 0xF2);
            skin.ColorPalette.AutoHideStripHovered.Border = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.AutoHideStripHovered.Text = Color.FromArgb(0xFF, 0x0E, 0x70, 0xC0);

            skin.ColorPalette.TabSelectedActive.Background = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.TabSelectedActive.Button = Color.FromArgb(0xFF, 0xD0, 0xE6, 0xF5);
            skin.ColorPalette.TabSelectedActive.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.TabSelectedInactive.Background = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.TabSelectedInactive.Button = Color.FromArgb(0xFF, 0x6D, 0x6D, 0x70);
            skin.ColorPalette.TabSelectedInactive.Text = Color.FromArgb(0xFF, 0x71, 0x71, 0x71);

            skin.ColorPalette.TabUnselected.Text = Color.FromArgb(0xFF, 0x1E, 0x1E, 0x1E);

            skin.ColorPalette.TabUnselectedHovered.Background = Color.FromArgb(0xFF, 0x1C, 0x97, 0xEA);
            skin.ColorPalette.TabUnselectedHovered.Button = Color.FromArgb(0xFF, 0xD0, 0xE6, 0xF5);
            skin.ColorPalette.TabUnselectedHovered.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.ToolWindowCaptionActive.Background = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.ToolWindowCaptionActive.Button = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            skin.ColorPalette.ToolWindowCaptionActive.Grip = Color.FromArgb(0xFF, 0x59, 0xA8, 0xDE);
            skin.ColorPalette.ToolWindowCaptionActive.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.ToolWindowCaptionInactive.Background = Color.FromArgb(0xFF, 0xEF, 0xEF, 0xF2);
            skin.ColorPalette.ToolWindowCaptionInactive.Button = Color.FromArgb(0xFF, 0x1E, 0x1E, 0x1E);
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = Color.FromArgb(0xFF, 0x99, 0x99, 0x99);
            skin.ColorPalette.ToolWindowCaptionInactive.Text = Color.FromArgb(0xFF, 0x44, 0x44, 0x44);

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = Color.FromArgb(0xFF, 0xF5, 0xF5, 0xF5);
            skin.ColorPalette.ToolWindowTabSelectedActive.Separator = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = Color.FromArgb(0xFF, 0x0E, 0x70, 0xC0);

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = Color.FromArgb(0xFF, 0xF6, 0xF6, 0xF6);
            skin.ColorPalette.ToolWindowTabSelectedInactive.Separator = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = Color.FromArgb(0xFF, 0x0E, 0x70, 0xC0);

            skin.ColorPalette.ToolWindowTabUnselected.Separator = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.ToolWindowTabUnselected.Text = Color.FromArgb(0xFF, 0x44, 0x44, 0x44);

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = Color.FromArgb(0xFF, 0xFE, 0xFE, 0xFE);
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Separator = Color.FromArgb(0xFF, 0xCC, 0xCE, 0xDB);
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);

            return skin;
        }
    }
}