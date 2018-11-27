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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool isFirstInput = true;   //是否第一次输入
		private string lastVal = "";         //双目运算的前一个数
		private string symbol = "";         //保存 当前运算符合,只有双目
		private bool isCanCalc = false;     //判断在按下双目运算符后 是进行计算 还是修改已有的Symbol
		private bool isClr = false;         //是否在输入框有数字的情况下,重新输入;

		public MainWindow()
		{
			InitializeComponent();
			beforeText.Text = "";          //表达式框
			resultText.Text = "0";         //输入框    
		}
		private void btnNum_Click(object sender, RoutedEventArgs e)
		{
			string numStr = (sender as Button).Content.ToString();   

			if (isClr == true)
			{                        //进行 这步操作, 接下了的if就会运行 < resultText.Text == "0" > 下的,
				resultText.Text = "0";                       //以此到达重新输入的目的
				isClr = false;
			}

			if (resultText.Text == "0")
				resultText.Text = numStr;
			else
				resultText.Text += numStr;

			if (isFirstInput == false)                  //排除了第一次输入后, 按下数字键,都表明可以进行计算
				isCanCalc = true;
		}
		private void btn_point_Click(object sender, RoutedEventArgs e)
		{
			string str = (sender as Button).Content.ToString();   // str即“.”

			if (resultText.Text.IndexOf(str) == -1)      
			{                                       
													// 只有输入框无小数点时,才可以添加 '.'
				resultText.Text += str;
			}
		}

		private void btn_nega_Click(object sender, RoutedEventArgs e) //取反
        {
			string str = resultText.Text;              
			double val = double.Parse(str);         
			val = -val;                             
			resultText.Text = val.ToString();
		}

		private void btn_sqrt_Click(object sender, RoutedEventArgs e)
		{
			string str = resultText.Text;                //取出显示的文本(输入的数字)
			double val = double.Parse(str);         //通过 double.Parse() 将 string类型 转换为 double leix

			if (val < 0)                             //负数开不了平方根
				resultText.Text = "无效输入";
			else
				val = Math.Sqrt(val);               //调用库函数 计算 平方根

			resultText.Text = val.ToString();        //重新显示出去( 赋值给Ctext.Text )
		}

		private void btn_reci_Click(object sender, RoutedEventArgs e)
		{
			string str = resultText.Text;                //取出显示的文本(输入的数字)
			double val = double.Parse(str);         //通过 double.Parse() 将 string类型 转换为 double leix
			if (val == 0.0)
				resultText.Text = "除数不能为零";
			else
				val = 1 / val;                      //取倒数


		}

		private void btn_DEL_Click(object sender, RoutedEventArgs e)
		{
			string str = resultText.Text;                //取出显示的文本(输入的数字)
			if (str.Length == 1)                         //如果显示的一个数字,将他变成0
				str = "0";
			else                                         //其他的 取前面的 n-1 个字符
				str = str.Substring(0, str.Length - 1);
			resultText.Text = str;
		}

		private void btn_CE_Click(object sender, RoutedEventArgs e)
		{
			resultText.Text = "0";   //清空当前输入
		}

		private void btn_cal_Click(object sender, RoutedEventArgs e)
		{
			string NowSymbol = (sender as Button).Content.ToString();
			double result;
			//如是第一次输入
			if (isFirstInput == true)
			{
				lastVal = resultText.Text;   //将当前的值赋给 lastVal
				symbol = NowSymbol;     //将取得计算符合传进symbol
				resultText.Text = "0";       //刷新输入 为输入下一个数做准备
				isFirstInput = false;   //已经完成 第一次输入 

				//添加到 RText
				beforeText.Text = lastVal + symbol; //显示第一个数和运算符合
				isCanCalc = false;      //没有输入第二个数 不能进行计算
			}
			else if (isCanCalc == true)    //如果允许计算
			{
				result = Calc(double.Parse(lastVal), double.Parse(resultText.Text), symbol); //计算函数
				beforeText.Text = beforeText.Text + resultText.Text + NowSymbol;   //更新 beforeText 的显示
				lastVal = resultText.Text = result.ToString();             //更新 lastVal 和 resultText 的值
				symbol = NowSymbol;                                 //更新 新的待执行的双目运算的符合
				isClr = true;                                       //允许清空 当前resultText的显示
				isCanCalc = false;                                  //没有输入输入下一个数,再次按下双目运算按钮,只能修改当前symbol的值
			}
			else
			{
				symbol = NowSymbol;     //不允许计算, 只能修改当前symbol的值
				resultText.Text = resultText.Text.Substring(0, resultText.Text.Length - 1) + symbol; //更新 Rext 的显示
			}
		}
		private double Calc(double v1, double v2, string symbol)
		{
			double result = 0.0;
			switch (symbol)
			{
				case "＋":
					result = v1 + v2;
					break;
				case "－":
					result = v1 - v2;
					break;
				case "×":
					result = v1 * v2;
					break;
				case "÷":
					result = v1 / v2;
					break;
			}

			return result;
		}

		private void btn_equal_Click(object sender, RoutedEventArgs e)
		{
			beforeText.Text = "";            //清空Text
			if (isFirstInput == false)     //判断是不是 第一次输入,不是就计算一次 , 是的话 就直接不用修改
				resultText.Text = Calc(double.Parse(lastVal), double.Parse(resultText.Text), symbol).ToString();

			isFirstInput = true;        //
			isClr = true;               //
		}

		private void btn_C_Click(object sender, RoutedEventArgs e)
		{
			//初始化
			beforeText.Text = "";
			resultText.Text = "0";
			isFirstInput = true;
			lastVal = "";
			symbol = "";
			isCanCalc = false;
			isClr = false;
		}

        private void Btn_pre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResultText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
