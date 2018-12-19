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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections.Specialized;

namespace CalculatorForWin10
{
    /// <summary>
    /// History.xaml 的交互逻辑
    /// </summary>
    public partial class History : UserControl
    {
        private static int count = 0;
        private static int itemCount = 0;
        MainWindowsViewModel vm = new MainWindowsViewModel();
        public History()
        {
            InitializeComponent();           
            listStockName1.ItemContainerGenerator.StatusChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, EventArgs e)
        {
            if(itemCount != listStockName1.Items.Count)
            {
                count++;
                if(count % 2 == 0)
                {
                    ListBoxItem firstItem = listStockName1.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
                    firstItem.Opacity = 0;
                    if(count == 4)
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
                        itemAnimation.BeginTime = TimeSpan.FromSeconds(0.6);
                        firstItem.BeginAnimation(OpacityProperty, itemAnimation);
                        ThicknessAnimation itemMarginAnimation = new ThicknessAnimation();
                        itemMarginAnimation.From = new Thickness(-5, 0, 5, 0);
                        itemMarginAnimation.To = new Thickness(-5, 0, 0, 0);
                        itemMarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
                        itemMarginAnimation.BeginTime = TimeSpan.FromSeconds(0.6);
                        firstItem.BeginAnimation(MarginProperty, itemMarginAnimation);
                        itemCount = listStockName1.Items.Count;
                        count = 0;
                    }
                }
            }
        }

        private void Mouse_H(object sender, MouseButtonEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            string[] arr = listStockName1.SelectedItem.ToString().Split(new char[] { '=' });
            Label ex = main.FindName("ex") as Label;
            TextBox re = main.FindName("re") as TextBox;
            ex.Content = arr[0].Trim();
            re.Text = arr[1].Trim();
        }

        private void Button_Click_Qc(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("test3");
            H.Visibility = Visibility.Visible;
            btn_history_dustbin.Visibility = Visibility.Hidden;
        }

        
    }
}
