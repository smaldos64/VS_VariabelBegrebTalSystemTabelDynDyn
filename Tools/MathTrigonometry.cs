using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{

    public class Triangle
    {
        public double a { get; set; }

        public double b { get; set; }

        public double c { get; set; }

        public double AngleA { get; set; }

        public double AngleB { get; set; }

        public double AngleC { get; set; }

        public Triangle(double a, double b, double c, double AngleA, double AngleB, double AngleC)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.AngleA = AngleA;
            this.AngleB = AngleB;
            this.AngleC = AngleC;
        }
    }
    public class MathTrigonometry
    {

        public static Triangle PackNumberListToTriangle(List<double> NumberList)
        {
            Triangle Triangle_Object = new Triangle(a : NumberList[0],
                                                    b : NumberList[1],
                                                    c : NumberList[2],
                                                    AngleA : NumberList[3],
                                                    AngleB : NumberList[4],
                                                    AngleC : NumberList[5]);

            return (Triangle_Object);
        }

        public static List<double> PackTriangleToNumberList(Triangle Triangle_Object)
        {
            List<double> DoubleList = new List<double>();

            DoubleList.Add(Triangle_Object.a);
            DoubleList.Add(Triangle_Object.b);
            DoubleList.Add(Triangle_Object.c);
            DoubleList.Add(Triangle_Object.AngleA);
            DoubleList.Add(Triangle_Object.AngleB);
            DoubleList.Add(Triangle_Object.AngleC);

            return (DoubleList);
        }
        public static double CalculateAreaOfTriangle(List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);

            return (0.5 * Triangle_Object.a * Triangle_Object.b * Math.Sin(Triangle_Object.AngleC)); 
        }

        public static double CalculateCircumferenceOfTriangle(List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);

            return (Triangle_Object.a + Triangle_Object.b + Triangle_Object.c);
        }
    }
}
