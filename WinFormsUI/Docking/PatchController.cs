using Microsoft.Win32;
using System;
using System.Configuration;
using WeifenLuo.WinFormsUI.Docking.Configuration;

namespace WeifenLuo.WinFormsUI.Docking
{
    public static class PatchController
    {
        public static bool? EnableAll { private get; set; }

        public static void Reset()
        {
            EnableAll = _highDpi = _memoryLeakFix 
                = _nestedDisposalFix = _focusLostFix = _contentOrderFix
                = _fontInheritanceFix = _activeXFix = _displayingPaneFix
                = _activeControlFix = _floatSplitterFix = _activateOnDockFix = null;
        }

#region Copy this section to create new option, and then comment it to show what needs to be modified.
        //*
        private static bool? _highDpi;

        public static bool? EnableHighDpi
        {
            get
            {
                if (_highDpi != null)
                {
                    return _highDpi;
                }

                if (EnableAll != null)
                {
                    return _highDpi = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _highDpi = section.EnableAll;
                    }

                    return _highDpi = section.EnableHighDpi;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableHighDpi");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _highDpi = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableHighDpi");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _highDpi = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableHighDpi");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _highDpi = enable;
                            }
                        }
                    }
                }

                return _highDpi = true;
            }

            set
            {
                _highDpi = value;
            }
        }
        // */
