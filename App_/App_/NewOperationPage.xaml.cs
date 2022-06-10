using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Text.RegularExpressions;
using App_.DataBase;
using Windows.Storage;

namespace App_
{
    public sealed partial class NewOperationPage : Page
    {
        string operation; //строка для хранения выбранной операции, которая пойдет в БД
        string category; //строка для хранения выбранной категории, которая пойдет в БД
        public NewOperationPage()
        {
            this.InitializeComponent();
            operation = null;
            category=null;
        }

        //Добавление новых данных в БД
        private void addItem()
        {
            //новое число, которое надо будет суммировать к основному бюджету
            int m=0;
            //новая сумма бюджета
            int amount;
            if(operation=="Расход")
            {
                m += int.Parse(summTB.Text) * (-1); 
            }
            else
            {
                m += int.Parse(summTB.Text);
            }
            amount = int.Parse(DataBaseClass.GetAmountOfMoney())+ m;
            string tt = DateTime.Now.Hour.ToString()+":"+ DateTime.Now.Minute.ToString();
            //добавляем новые данные в БД
            DataBaseClass.AddData(amount,operation, DateTime.Now.ToString(), m,category, commentsTB.Text);
        }
        //изменение категории
        private void categoriesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //если элемент comboBox не пустое
            if (categoriesCB.SelectedIndex != -1)
            {
                var comboBoxItem = categoriesCB.Items[categoriesCB.SelectedIndex] as ComboBoxItem;
                string selectedcmb = comboBoxItem.Content.ToString();
                category = selectedcmb;//сохраняем выбранную категорию в переменную в виде string
            }
        }
        //изменение операции
        private void operationsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> income=new List<string> { "Заработная плата", "Возврат долга", "Дивиденты" };
            List<string> expense = new List<string> { "Развлечения", "Еда", "Транспорт" };
            //если элемент comboBox не пустое
            if (operationsCB.SelectedIndex != -1)
            {
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
        }
        //меняем элементы в comboBox категории в зависимости от типа операции
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
        //проверка перед записью на правильность заполнения полей
        private void check_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); //через рег.выражения проверяем что в поле "Сумма" введено число
            //Проверка на пустоту
            if (regex.IsMatch(summTB.Text))
            {
                errorsTB.Text = "Сумма должна состоять из цифр!"; //Вывод ошибки
            }
            else if(operationsCB.SelectedIndex>-1 && categoriesCB.SelectedIndex > -1 && commentsTB.Text!="" && summTB.Text!="") 
            {
                addItem();
                errorsTB.Text = "Запись добавлена!";
            }
            else
            {
                errorsTB.Text="Не все поля заполнены!"; 
            }
        }
        //очистка полей
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            operation=null;
            category=null;
            commentsTB.Text = "";
            summTB.Text = "";
            operationsCB.SelectedIndex = -1;
            categoriesCB.SelectedIndex = -1;
            categoriesCB.Items.Clear();
        }
    }
}
