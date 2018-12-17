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
using MahApps.Metro.Controls;
using System.Diagnostics;
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
        private bool IsChangeCube = false;
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
                btn_mc.IsEnabled = true;
                btn_mr.IsEnabled = true;
                btn_mm.IsEnabled = true;
                btn_mp.IsEnabled = true;
                btn_ms.IsEnabled = true;
                btn_pre.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_squ.IsEnabled = true;
                btn_reci.IsEnabled = true;
                btn_CE.IsEnabled = true;
                btn_C.IsEnabled = true;
                btn_DEL.IsEnabled = true;
                btn_divi.IsEnabled = true;
                btn_9.IsEnabled = true;
                btn_8.IsEnabled = true;
                btn_7.IsEnabled = true;
                btn_6.IsEnabled = true;
                btn_5.IsEnabled = true;
                btn_4.IsEnabled = true;
                btn_3.IsEnabled = true;
                btn_2.IsEnabled = true;
                btn_1.IsEnabled = true;
                btn_0.IsEnabled = true;
                btn_muti.IsEnabled = true;
                btn_add.IsEnabled = true;
                btn_sub.IsEnabled = true;
                btn_equal.IsEnabled = true;
                this.HistoryFlyout.IsOpen = false;
                IsHistoryOpened = false;
            }
            else
            {
                btn_mc.IsEnabled = false;
                btn_mr.IsEnabled = false;
                btn_mm.IsEnabled = false;
                btn_mp.IsEnabled = false;
                btn_ms.IsEnabled = false;
                btn_pre.IsEnabled = false;
                btn_sqrt.IsEnabled = false;
                btn_squ.IsEnabled = false;
                btn_reci.IsEnabled = false;
                btn_CE.IsEnabled = false;
                btn_C.IsEnabled = false;
                btn_DEL.IsEnabled = false;
                btn_divi.IsEnabled = false;
                btn_9.IsEnabled = false;
                btn_8.IsEnabled = false;
                btn_7.IsEnabled = false;
                btn_6.IsEnabled = false;
                btn_5.IsEnabled = false;
                btn_4.IsEnabled = false;
                btn_3.IsEnabled = false;
                btn_2.IsEnabled = false;
                btn_1.IsEnabled = false;
                btn_0.IsEnabled = false;
                btn_muti.IsEnabled = false;
                btn_add.IsEnabled = false;
                btn_sub.IsEnabled = false;
                btn_equal.IsEnabled = false;
                this.HistoryFlyout.IsOpen = true;
                IsHistoryOpened = true;
            }
        }

        private void Btn_Memory_Click(object sender, RoutedEventArgs e)
        {        
            this.MemoryFlyout.Visibility = Visibility.Visible;
            
            if (IsMemoryOpened)
            {
                btn_mc.IsEnabled = true;
                btn_mr.IsEnabled = true;
                btn_mm.IsEnabled = true;
                btn_mp.IsEnabled = true;
                btn_ms.IsEnabled = true;
                btn_pre.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_squ.IsEnabled = true;
                btn_reci.IsEnabled = true;
                btn_CE.IsEnabled = true;
                btn_C.IsEnabled = true;
                btn_DEL.IsEnabled = true;
                btn_divi.IsEnabled = true;
                btn_9.IsEnabled = true;
                btn_8.IsEnabled = true;
                btn_7.IsEnabled = true;
                btn_6.IsEnabled = true;
                btn_5.IsEnabled = true;
                btn_4.IsEnabled = true;
                btn_3.IsEnabled = true;
                btn_2.IsEnabled = true;
                btn_1.IsEnabled = true;
                btn_0.IsEnabled = true;
                btn_muti.IsEnabled = true;
                btn_add.IsEnabled = true;
                btn_sub.IsEnabled = true;
                btn_equal.IsEnabled = true;
                this.MemoryFlyout.IsOpen = false;
                IsMemoryOpened = false;
            }
            else
            {
                btn_muti.IsEnabled = false;
                btn_add.IsEnabled = false;
                btn_sub.IsEnabled = false;
                btn_equal.IsEnabled = false;
                btn_mc.IsEnabled = false;
                btn_mr.IsEnabled = false;
                btn_mm.IsEnabled = false;
                btn_mp.IsEnabled = false;
                btn_ms.IsEnabled = false;
                btn_pre.IsEnabled = false;
                btn_sqrt.IsEnabled = false;
                btn_squ.IsEnabled = false;
                btn_reci.IsEnabled = false;
                btn_CE.IsEnabled = false;
                btn_C.IsEnabled = false;
                btn_DEL.IsEnabled = false;
                btn_divi.IsEnabled = false;
                btn_9.IsEnabled = false;
                btn_8.IsEnabled = false;
                btn_7.IsEnabled = false;
                btn_6.IsEnabled = false;
                btn_5.IsEnabled = false;
                btn_4.IsEnabled = false;
                btn_3.IsEnabled = false;
                btn_2.IsEnabled = false;
                btn_1.IsEnabled = false;
                btn_0.IsEnabled = false;
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
            if (this.Width >= 1025 && this.Height >= 640 && !IsChangeCube)            {                BtnGroup.RowDefinitions.Remove(BtnGroup.RowDefinitions.Last<RowDefinition>());                BtnGroup.ColumnDefinitions.Add(new ColumnDefinition());
                BtnGroup.Children.Add(InitCubeButton());
                //根号改变
                btn_sqrt.SetValue(Grid.RowProperty, 1);                btn_sqrt.SetValue(Grid.ColumnProperty, 0);                btn_sqrt.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //平方
                btn_squ.SetValue(Grid.RowProperty, 2);                btn_squ.SetValue(Grid.ColumnProperty, 0);                btn_squ.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //倒数
                btn_reci.SetValue(Grid.RowProperty, 4);                btn_reci.SetValue(Grid.ColumnProperty, 0);                btn_reci.SetValue(MarginProperty, new Thickness(4, 2, 2, 5));
                //CE
                btn_CE.SetValue(Grid.RowProperty, 0);                btn_CE.SetValue(Grid.ColumnProperty, 1);                btn_CE.SetValue(MarginProperty, new Thickness(2));
                //C
                btn_C.SetValue(Grid.RowProperty, 0);                btn_C.SetValue(Grid.ColumnProperty, 2);
                //退格
                btn_DEL.SetValue(Grid.RowProperty, 0);                btn_DEL.SetValue(Grid.ColumnProperty, 3);
                //除法
                btn_divi.SetValue(Grid.RowProperty, 0);                btn_divi.SetValue(Grid.ColumnProperty, 4);
                //7
                btn_7.SetValue(Grid.RowProperty, 1);                btn_7.SetValue(Grid.ColumnProperty, 1);                btn_7.SetValue(MarginProperty, new Thickness(2));
                //8
                btn_8.SetValue(Grid.RowProperty, 1);                btn_8.SetValue(Grid.ColumnProperty, 2);
                //9
                btn_9.SetValue(Grid.RowProperty, 1);                btn_9.SetValue(Grid.ColumnProperty, 3);
                //乘法
                btn_muti.SetValue(Grid.RowProperty, 1);                btn_muti.SetValue(Grid.ColumnProperty, 4);
                //4
                btn_4.SetValue(Grid.RowProperty, 2);                btn_4.SetValue(Grid.ColumnProperty, 1);                btn_4.SetValue(MarginProperty, new Thickness(2));
                //5
                btn_5.SetValue(Grid.RowProperty, 2);                btn_5.SetValue(Grid.ColumnProperty, 2);
                //6
                btn_6.SetValue(Grid.RowProperty, 2);                btn_6.SetValue(Grid.ColumnProperty, 3);
                //减法
                btn_sub.SetValue(Grid.RowProperty, 2);                btn_sub.SetValue(Grid.ColumnProperty, 4);
                //1
                btn_1.SetValue(Grid.RowProperty, 3);                btn_1.SetValue(Grid.ColumnProperty, 1);                btn_1.SetValue(MarginProperty, new Thickness(2));
                //2
                btn_2.SetValue(Grid.RowProperty, 3);                btn_2.SetValue(Grid.ColumnProperty, 2);
                //3
                btn_3.SetValue(Grid.RowProperty, 3);                btn_3.SetValue(Grid.ColumnProperty, 3);
                //加法
                btn_add.SetValue(Grid.RowProperty, 3);                btn_add.SetValue(Grid.ColumnProperty, 4);
                //正负
                btn_nega.SetValue(Grid.RowProperty, 4);                btn_nega.SetValue(Grid.ColumnProperty, 1);                btn_nega.SetValue(MarginProperty, new Thickness(2, 2, 2, 5));
                //0
                btn_0.SetValue(Grid.RowProperty, 4);                btn_0.SetValue(Grid.ColumnProperty, 2);
                //.
                btn_point.SetValue(Grid.RowProperty, 4);                btn_point.SetValue(Grid.ColumnProperty, 3);
                //等于
                btn_equal.SetValue(Grid.RowProperty, 4);                btn_equal.SetValue(Grid.ColumnProperty, 4);                IsChangeCube = true;            }
            if ((this.Width < 1025 || this.Height < 640) && IsChangeCube)            {                BtnGroup.Children.Remove(BtnGroup.FindChild<Button>("btn_cube"));                BtnGroup.ColumnDefinitions.Remove(BtnGroup.ColumnDefinitions.Last<ColumnDefinition>());                BtnGroup.RowDefinitions.Add(new RowDefinition());
                //根号改变
                btn_sqrt.SetValue(Grid.RowProperty, 0);                btn_sqrt.SetValue(Grid.ColumnProperty, 1);                btn_sqrt.SetValue(MarginProperty, new Thickness(2));
                //平方
                btn_squ.SetValue(Grid.RowProperty, 0);                btn_squ.SetValue(Grid.ColumnProperty, 2);                btn_squ.SetValue(MarginProperty, new Thickness(2));
                //倒数
                btn_reci.SetValue(Grid.RowProperty, 0);                btn_reci.SetValue(Grid.ColumnProperty, 3);                btn_reci.SetValue(MarginProperty, new Thickness(2, 2, 4, 2));
                //CE
                btn_CE.SetValue(Grid.RowProperty, 1);                btn_CE.SetValue(Grid.ColumnProperty, 0);                btn_CE.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //C
                btn_C.SetValue(Grid.RowProperty, 1);                btn_C.SetValue(Grid.ColumnProperty, 1);
                //退格
                btn_DEL.SetValue(Grid.RowProperty, 1);                btn_DEL.SetValue(Grid.ColumnProperty, 2);
                //除法
                btn_divi.SetValue(Grid.RowProperty, 1);                btn_divi.SetValue(Grid.ColumnProperty, 3);
                //7
                btn_7.SetValue(Grid.RowProperty, 2);                btn_7.SetValue(Grid.ColumnProperty, 0);                btn_7.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //8
                btn_8.SetValue(Grid.RowProperty, 2);                btn_8.SetValue(Grid.ColumnProperty, 1);
                //9
                btn_9.SetValue(Grid.RowProperty, 2);                btn_9.SetValue(Grid.ColumnProperty, 2);
                //乘法
                btn_muti.SetValue(Grid.RowProperty, 2);                btn_muti.SetValue(Grid.ColumnProperty, 3);
                //4
                btn_4.SetValue(Grid.RowProperty, 3);                btn_4.SetValue(Grid.ColumnProperty, 0);                btn_4.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //5
                btn_5.SetValue(Grid.RowProperty, 3);                btn_5.SetValue(Grid.ColumnProperty, 1);
                //6
                btn_6.SetValue(Grid.RowProperty, 3);                btn_6.SetValue(Grid.ColumnProperty, 2);
                //减法
                btn_sub.SetValue(Grid.RowProperty, 3);                btn_sub.SetValue(Grid.ColumnProperty, 3);
                //1
                btn_1.SetValue(Grid.RowProperty, 4);                btn_1.SetValue(Grid.ColumnProperty, 0);                btn_1.SetValue(MarginProperty, new Thickness(4, 2, 2, 2));
                //2
                btn_2.SetValue(Grid.RowProperty, 4);                btn_2.SetValue(Grid.ColumnProperty, 1);
                //3
                btn_3.SetValue(Grid.RowProperty, 4);                btn_3.SetValue(Grid.ColumnProperty, 2);
                //加法
                btn_add.SetValue(Grid.RowProperty, 4);                btn_add.SetValue(Grid.ColumnProperty, 3);
                //正负
                btn_nega.SetValue(Grid.RowProperty, 5);                btn_nega.SetValue(Grid.ColumnProperty, 0);                btn_nega.SetValue(MarginProperty, new Thickness(4, 2, 2, 5));
                //0
                btn_0.SetValue(Grid.RowProperty, 5);                btn_0.SetValue(Grid.ColumnProperty, 1);
                //.
                btn_point.SetValue(Grid.RowProperty, 5);                btn_point.SetValue(Grid.ColumnProperty, 2);
                //等于
                btn_equal.SetValue(Grid.RowProperty, 5);                btn_equal.SetValue(Grid.ColumnProperty, 3);                IsChangeCube = false;            }
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
            localm.btn_memory_dustbin.Visibility = Visibility.Hidden;
            Memory m = extensionControl.FindName("localm") as Memory;
            Label me = m.FindName("M") as Label;
            me.Visibility = Visibility.Visible;
            Button dustbin = m.FindName("btn_memory_dustbin") as Button;
            dustbin.Visibility = Visibility.Hidden;
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
        private Button InitCubeButton()        {            Button cubeButton = new Button();            cubeButton = new Button();            cubeButton.SetValue(NameProperty, "btn_cube");            cubeButton.Margin = new Thickness(4, 2, 2, 2);            cubeButton.Style = (Style)this.FindResource("CommonButtonStyle");            cubeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0F0F0"));            cubeButton.FontSize = 18;            cubeButton.Content = "x³";            cubeButton.SetValue(Grid.RowProperty, 3);            cubeButton.SetValue(Grid.ColumnProperty, 0);            cubeButton.FontWeight = FontWeights.UltraLight;            return cubeButton;        }

        private void MetroWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_mopt.IsEnabled == false)
            {
                btn_mc.IsEnabled = false;
                btn_mr.IsEnabled = false;
            }
            else
            {
                btn_mc.IsEnabled = true;
                btn_mr.IsEnabled = true;
            }
            btn_mm.IsEnabled = true;
            btn_mp.IsEnabled = true;
            btn_ms.IsEnabled = true;
            btn_pre.IsEnabled = true;
            btn_sqrt.IsEnabled = true;
            btn_squ.IsEnabled = true;
            btn_reci.IsEnabled = true;
            btn_CE.IsEnabled = true;
            btn_C.IsEnabled = true;
            btn_DEL.IsEnabled = true;
            btn_divi.IsEnabled = true;
            btn_9.IsEnabled = true;
            btn_8.IsEnabled = true;
            btn_7.IsEnabled = true;
            btn_6.IsEnabled = true;
            btn_5.IsEnabled = true;
            btn_4.IsEnabled = true;
            btn_3.IsEnabled = true;
            btn_2.IsEnabled = true;
            btn_1.IsEnabled = true;
            btn_0.IsEnabled = true;
            btn_muti.IsEnabled = true;
            btn_add.IsEnabled = true;
            btn_sub.IsEnabled = true;
            btn_equal.IsEnabled = true;
        }
    }
}