#endregion

        private static bool? _memoryLeakFix;

        public static bool? EnableMemoryLeakFix
        {
            get
            {
                if (_memoryLeakFix != null)
                {
                    return _memoryLeakFix;
                }

                if (EnableAll != null)
                {
                    return _memoryLeakFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _memoryLeakFix = section.EnableAll;
                    }

                    return _memoryLeakFix = section.EnableMemoryLeakFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableMemoryLeakFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _memoryLeakFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableMemoryLeakFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _memoryLeakFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableMemoryLeakFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _memoryLeakFix = enable;
                            }
                        }
                    }
                }

                return _memoryLeakFix = true;
            }

            set
            {
                _memoryLeakFix = value;
            }
        }

        private static bool? _focusLostFix;

        public static bool? EnableMainWindowFocusLostFix
        {
            get
            {
                if (_focusLostFix != null)
                {
                    return _focusLostFix;
                }

                if (EnableAll != null)
                {
                    return _focusLostFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _focusLostFix = section.EnableAll;
                    }

                    return _focusLostFix = section.EnableMainWindowFocusLostFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableMainWindowFocusLostFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _focusLostFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableMainWindowFocusLostFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _focusLostFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableMainWindowFocusLostFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _focusLostFix = enable;
                            }
                        }
                    }
                }

                return _focusLostFix = true;
            }

            set
            {
                _focusLostFix = value;
            }
        }

        private static bool? _nestedDisposalFix;

        public static bool? EnableNestedDisposalFix
        {
            get
            {
                if (_nestedDisposalFix != null)
                {
                    return _nestedDisposalFix;
                }

                if (EnableAll != null)
                {
                    return _nestedDisposalFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _nestedDisposalFix = section.EnableAll;
                    }

                    return _nestedDisposalFix = section.EnableNestedDisposalFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableNestedDisposalFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _nestedDisposalFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableNestedDisposalFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _nestedDisposalFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableNestedDisposalFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _nestedDisposalFix = enable;
                            }
                        }
                    }
                }

                return _nestedDisposalFix = true;
            }

            set
            {
                _focusLostFix = value;
            }
        }

        private static bool? _fontInheritanceFix;

        public static bool? EnableFontInheritanceFix
        {
            get
            {
                if (_fontInheritanceFix != null)
                {
                    return _fontInheritanceFix;
                }

                if (EnableAll != null)
                {
                    return _fontInheritanceFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _fontInheritanceFix = section.EnableAll;
                    }

                    return _fontInheritanceFix = section.EnableFontInheritanceFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableFontInheritanceFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _fontInheritanceFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableFontInheritanceFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _fontInheritanceFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableFontInheritanceFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _fontInheritanceFix = enable;
                            }
                        }
                    }
                }

                return _fontInheritanceFix = true;
            }

            set
            {
                _fontInheritanceFix = value;
            }
        }

        private static bool? _contentOrderFix;

        public static bool? EnableContentOrderFix
        {
            get
            {
                if (_contentOrderFix != null)
                {
                    return _contentOrderFix;
                }

                if (EnableAll != null)
                {
                    return _contentOrderFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _contentOrderFix = section.EnableAll;
                    }

                    return _contentOrderFix = section.EnableContentOrderFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableContentOrderFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _contentOrderFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableContentOrderFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _contentOrderFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableContentOrderFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _contentOrderFix = enable;
                            }
                        }
                    }
                }

                return _contentOrderFix = true;
            }

            set
            {
                _contentOrderFix = value;
            }
        }

        private static bool? _activeXFix;

        public static bool? EnableActiveXFix
        {
            get
            {
                if (_activeXFix != null)
                {
                    return _activeXFix;
                }

                if (EnableAll != null)
                {
                    return _activeXFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _activeXFix = section.EnableAll;
                    }

                    return _activeXFix = section.EnableActiveXFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableActiveXFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _activeXFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActiveXFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activeXFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActiveXFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activeXFix = enable;
                            }
                        }
                    }
                }

                return _activeXFix = false; // not enabled by default as it has side effect.
            }

            set
            {
                _activeXFix = value;
            }
        }

        private static bool? _displayingPaneFix;

        public static bool? EnableDisplayingPaneFix
        {
            get
            {
                if (_displayingPaneFix != null)
                {
                    return _displayingPaneFix;
                }

                if (EnableAll != null)
                {
                    return _displayingPaneFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _displayingPaneFix = section.EnableAll;
                    }

                    return _displayingPaneFix = section.EnableDisplayingPaneFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableDisplayingPaneFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _displayingPaneFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableDisplayingPaneFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _displayingPaneFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableDisplayingPaneFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _displayingPaneFix = enable;
                            }
                        }
                    }
                }

                return _displayingPaneFix = true;
            }

            set
            {
                _displayingPaneFix = value;
            }
        }

        private static bool? _activeControlFix;

        public static bool? EnableActiveControlFix
        {
            get
            {
                if (_activeControlFix != null)
                {
                    return _activeControlFix;
                }

                if (EnableAll != null)
                {
                    return _activeControlFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _activeControlFix = section.EnableAll;
                    }

                    return _activeControlFix = section.EnableActiveControlFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableActiveControlFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _activeControlFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActiveControlFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activeControlFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActiveControlFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activeControlFix = enable;
                            }
                        }
                    }
                }

                return _activeControlFix = true;
            }

            set
            {
                _activeControlFix = value;
            }
        }

        private static bool? _floatSplitterFix;

        public static bool? EnableFloatSplitterFix
        {
            get
            {
                if (_floatSplitterFix != null)
                {
                    return _floatSplitterFix;
                }

                if (EnableAll != null)
                {
                    return _floatSplitterFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _floatSplitterFix = section.EnableAll;
                    }

                    return _floatSplitterFix = section.EnableFloatSplitterFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableFloatSplitterFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _floatSplitterFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableFloatSplitterFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _floatSplitterFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableFloatSplitterFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _floatSplitterFix = enable;
                            }
                        }
                    }
                }

                return _floatSplitterFix = true;
            }

            set
            {
                _floatSplitterFix = value;
            }
        }

        private static bool? _activateOnDockFix;

        public static bool? EnableActivateOnDockFix
        {
            get
            {
                if (_activateOnDockFix != null)
                {
                    return _activateOnDockFix;
                }

                if (EnableAll != null)
                {
                    return _activateOnDockFix = EnableAll;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return _activateOnDockFix = section.EnableAll;
                    }

                    return _activateOnDockFix = section.EnableActivateOnDockFix;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableActivateOnDockFix");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return _activateOnDockFix = enable;
                    }
                }

                {
                    var key = Registry.CurrentUser.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActivateOnDockFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activateOnDockFix = enable;
                            }
                        }
                    }
                }

                {
                    var key = Registry.LocalMachine.OpenSubKey(@"Software\DockPanelSuite");
                    if (key != null)
                    {
                        var pair = key.GetValue("EnableActivateOnDockFix");
                        if (pair != null)
                        {
                            var enable = false;
                            if (bool.TryParse(pair.ToString(), out enable))
                            {
                                return _activateOnDockFix = enable;
                            }
                        }
                    }
                }

                return _activateOnDockFix = true;
            }

            set
            {
                _activateOnDockFix = value;
            }
        }
    }
}
