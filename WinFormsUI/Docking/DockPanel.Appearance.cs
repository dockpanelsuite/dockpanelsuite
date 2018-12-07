namespace WeifenLuo.WinFormsUI.Docking
{
    using System;
    using System.ComponentModel;

    public partial class DockPanel
    {
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelSkin_Description")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Obsolete("Use Theme.Skin instead.")]
        public DockPanelSkin Skin
        {
            get { return null;  }
        }

        private ThemeBase m_dockPanelTheme;

        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelTheme")]
        public ThemeBase Theme
        {
            get { return m_dockPanelTheme; }
            set
            {
                var old = m_dockPanelTheme;
                if (value == null)
                {
                    m_dockPanelTheme = null;
                    return;
                }

                if (m_dockPanelTheme?.GetType() == value.GetType())
                {
                    return;
                }

                m_dockPanelTheme?.CleanUp(this);
                m_dockPanelTheme = value;
                m_dockPanelTheme.ApplyTo(this);
                m_dockPanelTheme.PostApply(this);
                if (old == null)
                { 
                    m_autoHideWindow = m_dockPanelTheme?.Extender.AutoHideWindowFactory.CreateAutoHideWindow(this);
                    m_autoHideWindow.Visible = false;
                    m_autoHideWindow.ActiveContentChanged += m_autoHideWindow_ActiveContentChanged;
                    SetAutoHideWindowParent();
                    LoadDockWindows();
                }
            }
        }
    }
}
