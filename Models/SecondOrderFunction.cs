using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VariabelBegreb.Tools;

namespace VariabelBegreb.Models
{
    public class SecondOrderFunction
    {
        public double ACoefficient;
        public double BCoefficient;
        public double CCoefficient;

        public double Diskriminant;
        
        public TextBlock TextBlock_Object = null;

        public SecondOrderFunctionRoots SecondOrderFunctionRoots_Object = new SecondOrderFunctionRoots();
        public Point2Dimensions PointExtremum = new Point2Dimensions();
        public Point2Dimensions PointYAxisCross = new Point2Dimensions();

        private Boolean ShowDiskriminantCalculations = true;

        public SecondOrderFunction()
        {
        }

        public SecondOrderFunction(TextBlock TextBlock_Object)
        {
            this.TextBlock_Object = TextBlock_Object;
        }

        private Boolean IsTextBlockSet()
        {
            return (null == TextBlock_Object ? false : true);
        }
        public void ResetTextBlock()
        {
            this.TextBlock_Object = null;
        }
        public double CalculateDiskriminant()
        {
            this.Diskriminant = Math.Pow(this.BCoefficient, 2) - 4 * this.ACoefficient * this.CCoefficient;

            if (IsTextBlockSet() && ShowDiskriminantCalculations)
            {
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += "Diskriminant = ";
                this.TextBlock_Object.Text += PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient) + "^2";
                this.TextBlock_Object.Text += " - 4 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient);
                this.TextBlock_Object.Text += " * " + PrintOutTools.WriteNumberWithParanthesis(this.CCoefficient);
                this.TextBlock_Object.Text += " = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.Diskriminant, Const.DefaultNumberOfDecimals);
            }

            return (this.Diskriminant);
        }

        public SecondOrderFunctionRoots CalculateRoots()
        {
            this.Diskriminant = this.CalculateDiskriminant();
            if (this.Diskriminant < 0)
            {
                if (IsTextBlockSet())
                {
                    this.TextBlock_Object.Text += Environment.NewLine;
                    this.TextBlock_Object.Text += Environment.NewLine;
                    this.TextBlock_Object.Text += "Parablen har ingen rødder => den skærer ikke x-aksen i nogle punkter.";
                }

                this.SecondOrderFunctionRoots_Object.NumberOFRoots = 0;
                return (this.SecondOrderFunctionRoots_Object);
            }
            else
            {
                if (0 == this.Diskriminant)
                {
                    SecondOrderFunctionRoots_Object.Roots[0].XCoordinate = -BCoefficient / (2 * ACoefficient);
                    SecondOrderFunctionRoots_Object.Roots[0].YCoordinate = 0;

                    if (IsTextBlockSet())
                    {
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += "x1 , x2 = -" + PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient);
                        this.TextBlock_Object.Text += " / (2 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient);
                        this.TextBlock_Object.Text += " ) = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[0].XCoordinate, Const.DefaultNumberOfDecimals);
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += "Parablen har dobbelt roden : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[0].XCoordinate, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                    this.SecondOrderFunctionRoots_Object.NumberOFRoots = 1;
                }
                else
                {
                    SecondOrderFunctionRoots_Object.Roots[0].XCoordinate = (-BCoefficient - Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                    SecondOrderFunctionRoots_Object.Roots[0].YCoordinate = 0;

                    SecondOrderFunctionRoots_Object.Roots[1].XCoordinate = (-BCoefficient + Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                    SecondOrderFunctionRoots_Object.Roots[1].YCoordinate = 0;

                    if (IsTextBlockSet())
                    {
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += "x1 = ( -" + PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient);
                        this.TextBlock_Object.Text += " - sqrt(" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.Diskriminant, Const.DefaultNumberOfDecimals) + ") ) ";
                        this.TextBlock_Object.Text += " / (2 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient);
                        this.TextBlock_Object.Text += " ) = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[0].XCoordinate, Const.DefaultNumberOfDecimals);
                        this.TextBlock_Object.Text += Environment.NewLine;

                        this.TextBlock_Object.Text += "x2 = (-" + PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient);
                        this.TextBlock_Object.Text += " + sqrt(" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.Diskriminant, Const.DefaultNumberOfDecimals) + ") ) ";
                        this.TextBlock_Object.Text += " / (2 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient);
                        this.TextBlock_Object.Text += " ) = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[1].XCoordinate, Const.DefaultNumberOfDecimals);
                        this.TextBlock_Object.Text += Environment.NewLine;
                        this.TextBlock_Object.Text += "Parablen har rødderne : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[0].XCoordinate, Const.DefaultNumberOfDecimals) + " ; 0) og (" +
                        PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SecondOrderFunctionRoots_Object.Roots[1].XCoordinate, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                }
            }
            return (this.SecondOrderFunctionRoots_Object);
        }

        public Point2Dimensions CalculateExtremumPoint()
        {
            this.Diskriminant = this.CalculateDiskriminant();

            this.PointExtremum.XCoordinate = -this.BCoefficient / (2 * this.ACoefficient);
            this.PointExtremum.YCoordinate = -this.Diskriminant / (4 * this.ACoefficient);

            if (IsTextBlockSet())
            {
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += "T(x) = (-" + PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient);
                this.TextBlock_Object.Text += " / (2 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient) + " ) ";
                this.TextBlock_Object.Text += " = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.PointExtremum.XCoordinate, Const.DefaultNumberOfDecimals);
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += "T(y) = (-" + PrintOutTools.WriteNumberWithParanthesis(this.Diskriminant) + " ) ";
                this.TextBlock_Object.Text += " / (4 * " + PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient) + " ) ";
                this.TextBlock_Object.Text += " = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.PointExtremum.YCoordinate, Const.DefaultNumberOfDecimals);
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += "Parablen har Toppunkt : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.PointExtremum.XCoordinate, Const.DefaultNumberOfDecimals) + " ; " +
                   PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.PointExtremum.YCoordinate, Const.DefaultNumberOfDecimals) + ")";
            }
            return (this.PointExtremum);
        }

        public Point2Dimensions CalculatePointYAxisCross()
        {
            this.PointYAxisCross.XCoordinate = 0;
            this.PointYAxisCross.YCoordinate = this.CCoefficient;

            if (IsTextBlockSet())
            {
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += Environment.NewLine;
                this.TextBlock_Object.Text += "Parablen skærer y aksen i punktet : (x ; y) = ( 0; " +
                   PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(this.PointYAxisCross.YCoordinate, Const.DefaultNumberOfDecimals) + ")";
            }

            return (this.PointYAxisCross);
        }

        public void CalculateAndShowAllPoints(string TextBloxkText = "Her kommer rødder, toppunkt og skæring med y-aksen for parablen beskrevet herover")
        {
            this.TextBlock_Object.Text = TextBloxkText;
            CalculateDiskriminant();
            ShowDiskriminantCalculations = false;
            CalculateRoots();
            CalculateExtremumPoint();
            CalculatePointYAxisCross();
            ShowDiskriminantCalculations = true;
        }

        public string MakeFunctionFormulaToPrint()
        {
            string OutputString = "Beregninger på funktionen med forskriften : f(x) = ";

            OutputString += PrintOutTools.WriteNumberWithParanthesis(this.ACoefficient) + "x^2 + ";
            OutputString += PrintOutTools.WriteNumberWithParanthesis(this.BCoefficient) + "x + ";
            OutputString += PrintOutTools.WriteNumberWithParanthesis(this.CCoefficient);

            return (OutputString);
        }
    }
}
