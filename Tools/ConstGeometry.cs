using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VariabelBegreb.Tools
{
    public delegate double CalculateOnFigure(List<double> NumberList);
    //public delegate void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e);

    public enum Figures_Enum
    {
        Rectangle_Enum,
        Square_Enum,
        Cylinder_Enum,
        Ball_Enum
    }

    public enum Input_Output_Enum
    {
        Input_Enum,
        Output_Enum,
        Input_Output_Enum
    }

    public class MyControl<T>
    {
        public T XamlControl { get; set; }
        public string[] XamlControlStringArray { get; set; }

        public MyControl(string[] XamlControlStringArray)
        {
            this.XamlControlStringArray = XamlControlStringArray;
            this.XamlControl = default(T);
        }
    }

    public class MyTextBoxInputOutput : MyControl<TextBox>
    {
        public Input_Output_Enum Input_Output_Enum { get; set; }

        public MyTextBoxInputOutput(Input_Output_Enum Input_Output_Enum, string[] XamlControlStringArray) : base(XamlControlStringArray)
        {
            this.Input_Output_Enum = Input_Output_Enum;
        }
    }

    public class MyLabelWithUnit : MyControl<Label>
    {
        public bool IsCurrentLabelAnUnitLabel { get; set; }
        public string UnitDimensionString { get; set; }

        public MyLabelWithUnit(bool IsCurrentLabelAnUnitLabel, string[] XamlControlStringArray, string UnitDimensionString = "") : base(XamlControlStringArray)
        {
            this.UnitDimensionString = UnitDimensionString;
            this.IsCurrentLabelAnUnitLabel = IsCurrentLabelAnUnitLabel;
        }
    }

    public class MyLabelTextBoxRow
    {
        public MyLabelWithUnit[] LabelsArray { get; set; }
        public MyTextBoxInputOutput TextBox_Object { get; set; }

        public MyLabelTextBoxRow(MyLabelWithUnit[] LabelsArray, MyTextBoxInputOutput TextBox_Object)
        {
            this.LabelsArray = LabelsArray;
            this.TextBox_Object = TextBox_Object;
        }
    }

    public class CurrentFigureCalculation
    {
        public MyControl<Image> Image_Figure_Object { get; set; }

        public MyLabelTextBoxRow[] MyLabelTextBoxRowArray { get; set; }
        public ResultTextBoxToCalculationNew[] ResultTextBoxToCalculationNewArray { get; set; }

        public int FigureDimensions { get; set; }

        public string FigureName { get; set; }

        public CurrentFigureCalculation(MyControl<Image> Image_Figure_Object, MyLabelTextBoxRow[] MyLabelTextBoxRowArray,
                                        ResultTextBoxToCalculationNew[] ResultTextBoxToCalculationNewArray, int FigureDimensions,
                                        string FigureName)
        {
            this.Image_Figure_Object = Image_Figure_Object;
            this.MyLabelTextBoxRowArray = MyLabelTextBoxRowArray;
            this.ResultTextBoxToCalculationNewArray = ResultTextBoxToCalculationNewArray;
            this.FigureDimensions = FigureDimensions;
            this.FigureName = FigureName;
        }
    }

    public class FigureCalculation
    {
        public MyControl<Button> Button_Clear_Object { get; set; }
        public MyControl<Button> Button_Result_Object { get; set; }
        public MyControl<ComboBox> ComboBox_Unit_Object { get; set; }
        public MyControl<ComboBox> ComboBox_Figure_Object { get; set; }
        public CurrentFigureCalculation[] CurrentFigureCalculationArray { get; set; }

        public FigureCalculation(MyControl<Button> Button_Clear_Object, MyControl<Button> Button_Result_Object, MyControl<ComboBox> ComboBox_Unit_Object, MyControl<ComboBox> ComboBox_Figure_Object,
                                 CurrentFigureCalculation[] CurrentFigureCalculationArray)
        {
            this.Button_Clear_Object = Button_Clear_Object;
            this.Button_Result_Object = Button_Result_Object;
            this.ComboBox_Unit_Object = ComboBox_Unit_Object;
            this.ComboBox_Figure_Object = ComboBox_Figure_Object;
            this.CurrentFigureCalculationArray = CurrentFigureCalculationArray;
        }
    }

    public class ResultTextBoxToCalculationNew
    {
        public MyLabelTextBoxRow MyLabelTextBoxRow_Object { get; set; }
        public CalculateOnFigure CalculateOnFigure_Delegate { get; set; }
        public string NumberOfDimensionsInCalculationString { get; set; }

        public ResultTextBoxToCalculationNew(MyLabelTextBoxRow MyLabelTextBoxRow_Object, CalculateOnFigure CalculateOnFigure_Delegate, string NumberOfDimensionsInCalculationString)
        {
            this.MyLabelTextBoxRow_Object = MyLabelTextBoxRow_Object;
            this.CalculateOnFigure_Delegate = CalculateOnFigure_Delegate;
            this.NumberOfDimensionsInCalculationString = NumberOfDimensionsInCalculationString;
        }
    }

    public class ConstGeometry
    {
        private const string GeometryImages = "d:\\lars\\WpfMathGeometryImages\\";

        public const string Dimension1InCalculationString = "";
        public const string Dimension2InCalculationString = "2";
        public const string Dimension3InCalculationString = "3";

        public const string DefaultTextBoxValue = "0";

        public const int ControlNamePositionInArray = 0;
        public const int ImageFileNamePositionInArray = 1;
        public const int LabelTextPositionInArray = 1;
        public const int TextBoxTextPositionInArray = 1;
        public const int ButtonTextPositionInArray = 1;
        public const int GeometryLabelStartColumn = 0;
        public const int GeometryLabelDefaultColumnSpan = 1;

        public const int ImageHeight = 200;

        public static readonly FigureCalculation FigureCalculation_Object =
            new FigureCalculation
            (
                Button_Clear_Object: new MyControl<Button>(XamlControlStringArray: new string[] { "btnClearAll", "Clear" }),
                Button_Result_Object: new MyControl<Button>(XamlControlStringArray: new string[] { "btnCalculateResults", "Beregn" }),
                ComboBox_Unit_Object: new MyControl<ComboBox>(XamlControlStringArray: new string[] { "cmbUnits" }),
                ComboBox_Figure_Object: new MyControl<ComboBox>(XamlControlStringArray: new string[] { "cmbGeometryFigures" }),
                CurrentFigureCalculationArray: new CurrentFigureCalculation[]
                {
                    new CurrentFigureCalculation(
                        Image_Figure_Object : new MyControl<Image>(XamlControlStringArray: new string[]
                                              {"imgGeometryFigureQuadrat", GeometryImages + "kvadrat.png", "kvadrat"}),
                        MyLabelTextBoxRowArray : new MyLabelTextBoxRow[]
                        {
                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblQuadratLength", "Længde af kvadrat : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] {"lblQuadratLengthUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] {"txtQuadratLength", DefaultTextBoxValue }))
                        },
                        ResultTextBoxToCalculationNewArray : new ResultTextBoxToCalculationNew[]
                        {
                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblQuadratCircumference", "Omkreds af kvadrat : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] { "lblQuadratCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblQuadratCircumferenceFormula", "Omkreds = 4 * længde" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtQuadratCircumference", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateCircumferenceOfSquare,
                                NumberOfDimensionsInCalculationString : Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblQuadratArea", "Areal af kvadrat : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : Dimension2InCalculationString, XamlControlStringArray: new string[] {"lblQuadratAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblQuadratAreaFormula", "Areal = længde X længde" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] {"txtQuadratArea", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateAreaOfSQueare,
                                NumberOfDimensionsInCalculationString : Dimension2InCalculationString)
                        },
                        FigureDimensions : 2,
                        FigureName : "Kvadrat"),

                    new CurrentFigureCalculation(
                        Image_Figure_Object : new MyControl<Image>(XamlControlStringArray: new string[]
                                              {"imgGeometryFigureQuadrat", GeometryImages + "rektangel.png", "rektangel"}),
                        MyLabelTextBoxRowArray : new MyLabelTextBoxRow[]
                        {
                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblRectangleLength", "Længde af rektangel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblRectangleLengthUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtRectangleLength", DefaultTextBoxValue })),

                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblRectangleWidth", "Bredde af rektangel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel : true, XamlControlStringArray: new string[] { "lblRectangleWidthUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtRectangleWidth", DefaultTextBoxValue }))
                        },
                        ResultTextBoxToCalculationNewArray : new ResultTextBoxToCalculationNew[]
                        {
                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblRectangleCircumference", "Omkreds af rektangel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] { "lblRectangleCircumferenceUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblRectangleCircumferenceFormula", "Omkreds = 2 * længde + 2 * bredde" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtRectangleCircumference", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateCircumferenceOfRectangle,
                                NumberOfDimensionsInCalculationString : Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblRectangleArea", "Areal af rektangel : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : Dimension2InCalculationString, XamlControlStringArray: new string[] { "lblRectangleAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblRectangleAreaFormula", "Areal = længde X bredde" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtRectangleArea", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateAreaOfRectangle,
                                NumberOfDimensionsInCalculationString : Dimension2InCalculationString)
                        },
                        FigureDimensions : 2,
                        FigureName : "Rektangel"),

                    new CurrentFigureCalculation(
                        Image_Figure_Object : new MyControl<Image>(XamlControlStringArray: new string[]
                                              {"imgGeometryFigureBall", GeometryImages + "kugle.png", "bold"}),
                        MyLabelTextBoxRowArray : new MyLabelTextBoxRow[]
                        {
                            new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblBallRadius", "Radius af bold : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] {"lblBallRadiusUnit", "m" })
                                },
                                TextBox_Object : new MyTextBoxInputOutput(Input_Output_Enum : Input_Output_Enum.Input_Enum,
                                    XamlControlStringArray: new string[] { "txtBallRadiusUnit", DefaultTextBoxValue }))
                        },
                        ResultTextBoxToCalculationNewArray : new ResultTextBoxToCalculationNew[]
                        {
                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblBallDiameter", "Diameter af bold : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, XamlControlStringArray: new string[] { "lblBallDiameterUnit", "m" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblBallDiameterFormula", "Diameter = 2 * r" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtBallDiameter", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateDiameterFromRadius,
                                NumberOfDimensionsInCalculationString : Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblBallSurfaceArea", "Samlet overfladeareal af bold : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : Dimension2InCalculationString, XamlControlStringArray: new string[] { "llblBallSurfaceAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblBallSurfaceAreaFormula", "Overfladeareal = 4 * pi * r?2" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtBallSurfaceArea", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateBallSurfaceArea,
                                NumberOfDimensionsInCalculationString : Dimension2InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblBallVolume", "Rumfang af bold : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : Dimension3InCalculationString, XamlControlStringArray: new string[] { "lblBallVolumeUnit", "m3" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblBallVolumeFormula", "Rumfang = 4/3 * pi * r?3" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtBallVolume", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateBallVolume,
                                NumberOfDimensionsInCalculationString : Dimension3InCalculationString)
                        },
                        FigureDimensions : 3,
                        FigureName : "Bold")
                }
            );
    }
}
