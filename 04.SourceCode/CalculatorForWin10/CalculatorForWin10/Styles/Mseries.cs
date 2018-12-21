using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace CalculatorForWin10.Styles
{
    public partial class Mseries : ResourceDictionary
    {
        public Mseries()
        {
            InitializeComponent();
        }

        static double result;
        public void Click_MC(object sender, RoutedEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            Memory localm = main.FindName("localm") as Memory;
            ListBox listStockName = localm.FindName("listStockName") as ListBox;
            //ListBoxItem item = listStockName.SelectedItem as ListBoxItem;
            //item.Visibility = Visibility.Collapsed;
        }
        public void Click_Mplus(object sender, RoutedEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            TextBox t = main.FindName("re") as TextBox;
            string r = t.Text;
            Memory localm = main.FindName("localm") as Memory;
            ListBox listStockName = localm.FindName("listStockName") as ListBox;
            string s = listStockName.SelectedItem.ToString();
            result = Convert.ToDouble(r) + Convert.ToDouble(s);
            MessageBox.Show(result.ToString());
        }
        public void Click_Mminus(object sender, RoutedEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            TextBox t = main.FindName("re") as TextBox;
            string r = t.Text;
            Memory localm = main.FindName("localm") as Memory;
            ListBox listStockName = localm.FindName("listStockName") as ListBox;
            string s = listStockName.SelectedItem.ToString();
            result = Convert.ToDouble(r) - Convert.ToDouble(s);
            MessageBox.Show(result.ToString());
        }
    }
}
