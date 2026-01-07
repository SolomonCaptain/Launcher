using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Launcher.Pages;

namespace Launcher
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            NavView.ItemInvoked += NavView_ItemInvoked;
            NavView.BackRequested += NavView_BackRequested;
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var invokedItem = args.InvokedItemContainer as NavigationViewItem;
            if (invokedItem == null) return;

            switch (invokedItem.Tag?.ToString())
            {
                case "home":
                    ContentFrame.Navigate(typeof(HomePage));
                    break;
                case "settings":
                    ContentFrame.Navigate(typeof(SettingsPage));
                    break;
                default:
                    break;
            }
        }
    }
}