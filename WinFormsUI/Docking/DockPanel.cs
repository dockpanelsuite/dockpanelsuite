using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

// To simplify the process of finding the toolbox bitmap resource:
// #1 Create an internal class called "resfinder" outside of the root namespace.
// #2 Use "resfinder" in the toolbox bitmap attribute instead of the control name.
// #3 use the "<default namespace>.<resourcename>" string to locate the resource.
// See: http://www.bobpowell.net/toolboxbitmap.htm
internal class resfinder
{
}

namespace WeifenLuo.WinFormsUI.Docking
{
    using System.Linq;

    /// <summary>
    /// Deserialization handler of layout file/stream.
    /// </summary>
    /// <param name="persistString">Strings stored in layout file/stream.</param>
    /// <returns>Dock content deserialized from layout/stream.</returns>
    /// <remarks>
    /// The deserialization handler method should handle all possible exceptions.
    /// 
    /// If any exception happens during deserialization and is not handled, the program might crash or experience other issues.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "0#")]
    public delegate IDockContent DeserializeDockContent(string persistString);

    [LocalizedDescription("DockPanel_Description")]
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [ToolboxBitmap(typeof(resfinder), "WeifenLuo.WinFormsUI.Docking.DockPanel.bmp")]
    [DefaultProperty("DocumentStyle")]
    [DefaultEvent("ActiveContentChanged")]
    public partial class DockPanel : Panel
    {
        private readonly FocusManagerImpl m_focusManager;
        private AutoHideWindowControl m_autoHideWindow;

        public DockPanel()
        {
            ShowAutoHideContentOnHover = true;

            m_focusManager = new FocusManagerImpl(this);
            Panes = new DockPaneCollection();
            FloatWindows = new FloatWindowCollection();

            SuspendLayout();

            DummyControl = new DummyControl();
            DummyControl.Bounds = new Rectangle(0, 0, 1, 1);
            Controls.Add(DummyControl);

            Theme.ApplyTo(this);

            m_autoHideWindow = Theme.Extender.AutoHideWindowFactory.CreateAutoHideWindow(this);
            m_autoHideWindow.Visible = false;
            m_autoHideWindow.ActiveContentChanged += m_autoHideWindow_ActiveContentChanged;
            SetAutoHideWindowParent();

            LoadDockWindows();

            DummyContent = new DockContent();
            ResumeLayout();
        }

        internal void ResetDummy()
        {
            DummyControl.ResetBackColor();
        }

        internal void SetDummy()
        {
            DummyControl.BackColor = DockBackColor;
        }

        private Color m_BackColor;

        /// <summary>
        /// Determines the color with which the client rectangle will be drawn.
        /// If this property is used instead of the BackColor it will not have any influence on the borders to the surrounding controls (DockPane).
        /// The BackColor property changes the borders of surrounding controls (DockPane).
        /// Alternatively both properties may be used (BackColor to draw and define the color of the borders and DockBackColor to define the color of the client rectangle). 
        /// For Backgroundimages: Set your prefered Image, then set the DockBackColor and the BackColor to the same Color (Control)
        /// </summary>
        [Description("Determines the color with which the client rectangle will be drawn.\r\n" +
            "If this property is used instead of the BackColor it will not have any influence on the borders to the surrounding controls (DockPane).\r\n" +
            "The BackColor property changes the borders of surrounding controls (DockPane).\r\n" +
            "Alternatively both properties may be used (BackColor to draw and define the color of the borders and DockBackColor to define the color of the client rectangle).\r\n" +
            "For Backgroundimages: Set your prefered Image, then set the DockBackColor and the BackColor to the same Color (Control).")]
        public Color DockBackColor
        {
            get => !m_BackColor.IsEmpty ? m_BackColor : base.BackColor;

            set
            {
                if (m_BackColor != value)
                {
                    m_BackColor = value;
                    Refresh();
                }
            }
        }

        private bool ShouldSerializeDockBackColor()
        {
            return !m_BackColor.IsEmpty;
        }

