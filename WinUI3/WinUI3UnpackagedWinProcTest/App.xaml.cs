using Microsoft.UI.Xaml;

using System;
using System.Runtime.InteropServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App53
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x0010;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(m_window);

            //var wndProcFunc = new WNDPROC(WinProc);
            //var prevWndFunc = PInvoke.SetWindowLongPtr((HWND)hwnd, WINDOW_LONG_PTR_INDEX.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(wndProcFunc));
            //_prevWndFunc = Marshal.GetDelegateForFunctionPointer<WNDPROC>(prevWndFunc);

            var wndProcFunc = new SUBCLASSPROC(WinProc);
            SetWindowSubclass(hwnd, wndProcFunc, 0, 0);

            m_window.Activate();
        }

        private Window m_window;
        //private WNDPROC _prevWndFunc;

        //private LRESULT WinProc(HWND hwnd, uint msg, WPARAM wParam, LPARAM lParam)
        //{
        //    return PInvoke.CallWindowProc(_prevWndFunc, hwnd, msg, wParam, lParam);
        //}

        private int WinProc(IntPtr hwnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData)
        {
            return DefSubclassProc(hwnd, uMsg, wParam, lParam);
        }

    }
}
