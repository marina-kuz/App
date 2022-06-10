using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using App_.DataBase;

namespace App_
{
    public sealed partial class HistoryPage : Page
    {
        public ObservableCollection<History> list;
        public HistoryPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            list = DataBaseClass.GetAllData();
            dataGrid.ItemsSource = list;
        }
    }
}
