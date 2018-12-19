using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic.UnaryOperation;
using Arithmetic.BinaryOperaion;
using static System.Convert;
using System.Diagnostics;

namespace Arithmetic
{
    public static class ScientificCalculationTool
    {
        //平方
        public static string Square(string num)
        {
            string str = "";            
            str = ScientficNum(num);
            string left = str.Substring(0, str.IndexOf("e"));
            string right = str.Substring(str.LastIndexOf("e") + 1);
            decimal left1 = ToDecimal(left.Trim());
            int right1 = ToInt32(right.Trim());
            left1 = left1 * left1;
            right1 = right1 + right1;
            //将e左边平方后变为个位数
            str=RegulateNum(left1, right1);            
            return str;
        }
        //加减
        public static string Plus(string num1,string num2)
        {
            string str = "";
            num1 = ScientficNum(num1);
            num2 = ScientficNum(num2);
            int right1 = ToInt32(num1.Substring(num1.IndexOf('e')+1));
            int right2 = ToInt32(num2.Substring(num2.IndexOf('e') + 1));
            decimal left1 = ToDecimal(num1.Substring(0, num1.IndexOf('e')));
            decimal left2 = ToDecimal(num2.Substring(0, num2.IndexOf('e')));
            decimal left;
            int right;
            if (right1 >= right2)
            {
                int len = right1 - right2;
                if (len > 0)
                {
                    StringBuilder tem = new StringBuilder("0.");
                    tem.Append('0', len - 1);
                    left2 = ToDecimal(tem.Append(left2.ToString().Replace(".", "").Trim('0')).ToString());
                }          
                left = left1 + left2;
                right = right1;
            }
            else
            {
                //left1 = left1 / ToDecimal(Math.Pow(10, right2 - right1));
                int len = right2 - right1;
                StringBuilder tem = new StringBuilder("0.");
                tem.Append('0', len - 1);
                left1 = ToDecimal(tem.Append(left1.ToString().Replace(".", "").Trim('0')).ToString());
                left = left1 + left2;
                right = right2;
            }

            str = RegulateNum(left,right);
            return ReturnNum(str);
        }
        //乘
        public static string Mul(string num1, string num2)
        {
            string str = "";
            num1 = ScientficNum(num1);
            num2 = ScientficNum(num2);
            int right1 = ToInt32(num1.Substring(num1.IndexOf('e') + 1));
            int right2 = ToInt32(num2.Substring(num2.IndexOf('e') + 1));
            decimal left1 = ToDecimal(num1.Substring(0, num1.IndexOf('e')));
            decimal left2 = ToDecimal(num2.Substring(0, num2.IndexOf('e')));
            decimal left=left1*left2;
            int right=right1+right2;
            str = RegulateNum(left, right);
            return ReturnNum(str);
        }
        public static string Division(string num1, string num2)
        {
            string str = "";
            num1 = ScientficNum(num1);
            num2 = ScientficNum(num2);
            int right1 = ToInt32(num1.Substring(num1.IndexOf('e') + 1));
            int right2 = ToInt32(num2.Substring(num2.IndexOf('e') + 1));
            decimal left1 = ToDecimal(num1.Substring(0, num1.IndexOf('e')));
            decimal left2 = ToDecimal(num2.Substring(0, num2.IndexOf('e')));
            decimal left = left1 / left2;
            int right = right1 - right2;
            str = RegulateNum(left, right);
            return ReturnNum(str);
        }
        //将一个数值转为科学计数法
        public static string ScientficNum(string num)
        {
            if (num.Contains("e"))
                return num;
            string str = "";
            int mul;
            if (num.StartsWith("-"))
                str += "-";
            num = num.Replace("-", "");
            if (num.Contains("."))
            {
                mul = num.IndexOf(".") - 1;
                if (mul == 0)
                {
                    string zeroStr = num.Replace(".", "");
                    int index = 0;
                    for (int i = 0; i < zeroStr.Length; i++)
                    {
                        if (!zeroStr[i].Equals('0'))
                            break;
                        index++;
                    }
                    zeroStr = zeroStr.Trim('0').Insert(1, ".");
                    str += zeroStr + "e-" + index;
                    return str;
                }
                string right = num.Substring(num.IndexOf(".") + 1);
                string left = num.Substring(0, mul + 1);

                left = left.Insert(1, ".") + right;
                left = left.TrimEnd('0');
                str += left + "e+" + mul;
                return str;
            }
            else
            {
                int index = num.Length - 1;
                string left = num.Insert(1, ".").TrimEnd('0');
                str += left + "e+" + index;
                return str;
            }
        }

        //调节最终计算的值
        private static string RegulateNum(decimal left,int right)
        {
            int index = 0;
            string newLeft = "";
            string newRight = "";
            //左边计算的值超过两位数
            if (left >= 10)
            {
                if (left.ToString().Contains("."))
                    index = left.ToString().IndexOf(".") - 1;
                else
                    index = left.ToString().Length - 1;
                newLeft = left.ToString().Replace(".", "").Insert(1, ".");
            }
            else
                newLeft = left.ToString().TrimEnd('0');

            right = right + index;
            //左边计算的值小于1
            if (newLeft.StartsWith("0."))
            {
                int moveIndex = 0;
                newLeft = newLeft.Replace(".","");
                for(int i = 0; i < newLeft.Length; i++)
                {
                    if (!newLeft[i].Equals('0'))
                        break;
                    moveIndex++;
                }
                newLeft=newLeft.Trim('0').Insert(1, ".");
                right = right - moveIndex;
            }
            if (right >= 10000||right<=-10000)
            {
                return "溢出";
            }
            if (right > 0)
                newRight = "+"+right.ToString();
            else
                newRight= right.ToString();
            if (newLeft.Length == 1)
                newLeft += ".";

            return newLeft + "e" + newRight;
        }

        //将科学计数法转为数字
        public static string ReturnNum(string num)
        {
            Debug.WriteLine("nummmm:"+num);
            if (!num.Contains("e"))
                return num;
            int right = ToInt32(num.Substring(num.IndexOf('e') + 1));
            if (right > -4 && right < 16)
            {
                num = Decimal.Parse(num, System.Globalization.NumberStyles.Float).ToString();
            }
            else if (right <= -4 && right >= -18)
            {
                decimal num1 = Decimal.Parse(num, System.Globalization.NumberStyles.Float);
                if ((num1.ToString().Length <= 18 && num1 >= 0.00000001m))
                    num = num1.ToString();
            }
            

            
            return num;
        }
        //科学计数位数显示
        public static string DisplayScientficNum(string num)
        {
            string left = num.Substring(0, num.IndexOf("e"));
            if (left.Length > 17)
                left = Tool.Rounding2(left, 17).TrimEnd('0');
            return left + num.Substring(num.IndexOf("e"));
        }
    }
}
