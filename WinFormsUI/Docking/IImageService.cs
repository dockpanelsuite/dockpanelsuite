using System.Drawing;
using System.Drawing.Imaging;

namespace WeifenLuo.WinFormsUI.Docking
{
    public interface IImageService
    {
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
        Bitmap DockPaneActive_AutoHide { get; }
        Bitmap DockPane_Option { get; }
        Bitmap DockPane_OptionOverflow { get; }
        Bitmap DockPaneActive_Close { get; }
        Bitmap DockPaneActive_Dock { get; }
        Bitmap DockPaneActive_Option { get; }
        Bitmap DockPaneHover_Close { get; }
        Bitmap DockPaneHover_List { get; }
        Bitmap DockPaneHover_Dock { get; }
        Bitmap DockPaneActiveHover_AutoHide { get; }
        Bitmap DockPaneHover_Option { get; }
        Bitmap DockPaneHover_OptionOverflow { get; }
        Bitmap DockPanePress_Close { get; }
        Bitmap DockPanePress_List { get; }
        Bitmap DockPanePress_Dock { get; }
        Bitmap DockPanePress_AutoHide { get; }
        Bitmap DockPanePress_Option { get; }
        Bitmap DockPanePress_OptionOverflow { get; }
        Bitmap DockPaneActiveHover_Close { get; }
        Bitmap DockPaneActiveHover_Dock { get; }
        Bitmap DockPaneActiveHover_Option { get; }
        Image TabActive_Close { get; }
        Image TabInactive_Close { get; }
        Image TabLostFocus_Close { get; }
        Image TabHoverActive_Close { get; }
        Image TabHoverInactive_Close { get; }
        Image TabHoverLostFocus_Close { get; }
        Image TabPressActive_Close { get; }
        Image TabPressInactive_Close { get; }
        Image TabPressLostFocus_Close { get; }
    }

    public static class ImageServiceHelper
    {
        /// <summary>
        /// Gets images for tabs and captions.
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="glyph"></param>
        /// <param name="background"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        public static Bitmap GetImage(Bitmap mask, Color glyph, Color background, Color? border = null)
        {
            var width = mask.Width;
            var height = mask.Height;
            Bitmap input = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(input))
            {
                SolidBrush brush = new SolidBrush(glyph);
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
            {
                SolidBrush brush = new SolidBrush(background);
                SolidBrush brush2 = new SolidBrush(border.Value);
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

        public static Bitmap GetBackground(Color innerBorder, Color outerBorder, int width, IPaintingService painting)
        {
            Bitmap back = new Bitmap(width, width);
            using (Graphics gfx = Graphics.FromImage(back))
            {
                SolidBrush brush = painting.GetBrush(innerBorder);
                SolidBrush brush2 = painting.GetBrush(outerBorder);
                gfx.FillRectangle(brush2, 0, 0, width, width);
                gfx.FillRectangle(brush, 1, 1, width - 2, width - 2);
            }

            return back;
        }

        public static Bitmap GetLayerImage(Color color, int width, IPaintingService painting)
        {
            Bitmap back = new Bitmap(width, width);
            using (Graphics gfx = Graphics.FromImage(back))
            {
                SolidBrush brush = painting.GetBrush(color);
                gfx.FillRectangle(brush, 0, 0, width, width);
            }

            return back;
        }

        /// <summary>
        /// Gets images for docking indicators.
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetDockIcon(Bitmap maskArrow, Bitmap layerArrow, Bitmap maskWindow, Bitmap layerWindow, Bitmap maskBack, Color background, IPaintingService painting, Bitmap maskCore = null, Bitmap layerCore = null, Color? separator = null)
        {
            var width = maskBack.Width;
            var height = maskBack.Height;
            var rect = new Rectangle(0, 0, width, height);
            Bitmap arrowOut = null;

            if (maskArrow != null)
            {
                Bitmap input = layerArrow;
                arrowOut = MaskImages(input, maskArrow);
            }

            Bitmap windowIn = layerWindow;
            Bitmap windowOut = MaskImages(windowIn, maskWindow);

            Bitmap coreOut = null;
            if (layerCore != null)
            {
                var coreIn = layerCore;
                coreOut = MaskImages(coreIn, maskCore);
            }

            Bitmap backIn = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(backIn))
            {
                SolidBrush brush = painting.GetBrush(background);
                gfx.FillRectangle(brush, 0, 0, width, height);
                gfx.DrawImageUnscaled(windowOut, 0, 0);
                windowOut.Dispose();
                if (layerCore != null)
                {
                    gfx.DrawImageUnscaled(coreOut, 0, 0);
                    coreOut.Dispose();
                }

                if (separator != null)
                {
                    Pen sep = painting.GetPen(separator.Value);
                    gfx.DrawRectangle(sep, 0, 0, width - 1, height - 1);
                }
            }

            Bitmap backOut = MaskImages(backIn, maskBack);
            backIn.Dispose();

            using (Graphics gfx = Graphics.FromImage(backOut))
            {
                if (arrowOut != null)
                {
                    gfx.DrawImageUnscaled(arrowOut, 0, 0);
                    arrowOut.Dispose();
                }
            }

            return backOut;
        }

        public static Bitmap MaskImages(Bitmap input, Bitmap maskArrow)
        {
            var width = input.Width;
            var height = input.Height;
            var rect = new Rectangle(0, 0, width, height);
            var arrowOut = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bitsMask = maskArrow.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsInput = input.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsOutput = arrowOut.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                for (int y = 0; y < height; y++)
                {
                    byte* ptrMask = (byte*)bitsMask.Scan0 + y * bitsMask.Stride;
                    byte* ptrInput = (byte*)bitsInput.Scan0 + y * bitsInput.Stride;
                    byte* ptrOutput = (byte*)bitsOutput.Scan0 + y * bitsOutput.Stride;
                    for (int x = 0; x < width; x++)
                    {
                        ptrOutput[4 * x] = ptrInput[4 * x];           // blue
                        ptrOutput[4 * x + 1] = ptrInput[4 * x + 1];   // green
                        ptrOutput[4 * x + 2] = ptrInput[4 * x + 2];   // red
                        ptrOutput[4 * x + 3] = ptrMask[4 * x];        // alpha
                    }
                }
            }

            maskArrow.UnlockBits(bitsMask);
            input.UnlockBits(bitsInput);
            arrowOut.UnlockBits(bitsOutput);
            return arrowOut;
        }

