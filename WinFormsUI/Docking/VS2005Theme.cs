using System;
using WeifenLuo.WinFormsUI.Docking.Skins;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Visual Studio 2005 theme (default theme).
    /// </summary>
    public class VS2005Theme : ThemeBase
    {
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
            
            Measures.SplitterSize = 4;
            dockPanel.Extender.DockPaneCaptionFactory = null;
            dockPanel.Extender.AutoHideStripFactory = null;
            dockPanel.Extender.AutoHideWindowFactory = null;
            dockPanel.Extender.DockPaneStripFactory = null;
            dockPanel.Extender.DockPaneSplitterControlFactory = null;
            dockPanel.Extender.DockWindowFactory = null;
            dockPanel.SkinStyle = Style.VisualStudio2005;
        }
    }
}