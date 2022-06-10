using Windows.UI.Xaml.Controls;
using ClassLibrary;

namespace App_
{
    public sealed partial class AmountPage : Page
    {
        public AmountPage()
        {
            this.InitializeComponent();
            {
                amountTB.Text = Class.GetAmountOfMoney();
            };
        }
    }
}
