using App_.DataBase;
using Windows.UI.Xaml.Controls;

namespace App_
{
    public sealed partial class AmountPage : Page
    {
        public AmountPage()
        {
            this.InitializeComponent();
            {
                amountTB.Text = DataBaseClass.GetAmountOfMoney();
            };
        }
    }
}
