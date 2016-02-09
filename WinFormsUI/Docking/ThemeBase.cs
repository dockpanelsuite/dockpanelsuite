using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class ThemeBase : Component, ITheme
    {
        public DockPanelSkin Skin { get; protected set; }

        public abstract void Apply(DockPanel dockPanel);
    }
}
