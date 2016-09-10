using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace WeifenLuo.WinFormsUI.Docking
{
    public abstract class InertButtonBase : Control
    {
        protected InertButtonBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public abstract Bitmap HoverImage { get; }

        public abstract Bitmap Image { get; }

        private bool m_isMouseOver = false;
        protected bool IsMouseOver
        {
            get { return m_isMouseOver; }
            private set
            {
                if (m_isMouseOver == value)
                    return;

                m_isMouseOver = value;
                Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get { return Resources.DockPane_Close.Size; }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool over = ClientRectangle.Contains(e.X, e.Y);
            if (IsMouseOver != over)
                IsMouseOver = over;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsMouseOver)
                IsMouseOver = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (IsMouseOver)
                IsMouseOver = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap imgToDraw = Image;

            if (IsMouseOver && Enabled)
            {
                if (HoverImage != null)
                {
                    imgToDraw = HoverImage;
                }
                else
                {
                    using (Pen pen = new Pen(ForeColor))
                    {
                        e.Graphics.DrawRectangle(pen, Rectangle.Inflate(ClientRectangle, -1, -1));
                    }
                }
            }
            
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                ColorMap[] colorMap = new ColorMap[2];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.FromArgb(0, 0, 0);
                colorMap[0].NewColor = ForeColor;
                colorMap[1] = new ColorMap();
                colorMap[1].OldColor = imgToDraw.GetPixel(0, 0);
                colorMap[1].NewColor = Color.Transparent;

                imageAttributes.SetRemapTable(colorMap);

                e.Graphics.DrawImage(
                    imgToDraw,
                    PatchController.EnableHighDpi == true
                        ? ClientRectangle
                        : new Rectangle(0, 0, imgToDraw.Width, imgToDraw.Height),
                    0, 0,
                    imgToDraw.Width,
                    imgToDraw.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
            

            base.OnPaint(e);
        }

        public void RefreshChanges()
        {
            if (IsDisposed)
                return;

            bool mouseOver = ClientRectangle.Contains(PointToClient(Control.MousePosition));
            if (mouseOver != IsMouseOver)
                IsMouseOver = mouseOver;

            OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }
    }
}
