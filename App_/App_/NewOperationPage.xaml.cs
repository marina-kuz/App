using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;

namespace App_
{
    public sealed partial class NewOperationPage : Page
    {
        ObservableCollection<History> histories;
        List<Person> amount;

        int operation;
        string category;
        public NewOperationPage()
        {
            this.InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if(regex.IsMatch(summTB.Text))
            {
                test.Text = "Используйте только цифры!";
            }
            else
            {
                
            }
        }

        private void categoriesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = categoriesCB.Items[categoriesCB.SelectedIndex] as ComboBoxItem;
            string selectedcmb = comboBoxItem.Content.ToString();
            category = selectedcmb;
            
        }

        private void operationsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = operationsCB.Items[operationsCB.SelectedIndex] as ComboBoxItem;
            string selectedcmb = comboBoxItem.Content.ToString();

            switch (selectedcmb)
            {
                case "Доход": operation = 1;
                    categoriesCB.ItemsSource = new List<string> { "Заработная плата", "Возврат долга", "Дивиденты" };
                    break;
                case "Расход": operation = 0;
                    categoriesCB.ItemsSource = new List<string> { "Развлечения", "Еда", "Транспорт" };
                    break;
            }
        }
    }
}
