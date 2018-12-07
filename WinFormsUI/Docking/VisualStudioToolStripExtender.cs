using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ProvideProperty("EnableVSStyle", typeof(ToolStrip))]
    public partial class VisualStudioToolStripExtender : Component, IExtenderProvider
    {
        private class ToolStripProperties
        {
            private VsVersion version = VsVersion.Unknown;
            private readonly ToolStrip strip;
            private readonly Dictionary<ToolStripItem, string> menuText = new Dictionary<ToolStripItem, string>();
            

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null) throw new ArgumentNullException(nameof(toolstrip));
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

        public VisualStudioToolStripExtender()
        {
            InitializeComponent();
        }

        public VisualStudioToolStripExtender(IContainer container)
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

        [DefaultValue(false)]
        public VsVersion GetStyle(ToolStrip strip)
        {
            if (strips.ContainsKey(strip))
                return strips[strip].VsVersion;

            return VsVersion.Unknown;
        }

        public void SetStyle(ToolStrip strip, VsVersion version, ThemeBase theme)
        {
            ToolStripProperties properties = null;

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip) { VsVersion = version };
                strips.Add(strip, properties);
            }
            else
            {
                properties = strips[strip];
            }

            if (theme == null)
            {
                if (DefaultRenderer != null)
                    strip.Renderer = DefaultRenderer;
            }
            else
            {
                theme.ApplyTo(strip);
            }
            properties.VsVersion = version;
        }

        public enum VsVersion
        {
            Unknown,
            Vs2003,
            Vs2005,
            Vs2008,
            Vs2010,
            Vs2012,
            Vs2013,
            Vs2015
        }
    }
}
