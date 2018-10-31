using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using static WeifenLuo.WinFormsUI.Docking.DockPanel;
using static WeifenLuo.WinFormsUI.Docking.DockPanel.DockDragHandler;

namespace WeifenLuo.WinFormsUI.Docking
{
    public sealed class DockPanelExtender
    {
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneFactory
        {
            DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show);

            [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
            DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show);

            DockPane CreateDockPane(IDockContent content, DockPane previousPane, DockAlignment alignment,
                                    double proportion, bool show);

            [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
            DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show);
        }

        public interface IDockPaneSplitterControlFactory
        {
            DockPane.SplitterControlBase CreateSplitterControl(DockPane pane);
        }
        
        public interface IWindowSplitterControlFactory
        {
            SplitterBase CreateSplitterControl(ISplitterHost host);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IFloatWindowFactory
        {
            FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane);
            FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds);
        }

        public interface IDockWindowFactory
        {
            DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneCaptionFactory
        {
            DockPaneCaptionBase CreateDockPaneCaption(DockPane pane);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneStripFactory
        {
            DockPaneStripBase CreateDockPaneStrip(DockPane pane);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IAutoHideStripFactory
        {
            AutoHideStripBase CreateAutoHideStrip(DockPanel panel);
        }

        public interface IAutoHideWindowFactory
        {
            AutoHideWindowControl CreateAutoHideWindow(DockPanel panel);
        }

        public interface IPaneIndicatorFactory
        {
            IPaneIndicator CreatePaneIndicator(ThemeBase theme);
        }

        public interface IPanelIndicatorFactory
        {
            IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme);
        }

        public interface IDockOutlineFactory
        {
            DockOutlineBase CreateDockOutline();
        }

        public interface IDockIndicatorFactory
        {
            DockIndicator CreateDockIndicator(DockDragHandler dockDragHandler);
        }

        #region DefaultDockPaneFactory

        private class DefaultDockPaneFactory : IDockPaneFactory
        {
            public DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show)
            {
                return new DockPane(content, visibleState, show);
            }

            public DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show)
            {
                return new DockPane(content, floatWindow, show);
            }

            public DockPane CreateDockPane(IDockContent content, DockPane prevPane, DockAlignment alignment,
                                           double proportion, bool show)
            {
                return new DockPane(content, prevPane, alignment, proportion, show);
            }

            public DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
            {
                return new DockPane(content, floatWindowBounds, show);
            }
        }

        #endregion

        #region DefaultDockPaneSplitterControlFactory

        private class DefaultDockPaneSplitterControlFactory : IDockPaneSplitterControlFactory
        {
            public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
            {
                return new DockPane.DefaultSplitterControl(pane);
            }
        }

        #endregion
        
        #region DefaultWindowSplitterControlFactory

        private class DefaultWindowSplitterControlFactory : IWindowSplitterControlFactory
        {
            public SplitterBase CreateSplitterControl(ISplitterHost host)
            {
                return new DockWindow.DefaultSplitterControl(host);
            }
        }

        #endregion

        #region DefaultFloatWindowFactory

        private class DefaultFloatWindowFactory : IFloatWindowFactory
        {
            public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
            {
                return new FloatWindow(dockPanel, pane);
            }

            public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
            {
                return new FloatWindow(dockPanel, pane, bounds);
            }
        }

        #endregion

        #region DefaultDockWindowFactory

        private class DefaultDockWindowFactory : IDockWindowFactory
        {
            public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
            {
                return new DefaultDockWindow(dockPanel, dockState);
            }
        }

        #endregion

        private IDockPaneFactory m_dockPaneFactory = null;

        public IDockPaneFactory DockPaneFactory
        {
            get
            {
                if (m_dockPaneFactory == null)
                    m_dockPaneFactory = new DefaultDockPaneFactory();

                return m_dockPaneFactory;
            }
            set
            {
                m_dockPaneFactory = value;
            }
        }

        private IDockPaneSplitterControlFactory m_dockPaneSplitterControlFactory;

        public IDockPaneSplitterControlFactory DockPaneSplitterControlFactory
        {
            get
            {
                return m_dockPaneSplitterControlFactory ??
                       (m_dockPaneSplitterControlFactory = new DefaultDockPaneSplitterControlFactory());
            }

            set
            {
                m_dockPaneSplitterControlFactory = value;
            }
        }
        
        private IWindowSplitterControlFactory m_dockWindowSplitterControlFactory;

        public IWindowSplitterControlFactory WindowSplitterControlFactory
        {
            get
            {
                return m_dockWindowSplitterControlFactory ??
                       (m_dockWindowSplitterControlFactory = new DefaultWindowSplitterControlFactory());
            }

            set
            {
                m_dockWindowSplitterControlFactory = value;
            }
        }

        private IFloatWindowFactory m_floatWindowFactory = null;

        public IFloatWindowFactory FloatWindowFactory
        {
            get
            {
                if (m_floatWindowFactory == null)
                    m_floatWindowFactory = new DefaultFloatWindowFactory();

                return m_floatWindowFactory;
            }
            set
            {
                m_floatWindowFactory = value;
            }
        }

        private IDockWindowFactory m_dockWindowFactory;

        public IDockWindowFactory DockWindowFactory
        {
            get { return m_dockWindowFactory ?? (m_dockWindowFactory = new DefaultDockWindowFactory()); }
            set
            {
                m_dockWindowFactory = value;
            }
        }

        private IDockPaneCaptionFactory m_dockPaneCaptionFactory = null;

        public IDockPaneCaptionFactory DockPaneCaptionFactory
        {
            get
            {
                return m_dockPaneCaptionFactory;
            }
            set
            {
                m_dockPaneCaptionFactory = value;
            }
        }

        private IDockPaneStripFactory m_dockPaneStripFactory = null;

        public IDockPaneStripFactory DockPaneStripFactory
        {
            get
            {
                return m_dockPaneStripFactory;
            }
            set
            {
                m_dockPaneStripFactory = value;
            }
        }

        private IAutoHideStripFactory m_autoHideStripFactory = null;

        public IAutoHideStripFactory AutoHideStripFactory
        {
            get
            {
                return m_autoHideStripFactory;
            }
            set
            {
                if (m_autoHideStripFactory == value)
                    return;

                m_autoHideStripFactory = value;
            }
        }

        private IAutoHideWindowFactory m_autoHideWindowFactory;
        
        public IAutoHideWindowFactory AutoHideWindowFactory
        {
            get { return m_autoHideWindowFactory; }
            set
            {
                if (m_autoHideWindowFactory == value)
                {
                    return;
                }

                m_autoHideWindowFactory = value;
            }
        }

        private IPaneIndicatorFactory m_PaneIndicatorFactory;

        public IPaneIndicatorFactory PaneIndicatorFactory
        {
            get { return m_PaneIndicatorFactory; }
            set { m_PaneIndicatorFactory = value; }
        }

        private IPanelIndicatorFactory m_PanelIndicatorFactory;

        public IPanelIndicatorFactory PanelIndicatorFactory
        {
            get { return m_PanelIndicatorFactory; }
            set { m_PanelIndicatorFactory = value; }
        }

        private IDockOutlineFactory m_DockOutlineFactory;

        public IDockOutlineFactory DockOutlineFactory
        {
            get { return m_DockOutlineFactory; }
            set { m_DockOutlineFactory = value; }
        }

        private IDockIndicatorFactory m_DockIndicatorFactory;

        public IDockIndicatorFactory DockIndicatorFactory
        {
            get { return m_DockIndicatorFactory; }
            set { m_DockIndicatorFactory = value; }
        }
    }
}
