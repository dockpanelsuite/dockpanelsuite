using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal abstract class InertButtonBase : Label
    {
        protected InertButtonBase(ImageList imageList)
        {
            ImageList = imageList;
            FlatStyle = FlatStyle.Flat;
            Size = imageList.Images[0].Size;
            BorderStyle = BorderStyle.None;
            BackColor = Color.Transparent;
        }

        private bool m_isMouseOver = false;
        protected bool IsMouseOver
        {
            get { return m_isMouseOver; }
            private set
            {
                if (m_isMouseOver == value)
                    return;

                m_isMouseOver = value;
                OnRefreshChanges();
            }
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

        public void RefreshChanges()
        {
            bool mouseOver = ClientRectangle.Contains(PointToClient(Control.MousePosition));
            if (mouseOver != IsMouseOver)
                IsMouseOver = mouseOver;
            else
                OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }
    }
}
