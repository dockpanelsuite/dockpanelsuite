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
            Assert.IsTrue(PatchController.EnableContentOrderFix);
            Assert.IsTrue(PatchController.EnableFontInheritanceFix);
            Assert.IsTrue(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsTrue(PatchController.EnableMemoryLeakFix);
            Assert.IsTrue(PatchController.EnableNestedDisposalFix);
        }

        [Test]
        public void EnvironmentVariableFalse()
        { 
            PatchController.Reset();
            Environment.SetEnvironmentVariable("DPS_EnableHighDpi", "false");
            Assert.IsFalse(PatchController.EnableHighDpi);
            Environment.SetEnvironmentVariable("DPS_EnableHighDpi", null);

            Environment.SetEnvironmentVariable("DPS_EnableContentOrderFix", "false");
            Assert.IsFalse(PatchController.EnableContentOrderFix);
            Environment.SetEnvironmentVariable("DPS_EnableContentOrderFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableFontInheritanceFix", "false");
            Assert.IsFalse(PatchController.EnableFontInheritanceFix);
            Environment.SetEnvironmentVariable("DPS_EnableFontInheritanceFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableMainWindowFocusLostFix", "false");
            Assert.IsFalse(PatchController.EnableMainWindowFocusLostFix);
            Environment.SetEnvironmentVariable("DPS_EnableMainWindowFocusLostFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableMemoryLeakFix", "false");
            Assert.IsFalse(PatchController.EnableMemoryLeakFix);
            Environment.SetEnvironmentVariable("DPS_EnableMemoryLeakFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableNestedDisposalFix", "false");
            Assert.IsFalse(PatchController.EnableNestedDisposalFix);
            Environment.SetEnvironmentVariable("DPS_EnableNestedDisposalFix", null);

            PatchController.Reset();
            Assert.IsTrue(PatchController.EnableHighDpi);
            Assert.IsTrue(PatchController.EnableContentOrderFix);
            Assert.IsTrue(PatchController.EnableFontInheritanceFix);
            Assert.IsTrue(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsTrue(PatchController.EnableMemoryLeakFix);
            Assert.IsTrue(PatchController.EnableNestedDisposalFix);
        }

        [Test]
        public void RegistryValueFalse()
        {
            PatchController.Reset();
            var key = Registry.CurrentUser.CreateSubKey("Software\\DockPanelSuite");
            Assert.IsNotNull(key);
            key.SetValue("EnableHighDpi", "false", RegistryValueKind.String);
            key.SetValue("EnableContentOrderFix", "false", RegistryValueKind.String);
            key.SetValue("EnableFontInheritanceFix", "false", RegistryValueKind.String);
            key.SetValue("EnableMainWindowFocusLostFix", "false", RegistryValueKind.String);
            key.SetValue("EnableMemoryLeakFix", "false", RegistryValueKind.String);
            key.SetValue("EnableNestedDisposalFix", "false", RegistryValueKind.String);

            Assert.IsFalse(PatchController.EnableHighDpi);
            Assert.IsFalse(PatchController.EnableContentOrderFix);
            Assert.IsFalse(PatchController.EnableFontInheritanceFix);
            Assert.IsFalse(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsFalse(PatchController.EnableMemoryLeakFix);
            Assert.IsFalse(PatchController.EnableNestedDisposalFix);
            Registry.CurrentUser.DeleteSubKeyTree("Software\\DockPanelSuite");
        }

        [Test]
        public void DisableAll()
        {
            PatchController.Reset();
            PatchController.EnableAll = false;
            Assert.IsFalse(PatchController.EnableHighDpi);
            Assert.IsFalse(PatchController.EnableContentOrderFix);
            Assert.IsFalse(PatchController.EnableFontInheritanceFix);
            Assert.IsFalse(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsFalse(PatchController.EnableMemoryLeakFix);
            Assert.IsFalse(PatchController.EnableNestedDisposalFix);
        }
    }
}
