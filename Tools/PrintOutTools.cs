using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public class PrintOutTools
    {
        private const double NumericRoundingErrorValue = 0.000001;

        public static string WritDecimalStringWithSpecifiedNumberOfDecimals(double InputValue,
                                                                            int NumberOfDecimalDigits)
        {
            string DecimalPointString = "#.";
            string OutputString;

            if (Math.Abs(InputValue) < NumericRoundingErrorValue)
            {
                return ("0");
            }
            else
            {
                for (int Counter = 0; Counter < NumberOfDecimalDigits; Counter++)
                {
                    DecimalPointString += "#";
                }

                OutputString = InputValue.ToString(DecimalPointString);

                return (OutputString);
            }
        }
    }
}
