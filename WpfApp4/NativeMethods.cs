using System;
using System.Runtime.InteropServices;

namespace WpfApp4
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, int dwFlags);

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [DllImport("shcore.dll")]
        public static extern int GetDpiForMonitor(IntPtr hMonitor, int dpiType, out uint dpiX, out uint dpiY);

        [DllImport("user32.dll")]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MONITORINFO
    {
        public int cbSize;
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int x;
        public int y;
        public int cx;
        public int cy;

        public RECT(int x, int y, int cx, int cy)
        {
            this.x = x;
            this.y = y;
            this.cx = cx;
            this.cy = cy;
        }
    }

    internal static class Consts
    {
        public const int MONITOR_DEFAULTTOPRIMARY = 1;
        public const int MONITOR_DEFAULTTONEAREST = 2;

        public const int DPI_AWARENESS_CONTEXT_UNAWARE = 16;
        public const int DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = 17;
        public const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = 18;
        public const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = 34;

        public const int MDT_EFFECTIVE_DPI = 0;
        public const int MDT_ANGULAR_DPI = 1;
        public const int MDT_RAW_API = 3;

        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOZORDER = 0x0004;
    }
}
