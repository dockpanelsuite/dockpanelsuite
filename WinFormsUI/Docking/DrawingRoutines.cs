using System.Drawing;
using System.Drawing.Drawing2D;

namespace WeifenLuo.WinFormsUI.Docking {
    public static class DrawingRoutines {
        public static void SafelyDrawLinearGradient(Rectangle rectangle, Color startColor, Color endColor,
            LinearGradientMode mode, Graphics graphics)
        {
            if (rectangle.Width > 0 && rectangle.Height > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, startColor, endColor, mode))
                {
                    graphics.FillRectangle(brush, rectangle);
                }
            }
        }
    }
}
