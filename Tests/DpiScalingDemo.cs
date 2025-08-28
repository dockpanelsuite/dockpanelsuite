using System;
using System.Drawing;
using System.Drawing.Imaging;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    /// <summary>
    /// Simple demonstration program showing DPI scaling behavior
    /// </summary>
    public class DpiScalingDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("DPI Scaling Demonstration for DockPanelSuite");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            // Create a test mask
            var testMask = CreateTestMask(16, 16);
            
            // Test with DPI scaling disabled
            Console.WriteLine("Testing with DPI scaling DISABLED:");
            PatchController.EnableAll = false;
            var result1 = ImageServiceHelper.GetImage(testMask, Color.Black, Color.White);
            Console.WriteLine($"Input mask size: {testMask.Width}x{testMask.Height}");
            Console.WriteLine($"Output image size: {result1.Width}x{result1.Height}");
            Console.WriteLine($"Scale factor applied: {(float)result1.Width / testMask.Width:F2}x");
            Console.WriteLine();

            // Test with DPI scaling enabled
            Console.WriteLine("Testing with DPI scaling ENABLED:");
            PatchController.EnableAll = true;
            var result2 = ImageServiceHelper.GetImage(testMask, Color.Black, Color.White);
            Console.WriteLine($"Input mask size: {testMask.Width}x{testMask.Height}");
            Console.WriteLine($"Output image size: {result2.Width}x{result2.Height}");
            Console.WriteLine($"Scale factor applied: {(float)result2.Width / testMask.Width:F2}x");
            Console.WriteLine();

            // Cleanup
            testMask.Dispose();
            result1.Dispose();
            result2.Dispose();
            
            Console.WriteLine("Demo completed successfully!");
            Console.WriteLine();
            Console.WriteLine("Key benefits of the DPI scaling implementation:");
            Console.WriteLine("- Automatically scales UI elements for high-DPI displays");
            Console.WriteLine("- Maintains backward compatibility when disabled");
            Console.WriteLine("- Uses existing PatchController.EnableHighDpi infrastructure");
            Console.WriteLine("- Preserves image quality through proper scaling algorithms");
        }

        private static Bitmap CreateTestMask(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                // Create a simple test pattern
                graphics.Clear(Color.Transparent);
                graphics.FillEllipse(Brushes.Black, 2, 2, width - 4, height - 4);
            }
            return bitmap;
        }
    }
}