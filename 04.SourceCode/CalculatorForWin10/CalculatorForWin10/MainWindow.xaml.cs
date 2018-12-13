using CalculatorForWin10.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;
using NumberDefine;

namespace CalculatorForWin10
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        bool _clicked = false;
        MainWindowsViewModel vm=new MainWindowsViewModel();
        Screen s = new Screen();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext =vm;
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }
        

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Max(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click_His(object sender, RoutedEventArgs e)
        {
            History.Visibility = Visibility.Visible;
            Memory.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Mer(object sender, RoutedEventArgs e)
        {
            History.Visibility = Visibility.Hidden;
            Memory.Visibility = Visibility.Visible;
        }

        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            H.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Ms(object sender, RoutedEventArgs e)
        {
            M.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Qc(object sender, RoutedEventArgs e)
        {
            H.Visibility = Visibility.Visible;
        }
        private void Button_Click_Qc1(object sender, RoutedEventArgs e)
        {
            M.Visibility = Visibility.Visible;
        }
        private void Mouse_M(object sender, MouseEventArgs e)
        {
            vm.ResultText = listStockName.SelectedItem.ToString();
        }
        private void Mouse_H(object sender, MouseEventArgs e)
        {
            string[] arr = listStockName1.SelectedItem.ToString().Split(new char[] {'='});
            vm.ResultText = arr[1].Trim();
            vm.ExpressionText = arr[0].Trim();
        }
        
    }
}
