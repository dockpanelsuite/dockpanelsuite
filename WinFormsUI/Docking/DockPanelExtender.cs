using System;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

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
            DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel);
        }

        public interface IPaneIndicatorFactory
        {
            DockPanel.IPaneIndicator CreatePaneIndicator(ThemeBase theme);
        }

        public interface IPanelIndicatorFactory
        {
            DockPanel.IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme);
        }

        public interface IDockOutlineFactory
        {
            DockOutlineBase CreateDockOutline();
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

        #region DefaultDockPaneCaptionFactory

        private class DefaultDockPaneCaptionFactory : IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new VS2005DockPaneCaption(pane);
            }
        }

        #endregion

        #region DefaultDockPaneTabStripFactory

        private class DefaultDockPaneStripFactory : IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new VS2005DockPaneStrip(pane);
            }
        }

        #endregion

        #region DefaultAutoHideStripFactory

        private class DefaultAutoHideStripFactory : IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new VS2005AutoHideStrip(panel);
            }
        }

        #endregion

        #region DefaultAutoHideWindowFactory

        public class DefaultAutoHideWindowFactory : IAutoHideWindowFactory
        {
            public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
            {
                return new DockPanel.DefaultAutoHideWindowControl(panel);
            }
        }

        #endregion

        public class DefaultPaneIndicatorFactory : IPaneIndicatorFactory
        {
            public DockPanel.IPaneIndicator CreatePaneIndicator(ThemeBase theme)
            {
                return new DockPanel.DefaultPaneIndicator();
            }
        }

        public class DefaultPanelIndicatorFactory : IPanelIndicatorFactory
        {
            public DockPanel.IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme)
            {
                return new DockPanel.DefaultPanelIndicator(style);
            }
        }

        public class DefaultDockOutlineFactory : IDockOutlineFactory
        {
            public DockOutlineBase CreateDockOutline()
            {
                return new DockPanel.DefaultDockOutline();
            }
        }

        public DockPanelExtender(DockPanel dockPanel)
        {
            m_dockPanel = dockPanel;
        }

        private DockPanel m_dockPanel;

        private DockPanel DockPanel
        {
            get { return m_dockPanel; }
        }

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
                if (DockPanel.Panes.Count > 0)
                    throw new InvalidOperationException();

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
                if (DockPanel.Panes.Count > 0)
                {
                    throw new InvalidOperationException();
                }

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
                if (DockPanel.FloatWindows.Count > 0)
                    throw new InvalidOperationException();

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
                if (m_dockPaneCaptionFactory == null)
                    m_dockPaneCaptionFactory = new DefaultDockPaneCaptionFactory();

                return m_dockPaneCaptionFactory;
            }
            set
            {
                if (DockPanel.Panes.Count > 0)
                    throw new InvalidOperationException();

                m_dockPaneCaptionFactory = value;
            }
        }

        private IDockPaneStripFactory m_dockPaneStripFactory = null;

        public IDockPaneStripFactory DockPaneStripFactory
        {
            get
            {
                if (m_dockPaneStripFactory == null)
                    m_dockPaneStripFactory = new DefaultDockPaneStripFactory();

                return m_dockPaneStripFactory;
            }
            set
            {
                if (DockPanel.Contents.Count > 0)
                    throw new InvalidOperationException();

                m_dockPaneStripFactory = value;
            }
        }

        private IAutoHideStripFactory m_autoHideStripFactory = null;

        public IAutoHideStripFactory AutoHideStripFactory
        {
            get
            {
                if (m_autoHideStripFactory == null)
                    m_autoHideStripFactory = new DefaultAutoHideStripFactory();

                return m_autoHideStripFactory;
            }
            set
            {
                if (DockPanel.Contents.Count > 0)
                    throw new InvalidOperationException();

                if (m_autoHideStripFactory == value)
                    return;

                m_autoHideStripFactory = value;
            }
        }

        private IAutoHideWindowFactory m_autoHideWindowFactory;
        
        public IAutoHideWindowFactory AutoHideWindowFactory
        {
            get { return m_autoHideWindowFactory ?? (m_autoHideWindowFactory = new DefaultAutoHideWindowFactory()); }
            set
            {
                if (DockPanel.Contents.Count > 0)
                {
                    throw new InvalidOperationException();
                }

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
            get { return m_PaneIndicatorFactory ?? (m_PaneIndicatorFactory = new DefaultPaneIndicatorFactory()); }
            set { m_PaneIndicatorFactory = value; }
        }

        private IPanelIndicatorFactory m_PanelIndicatorFactory;

        public IPanelIndicatorFactory PanelIndicatorFactory
        {
            get { return m_PanelIndicatorFactory ?? (m_PanelIndicatorFactory = new DefaultPanelIndicatorFactory()); }
            set { m_PanelIndicatorFactory = value; }
        }

        private IDockOutlineFactory m_DockOutlineFactory;

        public IDockOutlineFactory DockOutlineFactory
        {
            get { return m_DockOutlineFactory ?? (m_DockOutlineFactory = new DefaultDockOutlineFactory()); }
            set { m_DockOutlineFactory = value; }
        }
    }
}
