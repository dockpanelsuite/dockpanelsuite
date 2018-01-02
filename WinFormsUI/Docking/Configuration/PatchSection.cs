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

        [ConfigurationProperty("enableFontInheritanceFix", DefaultValue = true)]
        public bool EnableFontInheritanceFix
        {
            get { return (bool)base["enableFontInheritanceFix"]; }
        }

        [ConfigurationProperty("enableContentOrderFix", DefaultValue = true)]
        public bool EnableContentOrderFix
        {
            get { return (bool)base["enableContentOrderFix"]; }
        }

        [ConfigurationProperty("enableActiveXFix", DefaultValue = false)] // disabled by default to avoid side effect.
        public bool EnableActiveXFix
        {
            get { return (bool)base["enableActiveXFix"]; }
        }

        [ConfigurationProperty("enableDisplayingPaneFix", DefaultValue = true)]
        public bool EnableDisplayingPaneFix
        {
            get { return (bool)base["enableDisplayingPaneFix"]; }
        }

        [ConfigurationProperty("enableActiveControlFix", DefaultValue = true)]
        public bool EnableActiveControlFix
        {
            get { return (bool)base["enableActiveControlFix"]; }
        }

        [ConfigurationProperty("enableFloatSplitterFix", DefaultValue = true)]
        public bool EnableFloatSplitterFix
        {
            get { return (bool)base["enableFloatSplitterFix"]; }
        }

        [ConfigurationProperty("enableActivateOnDockFix", DefaultValue = true)]
        public bool EnableActivateOnDockFix
        {
            get { return (bool)base["enableActivateOnDockFix"]; }
        }
    }
}
