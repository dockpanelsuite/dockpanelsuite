using NUnit.Framework;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class PatchControllerConfigTestFixture
    {
        /// <summary>
        /// All items are disabled one by one in app.config.
        /// </summary>
        [Test]
        public void Basic()
        {
            PatchController.Reset();
            Assert.IsFalse(PatchController.EnableHighDpi);
            Assert.IsFalse(PatchController.EnableContentOrderFix);
            Assert.IsFalse(PatchController.EnableFontInheritanceFix);
            Assert.IsFalse(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsFalse(PatchController.EnableMemoryLeakFix);
            Assert.IsFalse(PatchController.EnableNestedDisposalFix);
            Assert.IsTrue(PatchController.EnableActiveXFix);
            Assert.IsFalse(PatchController.EnableDisplayingPaneFix);
            Assert.IsFalse(PatchController.EnableActiveControlFix);
            Assert.IsFalse(PatchController.EnableFloatSplitterFix);
            Assert.IsFalse(PatchController.EnableActivateOnDockFix);
            Assert.IsFalse(PatchController.EnableSelectClosestOnClose);
            Assert.IsTrue(PatchController.EnablePerScreenDpi);
        }
    }
}