        private AutoHideStripBase m_autoHideStripControl;

        internal AutoHideStripBase AutoHideStripControl
        {
            get
            {
                if (m_autoHideStripControl == null)
                {
                    m_autoHideStripControl = Theme.Extender.AutoHideStripFactory.CreateAutoHideStrip(this);
                    Controls.Add(m_autoHideStripControl);
                }

                return m_autoHideStripControl;
            }
        }

        internal void ResetAutoHideStripControl()
        {
            m_autoHideStripControl?.Dispose();

            m_autoHideStripControl = null;
        }

        private void MdiClientHandleAssigned(object sender, EventArgs e)
        {
            SetMdiClient();
            PerformLayout();
        }

        private void MdiClient_Layout(object sender, LayoutEventArgs e)
        {
            if (DocumentStyle != DocumentStyle.DockingMdi)
                return;

            foreach (DockPane pane in Panes)
                if (pane.DockState == DockState.Document)
                    pane.SetContentBounds();

            InvalidateWindowRegion();
        }

        private bool m_disposed;

        protected override void Dispose(bool disposing)
        {
            if (!m_disposed && disposing)
            {
                m_focusManager.Dispose();
                if (m_mdiClientController != null)
                {
                    m_mdiClientController.HandleAssigned -= MdiClientHandleAssigned;
                    m_mdiClientController.MdiChildActivate -= ParentFormMdiChildActivate;
                    m_mdiClientController.Layout -= MdiClient_Layout;
                    m_mdiClientController.Dispose();
                }
                FloatWindows.Dispose();
                Panes.Dispose();
                DummyContent.Dispose();

                m_disposed = true;
            }

            base.Dispose(disposing);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDockContent ActiveAutoHideContent
        {
            get => AutoHideWindow.ActiveContent;
            set => AutoHideWindow.ActiveContent = value;
        }

        private bool m_allowEndUserDocking = !Win32Helper.IsRunningOnMono;
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_AllowEndUserDocking_Description")]
        [DefaultValue(true)]
        public bool AllowEndUserDocking
        {
            get
            {
                if (Win32Helper.IsRunningOnMono && m_allowEndUserDocking)
                    m_allowEndUserDocking = false;

                return m_allowEndUserDocking;
            }

            set
            {
                if (Win32Helper.IsRunningOnMono && value)
                    throw new InvalidOperationException("AllowEndUserDocking can only be false if running on Mono");

                m_allowEndUserDocking = value;
            }
        }

        private bool m_allowEndUserNestedDocking = !Win32Helper.IsRunningOnMono;
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_AllowEndUserNestedDocking_Description")]
        [DefaultValue(true)]
        public bool AllowEndUserNestedDocking
        {
            get
            {
                if (Win32Helper.IsRunningOnMono && m_allowEndUserDocking)
                    m_allowEndUserDocking = false;
                return m_allowEndUserNestedDocking;
            }

            set
            {
                if (Win32Helper.IsRunningOnMono && value)
                    throw new InvalidOperationException("AllowEndUserNestedDocking can only be false if running on Mono");

                m_allowEndUserNestedDocking = value;
            }
        }

        private DockContentCollection m_contents = new DockContentCollection();
        [Browsable(false)]
        public DockContentCollection Contents => m_contents;

        internal DockContent DummyContent { get; }

        private bool m_rightToLeftLayout;
        [DefaultValue(false)]
        [LocalizedCategory("Appearance")]
        [LocalizedDescription("DockPanel_RightToLeftLayout_Description")]
        public bool RightToLeftLayout
        {
            get => m_rightToLeftLayout;

            set
            {
                if (m_rightToLeftLayout == value)
                    return;

                m_rightToLeftLayout = value;
                foreach (FloatWindow floatWindow in FloatWindows)
                    floatWindow.RightToLeftLayout = value;
            }
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            foreach (FloatWindow floatWindow in FloatWindows)
                floatWindow.RightToLeft = RightToLeft;
        }

        private bool m_showDocumentIcon;
        [DefaultValue(false)]
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_ShowDocumentIcon_Description")]
        public bool ShowDocumentIcon
        {
            get => m_showDocumentIcon;
            set
            {
                if (m_showDocumentIcon == value)
                    return;

                m_showDocumentIcon = value;
                Refresh();
            }
        }

        [DefaultValue(DocumentTabStripLocation.Top)]
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DocumentTabStripLocation")]
        public DocumentTabStripLocation DocumentTabStripLocation { get; set; } = DocumentTabStripLocation.Top;

        [Browsable(false)]
        [Obsolete("Use Theme.Extender instead.")]
        public DockPanelExtender Extender => null;

        [Browsable(false)]
        [Obsolete("Use Theme.Extender instead.")]
        public DockPanelExtender.IDockPaneFactory DockPaneFactory => null;

        [Browsable(false)]
        [Obsolete("Use Theme.Extender instead.")]
        public DockPanelExtender.IFloatWindowFactory FloatWindowFactory => null;

        [Browsable(false)]
        [Obsolete("Use Theme.Extender instead.")]
        public DockPanelExtender.IDockWindowFactory DockWindowFactory => null;

        [Browsable(false)]
        public DockPaneCollection Panes { get; }

        /// <summary>
        /// Dock area.
        /// </summary>
        /// <remarks>
        /// This <see cref="Rectangle"/> is the center rectangle of <see cref="DockPanel"/> control.
        /// 
        /// Excluded spaces are for the following visual elements,
        /// * Auto hide strips on four sides.
        /// * Necessary paddings defined in themes.
        /// 
        /// Therefore, all dock contents mainly fall into this area (except auto hide window, which might slightly move beyond this area).
        /// </remarks>
        public Rectangle DockArea =>
            new Rectangle(DockPadding.Left, DockPadding.Top,
                ClientRectangle.Width - DockPadding.Left - DockPadding.Right,
                ClientRectangle.Height - DockPadding.Top - DockPadding.Bottom);

        private double m_dockBottomPortion = 0.25;

        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockBottomPortion_Description")]
        [DefaultValue(0.25)]
        public double DockBottomPortion
        {
            get => m_dockBottomPortion;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (Math.Abs(value - m_dockBottomPortion) < double.Epsilon)
                    return;

                m_dockBottomPortion = value;

                if (m_dockBottomPortion < 1 && m_dockTopPortion < 1)
                {
                    if (m_dockTopPortion + m_dockBottomPortion > 1)
                        m_dockTopPortion = 1 - m_dockBottomPortion;
                }

                PerformLayout();
            }
        }

