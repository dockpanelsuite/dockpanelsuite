using Microsoft.Win32;
using NUnit.Framework;
using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Tests
{
    [TestFixture]
    public class PatchControllerTestFixture
    {
        /// <summary>
        /// Test default values.
        /// </summary>
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
            Assert.IsFalse(PatchController.EnableActiveXFix);
            Assert.IsTrue(PatchController.EnableDisplayingPaneFix);
            Assert.IsTrue(PatchController.EnableActiveControlFix);
            Assert.IsTrue(PatchController.EnableFloatSplitterFix);
            Assert.IsTrue(PatchController.EnableActivateOnDockFix);
            Assert.IsTrue(PatchController.EnableSelectClosestOnClose);
            Assert.IsFalse(PatchController.EnablePerScreenDpi);
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

            Environment.SetEnvironmentVariable("DPS_EnableActiveXFix", "true");
            Assert.IsTrue(PatchController.EnableActiveXFix);
            Environment.SetEnvironmentVariable("DPS_EnableActiveXFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableDisplayingPaneFix", "false");
            Assert.IsFalse(PatchController.EnableDisplayingPaneFix);
            Environment.SetEnvironmentVariable("DPS_EnableDisplayingPaneFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableActiveControlFix", "false");
            Assert.IsFalse(PatchController.EnableActiveControlFix);
            Environment.SetEnvironmentVariable("DPS_EnableActiveControlFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableFloatSplitterFix", "false");
            Assert.IsFalse(PatchController.EnableFloatSplitterFix);
            Environment.SetEnvironmentVariable("DPS_EnableFloatSplitterFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableActivateOnDockFix", "false");
            Assert.IsFalse(PatchController.EnableActivateOnDockFix);
            Environment.SetEnvironmentVariable("DPS_EnableActivateOnDockFix", null);

            Environment.SetEnvironmentVariable("DPS_EnableSelectClosestOnClose", "false");
            Assert.IsFalse(PatchController.EnableSelectClosestOnClose);
            Environment.SetEnvironmentVariable("DPS_EnableSelectClosestOnClose", null);

            Environment.SetEnvironmentVariable("DPS_EnablePerScreenDpi", "true");
            Assert.IsTrue(PatchController.EnablePerScreenDpi);
            Environment.SetEnvironmentVariable("DPS_EnablePerScreenDpi", null);

            PatchController.Reset();
            Assert.IsTrue(PatchController.EnableHighDpi);
            Assert.IsTrue(PatchController.EnableContentOrderFix);
            Assert.IsTrue(PatchController.EnableFontInheritanceFix);
            Assert.IsTrue(PatchController.EnableMainWindowFocusLostFix);
            Assert.IsTrue(PatchController.EnableMemoryLeakFix);
            Assert.IsTrue(PatchController.EnableNestedDisposalFix);
            Assert.IsFalse(PatchController.EnableActiveXFix);
            Assert.IsTrue(PatchController.EnableDisplayingPaneFix);
            Assert.IsTrue(PatchController.EnableActiveControlFix);
            Assert.IsTrue(PatchController.EnableFloatSplitterFix);
            Assert.IsTrue(PatchController.EnableActivateOnDockFix);
            Assert.IsTrue(PatchController.EnableSelectClosestOnClose);
            Assert.IsFalse(PatchController.EnablePerScreenDpi);
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
            key.SetValue("EnableActiveXFix", "true", RegistryValueKind.String);
            key.SetValue("EnableDisplayingPaneFix", "false", RegistryValueKind.String);
            key.SetValue("EnableActiveControlFix", "false", RegistryValueKind.String);
            key.SetValue("EnableFloatSplitterFix", "false", RegistryValueKind.String);
            key.SetValue("EnableActivateOnDockFix", "false", RegistryValueKind.String);
            key.SetValue("EnableSelectClosestOnClose", "false", RegistryValueKind.String);
            key.SetValue("EnablePerScreenDpi", "true", RegistryValueKind.String);

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
            Assert.IsFalse(PatchController.EnableActiveXFix);
            Assert.IsFalse(PatchController.EnableDisplayingPaneFix);
            Assert.IsFalse(PatchController.EnableActiveControlFix);
            Assert.IsFalse(PatchController.EnableFloatSplitterFix);
            Assert.IsFalse(PatchController.EnableActivateOnDockFix);
            Assert.IsFalse(PatchController.EnableSelectClosestOnClose);
            Assert.IsFalse(PatchController.EnablePerScreenDpi);
        }
    }
}
