using System.Drawing;
using System.Drawing.Imaging;
using NUnit.Framework;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class DpiScalingTestFixture
    {
        [SetUp]
        public void Setup()
        {
            // Reset patch controller to default state
            PatchController.Reset();
        }

        [Test]
        public void DpiScaling_WhenDisabled_UseOriginalSizes()
        {
            // Arrange
            PatchController.EnableAll = false;
            Assert.IsFalse(PatchController.EnableHighDpi);

            var mask = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
            
            // Act
            var result = ImageServiceHelper.GetImage(mask, Color.Black, Color.White);
            
            // Assert
            Assert.AreEqual(16, result.Width);
            Assert.AreEqual(16, result.Height);
            
            mask.Dispose();
            result.Dispose();
        }

        [Test]
        public void DpiScaling_WhenEnabled_UsesScaledSizes()
        {
            // Arrange
            PatchController.EnableAll = true;
            Assert.IsTrue(PatchController.EnableHighDpi);

            var mask = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
            
            // Act
            var result = ImageServiceHelper.GetImage(mask, Color.Black, Color.White);
            
            // Assert
            // When DPI scaling is enabled, the result should be larger or equal to original size
            Assert.GreaterOrEqual(result.Width, 16);
            Assert.GreaterOrEqual(result.Height, 16);
            
            mask.Dispose();
            result.Dispose();
        }

        [Test]
        public void DpiScaling_GetDockIcon_HandlesNullParameters()
        {
            // Arrange
            PatchController.EnableAll = true;
            
            var maskWindow = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
            var layerWindow = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
            var maskBack = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
            var mockPainting = new MockPaintingService();
            
            // Act & Assert - Should not throw
            var result = ImageServiceHelper.GetDockIcon(
                null, null, // maskArrow and layerArrow can be null
                maskWindow, layerWindow, maskBack,
                Color.Blue, mockPainting);
            
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Width, 32);
            Assert.GreaterOrEqual(result.Height, 32);
            
            // Cleanup
            maskWindow.Dispose();
            layerWindow.Dispose();
            maskBack.Dispose();
            result.Dispose();
        }

        /// <summary>
        /// Mock implementation of IPaintingService for testing
        /// </summary>
        private class MockPaintingService : IPaintingService
        {
            public Pen GetPen(Color color, int thickness = 1)
            {
                return new Pen(color, thickness);
            }

            public System.Drawing.SolidBrush GetBrush(Color color)
            {
                return new System.Drawing.SolidBrush(color);
            }

            public void CleanUp()
            {
                // Mock implementation - no cleanup needed
            }
        }
    }
}