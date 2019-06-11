using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            var hMonitor = NativeMethods.MonitorFromWindow(hwnd, Consts.MONITOR_DEFAULTTOPRIMARY);

            var monitorInfo = new MONITORINFO
            {
                cbSize = Marshal.SizeOf<MONITORINFO>()
            };

            NativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo);

            Left = monitorInfo.rcWork.x + (monitorInfo.rcWork.cx - monitorInfo.rcWork.x - Width) / 2;
            Top = monitorInfo.rcWork.y + (monitorInfo.rcWork.cy - monitorInfo.rcWork.y - Height) / 2;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            var hMonitor = NativeMethods.MonitorFromWindow(hwnd, Consts.MONITOR_DEFAULTTOPRIMARY);

            var monitorInfo = new MONITORINFO
            {
                cbSize = Marshal.SizeOf<MONITORINFO>()
            };

            NativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo);

            var x = monitorInfo.rcWork.x + (monitorInfo.rcWork.cx - monitorInfo.rcWork.x - Width) / 2;
            var y = monitorInfo.rcWork.y + (monitorInfo.rcWork.cy - monitorInfo.rcWork.y - Height) / 2;

            NativeMethods.SetWindowPos(hwnd, IntPtr.Zero, (int)x, (int)y, 0, 0, Consts.SWP_NOSIZE);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            var hMonitor = NativeMethods.MonitorFromWindow(hwnd, Consts.MONITOR_DEFAULTTOPRIMARY);

            NativeMethods.GetDpiForMonitor(hMonitor, Consts.MDT_EFFECTIVE_DPI, out var dpiX, out var dpiY);

            var dpiFactorX = dpiX / 96.0;
            var dpiFactorY = dpiY / 96.0;

            var physicalWidth = (int)Math.Round(Width * dpiFactorX);
            var physicalHeight = (int)Math.Round(Height * dpiFactorY);

            var monitorInfo = new MONITORINFO
            {
                cbSize = Marshal.SizeOf<MONITORINFO>()
            };

            NativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo);

            Left = monitorInfo.rcWork.x + (monitorInfo.rcWork.cx - monitorInfo.rcWork.x - physicalWidth) / 2;
            Top = monitorInfo.rcWork.y + (monitorInfo.rcWork.cy - monitorInfo.rcWork.y - physicalHeight) / 2;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            var hMonitor = NativeMethods.MonitorFromWindow(hwnd, Consts.MONITOR_DEFAULTTOPRIMARY);

            NativeMethods.GetDpiForMonitor(hMonitor, Consts.MDT_EFFECTIVE_DPI, out var dpiX, out var dpiY);

            var dpiFactorX = dpiX / 96.0;
            var dpiFactorY = dpiY / 96.0;

            var physicalWidth = (int)Math.Round(Width * dpiFactorX);
            var physicalHeight = (int)Math.Round(Height * dpiFactorY);

            var monitorInfo = new MONITORINFO
            {
                cbSize = Marshal.SizeOf<MONITORINFO>()
            };

            NativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo);

            var x = monitorInfo.rcWork.x + (monitorInfo.rcWork.cx - monitorInfo.rcWork.x - physicalWidth) / 2;
            var y = monitorInfo.rcWork.y + (monitorInfo.rcWork.cy - monitorInfo.rcWork.y - physicalHeight) / 2;

            NativeMethods.SetWindowPos(hwnd, IntPtr.Zero, x, y, 0, 0, Consts.SWP_NOSIZE);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Left = (SystemParameters.WorkArea.Width - Width) / 2;
            Top = (SystemParameters.WorkArea.Height - Height) / 2;
        }
    }
}
