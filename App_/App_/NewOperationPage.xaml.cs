using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace App_
{
    public sealed partial class NewOperationPage : Page
    {
        string operation;
        string category;
        public NewOperationPage()
        {
            this.InitializeComponent();
            operation = null;
        }

        private void addItem()
        {
            int m=0;
            int amount = 0;
            if(operation=="Расход")
            {
                m += int.Parse(summTB.Text) * (-1);
            }
            else
            {
                m += int.Parse(summTB.Text);
            }
            amount = int.Parse(Class.GetAmountOfMoney())+ m;
            Class.AddData(amount,operation, DateTime.Now.ToShortDateString(),
                    m,category, commentsTB.Text);
        }
        private void categoriesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = categoriesCB.Items[categoriesCB.SelectedIndex] as ComboBoxItem;
            string selectedcmb = comboBoxItem.Content.ToString();
            category = selectedcmb;
        }

        private void operationsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> income=new List<string> { "Заработная плата", "Возврат долга", "Дивиденты" };
            List<string> expense = new List<string> { "Развлечения", "Еда", "Транспорт" };
            var comboBoxItem = operationsCB.Items[operationsCB.SelectedIndex] as ComboBoxItem;
            string selectedcmb = comboBoxItem.Content.ToString();

            switch (selectedcmb)
            {
                case "Доход": 
                    operation = "Доход";
                    addItemsInComboBox(income);
                    break;
                case "Расход": 
                    operation = "Расход";
                    addItemsInComboBox(expense);
                    break;
            }
        }
        private void addItemsInComboBox(List<string> str)
        {
            categoriesCB.Items.Clear();
            for (int i=0; i<str.Count;i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = str[i].ToString();
                categoriesCB.Items.Add(item);
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(summTB.Text))
            {
                test.Text = "Сумма должна состоять из цифр!";
            }
            else if(operationsCB.SelectedIndex>-1 && categoriesCB.SelectedIndex > -1 
                && commentsTB.Text!=null && summTB.Text!=null)
            {
                addItem();
            }
            else
            {
                test.Text = "Не все поля заполнены!";
            }
        }
    }
}
