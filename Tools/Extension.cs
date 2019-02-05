using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public static class Extension
    {
        public static bool ParseStringZeroOrEmpty(this string Value_String)
        {
            if (0 != Value_String.Length)
            {
                double Value_Double;
                if (double.TryParse(Value_String, out Value_Double))
                {
                    if (0 != Value_Double)
                    {
                        return (true);
                    }
                }
            }

            return (false);
        }

        public static double ReturnValueOrZero(this string Value_String)
        {
            if (0 == Value_String.Length)
            {
                return (0);
            }
            else
            {
                double Value_Double;
                if (double.TryParse(Value_String, out Value_Double))
                {
                    return (Value_Double);
                }
                else
                {
                    return (0);
                }
            }
        }
    }
}
