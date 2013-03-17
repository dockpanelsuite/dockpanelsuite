using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.Docking.Skins;

namespace DockSample.Customization
{
    /// <summary>
    /// Visual Studio 2005 theme (default theme).
    /// </summary>
    public class VS2005Theme : ITheme
    {
        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public void Apply(DockPanel dockPanel)
        {
            Measures.SplitterSize = 4;
            dockPanel.Extender.AutoHideStripFactory = null;
            dockPanel.Extender.DockPaneCaptionFactory = null;
            dockPanel.Extender.DockPaneStripFactory = null;
            dockPanel.Extender.DockPaneSplitterControlFactory = null;
            dockPanel.Extender.DockWindowFactory = null;
            dockPanel.SkinStyle = Style.VisualStudio2005;
        }
    }
}