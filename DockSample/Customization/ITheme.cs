using WeifenLuo.WinFormsUI.Docking;

namespace DockSample.Customization
{
    /// <summary>
    /// DockPanel Suite theme interface.
    /// </summary>
    public interface ITheme
    {
        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        void Apply(DockPanel dockPanel);
    }
    

}