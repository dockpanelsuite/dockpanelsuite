using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Dock window of Visual Studio 2012 Light theme.
    /// </summary>
    [ToolboxItem(false)]
    internal class VS2012DockWindow : DockWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VS2012DockWindow"/> class.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        /// <param name="dockState">State of the dock.</param>
        public VS2012DockWindow(DockPanel dockPanel, DockState dockState) : base(dockPanel, dockState)
        {
        }

        public override Rectangle DisplayingRectangle
        {
            get
            {
                Rectangle rect = ClientRectangle;
                if (DockState == DockState.DockLeft)
                    rect.Width -= DockPanel.Theme.Measures.SplitterSize;
                else if (DockState == DockState.DockRight)
                {
                    rect.X += DockPanel.Theme.Measures.SplitterSize;
                    rect.Width -= DockPanel.Theme.Measures.SplitterSize;
                }
                else if (DockState == DockState.DockTop)
                    rect.Height -= DockPanel.Theme.Measures.SplitterSize;
                else if (DockState == DockState.DockBottom)
                {
                    rect.Y += DockPanel.Theme.Measures.SplitterSize;
                    rect.Height -= DockPanel.Theme.Measures.SplitterSize;
                }

                return rect;
            }
        }
    }
}
