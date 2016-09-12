using System;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class ThemeBase : Component
    {
        protected ThemeBase()
        {
            Extender = new DockPanelExtender();
        }

        public DockPanelSkin Skin { get; protected set; }
        
        public DockPanelColorPalette ColorPalette { get; protected set; }

        public IImageService ImageService { get; protected set; }

        public IPaintingService PaintingService { get; protected set; }

        public Measures Measures { get; } = new Measures();

        public void Apply(DockPanel dockPanel)
        {
            if (dockPanel.Panes.Count > 0)
                throw new InvalidOperationException("Before applying themes all panes must be closed.");

            if (dockPanel.FloatWindows.Count > 0)
                throw new InvalidOperationException("Before applying themes all float windows must be closed.");

            if (dockPanel.Contents.Count > 0)
                throw new InvalidOperationException("Before applying themes all dock contents must be closed.");

            if (ColorPalette == null)
                dockPanel.ResetDockBackColor();
            else
                dockPanel.DockBackColor = ColorPalette.MainWindowActive.Background;
        }

        internal void PostApply(DockPanel dockPanel)
        {
            dockPanel.ResetAutoHideStripControl();
            dockPanel.ResetAutoHideStripWindow();
            dockPanel.ResetDockWindows();
        }

        public virtual void CleanUp(DockPanel dockPanel)
        {
        }

        public DockPanelExtender Extender { get; private set; }
    }
}
