using System.Collections.Generic;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    public class PaintingService : IPaintingService
    {
        IDictionary<KeyValuePair<int, int>, Pen> _penCache = new Dictionary<KeyValuePair<int, int>, Pen>();
        IDictionary<int, SolidBrush> _brushCache = new Dictionary<int, SolidBrush>();

        public SolidBrush GetBrush(Color color)
        {
            var key = color.ToArgb();
            if (_brushCache.ContainsKey(key))
            {
                return _brushCache[key];
            }

            var result = new SolidBrush(color);
            _brushCache.Add(key, result);
            return result;
        }

        public Pen GetPen(Color color, int thickness)
        {
            var key = new KeyValuePair<int, int>(color.ToArgb(), thickness);
            if (_penCache.ContainsKey(key))
            {
                return _penCache[key];
            }

            var result = new Pen(color, thickness);
            _penCache.Add(key, result);
            return result;
        }

        public void CleanUp()
        {
            foreach (var pen in _penCache)
            {
                pen.Value.Dispose();
            }

            _penCache.Clear();

            foreach (var brush in _brushCache)
            {
                brush.Value.Dispose();
            }

            _brushCache.Clear();
        }
    }
}
