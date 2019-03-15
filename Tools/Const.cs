using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VariabelBegreb.NumberSystems;
using System.Collections.ObjectModel;
using VariabelBegreb.Tools;

namespace VariabelBegreb.Tools
{
    public class Const
    {
        #region General_Stuff
        public static readonly int LabelColumnPosition = 0;
        public static readonly int LabelColumnSpanShort = 1;
        public static readonly int LabelColumnSpan = 2;
        public static readonly int TextBoxColumnPosition = 2;
        public static readonly int TextBoxColumnSpanShort = 1;
        public static readonly int TextBoxColumnSpan = 4;
        public static readonly int TextBoxWidthShort = 100;
        public static readonly int TextBoxWidth = 240;
        public static readonly int TextBoxHeight = 23;

        public static readonly int DynamicElementsRowHeight = 40;
        public static readonly int ComboBoxRowHeight = 30;

        public const int NumberFormatError = -1;
        public const int RadixNumberNotFound = -1;
        #endregion

        #region Const_FirstOrderEquation
        public const string txtParametersFor1OrderLineString = "Her kommer karakteristika for den rette linje beskrevet ved de 2 punkter herover";
        #endregion

        #region Const_SecondOrderEquation
        public const string txtParametersForParabelString = "Her kommer karakteristika for parablen beskrevet ved de 3 punkter herover";
        public const string txtParametersForParabelByCoefficientsString = "Her kommer rødder og toppunkt for parablen beskrevet herover";
        #endregion

        #region Const_EquationSystem
        public const int Min_Order_Of_Equations = 2;
        public const int Max_Order_Of_Equations = 10;
        
        public const int Min_Number_Of_Decimals = 2;
        public const int Max_Number_Of_Decimals = 10;
        
        public const string EqutionSystemDirectory = "EquationSystem";
        public const string EquationSystemExtension = "equ";
        public const string EquationSystemSolvedString = "Løsning til Ligningssystem : ";
        public const string EquationSystemNotSolvedString = "Her kommer løsningen på ligningssystemet.";
        #endregion

        #region Const_PercentageCalculations
        public const string lblPercentageOfBaseAmountText = "x % af y er : ";

        public static void SetDefaultUpDownLabelContent(Label UpDownLabel)
        {
            UpDownLabel.Content = lblPercentageOfBaseAmountText;
        }
        #endregion

        #region Const_FractionCalculations
        public const string lblPlusFractionsDefaultText = "Addition af Brøker : ";
        public const string lblMinusFractionsDefaultText = "Subtraktion af Brøker : ";
        public const string lblMultiplyFractionsDefaultText = "Multiplikation af Brøker : ";
        public const string lblDivideFractionsDefaultText = "Division af Brøker : ";

        public static void SetDefaultFractionsLabelsContent(Label PlusLabel,
                                                            Label MinusLabel,
                                                            Label MultiPlyLabel,
                                                            Label DivideLabel)
        {
            PlusLabel.Content = lblPlusFractionsDefaultText;
            MinusLabel.Content = lblMinusFractionsDefaultText;
            MultiPlyLabel.Content = lblMultiplyFractionsDefaultText;
            DivideLabel.Content = lblDivideFractionsDefaultText;
        }
        #endregion

        #region Const_General_Code
        public static int DefaultNumberOfDecimals = 3;

        public static void SetDefaultNumberOfDecimals(int DefaultNumberOfDecimalsSet)
        {
            DefaultNumberOfDecimals = DefaultNumberOfDecimalsSet;
        }

        public static int GetDefaultNumberOfDecimals()
        {
            return (DefaultNumberOfDecimals);
        }
        #endregion
    }
}
