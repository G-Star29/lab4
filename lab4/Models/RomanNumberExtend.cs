using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public static ushort ToRoman(string num_calc)
        {
         
            ushort to_integer = 0;
            for (int i = 0; i < num_calc.Length; i++)
            {
                switch (num_calc[i])
                {
                    case 'I':
                        to_integer += 1;
                        if (i > 0)
                        {
                            if (num_calc[i - 1] == 'X' || num_calc[i - 1] == 'V')
                            {
                                to_integer -= 2;
                            }
                        }
                        break;
                    case 'V':
                        to_integer += 5;
                        break;
                    case 'X':
                        to_integer += 10;
                        if (i > 0)
                        {
                            if (num_calc[i - 1] == 'C' || num_calc[i - 1] == 'L')
                            {
                                to_integer -= 20;
                            }
                        }
                        break;

                    case 'C':
                        to_integer += 100;
                        if (i > 0)
                        {
                            if (num_calc[i - 1] == 'M' || num_calc[i - 1] == 'D')
                            {
                                to_integer -= 200;
                            }
                        }
                        break;
                    case 'D':
                        to_integer += 500;
                        break;
                    case 'M':
                        to_integer += 1000;
                        break;
                    default:
                        break;
                }
            }
            return to_integer;
        }
        public RomanNumberExtend(string num) : base(ToRoman(num)) { }
    }
}
