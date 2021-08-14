﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using System;
using System.Linq;
using System.Reflection;


namespace WinUi3Template1
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Settings.CurrentTheme is null)
            {
                Settings.CurrentTheme = this.RequestedTheme.ToString();
            }
            themePanel.Children.Cast<RadioButton>().FirstOrDefault(c => c?.Tag?.ToString() == Settings.CurrentTheme).IsChecked = true;

            base.OnNavigatedTo(e);
        }

        void OnThemeRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var selectedTheme = ((RadioButton)sender)?.Tag?.ToString();
            if (selectedTheme is not null)
            {
                Grid content = MainPage.Current.Content as Grid;
                if (content is not null)
                {
                    content.RequestedTheme = GetEnum<ElementTheme>(selectedTheme);
                    Settings.CurrentTheme = content.RequestedTheme.ToString();
                }
            }
        }

        private TEnum GetEnum<TEnum>(string text) where TEnum : struct
        {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
            {
                throw new InvalidOperationException("Generic parameter 'TEnum' must be an enum.");
            }
            return (TEnum)Enum.Parse(typeof(TEnum), text);
        }

    }
}
