using Microsoft.Win32;
using NUnit.Framework;
using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class PatchControllerTestFixture
    {
        [Test]
        public void Basic()
        {
            PatchController.Reset();
            Assert.IsTrue(PatchController.EnableHighDpi);
        }

        [Test]
        public void EnvironmentVariableFalse()
        { 
            PatchController.Reset();
            Environment.SetEnvironmentVariable("DPS_EnableHighDpi", "false");
            Assert.IsFalse(PatchController.EnableHighDpi);
            Environment.SetEnvironmentVariable("DPS_EnableHighDpi", null);

            PatchController.Reset();
            Assert.IsTrue(PatchController.EnableHighDpi);
        }

        [Test]
        public void RegistryValueFalse()
        {
            PatchController.Reset();
            var key = Registry.CurrentUser.CreateSubKey("Software\\DockPanelSuite");
            Assert.IsNotNull(key);
            key.SetValue("EnableHighDpi", "false", RegistryValueKind.String);
            Assert.IsFalse(PatchController.EnableHighDpi);
            Registry.CurrentUser.DeleteSubKeyTree("Software\\DockPanelSuite");
        }

        [Test]
        public void DisableAll()
        {
            PatchController.Reset();
            PatchController.EnableAll = false;
            Assert.IsFalse(PatchController.EnableHighDpi);
        }
    }
}
