using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUi3Template1
{

    public sealed partial class Scenario1_ShortName : Page
    {

        private MainPage rootPage = MainPage.Current;
        public Scenario1_ShortName()
        {
            this.InitializeComponent();
        }

        private void StatusMessage_Click(object sender, RoutedEventArgs e)
        {
            rootPage.NotifyUser("Hello",InfoBarSeverity.Informational);
        }

        private void ErrorMessage_Click(object sender, RoutedEventArgs e)
        {
            rootPage.NotifyUser("Oh dear.\nSomething went wrong. Very wrong.", InfoBarSeverity.Error);
        }

        private void ClearMessage_Click(object sender, RoutedEventArgs e)
        {
            rootPage.NotifyUser("", InfoBarSeverity.Informational,false);
        }
    }
}
