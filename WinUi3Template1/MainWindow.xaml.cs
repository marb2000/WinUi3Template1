using Microsoft.UI.Xaml;
using System;

namespace WinUi3Template1
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Title = Settings.FeatureName;

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            LoadIcon(hwnd,"Assets/windows-sdk.ico");
            SetWindowSize(hwnd, 1920, 1080);
        }

        private void LoadIcon(IntPtr hwnd, string iconName)
        {

            IntPtr hIcon = PInvoke.User32.LoadImage(IntPtr.Zero, iconName,
                PInvoke.User32.ImageType.IMAGE_ICON, 16, 16, PInvoke.User32.LoadImageFlags.LR_LOADFROMFILE);

            PInvoke.User32.SendMessage(hwnd, PInvoke.User32.WindowMessage.WM_SETICON, (IntPtr)0, hIcon);
        }
        private void SetWindowSize(IntPtr hwnd, int width, int height)
        {
            // Win32 uses pixels and WinUI 3 uses effective pixels, so you should apply the DPI scale factor
            var dpi = PInvoke.User32.GetDpiForWindow(hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
                                        0, 0, width, height,
                                        PInvoke.User32.SetWindowPosFlags.SWP_NOMOVE);
        }
    }
}
