using System;
using Microsoft.UI.Xaml;
using Microsoft.Win32.SafeHandles;
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

            var hwnd = (HWND)WinRT.Interop.WindowNative.GetWindowHandle(this);
            LoadIcon(hwnd, "Assets/windows-sdk.ico");
            SetWindowSize(hwnd, 1920, 1080);
        }

        private void LoadIcon(HWND hwnd, string iconName)
        {
            SafeFileHandle hIcon = LoadImage(null, iconName, GDI_IMAGE_TYPE.IMAGE_ICON, 16, 16, IMAGE_FLAGS.LR_LOADFROMFILE);

            SendMessage(hwnd, WM_SETICON, 0, hIcon.DangerousGetHandle());
        }

        private void SetWindowSize(HWND hwnd, int width, int height)
        {
            // Win32 uses pixels and WinUI 3 uses effective pixels, so you should apply the DPI scale factor
            var dpi = GetDpiForWindow(hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            SetWindowPos(hwnd, HWND_TOP, 0, 0, width, height, SET_WINDOW_POS_FLAGS.SWP_NOMOVE);
        }
    }
}
