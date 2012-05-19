using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
        public static class Win32Helper
	{
                internal static Control ControlAtPoint(Point pt)
	        {
		        return Control.FromChildHandle(NativeMethods.WindowFromPoint(pt));
		}

                internal static uint MakeLong(int low, int high)
		{
			return (uint)((high << 16) + low);
		}

		public static bool IsRunningOnMono()
		{
			return Type.GetType ("Mono.Runtime") != null;
		}
	}
}
