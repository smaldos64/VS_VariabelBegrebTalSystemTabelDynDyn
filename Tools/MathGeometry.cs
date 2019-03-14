using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public class MathGeometry
    {
        public static double CalculateAreaOfSQueare(List<double> NumberList)
        {
            return (Math.Pow(NumberList[0], 2));
        }

        public static double CalculateCircumferenceOfSquare(List<double> NumberList)
        {
            return (NumberList[0] * 4);
        }

        public static double CalculateAreaOfRectangle(List<double> NumberList)
        {
            return (NumberList[0] * NumberList[1]);
        }

        public static double CalculateCircumferenceOfRectangle(List<double> NumberList)
        {
            return (2*(NumberList[0] + NumberList[1]));
        }

        public static double CalculateDiameterFromRadius(List<double> NumberList)
        {
            return (2 * NumberList[0]);
        }

        public static double CalculateBallSurfaceArea(List<double> NumberList)
        {
            return (4 * Math.PI * (Math.Pow(NumberList[0], 2)));
        }

        public static double CalculateBallVolume(List<double> NumberList)
        {
            return (4 / 3 * Math.PI * (Math.Pow(NumberList[0], 3)));
        }
    }
}