        public static Bitmap GetDockImage(Bitmap icon, Bitmap background)
        {
            var result = new Bitmap(background);
            var offset = (background.Width - icon.Width) / 2;
            using (var gfx = Graphics.FromImage(result))
            {
                gfx.DrawImage(icon, offset, offset);
            }

            return result;
        }

        public static Bitmap CombineFive(Bitmap five, Bitmap bottom, Bitmap center, Bitmap left, Bitmap right, Bitmap top)
        {
            var result = new Bitmap(five);
            var cell = (result.Width - bottom.Width) / 2;
            var offset = (cell - bottom.Width) / 2;
            using (var gfx = Graphics.FromImage(result))
            {
                gfx.DrawImageUnscaled(top, cell, offset);
                gfx.DrawImageUnscaled(center, cell, cell);
                gfx.DrawImageUnscaled(bottom, cell, 2 * cell - offset);
                gfx.DrawImageUnscaled(left, offset, cell);
                gfx.DrawImageUnscaled(right, 2 * cell - offset, cell);
            }

            return result;
        }

        public static Bitmap GetFiveBackground(Bitmap mask, Color innerBorder, Color outerBorder, IPaintingService painting)
        {
            // TODO: calculate points using functions.
            using (var input = GetLayerImage(innerBorder, mask.Width, painting))
            {
                using (var gfx = Graphics.FromImage(input))
                {
                    var pen = painting.GetPen(outerBorder);
                    gfx.DrawLines(pen, new[]
                    {
                        new Point(36, 25),new Point(36, 0),
                        new Point(75, 0), new Point(75, 25)
                    });
                    gfx.DrawLines(pen, new[]
                    {
                        new Point(86, 36), new Point(111, 36),
                        new Point(111, 75), new Point(86, 75)
                    });
                    gfx.DrawLines(pen, new[]
                    {
                        new Point(75, 86), new Point(75, 111),
                        new Point(36, 111), new Point(36, 86)
                    });
                    gfx.DrawLines(pen, new[]
                    {
                        new Point(25, 75), new Point(0, 75),
                        new Point(0, 36), new Point(25, 36)
                    });
                    var pen2 = painting.GetPen(outerBorder, 2);
                    gfx.DrawLine(pen2, new Point(36, 25), new Point(25, 36));
                    gfx.DrawLine(pen2, new Point(75, 25), new Point(86, 36));
                    gfx.DrawLine(pen2, new Point(86, 75), new Point(75, 86));
                    gfx.DrawLine(pen2, new Point(36, 86), new Point(25, 75));
                }

                return MaskImages(input, mask);
            }
        }
    }

}