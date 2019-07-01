using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class VisualStudioToolStripRenderer : ToolStripProfessionalRenderer
    {
        private static Rectangle[] baseSizeGripRectangles =
        {
            new Rectangle(6,0,1,1),
            new Rectangle(6,2,1,1),
            new Rectangle(6,4,1,1),
            new Rectangle(6,6,1,1),
            new Rectangle(4,2,1,1),
            new Rectangle(4,4,1,1),
            new Rectangle(4,6,1,1),
            new Rectangle(2,4,1,1),
            new Rectangle(2,6,1,1),
            new Rectangle(0,6,1,1)
        };

        private const int GRIP_PADDING = 4;
        private SolidBrush _statusBarBrush;
        private SolidBrush _statusGripBrush;
        private SolidBrush _statusGripAccentBrush;
        private SolidBrush _toolBarBrush;
        private SolidBrush _gripBrush;
        private Pen _toolBarBorderPen;
        private VisualStudioColorTable _table;
        private DockPanelColorPalette _palette;

        public bool UseGlassOnMenuStrip { get; set; }

        public VisualStudioToolStripRenderer(DockPanelColorPalette palette)
            : base(new VisualStudioColorTable(palette))
        {
            _table = (VisualStudioColorTable)ColorTable;
            _palette = palette;
            RoundedEdges = false;
            _statusBarBrush = new SolidBrush(palette.MainWindowStatusBarDefault.Background);
            _statusGripBrush = new SolidBrush(palette.MainWindowStatusBarDefault.ResizeGrip);
            _statusGripAccentBrush = new SolidBrush(palette.MainWindowStatusBarDefault.ResizeGripAccent);
            _toolBarBrush = new SolidBrush(palette.CommandBarToolbarDefault.Background);
            _gripBrush = new SolidBrush(palette.CommandBarToolbarDefault.Grip);
            _toolBarBorderPen = new Pen(palette.CommandBarToolbarDefault.Border);

            UseGlassOnMenuStrip = true;
        }

        #region Rendering Improvements (includes fixes for bugs occured when Windows Classic theme is on).
        //*
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            // Do not draw disabled item background.
            if (e.Item.Enabled)
            {
                bool isMenuDropDown = e.Item.Owner is MenuStrip;
                if (isMenuDropDown && e.Item.Pressed)
                {
                    base.OnRenderMenuItemBackground(e);
                }
                else if (e.Item.Selected)
                {
                    // Rect of item's content area.
                    Rectangle contentRect = e.Item.ContentRectangle;

                    // Fix item rect.
                    Rectangle itemRect = isMenuDropDown
                                             ? new Rectangle(
                                                   contentRect.X + 2, contentRect.Y - 2,
                                                   contentRect.Width - 5, contentRect.Height + 3)
                                             : new Rectangle(
                                                   contentRect.X, contentRect.Y - 1,
                                                   contentRect.Width, contentRect.Height + 1);

                    // Border pen and fill brush.
                    Color pen = ColorTable.MenuItemBorder;
                    Color brushBegin;
                    Color brushEnd;

                    if (isMenuDropDown)
                    {
                        brushBegin = ColorTable.MenuItemSelectedGradientBegin;
                        brushEnd = ColorTable.MenuItemSelectedGradientEnd;
                    }
                    else
                    {
                        brushBegin = ColorTable.MenuItemSelected;
                        brushEnd = Color.Empty;
                    }

                    DrawRectangle(e.Graphics, itemRect, brushBegin, brushEnd, pen, UseGlassOnMenuStrip);
                }
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            var status = e.ToolStrip as StatusStrip;
            if (status != null)
            {
                // IMPORTANT: left empty to remove white border.
                return;
            }

            var context = e.ToolStrip as MenuStrip;
            if (context != null)
            {
                base.OnRenderToolStripBorder(e);
                return;
            }

            var drop = e.ToolStrip as ToolStripDropDown;
            if (drop != null)
            {
                base.OnRenderToolStripBorder(e);
                return;
            }

            var rect = e.ToolStrip.ClientRectangle;
            e.Graphics.DrawRectangle(_toolBarBorderPen, new Rectangle(rect.Location, new Size(rect.Width - 1, rect.Height - 1)));
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var status = e.ToolStrip as StatusStrip;
            if (status != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            var context = e.ToolStrip as MenuStrip;
            if (context != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            var drop = e.ToolStrip as ToolStripDropDown;
            if (drop != null)
            {
                base.OnRenderToolStripBackground(e);
                return;
            }

            e.Graphics.FillRectangle(_toolBarBrush, e.ToolStrip.ClientRectangle);
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            // IMPORTANT: below code was taken from Microsoft's reference code (MIT license).
            Graphics g = e.Graphics;
            StatusStrip statusStrip = e.ToolStrip as StatusStrip;

            // we have a set of stock rectangles.  Translate them over to where the grip is to be drawn
            // for the white set, then translate them up and right one pixel for the grey.


            if (statusStrip != null)
            {
                Rectangle sizeGripBounds = statusStrip.SizeGripBounds;
                if (!LayoutUtils.IsZeroWidthOrHeight(sizeGripBounds))
                {
                    Rectangle[] whiteRectangles = new Rectangle[baseSizeGripRectangles.Length];
                    Rectangle[] greyRectangles = new Rectangle[baseSizeGripRectangles.Length];

                    for (int i = 0; i < baseSizeGripRectangles.Length; i++)
                    {
                        Rectangle baseRect = baseSizeGripRectangles[i];
                        if (statusStrip.RightToLeft == RightToLeft.Yes)
                        {
                            baseRect.X = sizeGripBounds.Width - baseRect.X - baseRect.Width;
                        }
                        baseRect.Offset(sizeGripBounds.X, sizeGripBounds.Bottom - 12 /*height of pyramid (10px) + 2px padding from bottom*/);
                        greyRectangles[i] = baseRect;
                        if (statusStrip.RightToLeft == RightToLeft.Yes)
                        {
                            baseRect.Offset(1, -1);
                        }
                        else
                        {
                            baseRect.Offset(-1, -1);
                        }
                        whiteRectangles[i] = baseRect;
                    }

                    g.FillRectangles(_statusGripAccentBrush, whiteRectangles);
                    g.FillRectangles(_statusGripBrush, greyRectangles);
                }
            }
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.GripBounds;
            ToolStrip toolStrip = e.ToolStrip;

            bool rightToLeft = (e.ToolStrip.RightToLeft == RightToLeft.Yes);

            int height = (toolStrip.Orientation == Orientation.Horizontal) ? bounds.Height : bounds.Width;
            int width = (toolStrip.Orientation == Orientation.Horizontal) ? bounds.Width : bounds.Height;

            int numRectangles = (height - (GRIP_PADDING * 2)) / 4;

            if (numRectangles > 0)
            {
                numRectangles++;
                // a MenuStrip starts its grip lower and has fewer grip rectangles.
                int yOffset = (toolStrip is MenuStrip) ? 2 : 0;

                Rectangle[] shadowRects = new Rectangle[numRectangles];
                int startY = GRIP_PADDING + 1 + yOffset;
                int startX = (width / 2);

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i] = (toolStrip.Orientation == Orientation.Horizontal) ?
                                        new Rectangle(startX, startY, 1, 1) :
                                        new Rectangle(startY, startX, 1, 1);

                    startY += 4;
                }

                // in RTL the GripLight rects should paint to the left of the GripDark rects.
                int xOffset = (rightToLeft) ? 2 : -2;

                if (rightToLeft)
                {
                    // scoot over the rects in RTL so they fit within the bounds.
                    for (int i = 0; i < numRectangles; i++)
                    {
                        shadowRects[i].Offset(-xOffset, 0);
                    }
                }

                Brush b = _gripBrush;
                for (int i = 0; i < numRectangles - 1; i++)
                {
                    g.FillRectangle(b, shadowRects[i]);
                }

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i].Offset(xOffset, -2);
                }

                g.FillRectangles(b, shadowRects);

                for (int i = 0; i < numRectangles; i++)
                {
                    shadowRects[i].Offset(-2 * xOffset, 0);
                }

                g.FillRectangles(b, shadowRects);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton button = e.Item as ToolStripButton;
            if (button != null && button.Enabled)
            {
                if (button.Selected || button.Checked)
                {
                    // Rect of item's content area.
                    Rectangle contentRect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);

                    Color pen;
                    Color brushBegin;
                    Color brushMiddle;
                    Color brushEnd;

                    if (button.Checked)
                    {
                        if (button.Selected)
                        {
                            pen = _table.ButtonCheckedHoveredBorder;
                            brushBegin = _table.ButtonCheckedHoveredBackground;
                            brushMiddle = _table.ButtonCheckedHoveredBackground;
                            brushEnd = _table.ButtonCheckedHoveredBackground;
                        }
                        else
                        {
                            pen = _table.ButtonCheckedBorder;
                            brushBegin = ColorTable.ButtonCheckedGradientBegin;
                            brushMiddle = ColorTable.ButtonCheckedGradientMiddle;
                            brushEnd = ColorTable.ButtonCheckedGradientEnd;
                        }
                    }
                    else if (button.Pressed)
                    {
                        pen = ColorTable.ButtonPressedBorder;
                        brushBegin = ColorTable.ButtonPressedGradientBegin;
                        brushMiddle = ColorTable.ButtonPressedGradientMiddle;
                        brushEnd = ColorTable.ButtonPressedGradientEnd;
                    }
                    else
                    {
                        pen = ColorTable.ButtonSelectedBorder;
                        brushBegin = ColorTable.ButtonSelectedGradientBegin;
                        brushMiddle = ColorTable.ButtonSelectedGradientMiddle;
                        brushEnd = ColorTable.ButtonSelectedGradientEnd;
                    }

                    DrawRectangle(e.Graphics, contentRect,
                        brushBegin, brushMiddle, brushEnd, pen, false);
                }
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }

        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            // IMPORTANT: enlarge grip area so grip can be rendered fully.
            toolStrip.GripMargin = new Padding(toolStrip.GripMargin.All + 1);
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var cache = _palette.CommandBarMenuPopupDefault.BackgroundTop;

            // IMPORTANT: not 100% accurate as the color change should only happen when the overflow menu is hovered.
            // here color change happens when the overflow menu is displayed.
            if (e.Item.Pressed)
                _palette.CommandBarMenuPopupDefault.BackgroundTop = _palette.CommandBarToolbarOverflowPressed.Background;
            base.OnRenderOverflowButtonBackground(e);
            if (e.Item.Pressed)
                _palette.CommandBarMenuPopupDefault.BackgroundTop = cache;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Selected ? _palette.CommandBarMenuPopupHovered.Arrow : _palette.CommandBarMenuPopupDefault.Arrow;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            ////base.OnRenderItemCheck(e);
            using (var imageAttr = new ImageAttributes())
            {
                Color foreColor = e.Item.Selected ? _palette.CommandBarMenuPopupHovered.Checkmark : _palette.CommandBarMenuPopupDefault.Checkmark;
                Color backColor = e.Item.Selected ? _palette.CommandBarMenuPopupHovered.CheckmarkBackground : _palette.CommandBarMenuPopupDefault.CheckmarkBackground;
                Color borderColor = _palette.CommandBarMenuPopupDefault.Border;

                // Create a color map.
                ColorMap[] colorMap = new ColorMap[1];
                colorMap[0] = new ColorMap();

                // old color determined from testing
                colorMap[0].OldColor = Color.FromArgb(4, 2, 4);
                colorMap[0].NewColor = foreColor;
                imageAttr.SetRemapTable(colorMap);

                using (var b = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(b, e.ImageRectangle);
                }
                e.Graphics.DrawImage(e.Image, e.ImageRectangle, 0, 0, e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, imageAttr);
                using (var p = new Pen(borderColor))
                {
                    e.Graphics.DrawRectangle(p, e.ImageRectangle);
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle r = e.Item.ContentRectangle;
            if (e.Vertical)
            {
                using (var p = new Pen(_palette.CommandBarToolbarDefault.Separator))
                {
                    e.Graphics.DrawLine(p, r.X, r.Y, r.X, r.Y + r.Height);
                }
                using (var p = new Pen(_palette.CommandBarToolbarDefault.SeparatorAccent))
                {
                    e.Graphics.DrawLine(p, r.X + 1, r.Y, r.X + 1, r.Y + r.Height);
                }
            }
            else
            {
                // if this is a menu, then account for the image column
                int x1 = r.X;
                int x2 = r.X + r.Width;
                var menu = e.ToolStrip as ToolStripDropDownMenu;
                if (menu != null)
                {
                    x1 += menu.Padding.Left;
                    x2 -= menu.Padding.Right;
                }

                using (var p = new Pen(_palette.CommandBarToolbarDefault.Separator))
                {
                    e.Graphics.DrawLine(p, x1, r.Y, x2, r.Y);
                }
                using (var p = new Pen(_palette.CommandBarToolbarDefault.SeparatorAccent))
                {
                    e.Graphics.DrawLine(p, x1, r.Y + 1, x2, r.Y + 1);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            Color color = Color.Black;
            var toolStrip = e.ToolStrip;
            if (toolStrip is StatusStrip)
            {
                if (e.Item.Selected)
                {
                    color = _palette.MainWindowStatusBarDefault.HighlightText;
                }
                else
                {
                    color = _palette.MainWindowStatusBarDefault.Text;
                }
            }
            else if (toolStrip is MenuStrip)
            {
                var button = e.Item as ToolStripButton;
                var checkedButton = button != null && button.Checked;
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                }
                else if (button != null && button.Pressed)
                {
                    color = _palette.CommandBarToolbarButtonPressed.Text;
                }
                else if (e.Item.Selected && checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonCheckedHovered.Text;
                }
                else if (e.Item.Selected)
                {
                    color = _palette.CommandBarMenuTopLevelHeaderHovered.Text;
                }
                else if (checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonChecked.Text;
                }
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }
            else if (toolStrip is ToolStripDropDown)
            {
                // This might differ from above branch, but left the same here.
                var button = e.Item as ToolStripButton;
                var checkedButton = button != null && button.Checked;
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                }
                else if (button != null && button.Pressed)
                {
                    color = _palette.CommandBarToolbarButtonPressed.Text;
                }
                else if (e.Item.Selected && checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonCheckedHovered.Text;
                }
                else if (e.Item.Selected)
                {
                    color = _palette.CommandBarMenuTopLevelHeaderHovered.Text;
                }
                else if (checkedButton)
                {
                    color = _palette.CommandBarToolbarButtonChecked.Text;
                }
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }
            else 
            {
                // Default color, if not it will be black no matter what 
                if (!e.Item.Enabled)
                {
                    color = _palette.CommandBarMenuPopupDisabled.Text;
                } 
                else
                {
                    color = _palette.CommandBarMenuDefault.Text;
                }
            }

            TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, color, e.TextFormat);
        }

        #region helpers
        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brushBegin, 
            Color brushMiddle, Color brushEnd, Color penColor, bool glass)
        {
            RectangleF firstHalf = new RectangleF(
                rect.X, rect.Y, 
                rect.Width, (float)rect.Height / 2);

            RectangleF secondHalf = new RectangleF(
                rect.X, rect.Y + (float)rect.Height / 2, 
                rect.Width, (float)rect.Height / 2);

            if (brushMiddle.IsEmpty && brushEnd.IsEmpty)
            {
                graphics.FillRectangle(new SolidBrush(brushBegin), rect);
            }
            if (brushMiddle.IsEmpty)
            {
                rect.SafelyDrawLinearGradient(brushBegin, brushEnd, LinearGradientMode.Vertical, graphics);
            }
            else
            {
                firstHalf.SafelyDrawLinearGradientF(brushBegin, brushMiddle, LinearGradientMode.Vertical, graphics);
                secondHalf.SafelyDrawLinearGradientF(brushMiddle, brushEnd, LinearGradientMode.Vertical, graphics);
            }

            if (glass)
            {
                Brush glassBrush = new SolidBrush(Color.FromArgb(120, Color.White));
                graphics.FillRectangle(glassBrush, firstHalf);
            }

            if (penColor.A > 0)
            {
                graphics.DrawRectangle(new Pen(penColor), rect);
            }
        }

        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brushBegin,
            Color brushEnd, Color penColor, bool glass)
        {
            DrawRectangle(graphics, rect, brushBegin, Color.Empty, brushEnd, penColor, glass);
        }

        private static void DrawRectangle(Graphics graphics, Rectangle rect, Color brush, 
            Color penColor, bool glass)
        {
            DrawRectangle(graphics, rect, brush, Color.Empty, Color.Empty, penColor, glass);
        }

        private static void FillRoundRectangle(Graphics graphics, Brush brush, Rectangle rect, int radius)
        {
            float fx = Convert.ToSingle(rect.X);
            float fy = Convert.ToSingle(rect.Y);
            float fwidth = Convert.ToSingle(rect.Width);
            float fheight = Convert.ToSingle(rect.Height);
            float fradius = Convert.ToSingle(radius);
            FillRoundRectangle(graphics, brush, fx, fy, fwidth, fheight, fradius);
        }

        private static void FillRoundRectangle(Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = GetRoundedRect(rectangle, radius);
            graphics.FillPath(brush, path);
        }

        private static void DrawRoundRectangle(Graphics graphics, Pen pen, Rectangle rect, int radius)
        {
            float fx = Convert.ToSingle(rect.X);
            float fy = Convert.ToSingle(rect.Y);
            float fwidth = Convert.ToSingle(rect.Width);
            float fheight = Convert.ToSingle(rect.Height);
            float fradius = Convert.ToSingle(radius);
            DrawRoundRectangle(graphics, pen, fx, fy, fwidth, fheight, fradius);
        }

        private static void DrawRoundRectangle(Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = GetRoundedRect(rectangle, radius);
            graphics.DrawPath(pen, path);
        }

        private static GraphicsPath GetRoundedRect(RectangleF baseRect, float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 

            if (radius <= 0)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 

            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 

            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static GraphicsPath GetCapsule(RectangleF baseRect)
        {
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();

            try
            {
                float diameter;
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }

            return path;
        }
        #endregion
        // */
        #endregion
    }
}