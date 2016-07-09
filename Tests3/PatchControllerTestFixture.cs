using NUnit.Framework;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class PatchControllerConfig2TestFixture
    {
        [Test]
        public void Basic()
        {
            PatchController.Reset();
            Assert.IsFalse(PatchController.EnableHighDpi);
        }
    }
}
