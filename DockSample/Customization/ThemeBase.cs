using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;

namespace DockSample.Customization
{
	public abstract class ThemeBase : Component, ITheme
	{
	    public abstract void Apply(DockPanel dockPanel);
	}
}
