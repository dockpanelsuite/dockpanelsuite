using System;

namespace WeifenLuo.WinFormsUI.Docking
{
    using System.ComponentModel;

    public partial class DockPanel
    {
        private DockPanelSkin m_dockPanelSkin = VS2005Theme.CreateVisualStudio2005();
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelSkin")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Please use Theme instead.")]
        [Browsable(false)]
        public DockPanelSkin Skin
        {
            get { return m_dockPanelSkin;  }
            set { m_dockPanelSkin = value; }
        }
        
        private ThemeBase m_dockPanelTheme = new VS2005Theme();
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelTheme")]
        public ThemeBase Theme
        {
            get { return m_dockPanelTheme; }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (m_dockPanelTheme.GetType() == value.GetType())
                {
                    return;
                }

                m_dockPanelTheme = value;
                m_dockPanelTheme.Apply(this);
            }
        }
    }
}