        private double m_dockLeftPortion = 0.25;

        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockLeftPortion_Description")]
        [DefaultValue(0.25)]
        public double DockLeftPortion
        {
            get => m_dockLeftPortion;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (Math.Abs(value - m_dockLeftPortion) < double.Epsilon)
                    return;

                m_dockLeftPortion = value;

                if (m_dockLeftPortion < 1 && m_dockRightPortion < 1)
                {
                    if (m_dockLeftPortion + m_dockRightPortion > 1)
                        m_dockRightPortion = 1 - m_dockLeftPortion;
                }
                PerformLayout();
            }
        }

        private double m_dockRightPortion = 0.25;

        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockRightPortion_Description")]
        [DefaultValue(0.25)]
        public double DockRightPortion
        {
            get => m_dockRightPortion;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (Math.Abs(value - m_dockRightPortion) < double.Epsilon)
                    return;

                m_dockRightPortion = value;

                if (m_dockLeftPortion < 1 && m_dockRightPortion < 1)
                {
                    if (m_dockLeftPortion + m_dockRightPortion > 1)
                        m_dockLeftPortion = 1 - m_dockRightPortion;
                }

                PerformLayout();
            }
        }

        private double m_dockTopPortion = 0.25;

        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockTopPortion_Description")]
        [DefaultValue(0.25)]
        public double DockTopPortion
        {
            get => m_dockTopPortion;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (Math.Abs(value - m_dockTopPortion) < double.Epsilon)
                    return;

                m_dockTopPortion = value;

                if (m_dockTopPortion < 1 && m_dockBottomPortion < 1)
                {
                    if (m_dockTopPortion + m_dockBottomPortion > 1)
                        m_dockBottomPortion = 1 - m_dockTopPortion;
                }
                PerformLayout();
            }
        }

        [Browsable(false)]
        public DockWindowCollection DockWindows { get; private set; }

        public void UpdateDockWindowZOrder(DockStyle dockStyle, bool fullPanelEdge)
        {
            if (dockStyle == DockStyle.Left)
            {
                if (fullPanelEdge)
                    DockWindows[DockState.DockLeft].SendToBack();
                else
                    DockWindows[DockState.DockLeft].BringToFront();
            }
            else if (dockStyle == DockStyle.Right)
            {
                if (fullPanelEdge)
                    DockWindows[DockState.DockRight].SendToBack();
                else
                    DockWindows[DockState.DockRight].BringToFront();
            }
            else if (dockStyle == DockStyle.Top)
            {
                if (fullPanelEdge)
                    DockWindows[DockState.DockTop].SendToBack();
                else
                    DockWindows[DockState.DockTop].BringToFront();
            }
            else if (dockStyle == DockStyle.Bottom)
            {
                if (fullPanelEdge)
                    DockWindows[DockState.DockBottom].SendToBack();
                else
                    DockWindows[DockState.DockBottom].BringToFront();
            }
        }

        [Browsable(false)]
        public int DocumentsCount => Documents.Count();

        public IDockContent[] DocumentsToArray()
        {
            return Documents.ToArray();
        }

        [Browsable(false)]
        public IEnumerable<IDockContent> Documents
        {
            get { return Contents.Where(content => content.DockHandler.DockState == DockState.Document); }
        }

        private Control DummyControl { get; }

        [Browsable(false)]
        public FloatWindowCollection FloatWindows { get; }

        [Category("Layout")]
        [LocalizedDescription("DockPanel_DefaultFloatWindowSize_Description")]
        public Size DefaultFloatWindowSize { get; set; } = new Size(300, 300);

        private bool ShouldSerializeDefaultFloatWindowSize()
        {
            return DefaultFloatWindowSize != new Size(300, 300);
        }

        private void ResetDefaultFloatWindowSize()
        {
            DefaultFloatWindowSize = new Size(300, 300);
        }

        private DocumentStyle m_documentStyle = DocumentStyle.DockingWindow;
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DocumentStyle_Description")]
        [DefaultValue(DocumentStyle.DockingWindow)]
        public DocumentStyle DocumentStyle
        {
            get => m_documentStyle;
            set
            {
                if (value == m_documentStyle)
                    return;

                if (!Enum.IsDefined(typeof(DocumentStyle), value))
                    throw new InvalidEnumArgumentException();

                if (value == DocumentStyle.SystemMdi && DockWindows[DockState.Document].VisibleNestedPanes.Count > 0)
                    throw new InvalidEnumArgumentException();

                m_documentStyle = value;

                SuspendLayout(true);

                SetAutoHideWindowParent();
                SetMdiClient();
                InvalidateWindowRegion();

                foreach (IDockContent content in Contents)
                {
                    if (content.DockHandler.DockState == DockState.Document)
                        content.DockHandler.SetPaneAndVisible(content.DockHandler.Pane);
                }

                PerformMdiClientLayout();

                ResumeLayout(true, true);
            }
        }

        [LocalizedCategory("Category_Performance")]
        [LocalizedDescription("DockPanel_SupportDeeplyNestedContent_Description")]
        [DefaultValue(false)]
        public bool SupportDeeplyNestedContent { get; set; }

        /// <summary>
        /// Flag to show autohide content on mouse hover. Default value is <code>true</code>.
        /// </summary>
        /// <remarks>
        /// This flag is ignored in VS2012/2013 themes. Such themes assume it is always <code>false</code>.
        /// </remarks>
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_ShowAutoHideContentOnHover_Description")]
        [DefaultValue(true)]
        public bool ShowAutoHideContentOnHover { get; set; }

        public int GetDockWindowSize(DockState dockState)
        {
            if (dockState == DockState.DockLeft || dockState == DockState.DockRight)
            {
                int width = ClientRectangle.Width - DockPadding.Left - DockPadding.Right;
                int dockLeftSize = m_dockLeftPortion >= 1 ? (int)m_dockLeftPortion : (int)(width * m_dockLeftPortion);
                int dockRightSize = m_dockRightPortion >= 1 ? (int)m_dockRightPortion : (int)(width * m_dockRightPortion);

                if (dockLeftSize < MeasurePane.MinSize)
                    dockLeftSize = MeasurePane.MinSize;
                if (dockRightSize < MeasurePane.MinSize)
                    dockRightSize = MeasurePane.MinSize;

                if (dockLeftSize + dockRightSize > width - MeasurePane.MinSize)
                {
                    int adjust = (dockLeftSize + dockRightSize) - (width - MeasurePane.MinSize);
                    dockLeftSize -= adjust / 2;
                    dockRightSize -= adjust / 2;
                }

                return dockState == DockState.DockLeft ? dockLeftSize : dockRightSize;
            }

            if (dockState == DockState.DockTop || dockState == DockState.DockBottom)
            {
                int height = ClientRectangle.Height - DockPadding.Top - DockPadding.Bottom;
                int dockTopSize = m_dockTopPortion >= 1 ? (int)m_dockTopPortion : (int)(height * m_dockTopPortion);
                int dockBottomSize = m_dockBottomPortion >= 1 ? (int)m_dockBottomPortion : (int)(height * m_dockBottomPortion);

                if (dockTopSize < MeasurePane.MinSize)
                    dockTopSize = MeasurePane.MinSize;
                if (dockBottomSize < MeasurePane.MinSize)
                    dockBottomSize = MeasurePane.MinSize;

                if (dockTopSize + dockBottomSize > height - MeasurePane.MinSize)
                {
                    int adjust = (dockTopSize + dockBottomSize) - (height - MeasurePane.MinSize);
                    dockTopSize -= adjust / 2;
                    dockBottomSize -= adjust / 2;
                }

                return dockState == DockState.DockTop ? dockTopSize : dockBottomSize;
            }

            return 0;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            SuspendLayout(true);

            AutoHideStripControl.Bounds = ClientRectangle;

            CalculateDockPadding();

            DockWindows[DockState.DockLeft].Width = GetDockWindowSize(DockState.DockLeft);
            DockWindows[DockState.DockRight].Width = GetDockWindowSize(DockState.DockRight);
            DockWindows[DockState.DockTop].Height = GetDockWindowSize(DockState.DockTop);
            DockWindows[DockState.DockBottom].Height = GetDockWindowSize(DockState.DockBottom);

            AutoHideWindow.Bounds = GetAutoHideWindowBounds(AutoHideWindowRectangle);

            DockWindow documentDockWindow = DockWindows[DockState.Document];

            if (ReferenceEquals(documentDockWindow.Parent, AutoHideWindow.Parent))
            {
                AutoHideWindow.Parent.Controls.SetChildIndex(AutoHideWindow, 0);
                documentDockWindow.Parent.Controls.SetChildIndex(documentDockWindow, 1);
            }
            else
            {
                documentDockWindow.BringToFront();
                AutoHideWindow.BringToFront();
            }

            base.OnLayout(levent);

            if (DocumentStyle == DocumentStyle.SystemMdi && MdiClientExists)
            {
                SetMdiClientBounds(SystemMdiClientBounds);
                InvalidateWindowRegion();
            }
            else if (DocumentStyle == DocumentStyle.DockingMdi)
            {
                InvalidateWindowRegion();
            }

            ResumeLayout(true, true);
        }

        internal Rectangle GetTabStripRectangle(DockState dockState)
        {
            return AutoHideStripControl.GetTabStripRectangle(dockState);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DockBackColor.ToArgb() == BackColor.ToArgb())
                return;

            Graphics g = e.Graphics;
            SolidBrush bgBrush = new SolidBrush(DockBackColor);
            g.FillRectangle(bgBrush, ClientRectangle);
        }

        internal void AddContent(IDockContent content)
        {
            if (content == null)
                throw (new ArgumentNullException());

            if (!Contents.Contains(content))
            {
                Contents.Add(content);
                OnContentAdded(new DockContentEventArgs(content));
            }
        }

        internal void AddPane(DockPane pane)
        {
            if (Panes.Contains(pane))
                return;

            Panes.Add(pane);
        }

        internal void AddFloatWindow(FloatWindow floatWindow)
        {
            if (FloatWindows.Contains(floatWindow))
                return;

            FloatWindows.Add(floatWindow);
        }

        private void CalculateDockPadding()
        {
            DockPadding.All = Theme.Measures.DockPadding;
            int standard = AutoHideStripControl.MeasureHeight();
            if (AutoHideStripControl.GetNumberOfPanes(DockState.DockLeftAutoHide) > 0)
                DockPadding.Left = standard;
            if (AutoHideStripControl.GetNumberOfPanes(DockState.DockRightAutoHide) > 0)
                DockPadding.Right = standard;
            if (AutoHideStripControl.GetNumberOfPanes(DockState.DockTopAutoHide) > 0)
                DockPadding.Top = standard;
            if (AutoHideStripControl.GetNumberOfPanes(DockState.DockBottomAutoHide) > 0)
                DockPadding.Bottom = standard;
        }

        internal void RemoveContent(IDockContent content)
        {
            if (content == null)
                throw (new ArgumentNullException());

            if (Contents.Contains(content))
            {
                Contents.Remove(content);
                OnContentRemoved(new DockContentEventArgs(content));
            }
        }

        internal void RemovePane(DockPane pane)
        {
            if (!Panes.Contains(pane))
                return;

            Panes.Remove(pane);
        }

        internal void RemoveFloatWindow(FloatWindow floatWindow)
        {
            if (!FloatWindows.Contains(floatWindow))
                return;

            FloatWindows.Remove(floatWindow);
            if (FloatWindows.Count != 0)
                return;

            ParentForm?.Focus();
        }

        public void SetPaneIndex(DockPane pane, int index)
        {
            int oldIndex = Panes.IndexOf(pane);
            if (oldIndex == -1)
                throw (new ArgumentException(Strings.DockPanel_SetPaneIndex_InvalidPane));

            if (index < 0 || index > Panes.Count - 1)
                if (index != -1)
                    throw (new ArgumentOutOfRangeException(Strings.DockPanel_SetPaneIndex_InvalidIndex));

            if (oldIndex == index)
                return;
            if (oldIndex == Panes.Count - 1 && index == -1)
                return;

            Panes.Remove(pane);
            if (index == -1)
                Panes.Add(pane);
            else if (oldIndex < index)
                Panes.AddAt(pane, index - 1);
            else
                Panes.AddAt(pane, index);
        }

        public void SuspendLayout(bool allWindows)
        {
            FocusManager.SuspendFocusTracking();
            SuspendLayout();
            if (allWindows)
                SuspendMdiClientLayout();
        }

        public void ResumeLayout(bool performLayout, bool allWindows)
        {
            FocusManager.ResumeFocusTracking();
            ResumeLayout(performLayout);
            if (allWindows)
                ResumeMdiClientLayout(performLayout);
        }

        internal Form ParentForm
        {
            get
            {
                if (!IsParentFormValid())
                    throw new InvalidOperationException(Strings.DockPanel_ParentForm_Invalid);

                return GetMdiClientController().ParentForm;
            }
        }

        private bool IsParentFormValid()
        {
            if (DocumentStyle == DocumentStyle.DockingSdi || DocumentStyle == DocumentStyle.DockingWindow)
                return true;

            if (!MdiClientExists)
                GetMdiClientController().RenewMdiClient();

            return (MdiClientExists);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            SetAutoHideWindowParent();
            GetMdiClientController().ParentForm = (this.Parent as Form);
            base.OnParentChanged(e);
        }

        private void SetAutoHideWindowParent()
        {
            Control parent;
            if (DocumentStyle == DocumentStyle.DockingMdi ||
                DocumentStyle == DocumentStyle.SystemMdi)
                parent = this.Parent;
            else
                parent = this;
            if (AutoHideWindow.Parent != parent)
            {
                AutoHideWindow.Parent = parent;
                AutoHideWindow.BringToFront();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
                SetMdiClient();
        }

        private Rectangle SystemMdiClientBounds
        {
            get
            {
                if (!IsParentFormValid() || !Visible)
                    return Rectangle.Empty;

                Rectangle rect = ParentForm.RectangleToClient(RectangleToScreen(DocumentWindowBounds));
                return rect;
            }
        }

        public Rectangle DocumentWindowBounds
        {
            get
            {
                Rectangle rectDocumentBounds = DisplayRectangle;
                if (DockWindows[DockState.DockLeft].Visible)
                {
                    rectDocumentBounds.X += DockWindows[DockState.DockLeft].Width;
                    rectDocumentBounds.Width -= DockWindows[DockState.DockLeft].Width;
                }
                if (DockWindows[DockState.DockRight].Visible)
                    rectDocumentBounds.Width -= DockWindows[DockState.DockRight].Width;
                if (DockWindows[DockState.DockTop].Visible)
                {
                    rectDocumentBounds.Y += DockWindows[DockState.DockTop].Height;
                    rectDocumentBounds.Height -= DockWindows[DockState.DockTop].Height;
                }
                if (DockWindows[DockState.DockBottom].Visible)
                    rectDocumentBounds.Height -= DockWindows[DockState.DockBottom].Height;

                return rectDocumentBounds;

            }
        }

        private PaintEventHandler m_dummyControlPaintEventHandler;
        private void InvalidateWindowRegion()
        {
            if (DesignMode)
                return;

            if (m_dummyControlPaintEventHandler == null)
                m_dummyControlPaintEventHandler = DummyControl_Paint;

            DummyControl.Paint += m_dummyControlPaintEventHandler;
            DummyControl.Invalidate();
        }

        void DummyControl_Paint(object sender, PaintEventArgs e)
        {
            DummyControl.Paint -= m_dummyControlPaintEventHandler;
            UpdateWindowRegion();
        }

        private void UpdateWindowRegion()
        {
            if (this.DocumentStyle == DocumentStyle.DockingMdi)
                UpdateWindowRegion_ClipContent();
            else if (this.DocumentStyle == DocumentStyle.DockingSdi ||
                this.DocumentStyle == DocumentStyle.DockingWindow)
                UpdateWindowRegion_FullDocumentArea();
            else if (this.DocumentStyle == DocumentStyle.SystemMdi)
                UpdateWindowRegion_EmptyDocumentArea();
        }

        private void UpdateWindowRegion_FullDocumentArea()
        {
            SetRegion(null);
        }

        private void UpdateWindowRegion_EmptyDocumentArea()
        {
            Rectangle rect = DocumentWindowBounds;
            SetRegion(new[] { rect });
        }

        private void UpdateWindowRegion_ClipContent()
        {
            int count = 0;
            foreach (DockPane pane in this.Panes)
            {
                if (!pane.Visible || pane.DockState != DockState.Document)
                    continue;

                count++;
            }

            if (count == 0)
            {
                SetRegion(null);
                return;
            }

            Rectangle[] rects = new Rectangle[count];
            int i = 0;
            foreach (DockPane pane in this.Panes)
            {
                if (!pane.Visible || pane.DockState != DockState.Document)
                    continue;

                rects[i] = RectangleToClient(pane.RectangleToScreen(pane.ContentRectangle));
                i++;
            }

            SetRegion(rects);
        }

        private Rectangle[] m_clipRects;
        private void SetRegion(Rectangle[] clipRects)
        {
            if (!IsClipRectsChanged(clipRects))
                return;

            m_clipRects = clipRects;

            if (m_clipRects == null || m_clipRects.GetLength(0) == 0)
                Region = null;
            else
            {
                Region region = new Region(new Rectangle(0, 0, this.Width, this.Height));
                foreach (Rectangle rect in m_clipRects)
                    region.Exclude(rect);
                Region?.Dispose();

                Region = region;
            }
        }

        private bool IsClipRectsChanged(Rectangle[] clipRects)
        {
            if (clipRects == null && m_clipRects == null)
                return false;
            else if ((clipRects == null) != (m_clipRects == null))
                return true;

            foreach (Rectangle rect in clipRects)
            {
                bool matched = false;
                foreach (Rectangle rect2 in m_clipRects)
                {
                    if (rect == rect2)
                    {
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                    return true;
            }

            foreach (Rectangle rect2 in m_clipRects)
            {
                bool matched = false;
                foreach (Rectangle rect in clipRects)
                {
                    if (rect == rect2)
                    {
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                    return true;
            }
            return false;
        }

        private static readonly object ActiveAutoHideContentChangedEvent = new object();
        [LocalizedCategory("Category_DockingNotification")]
        [LocalizedDescription("DockPanel_ActiveAutoHideContentChanged_Description")]
        public event EventHandler ActiveAutoHideContentChanged
        {
            add => Events.AddHandler(ActiveAutoHideContentChangedEvent, value);
            remove => Events.RemoveHandler(ActiveAutoHideContentChangedEvent, value);
        }
        protected virtual void OnActiveAutoHideContentChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[ActiveAutoHideContentChangedEvent];
            handler?.Invoke(this, e);
        }
        private void m_autoHideWindow_ActiveContentChanged(object sender, EventArgs e)
        {
            OnActiveAutoHideContentChanged(e);
        }


        private static readonly object ContentAddedEvent = new object();
        [LocalizedCategory("Category_DockingNotification")]
        [LocalizedDescription("DockPanel_ContentAdded_Description")]
        public event EventHandler<DockContentEventArgs> ContentAdded
        {
            add => Events.AddHandler(ContentAddedEvent, value);
            remove => Events.RemoveHandler(ContentAddedEvent, value);
        }
        protected virtual void OnContentAdded(DockContentEventArgs e)
        {
            EventHandler<DockContentEventArgs> handler = (EventHandler<DockContentEventArgs>)Events[ContentAddedEvent];
            handler?.Invoke(this, e);
        }

        private static readonly object ContentRemovedEvent = new object();
        [LocalizedCategory("Category_DockingNotification")]
        [LocalizedDescription("DockPanel_ContentRemoved_Description")]
        public event EventHandler<DockContentEventArgs> ContentRemoved
        {
            add => Events.AddHandler(ContentRemovedEvent, value);
            remove => Events.RemoveHandler(ContentRemovedEvent, value);
        }
        protected virtual void OnContentRemoved(DockContentEventArgs e)
        {
            EventHandler<DockContentEventArgs> handler = (EventHandler<DockContentEventArgs>)Events[ContentRemovedEvent];
            handler?.Invoke(this, e);
        }

        internal void ResetDockWindows()
        {
            if (m_autoHideWindow == null)
            {
                return;
            }

            var old = DockWindows;
            LoadDockWindows();
            foreach (var dockWindow in old)
            {
                Controls.Remove(dockWindow);
                dockWindow.Dispose();
            }
        }

        internal void LoadDockWindows()
        {
            DockWindows = new DockWindowCollection(this);
            foreach (var dockWindow in DockWindows)
            {
                Controls.Add(dockWindow);
            }
        }

        public void ResetAutoHideStripWindow()
        {
            var old = m_autoHideWindow;
            m_autoHideWindow = Theme.Extender.AutoHideWindowFactory.CreateAutoHideWindow(this);
            m_autoHideWindow.Visible = false;
            SetAutoHideWindowParent();

            old.Visible = false;
            old.Parent = null;
            old.Dispose();
        }
    }
}
