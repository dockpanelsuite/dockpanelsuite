using System.Windows.Forms;

namespace DockSample
{
    public partial class DummyPropertyWindow : ToolWindow
    {
        public DummyPropertyWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            propertyGrid.SelectedObject = propertyGrid;
        }
    }
}