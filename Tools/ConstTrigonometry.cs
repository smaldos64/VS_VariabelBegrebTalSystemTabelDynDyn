using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VariabelBegreb.Tools
{
    public class ConstTrigonometry
    {
        public static readonly int NumberOfValuesSetInTriangle = 3;
        private const string TrigonometryImages = "d:\\lars\\WpfMathTrigonometryImages\\";

        public static readonly FigureCalculation FigureCalculation_Object =
            new FigureCalculation
            (
                Button_Clear_Object: new MyControl<Button>(XamlControlStringArray: new string[] { "btnClearAll", "Clear" }),
                Button_Result_Object: new MyControl<Button>(XamlControlStringArray: new string[] { "btnCalculateResults", "Beregn" }),
                ComboBox_Unit_Object: new MyControl<ComboBox>(XamlControlStringArray: new string[] { "cmbUnits" }),
                ComboBox_Figure_Object: new MyControl<ComboBox>(XamlControlStringArray: new string[] { "cmbTrigonometryFigures" }),

                CurrentFigureCalculationArray: new CurrentFigureCalculation[]
                {
                    new CurrentFigureCalculation(
                        Image_Figure_Object : new MyControl<Image>(XamlControlStringArray: new string[]
                                              {"imgTrigonometryFigureRightAngle", TrigonometryImages + "Retvinklet_Trekant.png", "Retvinklet Trekant"}),

                        MyLabelTextBoxRowArray : new MyLabelTextBoxRow[]
                        {
                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblTriangleRightAngleCatetusA", "Længde af katete a : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleRightAngleCatetusAUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngleCatetusA", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblTriangleRightAngleCatetusB", "Længde af katete b : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleRightAngleCatetusBUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngleCatetusB", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleHypotenuseC", "Længde af hypotenuse c : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleRightAngleHypotenuseCUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngleHypotenuseC", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleA", "Vinkel A : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleAUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngle_AngleA", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleB", "Vinkel B : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleBUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngle_AngleB", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleC", "Vinkel C : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleRightAngle_AngleBUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Output_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleRightAngle_AngleC", "90" }))
                        },

                        ResultTextBoxToCalculationNewArray : new ResultTextBoxToCalculationNew[]
                        {
                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumference", "Omkreds af trekant : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumferenceFormula", "Omkreds = a + b + c" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumferenceOfTriangle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleArea", "Areal af trekant : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleAreaFormula", "Areal = 0.5 * a * b * Sin(C)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfTriangle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleRadius", "Radius af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleRadiusUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleRadiusFormula", "Radius = a * b * c / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtlblTriangleRightAngleCircumscribedCircleRadius", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateRadiusOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleCircumference", "Omkreds af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleCircumferenceFormula", "Omkreds = 2 * a * b * c * PI / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleCircumscribedCircleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumreferenceOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleArea", "Areal af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleCircumscribedCircleAreaFormula", "Areal = (a * b * c)2 * PI / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleCircumscribedCircleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString),

                             new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleRadius", "Radius af indskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleRadiusUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleRadiusFormula", "Radius = Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtlblTriangleRightAngleInscribedCircleRadius", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateRadiusOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                             new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleCircumference", "Omkreds af indkreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleCircumferenceFormula", "Omkreds = 2 * PI * Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleInscribedCircleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumreferenceOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleArea", "Areal af indskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleInscribedCircleAreaFormula", "Areal = (PI)2 * Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleRightAngleInscribedCircleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString)

                        },
                        FigureDimensions : 2,
                        FigureName : "Retvinklet Trekant"),
                
                new CurrentFigureCalculation(
                        Image_Figure_Object: new MyControl<Image>(XamlControlStringArray: new string[]
                                              {"imgTrigonometryFigure", TrigonometryImages + "Ikke_Retvinklet_Trekant.png", "Vilkårlig Trekant"}),

                        MyLabelTextBoxRowArray: new MyLabelTextBoxRow[]
                        {
                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblTriangleCatetusA", "Længde af katete a : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleCatetusAUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleCatetusA", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblTriangleCatetusB", "Længde af katete b : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleCatetusBUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleCatetusB", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleHypotenuseC", "Længde af hypotenuse c : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblTriangleHypotenuseCUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleleHypotenuseC", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleAngleA", "Vinkel A : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleAngleAUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleAngleA", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleAngleB", "Vinkel B : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleAngleBUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleAngleB", ConstGeometry.DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleAngleC", "Vinkel C : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : false, XamlControlStringArray: new string[] { "lblTriangleAngleBUnit", "°" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtTriangleAngleC", "0" }))
                        },

                        ResultTextBoxToCalculationNewArray: new ResultTextBoxToCalculationNew[]
                        {
                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumference", "Omkreds af trekant : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] { "lblTriangleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumferenceFormula", "Omkreds = a + b + c" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumferenceOfTriangle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleArea", "Areal af trekant : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleAreaFormula", "Areal = 0.5 * a * b * Sin(C)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfTriangle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleRadius", "Radius af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleRadiusUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleRadiusFormula", "Radius = a * b * c / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtlblTriangleCircumscribedCircleRadius", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateRadiusOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleCircumference", "Omkreds af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleCircumferenceFormula", "Omkreds = 2 * a * b * c * PI / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleCircumscribedCircleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumreferenceOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleArea", "Areal af omskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleCircumscribedCircleAreaFormula", "Areal = (a * b * c)2 * PI / 4 * Areal Trekant" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleCircumscribedCircleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfCircumscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString),

                             new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleRadius", "Radius af indskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleRadiusUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleRadiusFormula", "Radius = Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtlblTriangleInscribedCircleRadius", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateRadiusOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                             new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleCircumference", "Omkreds af indkreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension1InCalculationString, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleCircumferenceFormula", "Omkreds = 2 * PI * Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleInscribedCircleCircumference", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateCircumreferenceOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleArea", "Areal af indskreven cirkel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : ConstGeometry.Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleInscribedCircleAreaFormula", "Areal = (PI)2 * Areal Trekant / (0.5 * Omkreds Trekant)" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtTriangleInscribedCircleArea", ConstGeometry.DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathTrigonometry.CalculateAreaOfInscribedCircle,
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString)

                        },
                        FigureDimensions: 2,
                        FigureName: "Vilkårlig Trekant")
                    }
            );
    }
}
