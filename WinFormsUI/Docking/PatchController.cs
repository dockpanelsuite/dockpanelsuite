using Microsoft.Win32;
using System;
using System.Configuration;
using WeifenLuo.WinFormsUI.Docking.Configuration;

namespace WeifenLuo.WinFormsUI.Docking
{
    public static class PatchController
    {
        public static bool? EnableAll { private get; set; }

        private static bool? _highDpi;

        internal static void Reset()
        {
            EnableAll = _highDpi = _memoryLeakFix = _nestedDisposalFix = _focusLostFix = null;
        }

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
    }
}
