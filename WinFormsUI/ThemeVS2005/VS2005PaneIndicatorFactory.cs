using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanel;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace WeifenLuo.WinFormsUI.ThemeVS2005
{
    public class VS2005PaneIndicatorFactory : IPaneIndicatorFactory
    {
        public IPaneIndicator CreatePaneIndicator(ThemeBase theme)
        {
            return new VS2005PaneIndicator();
        }

        [ToolboxItem(false)]
        internal class VS2005PaneIndicator : PictureBox, IPaneIndicator
        {
            private Bitmap _bitmapPaneDiamond = Resources.DockIndicator_PaneDiamond;
            private Bitmap _bitmapPaneDiamondLeft = Resources.DockIndicator_PaneDiamond_Left;
            private Bitmap _bitmapPaneDiamondRight = Resources.DockIndicator_PaneDiamond_Right;
            private Bitmap _bitmapPaneDiamondTop = Resources.DockIndicator_PaneDiamond_Top;
            private Bitmap _bitmapPaneDiamondBottom = Resources.DockIndicator_PaneDiamond_Bottom;
            private Bitmap _bitmapPaneDiamondFill = Resources.DockIndicator_PaneDiamond_Fill;
            private Bitmap _bitmapPaneDiamondHotSpot = Resources.DockIndicator_PaneDiamond_HotSpot;
            private Bitmap _bitmapPaneDiamondHotSpotIndex = Resources.DockIndicator_PaneDiamond_HotSpotIndex;
            private static readonly HotSpotIndex[] _hotSpots =
            {
                new HotSpotIndex(1, 0, DockStyle.Top),
                new HotSpotIndex(0, 1, DockStyle.Left),
                new HotSpotIndex(1, 1, DockStyle.Fill),
                new HotSpotIndex(2, 1, DockStyle.Right),
                new HotSpotIndex(1, 2, DockStyle.Bottom)
            };

            private GraphicsPath _displayingGraphicsPath;

            public VS2005PaneIndicator()
            {
                _displayingGraphicsPath = DrawHelper.CalculateGraphicsPathFromBitmap(_bitmapPaneDiamond);
                SizeMode = PictureBoxSizeMode.AutoSize;
                Image = _bitmapPaneDiamond;
                Region = new Region(DisplayingGraphicsPath);
            }

            public GraphicsPath DisplayingGraphicsPath
            {
                get { return _displayingGraphicsPath; }
            }

            public DockStyle HitTest(Point pt)
            {
                if (!Visible)
                    return DockStyle.None;

                pt = PointToClient(pt);
                if (!ClientRectangle.Contains(pt))
                    return DockStyle.None;

                for (int i = _hotSpots.GetLowerBound(0); i <= _hotSpots.GetUpperBound(0); i++)
                {
                    if (_bitmapPaneDiamondHotSpot.GetPixel(pt.X, pt.Y) == _bitmapPaneDiamondHotSpotIndex.GetPixel(_hotSpots[i].X, _hotSpots[i].Y))
                        return _hotSpots[i].DockStyle;
                }

                return DockStyle.None;
            }

            private DockStyle m_status = DockStyle.None;
            public DockStyle Status
            {
                get { return m_status; }
                set
                {
                    m_status = value;
                    if (m_status == DockStyle.None)
                        Image = _bitmapPaneDiamond;
                    else if (m_status == DockStyle.Left)
                        Image = _bitmapPaneDiamondLeft;
                    else if (m_status == DockStyle.Right)
                        Image = _bitmapPaneDiamondRight;
                    else if (m_status == DockStyle.Top)
                        Image = _bitmapPaneDiamondTop;
                    else if (m_status == DockStyle.Bottom)
                        Image = _bitmapPaneDiamondBottom;
                    else if (m_status == DockStyle.Fill)
                        Image = _bitmapPaneDiamondFill;
                }
            }
        }
    }
}
