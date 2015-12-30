using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace DockSample
{
    [ProvideProperty("EnableVS2012Style", typeof(ToolStrip))]
    public partial class VSToolStripExtender : Component, IExtenderProvider
    {
        private class ToolStripProperties
        {
            private VsVersion version = VsVersion.Unkown;
            private readonly ToolStrip strip;
            private readonly Dictionary<ToolStripItem, string> menuText = new Dictionary<ToolStripItem, string>();
            

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null) throw new ArgumentNullException("toolstrip");
                strip = toolstrip;

                if (strip is MenuStrip)
                    SaveMenuStripText();
            }

            public VsVersion VsVersion 
            {
                get { return this.version; }
                set
                {
                    this.version = value;
                    UpdateMenuText(this.version == VsVersion.Vs2012 || this.version == VsVersion.Vs2013);
                }
            }

            private void SaveMenuStripText()
            {
                foreach (ToolStripItem item in strip.Items)
                    menuText.Add(item, item.Text);
            }

            public void UpdateMenuText(bool caps)
            {
                foreach (ToolStripItem item in menuText.Keys)
                {
                    var text = menuText[item];
                    item.Text = caps ? text.ToUpper() : text;
                }
            }
        }

        private readonly Dictionary<ToolStrip, ToolStripProperties> strips = new Dictionary<ToolStrip, ToolStripProperties>();

        public VSToolStripExtender()
        {
            InitializeComponent();
        }

        public VSToolStripExtender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is ToolStrip;
        }

        #endregion

        public ToolStripRenderer DefaultRenderer { get; set; }

        public ToolStripRenderer VS2012Renderer { get; set; }

        public ToolStripRenderer VS2013Renderer { get; set; }

        [DefaultValue(false)]
        public VsVersion GetStyle(ToolStrip strip)
        {
            if (strips.ContainsKey(strip))
                return strips[strip].VsVersion;

            return VsVersion.Unkown;
        }

        public void SetStyle(ToolStrip strip, VsVersion version)
        {
            var apply = false;
            ToolStripProperties properties = null;

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip) { VsVersion = version };
                strips.Add(strip, properties);
                apply = true;
            }
            else
            {
                properties = strips[strip];
                apply = properties.VsVersion != version;
            }

            if (apply)
            {
                strip.Renderer = version == VsVersion.Vs2013
                                     ? this.VS2013Renderer
                                     : version == VsVersion.Vs2012 ? VS2012Renderer : DefaultRenderer;
                properties.VsVersion = version;
            }
        }

        public enum VsVersion
        {
            Unkown,
            Vs2003,
            Vs2005,
            Vs2012,
            Vs2013
        }
    }
}
