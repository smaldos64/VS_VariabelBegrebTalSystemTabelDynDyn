﻿using System;
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

        private static int DetermineNumberOfSidesProvidedInTriangle(Triangle Triangle_Object)
        {
            int SidesProvidedCounter = 0;

            if (Triangle_Object.a != Const.NoValue)
            {
                SidesProvidedCounter++;
            }

            if (Triangle_Object.b != Const.NoValue)
            {
                SidesProvidedCounter++;
            }

            if (Triangle_Object.c != Const.NoValue)
            {
                SidesProvidedCounter++;
            }

            return (SidesProvidedCounter);
        }
        
        private static void CalculateMissingSideInRightAngleTriangleUsingPythagoras(Triangle Triangle_Object)
        {
            if (0 == Triangle_Object.a)
            {
                Triangle_Object.a = Math.Sqrt(Math.Pow(Triangle_Object.c, 2) -
                                              Math.Pow(Triangle_Object.b, 2));
            }

            if (0 == Triangle_Object.b)
            {
                Triangle_Object.b = Math.Sqrt(Math.Pow(Triangle_Object.c, 2) -
                                              Math.Pow(Triangle_Object.a, 2));
            }

            if (0 == Triangle_Object.c)
            {
                Triangle_Object.c = Math.Sqrt(Math.Pow(Triangle_Object.a, 2) +
                                              Math.Pow(Triangle_Object.b, 2));
            }
        }

        private static void CalculateMissingAnglesInRightAngleTriangleWith2SidesProvided(Triangle Triangle_Object)
        {
            if (0 == Triangle_Object.AngleA)
            {
                Triangle_Object.AngleA = Math.Asin(Triangle_Object.a / Triangle_Object.c);
                Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
            }

            if (0 == Triangle_Object.AngleB)
            {
                Triangle_Object.AngleB = Math.Asin(Triangle_Object.b / Triangle_Object.c);
                Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
            }
        }

        private static void CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.AngleA)
            {
                Triangle_Object.AngleA = 180 - Triangle_Object.AngleB - Triangle_Object.AngleC;
            }

            if (Const.NoValue == Triangle_Object.AngleB)
            {
                Triangle_Object.AngleB = 180 - Triangle_Object.AngleA - Triangle_Object.AngleC;
            }

            if (Const.NoValue == Triangle_Object.AngleC)
            {
                Triangle_Object.AngleC = 180 - Triangle_Object.AngleA - Triangle_Object.AngleB;
            }
        }

        private static void CalculateMissingSidesInRightAngleTriangleUsingTrigonometry(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.a)
            {
                if (Const.NoValue == Triangle_Object.b)
                {
                    Triangle_Object.a = Math.Cos(Triangle_Object.AngleB * Math.PI / 180) * Triangle_Object.c;
                }
                else
                {
                    Triangle_Object.a = Triangle_Object.b / Math.Tan(Triangle_Object.AngleB * Math.PI / 180);
                }
            }

            if (Const.NoValue == Triangle_Object.b)
            {
                Triangle_Object.b = Triangle_Object.a / Math.Tan(Triangle_Object.AngleA * Math.PI / 180);
            }

            if (Const.NoValue == Triangle_Object.c)
            {
                CalculateMissingSideInRightAngleTriangleUsingPythagoras(Triangle_Object);
            }
        }

        private static void CalculateMissingSidesInRandomTriangleUsingSinusRelations(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.a)
            {
                if (Const.NoValue == Triangle_Object.b)
                {
                    Triangle_Object.a = Triangle_Object.c *  Math.Sin(Triangle_Object.AngleA * Math.PI / 180) / Math.Sin(Triangle_Object.AngleC * Math.PI / 180);
                }
                else
                {
                    Triangle_Object.a = Triangle_Object.b * Math.Sin(Triangle_Object.AngleA * Math.PI / 180) / Math.Sin(Triangle_Object.AngleB * Math.PI / 180);
                }
            }

            if (Const.NoValue == Triangle_Object.b)
            {
                Triangle_Object.b = Triangle_Object.a * Math.Sin(Triangle_Object.AngleB * Math.PI / 180) / Math.Sin(Triangle_Object.AngleA * Math.PI / 180);
            }

            if (Const.NoValue == Triangle_Object.c)
            {
                Triangle_Object.c = Triangle_Object.a * Math.Sin(Triangle_Object.AngleC * Math.PI / 180) / Math.Sin(Triangle_Object.AngleA * Math.PI / 180);
            }
        }

        private static void CalculateMissingAnglesUsingCosinusRelations(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.AngleA)
            {
                Triangle_Object.AngleA = Math.Acos((Math.Pow(Triangle_Object.b, 2) +
                                         Math.Pow(Triangle_Object.c, 2) -
                                         Math.Pow(Triangle_Object.a, 2)) /
                                         (2 * Triangle_Object.b * Triangle_Object.c));
                Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
            }

            if (Const.NoValue == Triangle_Object.AngleB)
            {
                Triangle_Object.AngleB = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                                         Math.Pow(Triangle_Object.c, 2) -
                                         Math.Pow(Triangle_Object.b, 2)) /
                                         (2 * Triangle_Object.a * Triangle_Object.c));
                Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
            }

            if (Const.NoValue == Triangle_Object.AngleC)
            {
                Triangle_Object.AngleC = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                                         Math.Pow(Triangle_Object.b, 2) -
                                         Math.Pow(Triangle_Object.c, 2)) /
                                         (2 * Triangle_Object.a * Triangle_Object.b));
                Triangle_Object.AngleC = Triangle_Object.AngleC * 180 / Math.PI;
            }
        }

        private static bool CalculateAnglesAndSidesInRightAngleTriangle(ref List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);
            int SidesProvidedInRightAngleTriangle = DetermineNumberOfSidesProvidedInTriangle(Triangle_Object);

            switch (SidesProvidedInRightAngleTriangle)
            {
                case 0:
                    return (false);

                case 1:
                    CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle_Object);
                    CalculateMissingSidesInRightAngleTriangleUsingTrigonometry(Triangle_Object);
                    break;

                case 2:
                    CalculateMissingSideInRightAngleTriangleUsingPythagoras(Triangle_Object);
                    CalculateMissingAnglesInRightAngleTriangleWith2SidesProvided(Triangle_Object);
                    break;
            }

            NumberList = PackTriangleToNumberList(Triangle_Object);
            
            return (true);
        }

        private static bool CalculateAnglesAndSidesInRandomTriangle(ref List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);
            int SidesProvidedInRandomTriangle = DetermineNumberOfSidesProvidedInTriangle(Triangle_Object);

            switch (SidesProvidedInRandomTriangle)
            {
                case 0:
                    return (false);

                case 1:
                    CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle_Object);
                    CalculateMissingSidesInRandomTriangleUsingSinusRelations(Triangle_Object);
                    break;

                case 2:
                    return (false);
                    //CalculateMissingSideInRightAngleTriangleUsingPythagoras(Triangle_Object);
                    //CalculateMissingAnglesInRightAngleTriangleWith2SidesProvided(Triangle_Object);
                    //break;

                case 3:
                    CalculateMissingAnglesUsingCosinusRelations(Triangle_Object);
                    break;
            }

            NumberList = PackTriangleToNumberList(Triangle_Object);

            return (true);
        }
        public static bool CalculateAnglesAndSidesInTriangle(ref List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);

            if (90 == Triangle_Object.AngleC)
            {
                return (CalculateAnglesAndSidesInRightAngleTriangle(ref NumberList));
            }
            else
            {
                return (CalculateAnglesAndSidesInRandomTriangle(ref NumberList));
            }

        }
        public static double CalculateAreaOfTriangle(List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);

            return (0.5 * Triangle_Object.a * Triangle_Object.b * Math.Sin(Triangle_Object.AngleC * Math.PI/ 180)); 
        }

        public static double CalculateCircumferenceOfTriangle(List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);

            return (Triangle_Object.a + Triangle_Object.b + Triangle_Object.c);
        }

        public static double CalculateRadiusOfCircumscribedCircle(List<double> NumberList)
        {
            Triangle Triangle_Object = PackNumberListToTriangle(NumberList);
            double RadiusOfCircumScribedCircle;

            RadiusOfCircumScribedCircle = Triangle_Object.a * Triangle_Object.b * Triangle_Object.c / (4 * CalculateAreaOfTriangle(NumberList));

            return (RadiusOfCircumScribedCircle);
        }

        public static double CalculateCircumreferenceOfCircumscribedCircle(List<double> NumberList)
        {
            double RadiusOfCircumScribedCircle;

            RadiusOfCircumScribedCircle = CalculateRadiusOfCircumscribedCircle(NumberList);

            return (MathTools.CalculateCircumreferenceOfCircle(RadiusOfCircumScribedCircle));
        }

        public static double CalculateAreaOfCircumscribedCircle(List<double> NumberList)
        {
            double RadiusOfCircumScribedCircle;

            RadiusOfCircumScribedCircle = CalculateRadiusOfCircumscribedCircle(NumberList);

            return (MathTools.CalculateAreaOfCircle(RadiusOfCircumScribedCircle));
        }

        public static double CalculateRadiusOfInscribedCircle(List<double> NumberList)
        {
            double RadiusOfInscribedCircle;

            RadiusOfInscribedCircle = CalculateAreaOfTriangle(NumberList) / (0.5 * CalculateCircumferenceOfTriangle(NumberList));

            return (RadiusOfInscribedCircle);
        }

        public static double CalculateCircumreferenceOfInscribedCircle(List<double> NumberList)
        {
            double RadiusOfInscribedCircle;

            RadiusOfInscribedCircle = CalculateRadiusOfInscribedCircle(NumberList);

            return (MathTools.CalculateCircumreferenceOfCircle(RadiusOfInscribedCircle));
        }

        public static double CalculateAreaOfInscribedCircle(List<double> NumberList)
        {
            double RadiusOfInscribedCircle;

            RadiusOfInscribedCircle = CalculateRadiusOfInscribedCircle(NumberList);

            return (MathTools.CalculateAreaOfCircle(RadiusOfInscribedCircle));
        }
    }
}
