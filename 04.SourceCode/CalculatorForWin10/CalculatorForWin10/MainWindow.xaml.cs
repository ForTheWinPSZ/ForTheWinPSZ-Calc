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
using MahApps.Metro.Controls;
namespace CalculatorForWin10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool IsHistoryOpened = false;
        private bool IsMemoryOpened = false;
        private bool Arrived = false;
        private Grid extension;
        private UserControl extensionControl;
        private UserControl historyControl;
        private UserControl memoryControl;
        private Style titleStyle;
        private Style maxTitleStyle;
        MainWindowsViewModel vm = new MainWindowsViewModel();
        Screen s = new Screen();
        public MainWindow()
        {
            extensionControl = new Extension();
            historyControl = new History();
            memoryControl = new Memory();
            extension = new Grid();
            extension.Width = 320;
            extension.SetValue(Grid.ColumnProperty, 1);
            extension.SetValue(NameProperty, "Second");
            extension.Children.Add(extensionControl);
            titleStyle = (Style)this.FindResource("TitleButtonStyle");
            maxTitleStyle = (Style)this.FindResource("MaxButtonStyle");

            InitializeComponent();
            this.DataContext = vm;
        }

        private void MetroWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Btn_Max_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                Max_Button.Style = titleStyle;
                Max_Button.Padding = new Thickness(0,0,0,5);
            }
            else
            {
                WindowState = WindowState.Maximized;
                Max_Button.Style = maxTitleStyle;
                Max_Button.Padding = new Thickness(0);
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_History_Click(object sender, RoutedEventArgs e)
        {
            this.HistoryFlyout.Visibility = Visibility.Visible;
            if (IsHistoryOpened)
            {
                this.HistoryFlyout.IsOpen = false;
                IsHistoryOpened = false;
            }
            else
            {
                this.HistoryFlyout.IsOpen = true;
                IsHistoryOpened = true;
            }
        }

        private void Btn_Memory_Click(object sender, RoutedEventArgs e)
        {        
            this.MemoryFlyout.Visibility = Visibility.Visible;
            if (IsMemoryOpened)
            {
                this.MemoryFlyout.IsOpen = false;
                IsMemoryOpened = false;
            }
            else
            {
                this.MemoryFlyout.IsOpen = true;
                IsMemoryOpened = true;
            }
        }

        private void MetroWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.MemoryFlyout.IsOpen = false;
            this.HistoryFlyout.IsOpen = false;
            IsHistoryOpened = false;
            IsMemoryOpened = false;
            if (this.Width > 624 && Arrived == false)
            {
                this.MaxWidth = SystemParameters.WorkArea.Width;
                ColumnDefinition col2 = new ColumnDefinition();
                col2.MinWidth = 320;
                col2.MaxWidth = 320;
                Main.ColumnDefinitions.Add(col2);
                Main.Children.Add(extension);
                btn_history.Visibility = Visibility.Hidden;
                btn_mopt.Visibility = Visibility.Hidden;
                Arrived = true;
            }

            if (this.Width <= 624 && Arrived == true)
            {
                extension = Main.FindChild<Grid>("Second");
                Main.Children.Remove(extension);
                Main.ColumnDefinitions.RemoveAt(1);
                btn_history.Visibility = Visibility.Visible;
                btn_mopt.Visibility = Visibility.Visible;
                Arrived = false;
            }
        }
        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            localh.H.Visibility = Visibility.Hidden;
            localh.btn_history_dustbin.Visibility = Visibility.Visible;
            History h = extensionControl.FindName("localh") as History;
            Label hi = h.FindName("H") as Label;
            hi.Visibility = Visibility.Hidden;
            Button dustbin = h.FindName("btn_history_dustbin") as Button;
            dustbin.Visibility = Visibility.Visible;
        }
        private void Button_Click_Ms(object sender, RoutedEventArgs e)
        {
            localm.M.Visibility = Visibility.Hidden;
            localm.btn_memory_dustbin.Visibility = Visibility.Visible;
            Memory m = extensionControl.FindName("localm") as Memory;
            Label me =m.FindName("M") as Label;
            me.Visibility = Visibility.Hidden;
            Button dustbin= m.FindName("btn_memory_dustbin") as Button;
            dustbin.Visibility = Visibility.Visible;
            btn_mc.IsEnabled = true;
            btn_mr.IsEnabled = true;
            btn_mopt.IsEnabled = true;
        }
        private void Button_Click_Qc1(object sender, RoutedEventArgs e)
        {
            localm.M.Visibility = Visibility.Visible;
            Memory m = extensionControl.FindName("localm") as Memory;
            Label me = m.FindName("M") as Label;
            me.Visibility = Visibility.Visible;
            btn_mc.IsEnabled = false;
            btn_mr.IsEnabled = false;
            btn_mopt.IsEnabled = false;
        }

        private void Btn_mp_Click(object sender, RoutedEventArgs e)
        {
            localm.M.Visibility = Visibility.Hidden;
            localm.btn_memory_dustbin.Visibility = Visibility.Visible;
            Memory m = extensionControl.FindName("localm") as Memory;
            Label me = m.FindName("M") as Label;
            me.Visibility = Visibility.Hidden;
            Button dustbin = m.FindName("btn_memory_dustbin") as Button;
            dustbin.Visibility = Visibility.Visible;
            btn_mc.IsEnabled = true;
            btn_mr.IsEnabled = true;
            btn_mopt.IsEnabled = true;
        }

        private void Btn_mm_Click(object sender, RoutedEventArgs e)
        {
            localm.M.Visibility = Visibility.Hidden;
            localm.btn_memory_dustbin.Visibility = Visibility.Visible;
            Memory m = extensionControl.FindName("localm") as Memory;
            Label me = m.FindName("M") as Label;
            me.Visibility = Visibility.Hidden;
            Button dustbin = m.FindName("btn_memory_dustbin") as Button;
            dustbin.Visibility = Visibility.Visible;
            btn_mc.IsEnabled = true;
            btn_mr.IsEnabled = true;
            btn_mopt.IsEnabled = true;
        }
    }
}
