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
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblTriangleRightAngleHypotenuseC", "Længde af hypotenuse a : " }),
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
                                NumberOfDimensionsInCalculationString : ConstGeometry.Dimension2InCalculationString)
                        },
                        FigureDimensions : 2,
                        FigureName : "Retvinklet Trekant")
                    }
            );
    }
}
