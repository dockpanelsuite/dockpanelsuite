using System.Configuration;

namespace WeifenLuo.WinFormsUI.Docking.Configuration
{
    public class PatchSection : ConfigurationSection
    {
        [ConfigurationProperty("enableAll", DefaultValue = null)]
        public bool? EnableAll
        {
            get { return (bool?)base["enableAll"]; }
        }

        [ConfigurationProperty("enableHighDpi", DefaultValue = true)]
        public bool EnableHighDpi
        {
            get { return (bool)base["enableHighDpi"]; }
        }

        [ConfigurationProperty("enableMemoryLeakFix", DefaultValue = true)]
        public bool EnableMemoryLeakFix
        {
            get { return (bool)base["enableMemoryLeakFix"]; }
        }

        [ConfigurationProperty("enableMainWindowFocusLostFix", DefaultValue = true)]
        public bool EnableMainWindowFocusLostFix
        {
            get { return (bool)base["enableMainWindowFocusLostFix"]; }
        }

        [ConfigurationProperty("enableNestedDisposalFix", DefaultValue = true)]
        public bool EnableNestedDisposalFix
        {
            get { return (bool)base["enableNestedDisposalFix"]; }
        }
    }
}
