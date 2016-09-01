using System;
using System.Collections.Generic;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    public class PaintingService : IPaintingService
    {
        IDictionary<KeyValuePair<Color, int>, Pen> _penCache = new Dictionary<KeyValuePair<Color, int>, Pen>();
        IDictionary<Color, SolidBrush> _brushCache = new Dictionary<Color, SolidBrush>();

        public SolidBrush GetBrush(Color color)
        {
            if (_brushCache.ContainsKey(color))
            {
                return _brushCache[color];
            }

            var result = new SolidBrush(color);
            _brushCache.Add(color, result);
            return result;
        }

        public Pen GetPen(Color color, int thickness)
        {
            var key = new KeyValuePair<Color, int>(color, thickness);
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
