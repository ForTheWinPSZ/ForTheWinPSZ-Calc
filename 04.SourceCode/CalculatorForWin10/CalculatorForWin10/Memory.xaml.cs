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
        Window main = Application.Current.MainWindow;
        public Memory()
        {
            InitializeComponent();
        }

        private void Mouse_M(object sender, MouseButtonEventArgs e)
        {
            //Label re = main.FindName("re") as Label;
            //re.Content = listStockName.SelectedItem.ToString();
            //Label ex = main.FindName("ex") as Label;
            //ex.Content = "";
            string s = listStockName.SelectedItem.ToString();
           // vm.UseMemory(s);
        }

        private void Button_Click_Qc1(object sender, RoutedEventArgs e)
        {
            M.Visibility = Visibility.Visible;
            Button mc = main.FindName("btn_mc") as Button;
            mc.IsEnabled = false;
            Button mr = main.FindName("btn_mr") as Button;
            mr.IsEnabled = false;
            Button mopt = main.FindName("btn_mopt") as Button;
            mopt.IsEnabled = false;
            btn_memory_dustbin.Visibility = Visibility.Hidden;
        }
        
    }
}
