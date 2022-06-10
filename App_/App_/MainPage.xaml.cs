using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App_
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AmountPage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if(args.IsSettingsSelected)
            {

            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch(item.Tag.ToString())
                {
                    case "Amount":
                        ContentFrame.Navigate(typeof(AmountPage));
                        break;
                    case "Operation":
                        ContentFrame.Navigate(typeof(NewOperationPage));
                        break;
                    case "History":
                        ContentFrame.Navigate(typeof(HistoryPage));
                        break;
                }
            }
        }
    }
}
