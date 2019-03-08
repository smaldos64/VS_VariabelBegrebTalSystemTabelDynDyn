using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public class MathGeometry
    {
        public static double CalculateAreaOfSQueare(double[] NumberList)
        {
            return (Math.Pow(NumberList[0], 2));
        }

        public static double CalculateCircumferenceOfSquare(double[] NumberList)
        {
            return (NumberList[0] * 4);
        }

        public static double CalculateAreaOfRectangle(double[] NumberList)
        {
            return (NumberList[0] * NumberList[1]);
        }

        public static double CalculateCircumferenceOfRectangle(double[] NumberList)
        {
            return (2*(NumberList[0] + NumberList[1]));
        }
    }
}
