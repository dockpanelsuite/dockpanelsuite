using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.ThemeVS2005Multithreading;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2005MultithreadingPaneIndicator : PictureBox, DockPanel.IPaneIndicator
    {
        private Bitmap _bitmapPaneDiamond;
        private Bitmap _bitmapPaneDiamondLeft;
        private Bitmap _bitmapPaneDiamondRight;
        private Bitmap _bitmapPaneDiamondTop;
        private Bitmap _bitmapPaneDiamondBottom;
        private Bitmap _bitmapPaneDiamondFill;
        private Bitmap _bitmapPaneDiamondHotSpot;
        private Bitmap _bitmapPaneDiamondHotSpotIndex;

        private static DockPanel.HotSpotIndex[] _hotSpots = new[]
        {
                new DockPanel.HotSpotIndex(1, 0, DockStyle.Top),
                new DockPanel.HotSpotIndex(0, 1, DockStyle.Left),
                new DockPanel.HotSpotIndex(1, 1, DockStyle.Fill),
                new DockPanel.HotSpotIndex(2, 1, DockStyle.Right),
                new DockPanel.HotSpotIndex(1, 2, DockStyle.Bottom)
            };

        private GraphicsPath _displayingGraphicsPath;

        public VS2005MultithreadingPaneIndicator()
        {
            lock (typeof(Resources))
            {
                _bitmapPaneDiamond = (Bitmap)Resources.DockIndicator_PaneDiamond.Clone();
                _bitmapPaneDiamondLeft = (Bitmap)Resources.DockIndicator_PaneDiamond_Left.Clone();
                _bitmapPaneDiamondRight = (Bitmap)Resources.DockIndicator_PaneDiamond_Right.Clone();
                _bitmapPaneDiamondTop = (Bitmap)Resources.DockIndicator_PaneDiamond_Top.Clone();
                _bitmapPaneDiamondBottom = (Bitmap)Resources.DockIndicator_PaneDiamond_Bottom.Clone();
                _bitmapPaneDiamondFill = (Bitmap)Resources.DockIndicator_PaneDiamond_Fill.Clone();
                _bitmapPaneDiamondHotSpot = (Bitmap)Resources.DockIndicator_PaneDiamond_HotSpot.Clone();
                _bitmapPaneDiamondHotSpotIndex = (Bitmap)Resources.DockIndicator_PaneDiamond_HotSpotIndex.Clone();
            }

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
