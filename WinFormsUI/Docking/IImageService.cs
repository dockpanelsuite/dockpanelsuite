using System.Drawing;
using System.Drawing.Imaging;

namespace WeifenLuo.WinFormsUI.Docking
{
    public interface IImageService
    {
        Image ActiveTabHover_Close { get; }
        Image ActiveTab_Close { get; }
        Bitmap Dockindicator_PaneDiamond { get; }
        Bitmap Dockindicator_PaneDiamond_Fill { get; }
        Bitmap Dockindicator_PaneDiamond_Hotspot { get; }
        Bitmap DockIndicator_PaneDiamond_HotspotIndex { get; }
        Image DockIndicator_PanelBottom { get; }
        Image DockIndicator_PanelFill { get; }
        Image DockIndicator_PanelLeft { get; }
        Image DockIndicator_PanelRight { get; }
        Image DockIndicator_PanelTop { get; }
        Bitmap DockPane_Close { get; }
        Bitmap DockPane_List { get; }
        Bitmap DockPane_Dock { get; }
        Bitmap DockPane_AutoHide { get; }
        Bitmap DockPane_Option { get; }
        Bitmap DockPane_OptionOverflow { get; }
        Bitmap DockPaneActive_Close { get; }
        Bitmap DockPaneActive_Dock { get; }
        Bitmap DockPaneActive_Option { get; }
        Bitmap DockPaneHover_Close { get; }
        Bitmap DockPaneHover_List { get; }
        Bitmap DockPaneHover_Dock { get; }
        Bitmap DockPaneHover_AutoHide { get; }
        Bitmap DockPaneHover_Option { get; }
        Bitmap DockPaneHover_OptionOverflow { get; }
        Bitmap DockPaneActiveHover_Close { get; }
        Bitmap DockPaneActiveHover_Dock { get; }
        Bitmap DockPaneActiveHover_Option { get; }
        Image InactiveTab_Close { get; }
        Image InactiveTabHover_Close { get; }
        Image LostFocusTabHover_Close { get; }
        Image LostFocusTab_Close { get; }
    }

    public static class ImageServiceHelper
    {
        public static Bitmap GetImage(Bitmap mask, Color glyph, Color background, Color? border = null)
        {
            var width = mask.Width;
            var height = mask.Height;
            Bitmap input = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(input))
            using (SolidBrush brush = new SolidBrush(glyph))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }

            Bitmap output = new Bitmap(input.Width, input.Height, PixelFormat.Format32bppArgb);
            var rect = new Rectangle(0, 0, input.Width, input.Height);
            var bitsMask = mask.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsInput = input.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsOutput = output.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                for (int y = 0; y < input.Height; y++)
                {
                    byte* ptrMask = (byte*)bitsMask.Scan0 + y * bitsMask.Stride;
                    byte* ptrInput = (byte*)bitsInput.Scan0 + y * bitsInput.Stride;
                    byte* ptrOutput = (byte*)bitsOutput.Scan0 + y * bitsOutput.Stride;
                    for (int x = 0; x < input.Width; x++)
                    {
                        ptrOutput[4 * x] = ptrInput[4 * x];           // blue
                        ptrOutput[4 * x + 1] = ptrInput[4 * x + 1];   // green
                        ptrOutput[4 * x + 2] = ptrInput[4 * x + 2];   // red
                        ptrOutput[4 * x + 3] = ptrMask[4 * x];        // alpha
                    }
                }
            }

            mask.UnlockBits(bitsMask);
            input.UnlockBits(bitsInput);
            output.UnlockBits(bitsOutput);
            input.Dispose();

            if (border == null)
            {
                border = background;
            }

            Bitmap back = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(back))
            using (SolidBrush brush = new SolidBrush(background))
            using (SolidBrush brush2 = new SolidBrush(border.Value))
            {
                gfx.FillRectangle(brush2, 0, 0, width, height);
                if (background != border.Value)
                {
                    gfx.FillRectangle(brush, 1, 1, width - 2, height - 2);
                }

                gfx.DrawImageUnscaled(output, 0, 0);
            }

            output.Dispose();
            return back;
        }
    }
}