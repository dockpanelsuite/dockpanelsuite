using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
	public abstract class ThemeBase : Component, ITheme
	{
	    public abstract void Apply(DockPanel dockPanel);
	}
}
