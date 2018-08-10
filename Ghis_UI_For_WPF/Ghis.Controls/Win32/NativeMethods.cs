using Ghis.Controls.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ghis.Controls.Win32
{
  internal class NativeMethods
  {
    public const int MONITOR_DEFAULTTONEAREST = 0x00000002;
    public const int S_OK = 0;
    public const int WM_DPICHANGED = 0x02E0;

    [DllImport("shcore.dll")]
    public static extern int GetDpiForMonitor(IntPtr hMonitor, int dpiType, ref uint xDpi, ref uint yDpi);

    [DllImport("Shcore.dll")]
    public static extern int GetProcessDpiAwareness(IntPtr hprocess, out ProcessDpiAwareness value);

    [DllImport("user32.dll")]
    public static extern bool IsProcessDPIAware();

    [DllImport("user32.dll")]
    public static extern IntPtr MonitorFromWindow(IntPtr hwnd, int flag);

    [DllImport("user32.dll")]
    public static extern int SetProcessDPIAware();

    [DllImport("Shcore.dll")]
    public static extern int SetProcessDpiAwareness(ProcessDpiAwareness value);
  }
}