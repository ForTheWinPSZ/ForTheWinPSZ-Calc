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
    /// Memory.xaml 的交互逻辑
    /// </summary>
    public partial class Memory : UserControl
    {
        MainWindowsViewModel vm = new MainWindowsViewModel();
        public Memory()
        {
            InitializeComponent();
        }

        private void Mouse_M(object sender, MouseButtonEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            Label re = main.FindName("re") as Label;
            re.Content = listStockName.SelectedItem.ToString();
            Label ex = main.FindName("ex") as Label;
            ex.Content = "";
        }

        private void Button_Click_Qc1(object sender, RoutedEventArgs e)
        {
            M.Visibility = Visibility.Visible;
        }
    }
}
