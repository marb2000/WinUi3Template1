using Microsoft.UI.Xaml;
using System;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Controls;
using Windows.Win32.UI.WindowsAndMessaging;

using static Windows.Win32.PInvoke;
using static Windows.Win32.Constants;

namespace WinUi3Template1
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Title = Settings.FeatureName;

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            LoadIcon(hwnd, "Assets/windows-sdk.ico");
            SetWindowSize(hwnd, 1920, 1080);
        }

        private void LoadIcon(IntPtr hwnd, string iconName)
        {
            var hIcon = LoadImage(null, iconName, GDI_IMAGE_TYPE.IMAGE_ICON, 16, 16, IMAGE_FLAGS.LR_LOADFROMFILE);

            var success = false;
            hIcon.DangerousAddRef(ref success);
            SendMessage((HWND)hwnd, WM_SETICON, 0, hIcon.DangerousGetHandle());
            hIcon.DangerousRelease();
        }
        private void SetWindowSize(IntPtr hwnd, int width, int height)
        {
            // Win32 uses pixels and WinUI 3 uses effective pixels, so you should apply the DPI scale factor
            var dpi = GetDpiForWindow((HWND)hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            SetWindowPos((HWND)hwnd, HWND_TOP, 0, 0, width, height, SET_WINDOW_POS_FLAGS.SWP_NOMOVE);
        }
    }
}
