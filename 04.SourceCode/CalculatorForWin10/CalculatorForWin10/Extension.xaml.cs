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
using System.Windows.Media.Animation;

namespace CalculatorForWin10
{
    /// <summary>
    /// Extension.xaml 的交互逻辑
    /// </summary>
    public partial class Extension : UserControl
    {
        private bool IsHistoryOpened = true;
        public Extension()
        {
            InitializeComponent();
        }

        private void His_Click(object sender, RoutedEventArgs e)
        {
            his_lab.Visibility = Visibility.Visible;
            mem_lab.Visibility = Visibility.Hidden;
            if (IsHistoryOpened == false)
            {
                MemoryLeave();
                HistoryEnter();
                IsHistoryOpened = true;
                his_Control.SetValue(Panel.ZIndexProperty, 1);
                mem_Control.SetValue(Panel.ZIndexProperty, 0);
            }
        }

        private void Mem_Click(object sender, RoutedEventArgs e)
        {
            his_lab.Visibility = Visibility.Hidden;
            mem_lab.Visibility = Visibility.Visible;
            if (IsHistoryOpened == true)
            {
                HistoryLeave();
                MemoryEnter();
                IsHistoryOpened = false;
                his_Control.SetValue(Panel.ZIndexProperty, 0);
                mem_Control.SetValue(Panel.ZIndexProperty, 1);
            }
        }

        private void HistoryLeave()
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 1;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.005);
            his_Control.BeginAnimation(OpacityProperty, OpacityAnimation);
            ThicknessAnimation MarginAnimation = new ThicknessAnimation();
            MarginAnimation.From = new Thickness(0, 0, 0, 0);
            MarginAnimation.To = new Thickness(-20, 0, 0, 0);
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
            extensionButtom.BeginAnimation(MarginProperty, MarginAnimation);
        }

        private void HistoryEnter()
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            his_Control.BeginAnimation(OpacityProperty, OpacityAnimation);
            ThicknessAnimation MarginAnimation = new ThicknessAnimation();
            MarginAnimation.From = new Thickness(-20, 0, 0, 0);
            MarginAnimation.To = new Thickness(0, 0, 0, 0);
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
            extensionButtom.BeginAnimation(MarginProperty, MarginAnimation);
        }

        private void MemoryLeave()
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 1;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.005);
            mem_Control.BeginAnimation(OpacityProperty, OpacityAnimation);
            ThicknessAnimation MarginAnimation = new ThicknessAnimation();
            MarginAnimation.From = new Thickness(0, 0, 0, 0);
            MarginAnimation.To = new Thickness(30, 0, 0, 0);
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
            extensionButtom.BeginAnimation(MarginProperty, MarginAnimation);
        }

        private void MemoryEnter()
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            mem_Control.BeginAnimation(OpacityProperty, OpacityAnimation);
            ThicknessAnimation MarginAnimation = new ThicknessAnimation();
            MarginAnimation.From = new Thickness(30, 0, 0, 0);
            MarginAnimation.To = new Thickness(0, 0, 0, 0);
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.3);
            extensionButtom.BeginAnimation(MarginProperty, MarginAnimation);
        }
    }
}
