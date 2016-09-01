using System;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2012;
    using WeifenLuo.WinFormsUI.ThemeVS2012.Dark;

    /// <summary>
    /// Visual Studio 2012 Dark theme.
    /// </summary>
    public class VS2012DarkTheme : ThemeBase
    {
        public VS2012DarkTheme()
        {
            Skin = CreateVisualStudio2012Dark();
            ImageService = new ImageService();
        }

        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public override void Apply(DockPanel dockPanel)
        {
            if (dockPanel == null)
            {
                throw new NullReferenceException("dockPanel");
            }

            Measures.SplitterSize = 6;
            dockPanel.Extender.DockPaneCaptionFactory = new VS2012DockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new VS2012AutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = new VS2012AutoHideWindowFactory();
            dockPanel.Extender.DockPaneStripFactory = new VS2012DockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = new VS2012DockPaneSplitterControlFactory();
            dockPanel.Extender.DockWindowSplitterControlFactory = new VS2012DockWindowSplitterControlFactory();
            dockPanel.Extender.DockWindowFactory = new VS2012DockWindowFactory();
            dockPanel.Extender.PaneIndicatorFactory = new VS2012PaneIndicatorFactory();
            dockPanel.Extender.PanelIndicatorFactory = new VS2012PanelIndicatorFactory();
            dockPanel.Extender.DockOutlineFactory = new VS2012DockOutlineFactory();
        }

        public static DockPanelSkin CreateVisualStudio2012Dark()
        {
            var skin = new DockPanelSkin();

            skin.ColorPalette.MainWindowActive.Background = Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30);

            skin.ColorPalette.AutoHideStripDefault.Background = Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30);
            skin.ColorPalette.AutoHideStripDefault.Border = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.AutoHideStripDefault.Text = Color.FromArgb(0xFF, 0xD0, 0xD0, 0xD0);

            skin.ColorPalette.AutoHideStripHovered.Background = Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30);
            skin.ColorPalette.AutoHideStripHovered.Border = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.AutoHideStripHovered.Text = Color.FromArgb(0xFF, 0x00, 0x97, 0xFB);

            skin.ColorPalette.TabSelectedActive.Background = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.TabSelectedActive.Button = Color.FromArgb(0xFF, 0xD0, 0xE6, 0xF5);
            skin.ColorPalette.TabSelectedActive.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.TabSelectedInactive.Background = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.TabSelectedInactive.Button = Color.FromArgb(0xFF, 0x6D, 0x6D, 0x70);
            skin.ColorPalette.TabSelectedInactive.Text = Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1);

            skin.ColorPalette.TabUnselected.Text = Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1);

            skin.ColorPalette.TabUnselectedHovered.Background = Color.FromArgb(0xFF, 0x1C, 0x97, 0xEA);
            skin.ColorPalette.TabUnselectedHovered.Button = Color.FromArgb(0xFF, 0xD0, 0xE6, 0xF5);
            skin.ColorPalette.TabUnselectedHovered.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.ToolWindowCaptionActive.Background = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            skin.ColorPalette.ToolWindowCaptionActive.Button = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            skin.ColorPalette.ToolWindowCaptionActive.Grip = Color.FromArgb(0xFF, 0x59, 0xA8, 0xDE);
            skin.ColorPalette.ToolWindowCaptionActive.Text = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);

            skin.ColorPalette.ToolWindowCaptionInactive.Background = Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30);
            skin.ColorPalette.ToolWindowCaptionInactive.Button = Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1);
            skin.ColorPalette.ToolWindowCaptionInactive.Grip = Color.FromArgb(0xFF, 0x46, 0x46, 0x4A);
            skin.ColorPalette.ToolWindowCaptionInactive.Text = Color.FromArgb(0xFF, 0xD0, 0xD0, 0xD0);

            skin.ColorPalette.ToolWindowTabSelectedActive.Background = Color.FromArgb(0xFF, 0x25, 0x25, 0x26);
            skin.ColorPalette.ToolWindowTabSelectedActive.Separator = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.ToolWindowTabSelectedActive.Text = Color.FromArgb(0xFF, 0x00, 0x97, 0xFB);

            skin.ColorPalette.ToolWindowTabSelectedInactive.Background = Color.FromArgb(0xFF, 0x25, 0x25, 0x26);
            skin.ColorPalette.ToolWindowTabSelectedInactive.Separator = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.ToolWindowTabSelectedInactive.Text = Color.FromArgb(0xFF, 0x00, 0x97, 0xFB);

            skin.ColorPalette.ToolWindowTabUnselected.Separator = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.ToolWindowTabUnselected.Text = Color.FromArgb(0xFF, 0xD0, 0xD0, 0xD0);

            skin.ColorPalette.ToolWindowTabUnselectedHovered.Background = Color.FromArgb(0xFF, 0x3E, 0x3E, 0x40);
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Separator = Color.FromArgb(0xFF, 0x3F, 0x3F, 0x46);
            skin.ColorPalette.ToolWindowTabUnselectedHovered.Text = Color.FromArgb(0xFF, 0x55, 0xAA, 0xFF);

            return skin;
        }
    }
}