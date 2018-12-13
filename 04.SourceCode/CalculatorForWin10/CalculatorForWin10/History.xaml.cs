using CalculatorForWin10.ViewModel;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorForWin10
{
    /// <summary>
    /// History.xaml 的交互逻辑
    /// </summary>
    public partial class History : UserControl
    {
        MainWindowsViewModel vm = new MainWindowsViewModel();
        public History()
        {
            InitializeComponent();
        }

        private void Mouse_H(object sender, MouseButtonEventArgs e)
        {
            string[] arr = listStockName1.SelectedItem.ToString().Split(new char[] { '=' });
            vm.ResultText = arr[1].Trim();
            vm.ExpressionText = arr[0].Trim();
        }

        private void Button_Click_Qc(object sender, RoutedEventArgs e)
        {
            H.Visibility = Visibility.Visible;
        }
    }
}
