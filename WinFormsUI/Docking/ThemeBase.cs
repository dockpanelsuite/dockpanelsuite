using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class ThemeBase : Component
    {
        public DockPanelSkin Skin { get; protected set; }

        public IImageService ImageService { get; protected set; }

        public IPaintingService PaintingService { get; protected set; }

        public Measures Measures { get; } = new Measures();

        public abstract void Apply(DockPanel dockPanel);

        public virtual void CleanUp(DockPanel dockPanel)
        {
        }

        public DockPanelExtender Extender { get; protected set; }
    }
}
