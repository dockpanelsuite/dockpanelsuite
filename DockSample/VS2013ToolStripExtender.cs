using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DockSample
{
    [ProvideProperty("EnableVS2013Style", typeof (ToolStrip))]
    public partial class Vs2013ToolStripExtender : Component, IExtenderProvider
    {
        private readonly Dictionary<ToolStrip, ToolStripProperties> strips =
            new Dictionary<ToolStrip, ToolStripProperties>();

        public Vs2013ToolStripExtender()
        {
            InitializeComponent();
        }

        public Vs2013ToolStripExtender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ToolStripRenderer DefaultRenderer { get; set; }
        public ToolStripRenderer Vs2013Renderer { get; set; }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is ToolStrip;
        }

        #endregion

        [DefaultValue(false)]
        public bool GetEnableVs2013Style(ToolStrip strip)
        {
            if (strips.ContainsKey(strip))
                return strips[strip].EnableVs2013Style;

            return false;
        }

        public void SetEnableVs2013Style(ToolStrip strip, bool enable)
        {
            var apply = false;
            ToolStripProperties properties = null;

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip) {EnableVs2013Style = enable};
                strips.Add(strip, properties);
                apply = true;
            }
            else
            {
                properties = strips[strip];
                apply = properties.EnableVs2013Style != enable;
            }

            if (apply)
            {
                //ToolStripManager.Renderer = enable ? VS2013Renderer : DefaultRenderer;
                strip.Renderer = enable ? Vs2013Renderer : DefaultRenderer;
                properties.EnableVs2013Style = enable;
            }
        }

        private class ToolStripProperties
        {
            private readonly Dictionary<ToolStripItem, string> _menuText = new Dictionary<ToolStripItem, string>();
            private readonly ToolStrip _strip;
            private bool _enabled;

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null) throw new ArgumentNullException("toolstrip");
                _strip = toolstrip;

                if (_strip is MenuStrip)
                    SaveMenuStripText();
            }

            public bool EnableVs2013Style
            {
                get { return _enabled; }
                set
                {
                    _enabled = value;
                    //UpdateMenuText(enabled);
                    UpdateMenuText(false);
                }
            }

            private void SaveMenuStripText()
            {
                foreach (ToolStripItem item in _strip.Items)
                    _menuText.Add(item, item.Text);
            }

            public void UpdateMenuText(bool caps)
            {
                foreach (var item in _menuText.Keys)
                {
                    var text = _menuText[item];
                    item.Text = caps ? text.ToUpper() : text;
                }
            }
        }
    }
}