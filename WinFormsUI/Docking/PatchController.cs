using Microsoft.Win32;
using System;
using System.Configuration;
using WeifenLuo.WinFormsUI.Docking.Configuration;

namespace WeifenLuo.WinFormsUI.Docking
{
    public static class PatchController
    {
        public static bool? EnableAll { get; set; }

        private static bool? _highDpi;

        public static bool EnableHighDpiSupport
        {
            get
            {
                if (_highDpi != null)
                {
                    return _highDpi.Value;
                }

                if (EnableAll != null)
                {
                    return (_highDpi = EnableAll).Value;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return (_highDpi = section.EnableAll).Value;
                    }

                    return (_highDpi = section.EnableHighDpi).Value;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableHighDpi");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return (_highDpi = enable).Value;
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
                                return (_highDpi = enable).Value;
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
                                return (_highDpi = enable).Value;
                            }
                        }
                    }
                }

                return (_highDpi = true).Value;
            }

            set
            {
                _highDpi = value;
            }
        }

        private static bool? _memoryLeakFix;

        public static bool EnableMemoryLeakFix
        {
            get
            {
                if (_memoryLeakFix != null)
                {
                    return _memoryLeakFix.Value;
                }

                if (EnableAll != null)
                {
                    return (_memoryLeakFix = EnableAll).Value;
                }

                var section = ConfigurationManager.GetSection("dockPanelSuite") as PatchSection;
                if (section != null)
                {
                    if (section.EnableAll != null)
                    {
                        return (_memoryLeakFix = section.EnableAll).Value;
                    }

                    return (_memoryLeakFix = section.EnableHighDpi).Value;
                }

                var environment = Environment.GetEnvironmentVariable("DPS_EnableHighDpi");
                if (!string.IsNullOrEmpty(environment))
                {
                    var enable = false;
                    if (bool.TryParse(environment, out enable))
                    {
                        return (_memoryLeakFix = enable).Value;
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
                                return (_memoryLeakFix = enable).Value;
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
                                return (_memoryLeakFix = enable).Value;
                            }
                        }
                    }
                }

                return (_memoryLeakFix = true).Value;
            }

            set
            {
                _memoryLeakFix = value;
            }
        }
    }
}
