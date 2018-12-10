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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;
namespace CalculatorForWin10
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        bool _clicked = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowsViewModel();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_clicked)
            {
                main.Width = 360;
                smallClose.Visibility = Visibility.Visible;
                smallMin.Visibility = Visibility.Visible;
                smallMax.Visibility = Visibility.Visible;
                bigClose.Visibility = Visibility.Hidden;
                bigMin.Visibility = Visibility.Hidden;
                bigMax.Visibility = Visibility.Hidden;
                _clicked = false;
            }
            else
            {
                main.Width = 700;
                bigClose.Visibility = Visibility.Visible;
                bigMin.Visibility = Visibility.Visible;
                bigMax.Visibility = Visibility.Visible;
                smallClose.Visibility = Visibility.Hidden;
                smallMin.Visibility = Visibility.Hidden;
                smallMax.Visibility = Visibility.Hidden;
                _clicked = true;
            }
            
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Max(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                if (_clicked)
                {
                    bigClose.Visibility = Visibility.Visible;
                    bigMin.Visibility = Visibility.Visible;
                    bigMax.Visibility = Visibility.Visible;
                    smallClose.Visibility = Visibility.Hidden;
                    smallMin.Visibility = Visibility.Hidden;
                    smallMax.Visibility = Visibility.Hidden;
                }
                else
                {
                    smallClose.Visibility = Visibility.Visible;
                    smallMin.Visibility = Visibility.Visible;
                    smallMax.Visibility = Visibility.Visible;
                    bigClose.Visibility = Visibility.Hidden;
                    bigMin.Visibility = Visibility.Hidden;
                    bigMax.Visibility = Visibility.Hidden;
                }
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                bigClose.Visibility = Visibility.Visible;
                bigMin.Visibility = Visibility.Visible;
                bigMax.Visibility = Visibility.Visible;
                smallClose.Visibility = Visibility.Hidden;
                smallMin.Visibility = Visibility.Hidden;
                smallMax.Visibility = Visibility.Hidden;
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
    }
}
