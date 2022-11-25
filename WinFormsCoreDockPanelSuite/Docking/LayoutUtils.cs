using System.Drawing;

namespace WinFormsCoreDockPanelSuite.Docking
{
    public static class LayoutUtils
    {
        public static bool IsZeroWidthOrHeight(Rectangle rectangle)
        {
            return (rectangle.Width == 0 || rectangle.Height == 0);
        }
    }
}
