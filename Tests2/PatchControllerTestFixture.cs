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
        }
    }
}
