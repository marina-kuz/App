using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace App_
{
    public sealed partial class AmountPage : Page
    {
        public List<Person> person { get; set; }
        public AmountPage()
        {
            this.InitializeComponent();
            person = new List<Person>
            {
                new Person {Id=1, Amount_money=1000 }
            };
        }
    }
}
