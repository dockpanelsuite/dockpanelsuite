using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class ThemeBase : Component
    {
        private Color _dockBackColor;
        private bool _showAutoHideContentOnHover;

        protected ThemeBase()
        {
            Extender = new DockPanelExtender();
        }

        public DockPanelSkin Skin { get; protected set; }

        public DockPanelColorPalette ColorPalette { get; protected set; }

        public IImageService ImageService { get; protected set; }

        public IPaintingService PaintingService { get; protected set; }

        protected ToolStripRenderer ToolStripRenderer { get; set;}

        private Dictionary<ToolStrip, KeyValuePair<ToolStripRenderMode, ToolStripRenderer>> _stripBefore 
            = new Dictionary<ToolStrip, KeyValuePair<ToolStripRenderMode, ToolStripRenderer>>();

        public void ApplyTo(ToolStrip toolStrip)
        {
            if (toolStrip == null)
                return;

            _stripBefore[toolStrip] = new KeyValuePair<ToolStripRenderMode, ToolStripRenderer>(toolStrip.RenderMode, toolStrip.Renderer);
            toolStrip.Renderer = ToolStripRenderer;

            if (Win32Helper.IsRunningOnMono)
            {
                foreach (var item in toolStrip.Items.OfType<ToolStripDropDownItem>())
                {
                    ItemResetOwnerHack(item);
                }
            }
        }

        private void ItemResetOwnerHack(ToolStripDropDownItem item)
        {
            var oldOwner = item.DropDown.OwnerItem;
            item.DropDown.OwnerItem = null;
            item.DropDown.OwnerItem = oldOwner;

            foreach (var child in item.DropDownItems.OfType<ToolStripDropDownItem>())
            {
                ItemResetOwnerHack(child);
            }
        }

        private KeyValuePair<ToolStripManagerRenderMode, ToolStripRenderer> _managerBefore;

        public void ApplyToToolStripManager()
        {
            _managerBefore = new KeyValuePair<ToolStripManagerRenderMode, ToolStripRenderer>(ToolStripManager.RenderMode, ToolStripManager.Renderer);
        }

        public Measures Measures { get; } = new Measures();

        public bool ShowAutoHideContentOnHover { get; protected set; } = true;

        public void ApplyTo(DockPanel dockPanel)
        {
            if (dockPanel.Panes.Count > 0)
                throw new InvalidOperationException("Before applying themes all panes must be closed.");

            if (dockPanel.FloatWindows.Count > 0)
                throw new InvalidOperationException("Before applying themes all float windows must be closed.");

            if (dockPanel.Contents.Count > 0)
                throw new InvalidOperationException("Before applying themes all dock contents must be closed.");

            if (ColorPalette == null)
            {
                dockPanel.ResetDummy();
            }
            else
            {
                _dockBackColor = dockPanel.DockBackColor;
                dockPanel.DockBackColor = ColorPalette.MainWindowActive.Background;
                dockPanel.SetDummy();
            }

            _showAutoHideContentOnHover = dockPanel.ShowAutoHideContentOnHover;
            dockPanel.ShowAutoHideContentOnHover = ShowAutoHideContentOnHover;
        }

        internal void PostApply(DockPanel dockPanel)
        {
            dockPanel.ResetAutoHideStripControl();
            dockPanel.ResetAutoHideStripWindow();
            dockPanel.ResetDockWindows();
        }

        public virtual void CleanUp(DockPanel dockPanel)
        {
            if (dockPanel != null)
            {
                if (ColorPalette != null)
                {
                    dockPanel.DockBackColor = _dockBackColor;
                }

                dockPanel.ShowAutoHideContentOnHover = _showAutoHideContentOnHover;
            }

            foreach (var item in _stripBefore)
            {
                var strip = item.Key;
                var cache = item.Value;
                if (cache.Key == ToolStripRenderMode.Custom)
                    strip.Renderer = cache.Value;
                else
                    strip.RenderMode = cache.Key;
            }

            _stripBefore.Clear();
            if (_managerBefore.Key == ToolStripManagerRenderMode.Custom)
                ToolStripManager.Renderer = _managerBefore.Value;
            else
                ToolStripManager.RenderMode = _managerBefore.Key;
        }

        public DockPanelExtender Extender { get; private set; }

        public static byte[] Decompress(byte[] fileToDecompress)
        {
            using (MemoryStream originalFileStream = new MemoryStream(fileToDecompress))
            {
                using (MemoryStream decompressedFileStream = new MemoryStream())
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        //Copy the decompression stream into the output file.
                        byte[] buffer = new byte[4096];
                        int numRead;
                        while ((numRead = decompressionStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            decompressedFileStream.Write(buffer, 0, numRead);
                        }

                        return decompressedFileStream.ToArray();
                    }
                }
            }
        }
    }
}
