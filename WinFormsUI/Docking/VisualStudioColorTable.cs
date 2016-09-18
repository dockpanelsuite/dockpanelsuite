using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class VisualStudioColorTable : ProfessionalColorTable
    {
        private DockPanelColorPalette _palette;

        public VisualStudioColorTable(DockPanelColorPalette palette)
        {
            _palette = palette;
        }

        public Color ButtonCheckedHoveredBorder
        {
            get { return _palette.CommandBarToolbarButtonCheckedHovered.Border; }
        }

        public Color ButtonCheckedHoveredBackground
        {
            get { return _palette.CommandBarMenuPopupHovered.CheckmarkBackground; }
        }

        public Color ButtonCheckedBorder
        {
            get { return _palette.CommandBarToolbarButtonChecked.Border; }
        }

        public override Color ButtonCheckedGradientBegin
        {
            get { return _palette.CommandBarToolbarButtonChecked.Background; }
        }

        public override Color ButtonCheckedGradientMiddle
        {
            get { return _palette.CommandBarToolbarButtonChecked.Background; }
        }

        public override Color ButtonCheckedGradientEnd
        {
            get { return _palette.CommandBarToolbarButtonChecked.Background; }
        }

        //public override Color ButtonCheckedHighlight
        //{
        //    get { return _palette.CommandBarMenuPopupDefault.CheckmarkBackground; }
        //}

        //public override Color ButtonCheckedHighlightBorder
        //{
        //    get { return _palette.CommandBarMenuPopupDefault.Checkmark; }
        //}

        public override Color CheckBackground
        {
            get { return _palette.CommandBarMenuPopupDefault.CheckmarkBackground; }
        }

        public override Color CheckSelectedBackground
        {
            get { return _palette.CommandBarMenuPopupHovered.CheckmarkBackground; }
        }

        public override Color CheckPressedBackground
        {
            get { return _palette.CommandBarMenuPopupHovered.CheckmarkBackground; }
        }

        //public override Color ButtonPressedHighlight
        //{
        //    get { return ButtonPressedGradientMiddle; }
        //}

        //public override Color ButtonPressedHighlightBorder
        //{
        //    get { return ButtonPressedBorder; }
        //}

        public override Color ButtonPressedBorder
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Border; }
        }

        public override Color ButtonPressedGradientBegin
        {
            get { return _palette.CommandBarToolbarButtonPressed.Background; }
        }

        public override Color ButtonPressedGradientMiddle
        {
            get { return _palette.CommandBarToolbarButtonPressed.Background; }
        }

        public override Color ButtonPressedGradientEnd
        {
            get { return _palette.CommandBarToolbarButtonPressed.Background; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return _palette.CommandBarMenuPopupDefault.BackgroundTop; }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return _palette.CommandBarMenuPopupDefault.BackgroundTop; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return _palette.CommandBarMenuPopupDefault.BackgroundTop; }
        }

        //public override Color ButtonSelectedHighlight
        //{
        //    get { return Color.Red; }
        //}
        //public override Color ButtonSelectedHighlightBorder
        //{
        //    get { return ButtonSelectedBorder; }
        //}
        
        public override Color ButtonSelectedBorder
        {
            get { return _palette.CommandBarToolbarButtonChecked.Border; }
        }

        public override Color ButtonSelectedGradientBegin
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Background; }
        }

        public override Color ButtonSelectedGradientMiddle
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Background; }
        }

        public override Color ButtonSelectedGradientEnd
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Background; }
        }

        public override Color MenuItemSelected
        {
            get { return _palette.CommandBarMenuPopupHovered.ItemBackground; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Background; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Background; }
        }

        public override Color GripDark
        {
            get { return _palette.CommandBarToolbarDefault.Grip; }
        }

        public override Color GripLight
        {
            get { return _palette.CommandBarToolbarDefault.Grip; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return _palette.CommandBarMenuPopupDefault.IconBackground; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return _palette.CommandBarMenuPopupDefault.IconBackground; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return _palette.CommandBarMenuPopupDefault.IconBackground; }
        }

        //public override Color ImageMarginRevealedGradientBegin
        //{
        //    get { return Color.FromArgb(255, 231, 232, 236); }
        //}

        //public override Color ImageMarginRevealedGradientMiddle
        //{
        //    get { return Color.FromArgb(255, 231, 232, 236); }
        //}

        //public override Color ImageMarginRevealedGradientEnd
        //{
        //    get { return Color.FromArgb(255, 231, 232, 236); }
        //}

        public override Color MenuStripGradientBegin
        {
            get { return _palette.CommandBarMenuDefault.Background; }
        }

        public override Color MenuStripGradientEnd
        {
            get { return _palette.CommandBarMenuDefault.Background; }
        }

        public override Color MenuItemBorder
        {
            get { return _palette.CommandBarMenuTopLevelHeaderHovered.Border; }
        }

        public override Color MenuBorder
        {
            get { return _palette.CommandBarMenuPopupDefault.Border; }
        }

        //public override Color RaftingContainerGradientBegin
        //{
        //    get { return Color.FromArgb(255, 186, 192, 201); }
        //}
        //public override Color RaftingContainerGradientEnd
        //{
        //    get { return Color.FromArgb(255, 186, 192, 201); }
        //}

        public override Color SeparatorDark
        {
            get { return _palette.CommandBarToolbarDefault.Separator; }
        }

        public override Color SeparatorLight
        {
            get { return _palette.CommandBarToolbarDefault.SeparatorAccent; }
        }

        public override Color StatusStripGradientBegin
        {
            get { return _palette.MainWindowStatusBarDefault.Background; }
        }
        public override Color StatusStripGradientEnd
        {
            get { return _palette.MainWindowStatusBarDefault.Background; }
        }

        public override Color ToolStripBorder
        {
            get { return _palette.CommandBarToolbarDefault.Border; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return _palette.CommandBarMenuPopupDefault.BackgroundBottom; }
        }

        public override Color ToolStripGradientBegin
        {
            get { return _palette.CommandBarToolbarDefault.Background; }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return _palette.CommandBarToolbarDefault.Background; }
        }

        public override Color ToolStripGradientEnd
        {
            get { return _palette.CommandBarToolbarDefault.Background; }
        }

        //public override Color ToolStripContentPanelGradientBegin
        //{
        //    get { return Color.FromArgb(255, 239, 239, 242); }
        //}
        //public override Color ToolStripContentPanelGradientEnd
        //{
        //    get { return Color.FromArgb(255, 239, 239, 242); }
        //}
        //public override Color ToolStripPanelGradientBegin
        //{
        //    get { return Color.FromArgb(255, 239, 239, 242); }
        //}
        //public override Color ToolStripPanelGradientEnd
        //{
        //    get { return Color.FromArgb(255, 239, 239, 242); }
        //}

        public override Color OverflowButtonGradientBegin
        {
            get { return _palette.CommandBarToolbarDefault.OverflowButtonBackground; }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get { return _palette.CommandBarToolbarDefault.OverflowButtonBackground; }
        }
        public override Color OverflowButtonGradientEnd
        {
            get { return _palette.CommandBarToolbarDefault.OverflowButtonBackground; }
        }
    }

}
