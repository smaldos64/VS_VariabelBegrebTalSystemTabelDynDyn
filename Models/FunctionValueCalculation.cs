using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VariabelBegreb.Tools;

namespace VariabelBegreb.Models
{
    public class FunctionValueCalculation
    {
        static public int OverallCalculationIndex = 1;
        public int CalculationIndex { get; set; }
        public double XValue { get; set; }
        public double YValue { get; set; }
        public string CalculationText { get; set; }
        public TextBox EraseCalculationTextBox { get; set; }
        public FunctionValueCalculation(SecondOrderFunction SecondOrderFunction_Objext,
                                        double XValue)
        {
            this.XValue = XValue;
            this.YValue = SecondOrderFunction_Objext.ACoefficient * Math.Pow(this.XValue, 2) +
                          SecondOrderFunction_Objext.BCoefficient * this.XValue +
                          SecondOrderFunction_Objext.CCoefficient;
            this.CalculationIndex = OverallCalculationIndex++;
            this.CalculationText = "y = f(";
            this.CalculationText += PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.XValue, Const.DefaultNumberOfDecimals) +") = ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(SecondOrderFunction_Objext.ACoefficient) + " * ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(this.XValue) + "^2 + ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(SecondOrderFunction_Objext.BCoefficient) + " * ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(this.XValue) + " + ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(SecondOrderFunction_Objext.CCoefficient);
            this.CalculationText += " = ";
            this.CalculationText += PrintOutTools.WriteNumberWithParanthesis(YValue);
        }
    }
}
