using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{

    public enum Triangle_Angles_Enum
    {
        AngleA,
        AngleB,
        AngleC
    }

    public enum Triangle_Sides_Enum
    {
        SideA,
        SideB,
        SideC
    }

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

        #region RightAngleTriangle
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

        // This function is used when we have 1 side and 2 angles.
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

        // This function is used when we have 1 side and 3 angles.
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
        #endregion

        #region RandomTriangle
        private static void CalculateAngleUsingSinusRelation(Triangle Triangle_Object,
                                                             Triangle_Angles_Enum Current_Angle,
                                                             Triangle_Angles_Enum AngleToUse)
        {
            switch (Current_Angle)
            {
                case Triangle_Angles_Enum.AngleA:
                    if (Triangle_Angles_Enum.AngleB == AngleToUse)
                    {
                        Triangle_Object.AngleA = Math.Asin(Math.Sin(Triangle_Object.AngleB * Math.PI / 180) * Triangle_Object.a / Triangle_Object.b);
                        Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
                    }

                    if (Triangle_Angles_Enum.AngleC == AngleToUse)
                    {
                        Triangle_Object.AngleA = Math.Asin(Math.Sin(Triangle_Object.AngleC * Math.PI / 180) * Triangle_Object.a / Triangle_Object.c);
                        Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
                    }
                    break;

                case Triangle_Angles_Enum.AngleB:
                    if (Triangle_Angles_Enum.AngleA == AngleToUse)
                    {
                        Triangle_Object.AngleB = Math.Asin(Math.Sin(Triangle_Object.AngleA * Math.PI / 180) * Triangle_Object.b / Triangle_Object.a);
                        Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
                    }

                    if (Triangle_Angles_Enum.AngleC == AngleToUse)
                    {
                        Triangle_Object.AngleB = Math.Asin(Math.Sin(Triangle_Object.AngleC * Math.PI / 180) * Triangle_Object.b / Triangle_Object.c);
                        Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
                    }
                    break;

                case Triangle_Angles_Enum.AngleC:
                    if (Triangle_Angles_Enum.AngleA == AngleToUse)
                    {
                        Triangle_Object.AngleC = Math.Asin(Math.Sin(Triangle_Object.AngleA * Math.PI / 180) * Triangle_Object.c / Triangle_Object.a);
                        Triangle_Object.AngleC = Triangle_Object.AngleC * 180 / Math.PI;
                    }

                    if (Triangle_Angles_Enum.AngleB == AngleToUse)
                    {
                        Triangle_Object.AngleC = Math.Asin(Math.Sin(Triangle_Object.AngleB * Math.PI / 180) * Triangle_Object.c / Triangle_Object.b);
                        Triangle_Object.AngleC = Triangle_Object.AngleC * 180 / Math.PI;
                    }
                    break;
            }
        }

        private static void CalculateSideUsingSinusRelation(Triangle Triangle_Object,
                                                            Triangle_Sides_Enum Current_Side,
                                                            Triangle_Angles_Enum AngleToUse)
        {
            switch (Current_Side)
            {
                case Triangle_Sides_Enum.SideA:
                    if (Triangle_Angles_Enum.AngleB == AngleToUse)
                    {
                        Triangle_Object.a = Math.Sin(Triangle_Object.AngleA * Math.PI / 180) *
                                            Triangle_Object.b /
                                            Math.Sin(Triangle_Object.AngleB * Math.PI / 180);
                    }

                    if (Triangle_Angles_Enum.AngleC == AngleToUse)
                    {
                        Triangle_Object.a = Math.Sin(Triangle_Object.AngleA * Math.PI / 180) *
                                            Triangle_Object.c /
                                            Math.Sin(Triangle_Object.AngleC * Math.PI / 180);
                    }
                    break;

                case Triangle_Sides_Enum.SideB:
                    if (Triangle_Angles_Enum.AngleA == AngleToUse)
                    {
                        Triangle_Object.b = Math.Sin(Triangle_Object.AngleB * Math.PI / 180) *
                                            Triangle_Object.a /
                                            Math.Sin(Triangle_Object.AngleA * Math.PI / 180);
                    }

                    if (Triangle_Angles_Enum.AngleC == AngleToUse)
                    {
                        Triangle_Object.b = Math.Sin(Triangle_Object.AngleB * Math.PI / 180) *
                                            Triangle_Object.c /
                                            Math.Sin(Triangle_Object.AngleC * Math.PI / 180);
                    }
                    break;

                case Triangle_Sides_Enum.SideC:
                    if (Triangle_Angles_Enum.AngleA == AngleToUse)
                    {
                        Triangle_Object.c = Math.Sin(Triangle_Object.AngleC * Math.PI / 180) *
                                            Triangle_Object.a /
                                            Math.Sin(Triangle_Object.AngleA * Math.PI / 180);
                    }

                    if (Triangle_Angles_Enum.AngleB == AngleToUse)
                    {
                        Triangle_Object.c = Math.Sin(Triangle_Object.AngleC * Math.PI / 180) *
                                            Triangle_Object.b /
                                            Math.Sin(Triangle_Object.AngleB * Math.PI / 180);
                    }
                    break;
            }
        }

        // This function is used when we have 1 side and 3 angles.
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

        private static void CalculateAngleUsingCosinusRelation(Triangle Triangle_Object,
                                                               Triangle_Angles_Enum Current_Angle)
        {
            switch (Current_Angle)
            {
                case Triangle_Angles_Enum.AngleA:
                    Triangle_Object.AngleA = Math.Acos((Math.Pow(Triangle_Object.b, 2) +
                                         Math.Pow(Triangle_Object.c, 2) -
                                         Math.Pow(Triangle_Object.a, 2)) /
                                         (2 * Triangle_Object.b * Triangle_Object.c));
                    Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
                    break;

                case Triangle_Angles_Enum.AngleB:
                    Triangle_Object.AngleB = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                                         Math.Pow(Triangle_Object.c, 2) -
                                         Math.Pow(Triangle_Object.b, 2)) /
                                         (2 * Triangle_Object.a * Triangle_Object.c));
                    Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
                    break;

                case Triangle_Angles_Enum.AngleC:
                    Triangle_Object.AngleC = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                                         Math.Pow(Triangle_Object.b, 2) -
                                         Math.Pow(Triangle_Object.c, 2)) /
                                         (2 * Triangle_Object.a * Triangle_Object.b));
                    Triangle_Object.AngleC = Triangle_Object.AngleC * 180 / Math.PI;
                    break;
            }
        }

        private static void CalculateSideUsingCosinusRelation(Triangle Triangle_Object,
                                                              Triangle_Sides_Enum Current_Side)
        {
            switch (Current_Side)
            {
                case Triangle_Sides_Enum.SideA:
                    Triangle_Object.a = Math.Sqrt(Math.Pow(Triangle_Object.b, 2) +
                                                  Math.Pow(Triangle_Object.c, 2) -
                                                  2 * Triangle_Object.b * Triangle_Object.c *
                                                  Math.Cos(Triangle_Object.AngleA * Math.PI / 180));
                    break;

                case Triangle_Sides_Enum.SideB:
                    Triangle_Object.b = Math.Sqrt(Math.Pow(Triangle_Object.a, 2) +
                                                  Math.Pow(Triangle_Object.c, 2) -
                                                  2 * Triangle_Object.a * Triangle_Object.c *
                                                  Math.Cos(Triangle_Object.AngleB * Math.PI / 180));
                    break;

                case Triangle_Sides_Enum.SideC:
                    Triangle_Object.c = Math.Sqrt(Math.Pow(Triangle_Object.a, 2) +
                                                  Math.Pow(Triangle_Object.b, 2) -
                                                  2 * Triangle_Object.a * Triangle_Object.b *
                                                  Math.Cos(Triangle_Object.AngleC * Math.PI / 180));
                    break;
            }
        }

        // This function is used when we have 3 sides and 0 angles.
        private static void CalculateMissingAnglesUsingCosinusRelations(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.AngleA)
            {
                CalculateAngleUsingCosinusRelation(Triangle_Object, Triangle_Angles_Enum.AngleA);
                //Triangle_Object.AngleA = Math.Acos((Math.Pow(Triangle_Object.b, 2) +
                //                         Math.Pow(Triangle_Object.c, 2) -
                //                         Math.Pow(Triangle_Object.a, 2)) /
                //                         (2 * Triangle_Object.b * Triangle_Object.c));
                //Triangle_Object.AngleA = Triangle_Object.AngleA * 180 / Math.PI;
            }

            if (Const.NoValue == Triangle_Object.AngleB)
            {
                CalculateAngleUsingCosinusRelation(Triangle_Object, Triangle_Angles_Enum.AngleB);
                //Triangle_Object.AngleB = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                //                         Math.Pow(Triangle_Object.c, 2) -
                //                         Math.Pow(Triangle_Object.b, 2)) /
                //                         (2 * Triangle_Object.a * Triangle_Object.c));
                //Triangle_Object.AngleB = Triangle_Object.AngleB * 180 / Math.PI;
            }

            if (Const.NoValue == Triangle_Object.AngleC)
            {
                CalculateAngleUsingCosinusRelation(Triangle_Object, Triangle_Angles_Enum.AngleC);
                //Triangle_Object.AngleC = Math.Acos((Math.Pow(Triangle_Object.a, 2) +
                //                         Math.Pow(Triangle_Object.b, 2) -
                //                         Math.Pow(Triangle_Object.c, 2)) /
                //                         (2 * Triangle_Object.a * Triangle_Object.b));
                //Triangle_Object.AngleC = Triangle_Object.AngleC * 180 / Math.PI;
            }
        }

        // This function is used when we have 2 sides and 1 angle.
        private static void CalculateMissingAnglesAndSidesUsingCosinusOrSinusRelations(Triangle Triangle_Object)
        {
            if (Const.NoValue == Triangle_Object.a)
            {
                if (Const.NoValue != Triangle_Object.AngleA)
                {
                    CalculateSideUsingCosinusRelation(Triangle_Object, Triangle_Sides_Enum.SideA);
                    CalculateMissingAnglesUsingCosinusRelations(Triangle_Object);
                }
                else
                {
                    if (Const.NoValue != Triangle_Object.AngleB)
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleC,
                                                         Triangle_Angles_Enum.AngleB);
                    }
                    else
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleB,
                                                         Triangle_Angles_Enum.AngleC);
                    }
                    CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle_Object);
                    CalculateMissingSidesInRandomTriangleUsingSinusRelations(Triangle_Object);
                }
            }

            if (Const.NoValue == Triangle_Object.b)
            {
                if (Const.NoValue != Triangle_Object.AngleB)
                {
                    CalculateSideUsingCosinusRelation(Triangle_Object, Triangle_Sides_Enum.SideB);
                    CalculateMissingAnglesUsingCosinusRelations(Triangle_Object);
                }
                else
                {
                    if (Const.NoValue != Triangle_Object.AngleA)
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleC,
                                                         Triangle_Angles_Enum.AngleA);
                    }
                    else
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleA,
                                                         Triangle_Angles_Enum.AngleC);
                    }
                    CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle_Object);
                    CalculateMissingSidesInRandomTriangleUsingSinusRelations(Triangle_Object);
                }
            }

            if (Const.NoValue == Triangle_Object.c)
            {
                if (Const.NoValue != Triangle_Object.AngleC)
                {
                    CalculateSideUsingCosinusRelation(Triangle_Object, Triangle_Sides_Enum.SideC);
                    CalculateMissingAnglesUsingCosinusRelations(Triangle_Object);
                }
                else
                {
                    if (Const.NoValue != Triangle_Object.AngleA)
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleB,
                                                         Triangle_Angles_Enum.AngleA);
                    }
                    else
                    {
                        CalculateAngleUsingSinusRelation(Triangle_Object,
                                                         Triangle_Angles_Enum.AngleA,
                                                         Triangle_Angles_Enum.AngleB);
                    }
                    CalculateMissingAngleInTriangleUsing180DegreeRule(Triangle_Object);
                    CalculateMissingSidesInRandomTriangleUsingSinusRelations(Triangle_Object);
                }
            }
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
                    CalculateMissingAnglesAndSidesUsingCosinusOrSinusRelations(Triangle_Object);
                    break;

                case 3:
                    CalculateMissingAnglesUsingCosinusRelations(Triangle_Object);
                    break;
            }

            NumberList = PackTriangleToNumberList(Triangle_Object);

            return (true);
        }
        #endregion

        #region Triangle_Common
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
        #endregion
    }
}
