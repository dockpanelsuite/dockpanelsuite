using NUnit.Framework;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class PatchControllerConfigTestFixture
    {
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
        }
    }
}
