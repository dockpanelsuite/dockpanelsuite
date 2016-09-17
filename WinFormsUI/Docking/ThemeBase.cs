using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class ThemeBase : Component
    {
        private Color _dockBackColor;
        private bool _showAutoHideContentOnHover;

        protected ThemeBase()
        {
            Extender = new DockPanelExtender();
        }

        public DockPanelSkin Skin { get; protected set; }

        public DockPanelColorPalette ColorPalette { get; protected set; }

        public IImageService ImageService { get; protected set; }

        public IPaintingService PaintingService { get; protected set; }

        public ToolStripRenderer ToolStripRenderer { get; protected set;}

        public Measures Measures { get; } = new Measures();

        public bool ShowAutoHideContentOnHover { get; protected set; } = true;

        public void Apply(DockPanel dockPanel)
        {
            if (dockPanel.Panes.Count > 0)
                throw new InvalidOperationException("Before applying themes all panes must be closed.");

            if (dockPanel.FloatWindows.Count > 0)
                throw new InvalidOperationException("Before applying themes all float windows must be closed.");

            if (dockPanel.Contents.Count > 0)
                throw new InvalidOperationException("Before applying themes all dock contents must be closed.");

            if (ColorPalette == null)
            {
                dockPanel.ResetDummy();
            }
            else
            {
                _dockBackColor = dockPanel.DockBackColor;
                dockPanel.DockBackColor = ColorPalette.MainWindowActive.Background;
                dockPanel.SetDummy();
            }

            _showAutoHideContentOnHover = dockPanel.ShowAutoHideContentOnHover;
            dockPanel.ShowAutoHideContentOnHover = ShowAutoHideContentOnHover;
        }

        internal void PostApply(DockPanel dockPanel)
        {
            dockPanel.ResetAutoHideStripControl();
            dockPanel.ResetAutoHideStripWindow();
            dockPanel.ResetDockWindows();
        }

        public virtual void CleanUp(DockPanel dockPanel)
        {
            if (ColorPalette != null)
            {
                dockPanel.DockBackColor = _dockBackColor;
            }

            dockPanel.ShowAutoHideContentOnHover = _showAutoHideContentOnHover;
        }

        public DockPanelExtender Extender { get; private set; }
    }
}
