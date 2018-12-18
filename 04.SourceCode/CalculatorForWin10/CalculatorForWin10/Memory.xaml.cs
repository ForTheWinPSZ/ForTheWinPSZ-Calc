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
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace CalculatorForWin10
{
    /// <summary>
    /// Memory.xaml 的交互逻辑
    /// </summary>
    public partial class Memory : UserControl
    {
        private static int count = 0;
        private static int itemCount = 0;
        MainWindowsViewModel vm = new MainWindowsViewModel();
        Window main = Application.Current.MainWindow;
        public Memory()
        {
            InitializeComponent();
            listStockName.ItemContainerGenerator.StatusChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, EventArgs e)
        {
            if (itemCount != listStockName.Items.Count)
            {
                count++;
                if (count % 2 == 0)
                {
                    ListBoxItem firstItem = listStockName.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
                    firstItem.Opacity = 0;
                    if (count == 4)
                    {
                        DoubleAnimation itemAnimation1 = new DoubleAnimation();
                        itemAnimation1.From = 0;
                        itemAnimation1.To = firstItem.ActualHeight;
                        itemAnimation1.Duration = TimeSpan.FromSeconds(0.1);
                        itemAnimation1.BeginTime = TimeSpan.FromSeconds(0);
                        firstItem.BeginAnimation(HeightProperty, itemAnimation1);
                        DoubleAnimation itemAnimation = new DoubleAnimation();
                        itemAnimation.From = 0;
                        itemAnimation.To = 1;
                        itemAnimation.Duration = TimeSpan.FromSeconds(0.3);
                        itemAnimation.BeginTime = TimeSpan.FromSeconds(0.3);
                        firstItem.BeginAnimation(OpacityProperty, itemAnimation);
                        ThicknessAnimation itemMarginAnimation = new ThicknessAnimation();
                        itemMarginAnimation.From = new Thickness(-5, 0, 5, 0);
                        itemMarginAnimation.To = new Thickness(-5, 0, 0, 0);
                        itemMarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
                        itemMarginAnimation.BeginTime = TimeSpan.FromSeconds(0.3);
                        firstItem.BeginAnimation(MarginProperty, itemMarginAnimation);
                        itemCount = listStockName.Items.Count;
                        count = 0;
                    }
                }

            }
        }
        private void Mouse_M(object sender, MouseButtonEventArgs e)
        {
            Label re = main.FindName("re") as Label;
            re.Content = listStockName.SelectedItem.ToString();
            Label ex = main.FindName("ex") as Label;
            ex.Content = "";
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
