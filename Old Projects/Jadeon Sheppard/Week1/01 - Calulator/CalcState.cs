using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01___Calulator
{
    [Serializable]
    public class CalcState
    {
        public enum Operator
        {
            Add,
            Sub,
            Mul,
            Div
        }

        private double cNum;
        private string cText;
        private Operator cOperator;
        private bool isCalc;

        public CalcState()
        {
            cNum = 0;
            cText = "0";
            cOperator = Operator.Add;
            isCalc = false;
        }

        public string DoOperator(Operator op)
        {
            if (!isCalc)
                DoEqual();

            cText = "";

            isCalc = false;
            cOperator = op;

            return cNum.ToString();
        }

        public string DoEqual()
        {
            double rn = Double.Parse(cText);

            switch (cOperator)
            {
                case Operator.Add:
                    cNum += rn;
                    break;

                case Operator.Sub:
                    cNum -= rn;
                    break;

                case Operator.Mul:
                    cNum *= rn;
                    break;

                case Operator.Div:
                    if (Math.Abs(rn) < 0.0000001)
                        cNum = 0;
                    else
                        cNum /= rn;
                    break;
            }

            isCalc = true;
            return format(cNum.ToString());
        }

        public string DoNum(string num)
        {
            if (isCalc)
            {
                cNum = 0;
                cText = "";
                cOperator = Operator.Add;
                isCalc = false;
            }

            cText = format(cText + num);

            isCalc = false;

            return cText;
        }

        public static string format(string input)
        {
            string tr = "";

            int numcount = 0;
            bool isNeg = false;
            bool hasdec = false;

            for (int n = 0; n < input.Length; n++)
            {
                char c = input[n];

                if (c == '-')
                {
                    if (n == 0)
                        isNeg = true;
                    else
                        break;
                }
                else if (c >= '0' && c <= '9')
                {
                    if (hasdec && numcount > 0)
                    {
                        break;
                    }
                    else if (!(c == '0' && numcount == 0))
                    {
                        tr += c;
                        numcount++;
                    }
                }
                else if (c == '.')
                {
                    if (hasdec)
                    {
                        break;
                    }
                    else
                    {
                        if (numcount == 0)
                            tr += '0';

                        tr += '.';
                        hasdec = true;
                        numcount = 0;
                    }
                }
                else
                {
                    break;
                }
            }

            return isNeg ? '-' + tr : tr;
        }
    }
}