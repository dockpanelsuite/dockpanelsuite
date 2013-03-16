using System.Drawing;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Dock window of Visual Studio 2012 Light theme.
    /// </summary>
	[ToolboxItem(false)]
	public class VS2012LightDockWindow : DockWindow
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="VS2012LightDockWindow"/> class.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        /// <param name="dockState">State of the dock.</param>
	    public VS2012LightDockWindow(DockPanel dockPanel, DockState dockState) : base(dockPanel, dockState)
	    {
		}

		public override Rectangle DisplayingRectangle
		{
			get
			{
				Rectangle rect = ClientRectangle;
				// if DockWindow is document, exclude the border
				// exclude the splitter
				if (DockState == DockState.DockLeft)
					rect.Width -= Measures.SplitterSize;
				else if (DockState == DockState.DockRight)
				{
					rect.X += Measures.SplitterSize;
					rect.Width -= Measures.SplitterSize;
				}
				else if (DockState == DockState.DockTop)
					rect.Height -= Measures.SplitterSize;
				else if (DockState == DockState.DockBottom)
				{
					rect.Y += Measures.SplitterSize;
					rect.Height -= Measures.SplitterSize;
				}

				return rect;
			}
		}
    }
}
