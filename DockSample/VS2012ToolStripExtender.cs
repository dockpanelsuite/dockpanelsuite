using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace DockSample
{
    [ProvideProperty("EnableVS2012Style", typeof(ToolStrip))]
    public partial class VS2012ToolStripExtender : Component, IExtenderProvider
    {
        private class ToolStripProperties
        {
            private bool enabled = false;
            private readonly ToolStrip strip;
            private readonly Dictionary<ToolStripItem, string> menuText = new Dictionary<ToolStripItem, string>();
            

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null) throw new ArgumentNullException("toolstrip");
                strip = toolstrip;

                if (strip is MenuStrip)
                    SaveMenuStripText();
            }

            public bool EnableVS2012Style 
            {
                get { return enabled; }
                set
                {
                    enabled = value;
                    UpdateMenuText(enabled);
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

        public VS2012ToolStripExtender()
        {
            InitializeComponent();
        }

        public VS2012ToolStripExtender(IContainer container)
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

        [DefaultValue(false)]
        public bool GetEnableVS2012Style(ToolStrip strip)
        {
            if (strips.ContainsKey(strip))
                return strips[strip].EnableVS2012Style;

            return false;
        }

        public void SetEnableVS2012Style(ToolStrip strip, bool enable)
        {
            var apply = false;
            ToolStripProperties properties = null;

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip) { EnableVS2012Style = enable };
                strips.Add(strip, properties);
                apply = true;
            }
            else
            {
                properties = strips[strip];
                apply = properties.EnableVS2012Style != enable;
            }

            if (apply)
            {
                //ToolStripManager.Renderer = enable ? VS2012Renderer : DefaultRenderer;
                strip.Renderer = enable ? VS2012Renderer : DefaultRenderer;
                properties.EnableVS2012Style = enable;
            }
        }
    }
}
