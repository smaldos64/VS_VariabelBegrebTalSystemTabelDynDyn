﻿using System;
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
    #region Geometry
    public delegate double CalculateOnFigure(double[] NumberList);

    public enum Dimension2_Figures_Enum
    {
        Rectangle_Enum,
        Square_Enum
    }

    public enum Dimension3_Figures_Enum
    {
        Cylinder_Enum,
        Ball_Enum
    }

    public enum Input_Output_Enum
    {
        Input_Enum,
        Output_Enum,
        Input_Output_Enum
    }

    public class MyLabel
    {
        public string MyLabelName { get; set; }
        public string MyLabelContent { get; set; }
        public Label MyLabelControl { get; set; }

        public MyLabel(string MyLabelName, string MyLabelContent)
        {
            this.MyLabelName = MyLabelName;
            this.MyLabelContent = MyLabelContent;
        }
    }

    public class MyTextBox
    {
        public string MyTextBoxName { get; set; }
        public Label MyTextBoxControl { get; set; }
        public Input_Output_Enum Input_Output_Enum { get; set; }

        public MyTextBox(string MyTextBoxName, Input_Output_Enum Input_Output_Enum)
        {
            this.MyTextBoxName = MyTextBoxName;
            this.Input_Output_Enum = Input_Output_Enum;
        }
    }

    public class MyButton
    {
        public string MyButtonName { get; set; }
        public string MyButtonText { get; set; }
        public Button MyButtonControl { get; set; }

        public MyButton(string MyButtonName, string MyButtonText)
        {
            this.MyButtonName = MyButtonName;
            this.MyButtonText = MyButtonText;
        }
    }

    public class MyComboBox
    {
        public string MyComboBoxName { get; set; }
        public ComboBox ComboBox_Object { get; set; }

        public MyComboBox(string MyComboBoxName)
        {
            this.MyComboBoxName = MyComboBoxName;
        }
    }

    public class MyImage
    {
        public string MyImageName { get; set; }
        public Image Image_Object { get; set; }
    }

    public class MySimpleControl<T>
    {
        public string SimpleControlName { get; set; }
        public T SimpleControl {get; set;}
    }

    public class ResultTextBoxToCalculation
    {
        public MyTextBox MyTestBox_Object { get; set; }
        public CalculateOnFigure CalculateOnFigure_Delegate { get; set; }
        public string NumberOfDimensionsInCalculationString { get; set; }

        public ResultTextBoxToCalculation(MyTextBox MyTestBox_Object, CalculateOnFigure CalculateOnFigure_Delegate, string NumberOfDimensionsInCalculationString)
        {
            this.MyTestBox_Object = MyTestBox_Object;
            this.CalculateOnFigure_Delegate = CalculateOnFigure_Delegate;
            this.NumberOfDimensionsInCalculationString = NumberOfDimensionsInCalculationString;
        }
    }

    public class FigureCalculator
    {
        public string FigureName { get; set; }
        public string FigurePictureName { get; set; }

        public MyLabel[] FigureLabels { get; set; }

        public MyTextBox[] FigureTextBoxesInput { get; set; }

        public ResultTextBoxToCalculation[] FigureTextBoxesOutput { get; set; }

        public FigureCalculator(string FigureName, string FigurePictureName, MyLabel[] FigureLabels, MyTextBox[] FigureTextBoxesInput)
        {
            this.FigureName = FigureName;
            this.FigurePictureName = FigurePictureName;
            this.FigureLabels = FigureLabels;
            this.FigureTextBoxesInput = FigureTextBoxesInput;
        }
    }

    public class Figure2DimenCalculator : FigureCalculator
    {
        public ResultTextBoxToCalculation CalculateOnFigure_Area { get; set; }
        public ResultTextBoxToCalculation CalculateOnFigure_Circumference { get; set; }

        public Dimension2_Figures_Enum Dimension2_Figures_Enum { get; set; }

        public Figure2DimenCalculator(string FigureName, string FigurePictureName, MyLabel[] FigureLabels, MyTextBox[] FigureTextBoxesInput,
            ResultTextBoxToCalculation CalculateOnFigure_Area, ResultTextBoxToCalculation CalculateOnFigure_Circumference, Dimension2_Figures_Enum Dimension2_Figures_Enum) :
            base(FigureName, FigurePictureName, FigureLabels, FigureTextBoxesInput)
        {
            this.CalculateOnFigure_Area = CalculateOnFigure_Area;
            this.CalculateOnFigure_Circumference = CalculateOnFigure_Circumference;
        }
    }

    //--------------------------------------------------------------------------------------------

    public enum Figures_Enum
    {
        Rectangle_Enum,
        Square_Enum,
        Cylinder_Enum,
        Ball_Enum
    }

    public class MyControl<T>
    {
        public T XamlControl { get; set; }
        public string[] XamlControlStringArray { get; set; }

        public MyControl(string[] XamlControlStringArray)
        {
            this.XamlControlStringArray = XamlControlStringArray;
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

        // Konstruktoren herunder skal fjernes igen !!!
        //public MyLabelTextBoxRow(MyTextBoxInputOutput TextBox_Object)
        //{
        //    this.TextBox_Object = TextBox_Object;
        //}
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

    //-----------------------------------------------

    public class Figure2DimenCalculatorOverall
    {
        public Figure2DimenCalculator[] Figure2DimenCalculatorArray { get; set; }
        //public MyButton MyButton_Object { get; set; }
        //public ComboBox ComboBox_Unit_Object { get; set; }
        //public ComboBox ComboBox_Figure_Object { get; set; }

        public MyControl<Button> MyButton_Object { get; set; }
        public MyControl<ComboBox> ComboBox_Unit_Object { get; set; }
        public MyControl<ComboBox> ComboBox_Figure_Object { get; set; }
    }

    public class Figure3DimensionCalculator : FigureCalculator
    {
        public CalculateOnFigure CalculateOnFigure_SurfaceArea { get; set; }
        public CalculateOnFigure CalculateOnFigure_Volume { get; set; }

        public Dimension3_Figures_Enum Dimension3_Figures_Enum { get; set; }

        public Figure3DimensionCalculator(string FigureName, string FigurePictureName, MyLabel[] FigureLabels, MyTextBox[] FigureTextBoxes,
            CalculateOnFigure CalculateOnFigure_SurfaceArea, CalculateOnFigure CalculateOnFigure_Volume, Dimension3_Figures_Enum Dimension3_Figures_Enum) :
            base(FigureName, FigurePictureName, FigureLabels, FigureTextBoxes)
        {
            this.CalculateOnFigure_SurfaceArea = CalculateOnFigure_SurfaceArea;
            this.CalculateOnFigure_Volume = CalculateOnFigure_Volume;
        }
    }
    #endregion

    #region UnitsConverter
    public struct UnitInPlace
    {
        public int UnitInPlaceRow;
        public int UnitInPlaceColumn;

        public UnitInPlace(int UnitInPlaceRow, int UnitInPlaceColumn)
        {
            this.UnitInPlaceRow = UnitInPlaceRow;
            this.UnitInPlaceColumn = UnitInPlaceColumn;
        }
    }

    public class UnitsConverter
    {
        public double FactorToBaseUnit { get; set; }
        public string UnitShortName { get; set; }
        public string UnitLongName { get; set; }
        public TextBox TextBox_Object { get; set; }

        public UnitsConverter(double FactorToBaseUnit, string UnitShortName, string UnitLongName)
        {
            this.FactorToBaseUnit = FactorToBaseUnit;
            this.UnitShortName = UnitShortName;
            this.UnitLongName = UnitLongName;
        }
    }

    public class UnitsOverallConverter
    {
        //public List<UnitsConverter> UnitsConverterList { get; set; }
        public UnitsConverter[] UnitsConverterArray { get; set; }
        public string UnitsBelongTo { get; set; }
        public Units_ENUM This_Units_ENUM { get; set; }
        public Button Button_Object { get; set; }

        //public UnitsOverallConverter(List<UnitsConverter> UnitsConverterList, string UnitsBelongTo, Units_ENUM This_Units_ENUM)
        public UnitsOverallConverter(UnitsConverter[] UnitsConverterArray, string UnitsBelongTo, Units_ENUM This_Units_ENUM)
        {
            this.UnitsConverterArray = UnitsConverterArray;
            this.UnitsBelongTo = UnitsBelongTo;
            this.This_Units_ENUM = This_Units_ENUM;
        }
    }

    public enum Units_ENUM
    {
        LENGTH_ENUM,
        AREA_ENUM,
        VOLUME_ENUM,
        WEIGHT_ENUM,
        LIQUID_ENUM,
        TIME_ENUM
    }
    #endregion

    //public enum ComboBox_ENUM
    //{
    //    SPACE_CHARACTER_COUNTER,
    //    SPACE_CHARACTER
    //}

    #region NumberSystems
    public enum RadixNumber_ENUM
    {
        BINARY_NUMBER,
        OCTAL_NUMBER,
        DECIMAL_NUMBER,
        HEXADECIMAL_NUMBER,
        RADIX24_NUMBER,
        RADIX32_NUMBER,
        ROMER_NUMBER,
    }

    public class ConstRadixSystem
    {
        public int RadixValue { get; set; }
        public int RadixSpaceCounter { get; set; }
        public char RadixSpaceCharacter { get; set; }
        public Key[] ValidKeysArray;

        public ConstRadixSystem(int RadixValue, int RadixSpaceCounter,
                                char RadixSpaceCharacter, Key[] ValidKeysArray)
        {
            this.RadixValue = RadixValue;
            this.RadixSpaceCounter = RadixSpaceCounter;
            this.RadixSpaceCharacter = RadixSpaceCharacter;
            this.ValidKeysArray = ValidKeysArray;
        }

        public ConstRadixSystem()
        {

        }
    }

    public delegate string ConvertFromRadix10Int(int Radix10Number, char CharacterToInsert, int CharacterToInsertCouner);
    public delegate int ConvertToRadix10Int(string Radix10String, char CharacterToRemove);

    public class ConstRadixSystemAndDelegates
    {
        public ConstRadixSystem ConstRadixSystem_Object { get; set; }
        public ConvertToRadix10Int FunctionPointerToRadix10 { get; set; }
        public ConvertFromRadix10Int FunctionPointerFromRadix10 { get; set; }
        public TextBox TextBox_Object { get; set; }
        public string TextBox_Object_Name { get; set; }
        public string Label_Object_Name { get; set; } 
        public string Label_Object_Text { get; set; }

        public ComboBox ComboBox_Object_RadixSpaceCounter { get; set; }
        public string ComboBox_Object_RadixSpaceCounter_Name { get; set; }
        public ComboBox ComboBox_Object_RadixSpaceCharacter { get; set; }
        public string ComboBox_Object_RadixSpaceCharacter_Name { get; set; }
        public Button Button_Object_Delete { get; set; }
        public string Button_Object_Delete_Name { get; set; }

        public int FirstLabelInGridRowPosition { get; set; }
        public int GridRowPosition { get; set; }

        public ConstRadixSystemAndDelegates(ConstRadixSystem ConstRadixSystem_Object,
                                            string TextBox_Object_Name,
                                            string Label_Object_Name,
                                            string Label_Object_Text,
                                            ConvertToRadix10Int FunctionPointerToRadix10,
                                            ConvertFromRadix10Int FunctionPointerFromRadix10)
        {
            this.ConstRadixSystem_Object = ConstRadixSystem_Object;
            this.TextBox_Object_Name = TextBox_Object_Name;
            this.Label_Object_Name = Label_Object_Name;
            this.Label_Object_Text = Label_Object_Text;
            this.FunctionPointerToRadix10 = FunctionPointerToRadix10;
            this.FunctionPointerFromRadix10 = FunctionPointerFromRadix10;
        }

        public ConstRadixSystemAndDelegates(ConstRadixSystem ConstRadixSystem_Object,
                                            string TextBox_Object_Name,
                                            string Label_Object_Name,
                                            string Label_Object_Text,
                                            string ComboBox_Object_RadixSpaceCharacter_Name,
                                            string ComboBox_Object_RadixSpaceCounter_Name,
                                            string Button_Object_Delete_Name,
                                            ConvertToRadix10Int FunctionPointerToRadix10,
                                            ConvertFromRadix10Int FunctionPointerFromRadix10)
        {
            this.ConstRadixSystem_Object = ConstRadixSystem_Object;
            this.TextBox_Object_Name = TextBox_Object_Name;
            this.Label_Object_Name = Label_Object_Name;
            this.Label_Object_Text = Label_Object_Text;
            this.FunctionPointerToRadix10 = FunctionPointerToRadix10;
            this.FunctionPointerFromRadix10 = FunctionPointerFromRadix10;

            this.ComboBox_Object_RadixSpaceCharacter_Name = ComboBox_Object_RadixSpaceCharacter_Name;
            this.ComboBox_Object_RadixSpaceCounter_Name = ComboBox_Object_RadixSpaceCounter_Name;
            this.Button_Object_Delete_Name = Button_Object_Delete_Name;
        }

        public ConstRadixSystemAndDelegates()
        {
            this.ConstRadixSystem_Object = new ConstRadixSystem();
        }
    }

    public class ConstRadixSystemAndDelegatesExtended
    {
        public ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object { get; set; }
        public RadixNumber RadixNumber_Object { get; set; }

        public ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object,
                                                    RadixNumber RadixNumber_Object)
        {
            this.ConstRadixSystemAndDelegates_Object = ConstRadixSystemAndDelegates_Object;
            this.RadixNumber_Object = RadixNumber_Object;
        }

        public ConstRadixSystemAndDelegatesExtended()
        {
            this.ConstRadixSystemAndDelegates_Object = new ConstRadixSystemAndDelegates();
            this.RadixNumber_Object = new RadixNumber();
        }
    }

    public class KeyToCharConverter
    {
        public int Value { get; set; }
        public int KeyValue { get; set; }
        public char KeyChar { get; set; }

        public KeyToCharConverter(int Value, int KeyValue, char KeyChar)
        {
            this.Value = Value;
            this.KeyValue = KeyValue;
            this.KeyChar = KeyChar;
        }
    }
    #endregion

    public class Const
    {
        //private const string Image2DimensionelPath = "\\Images\\Geometry2Dimensionel\\";
        //private const string Image3DimensionelPath = "\\Images\\Geometry3Dimensionel\\";
        //private const string GeometryImages = "/Images/GeometryFigures/";
        private const string GeometryImages = "d:\\lars\\WpfMathGeometryImages\\";

        private const string Dimension1InCalculationString = "";
        private const string Dimension2InCalculationString = "2";
        private const string Dimension3InCalculationString = "3";

        private const string DefaultTextBoxValue = "0";

        public const int ControlNamePositionInArray = 0;
        public const int ImageFileNamePositionInArray = 1;
        public const int LabelTextPositionInArray = 1;
        public const int TextBoxTextPositionInArray = 1;
        public const int ButtonTextPositionInArray = 1;
        public const int GeometryLabelStartColumn = 0;
        public const int GeometryLabelDefaultColumnSpan = 1;

        public const int ImageHeight = 200;

        #region Geometry
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
                                CalculateOnFigure_Delegate : MathGeometry.CalculateCircumferenceOfSquare,
                                NumberOfDimensionsInCalculationString : Dimension1InCalculationString),

                            new ResultTextBoxToCalculationNew(MyLabelTextBoxRow_Object : new MyLabelTextBoxRow(
                                LabelsArray : new MyLabelWithUnit[]
                                {
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] {"lblBallSurfaceArea", "Samlet overfladeareal af bold : " }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  true, UnitDimensionString : Dimension2InCalculationString, XamlControlStringArray: new string[] { "llblBallSurfaceAreaUnit", "m2" }),
                                    new MyLabelWithUnit(IsCurrentLabelAnUnitLabel :  false, XamlControlStringArray: new string[] { "lblBallSurfaceAreaFormula", "Overfladeareal = 4 * pi * r?3" }),
                                },
                                TextBox_Object : new MyTextBoxInputOutput(
                                Input_Output_Enum : Input_Output_Enum.Output_Enum, XamlControlStringArray: new string[] { "txtBallSurfaceArea", DefaultTextBoxValue })),
                                CalculateOnFigure_Delegate : MathGeometry.CalculateCircumferenceOfSquare,
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
                                CalculateOnFigure_Delegate : MathGeometry.CalculateAreaOfSQueare,
                                NumberOfDimensionsInCalculationString : Dimension3InCalculationString)
                        },
                        FigureDimensions : 3,
                        FigureName : "Bold")
                }                
            );
        
        //public static readonly Figure2DimenCalculator[] Figure2DimenCalculatorArray =
        //{
        //        new Figure2DimenCalculator
        //        (
        //            FigureName : "Kvadrat",
        //            FigurePictureName : Image2DimensionelPath + "kvadrat.png",
        //            FigureLabels : new MyLabel[]
        //            {
        //                new MyLabel(MyLabelName : "lblSideLength", MyLabelContent : "Indtast Sidelængde : ")
        //            },
        //            FigureTextBoxesInput: new MyTextBox[]
        //            {
        //                new MyTextBox(MyTextBoxName : "txtSideLength", Input_Output_Enum: Input_Output_Enum.Input_Enum)
        //            },
        //            CalculateOnFigure_Area : new ResultTextBoxToCalculation(new MyTextBox(MyTextBoxName : "txtAreaSqueare", Input_Output_Enum : Input_Output_Enum.Output_Enum),
        //                MathGeometry.CalculateAreaOfSQueare, NumberOfDimensionsInCalculationString : Dimension1InCalculationString),
        //            CalculateOnFigure_Circumference : new ResultTextBoxToCalculation(new MyTextBox(MyTextBoxName : "txtCircumferenceSqueare", Input_Output_Enum : Input_Output_Enum.Output_Enum),
        //                MathGeometry.CalculateCircumferenceOfSquare, NumberOfDimensionsInCalculationString : Dimension1InCalculationString),
        //            Dimension2_Figures_Enum : Dimension2_Figures_Enum.Square_Enum
        //        ),
        //        new Figure2DimenCalculator
        //        (
        //            FigureName : "Rekatangel",
        //            FigurePictureName : Image2DimensionelPath + "rektangel.png",
        //            FigureLabels : new MyLabel[]
        //            {
        //                new MyLabel(MyLabelName : "lblLength", MyLabelContent : "Indtast Længde : "),
        //                new MyLabel(MyLabelName : "lblWidth", MyLabelContent : "Indtast bredde : ")
        //            },
        //            FigureTextBoxesInput: new MyTextBox[]
        //            {
        //                new MyTextBox(MyTextBoxName : "txtLength", Input_Output_Enum: Input_Output_Enum.Input_Enum),
        //                new MyTextBox(MyTextBoxName : "txtWidth", Input_Output_Enum: Input_Output_Enum.Input_Enum)
        //            },
        //            CalculateOnFigure_Area : new ResultTextBoxToCalculation(new MyTextBox(MyTextBoxName : "txtAreaRectangle", Input_Output_Enum : Input_Output_Enum.Output_Enum),
        //                MathGeometry.CalculateAreaOfRectangle, NumberOfDimensionsInCalculationString : Dimension2InCalculationString),
        //            CalculateOnFigure_Circumference : new ResultTextBoxToCalculation(new MyTextBox(MyTextBoxName : "txtCircumferenceRectangle", Input_Output_Enum : Input_Output_Enum.Output_Enum),
        //                MathGeometry.CalculateCircumferenceOfRectangle, NumberOfDimensionsInCalculationString : Dimension1InCalculationString),
        //            Dimension2_Figures_Enum : Dimension2_Figures_Enum.Rectangle_Enum
        //        )
        //};
        #endregion

        #region UnitsConverter
        public static readonly int NumberOFRowsPrUnitSystem = 5;

        public static readonly UnitsOverallConverter[] UnitsOverallConverterArray =
        {
            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 1000, UnitShortName : "km", UnitLongName : "Kilometer"),
                    new UnitsConverter(FactorToBaseUnit : 100, UnitShortName : "hm", UnitLongName : "Hektometer"),
                    new UnitsConverter(FactorToBaseUnit : 10, UnitShortName : "dam", UnitLongName : "Dekameter"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m", UnitLongName : "Meter"),
                    new UnitsConverter(FactorToBaseUnit : 0.1, UnitShortName : "dm", UnitLongName : "Decimeter"),
                    new UnitsConverter(FactorToBaseUnit : 0.01, UnitShortName : "cm", UnitLongName : "Centimeter"),
                    new UnitsConverter(FactorToBaseUnit : 0.001, UnitShortName : "mm", UnitLongName : "Milimeter")
                },
                UnitsBelongTo : "Længdemål",
                This_Units_ENUM : Units_ENUM.LENGTH_ENUM
            ),

            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 1000 * 1000, UnitShortName : "km2", UnitLongName : "Kvadrat Kilometer"),
                    new UnitsConverter(FactorToBaseUnit : 100 * 100, UnitShortName : "hektar", UnitLongName : "Hektar"),
                    new UnitsConverter(FactorToBaseUnit : 10 * 10, UnitShortName : "ar", UnitLongName : "Ar"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m2", UnitLongName : "Kvadrat Meter"),
                    new UnitsConverter(FactorToBaseUnit : 0.1 * 0.1, UnitShortName : "dm2", UnitLongName : "Kvadrat Decimeter"),
                    new UnitsConverter(FactorToBaseUnit : 0.01 * 0.01, UnitShortName : "cm2", UnitLongName : "Kvadrat Centimeter"),
                    new UnitsConverter(FactorToBaseUnit : 0.001 * 0.001, UnitShortName : "mm2", UnitLongName : "Kvadrat Milimeter")
                },
                UnitsBelongTo : "Areal/Flade",
                This_Units_ENUM : Units_ENUM.AREA_ENUM
            ),

            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 1000 * 1000 * 1000, UnitShortName : "km3", UnitLongName : "Kubik Kilometer"),
                    new UnitsConverter(FactorToBaseUnit : 100 * 100 * 100, UnitShortName : "hm3", UnitLongName : "Kubik Hektometer"),
                    new UnitsConverter(FactorToBaseUnit : 10 * 10 * 10, UnitShortName : "dam3", UnitLongName : "Kubik Dekamater"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m3/kl", UnitLongName : "Kubik Meter"),
                    new UnitsConverter(FactorToBaseUnit : 0.1 * 0.1 * 0.1, UnitShortName : "dm3/l", UnitLongName : "Kubik Decimeter/liter"),
                    new UnitsConverter(FactorToBaseUnit : 0.01 * 0.01 * 0.01, UnitShortName : "cm3/ml", UnitLongName : "Kubik Centimeter"),
                    new UnitsConverter(FactorToBaseUnit : 0.001 * 0.001 * 0.001, UnitShortName : "mm3", UnitLongName : "Kubik Milimeter")
                },
                UnitsBelongTo : "Rumfang/Volume",
                This_Units_ENUM : Units_ENUM.VOLUME_ENUM
            ),
            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 1000, UnitShortName : "kl", UnitLongName : "Kiloliter"),
                    new UnitsConverter(FactorToBaseUnit : 100, UnitShortName : "hl", UnitLongName : "Hektoliter"),
                    new UnitsConverter(FactorToBaseUnit : 10, UnitShortName : "dal", UnitLongName : "Dekaliter"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "l", UnitLongName : "Liter"),
                    new UnitsConverter(FactorToBaseUnit : 0.1, UnitShortName : "dl", UnitLongName : "Deciliter"),
                    new UnitsConverter(FactorToBaseUnit : 0.01, UnitShortName : "cl", UnitLongName : "Centiliter"),
                    new UnitsConverter(FactorToBaseUnit : 0.001, UnitShortName : "ml", UnitLongName : "Mililiter")
                },
                UnitsBelongTo : "Væske",
                This_Units_ENUM : Units_ENUM.VOLUME_ENUM
            ),
            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 1000, UnitShortName : "t", UnitLongName : "Ton"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "kg", UnitLongName : "Kilo"),
                    new UnitsConverter(FactorToBaseUnit : 0.1, UnitShortName : "h", UnitLongName : "Hektogram"),
                    new UnitsConverter(FactorToBaseUnit : 0.01, UnitShortName : "dk", UnitLongName : "Dekagram"),
                    new UnitsConverter(FactorToBaseUnit : 0.001, UnitShortName : "g", UnitLongName : "Gram")
                },
                UnitsBelongTo : "Vægt",
                This_Units_ENUM : Units_ENUM.WEIGHT_ENUM
            ),
            new UnitsOverallConverter
            (
                UnitsConverterArray : new UnitsConverter[]
                {
                    new UnitsConverter(FactorToBaseUnit : 24 * 60 * 60 * 365, UnitShortName : "År", UnitLongName : "År"),
                    new UnitsConverter(FactorToBaseUnit : 24 * 60 * 60, UnitShortName : "Dage", UnitLongName : "Dage"),
                    new UnitsConverter(FactorToBaseUnit : 60 * 60, UnitShortName : "t", UnitLongName : "Timer"),
                    new UnitsConverter(FactorToBaseUnit : 60, UnitShortName : "m", UnitLongName : "Minutter"),
                    new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "s", UnitLongName : "Sekunder")
                },
                UnitsBelongTo : "Tid",
                This_Units_ENUM : Units_ENUM.TIME_ENUM
            )
        };

        //public static readonly UnitsConverter[][] UnitsConverterControlsArray =
        //{
        //    new UnitsConverter[]
        //    {
        //        new UnitsConverter(FactorToBaseUnit : 1000, UnitShortName : "km", UnitLongName : "Kilometer"),
        //        new UnitsConverter(FactorToBaseUnit : 100, UnitShortName : "hm", UnitLongName : "Hektometer"),
        //        new UnitsConverter(FactorToBaseUnit : 10, UnitShortName : "dam", UnitLongName : "Dekameter"),
        //        new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m", UnitLongName : "Meter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/10, UnitShortName : "dm", UnitLongName : "Decimeter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/100, UnitShortName : "cm", UnitLongName : "Centimeter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/1000, UnitShortName : "mm", UnitLongName : "Milimeter")
        //    },

        //    new UnitsConverter[]
        //    {
        //        new UnitsConverter(FactorToBaseUnit : 1000 * 1000, UnitShortName : "km2", UnitLongName : "Kvadrat Kilometer"),
        //        new UnitsConverter(FactorToBaseUnit : 100 * 100, UnitShortName : "hektar", UnitLongName : "Hektar"),
        //        new UnitsConverter(FactorToBaseUnit : 10 * 10, UnitShortName : "ar", UnitLongName : "Ar"),
        //        new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m2", UnitLongName : "Kvadrat Meter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/10 * 1/10, UnitShortName : "dm2", UnitLongName : "Kvadrat Decimeter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/100 * 1/100, UnitShortName : "cm2", UnitLongName : "Kvadrat Centimeter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/1000 * 1/1000, UnitShortName : "mm2", UnitLongName : "Kvadrat Milimeter")
        //    },

        //    new UnitsConverter[]
        //    {
        //        new UnitsConverter(FactorToBaseUnit : 1000 * 1000 * 1000, UnitShortName : "km3", UnitLongName : "Kubik Kilometer"),
        //        new UnitsConverter(FactorToBaseUnit : 100 * 100 * 100, UnitShortName : "hm3", UnitLongName : "Kubik Hektometer"),
        //        new UnitsConverter(FactorToBaseUnit : 10 * 10 * 10, UnitShortName : "dam3", UnitLongName : "Kubik Dekamater"),
        //        new UnitsConverter(FactorToBaseUnit : 1, UnitShortName : "m3", UnitLongName : "Kubik Meter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/10 * 1/10 * 1/10, UnitShortName : "dm3/l", UnitLongName : "Kubik Decimeter / Liter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/100 * 1/100 * 1/100, UnitShortName : "cm3", UnitLongName : "Kubik Centimeter"),
        //        new UnitsConverter(FactorToBaseUnit : 1/1000 * 1/1000 * 1/1000, UnitShortName : "mm3", UnitLongName : "Kubik Milimeter")
        //    }
        //};
        #endregion

        #region NumberSystems
        public static readonly int GridStartNumberSystemRow = 5;
        public static readonly int LabelColumnPosition = 0;
        public static readonly int LabelColumnSpanShort = 1;
        public static readonly int LabelColumnSpan = 2;
        public static readonly int TextBoxColumnPosition = 2;
        public static readonly int TextBoxColumnSpanShort = 1;
        public static readonly int TextBoxColumnSpan = 4;
        public static readonly int TextBoxWidthShort = 100;
        public static readonly int TextBoxWidth = 240;
        public static readonly int TextBoxHeight = 23;

        public static readonly int ComboBoxRadixSpaceCounterColumn = 6;
        public static readonly int ComboBoxRadixSpaceCharacterColumn = 8;

        public static readonly int ButtonxRadixDeleteColumn = 9;
        public static readonly int ButtonxRadixDeleteColumnSpan = 2;
        public static readonly int ButtonxRadixDeleteHeight = 23;
        public static readonly int ButtonxRadixDeleteWidth = 70;
        
        public static readonly int DynamicElementsRowHeight = 40;
        public static readonly int ComboBoxRowHeight = 30; 

        public static readonly int MinRadixSystemValue = 2;
        public static readonly int MaxRadixSystemValue = 32;
        public static readonly int MinRadixSystemSpaces = 0;
        public static readonly int MaxRadixSystemSpaces = 5;

        public static readonly int NumberOfControlsInGridRow = 5;

        public static readonly char[] RadixSystemSpaceCharacterArray =
        {
            '.',
            ',',
            ' ',
            '#',
            '%',
            '@',
            '/',
            '\\'
        };

        private static Key[] Radix2ValidKeysArray = { Key.D0, Key.D1 };
        private static Key[] Radix8ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7};
        private static Key[] Radix10ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D2, Key.D3, Key.D4,
                                                       Key.D5, Key.D6, Key.D7, Key.D8, Key.D9};
        private static Key[] Radix16ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F};
        private static Key[] Radix24ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F,
                                                       Key.G, Key.H, Key.I, Key.J, Key.L, Key.M, Key.N, Key.O};
        private static Key[] Radix32ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7,
                                                       Key.D8, Key.D9, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F,
                                                       Key.G, Key.H, Key.I, Key.J, Key.K, Key.L, Key.M, Key.N,
                                                       Key.O, Key.P, Key.Q, Key.R, Key.S, Key.T, Key.U, Key.V};

        public static readonly ConstRadixSystem[] RadixSystemArray =
        {
            new ConstRadixSystem(RadixValue : 2, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix2ValidKeysArray),
            new ConstRadixSystem(RadixValue : 8, RadixSpaceCounter : 3, RadixSpaceCharacter : ' ', ValidKeysArray : Radix8ValidKeysArray),
            new ConstRadixSystem(RadixValue : 10, RadixSpaceCounter : 3, RadixSpaceCharacter : '.', ValidKeysArray : Radix10ValidKeysArray),
            new ConstRadixSystem(RadixValue : 16, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix16ValidKeysArray),
            new ConstRadixSystem(RadixValue : 24, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix24ValidKeysArray),
            new ConstRadixSystem(RadixValue : 32, RadixSpaceCounter : 4, RadixSpaceCharacter : ' ', ValidKeysArray : Radix32ValidKeysArray)
        };

        public static readonly ConstRadixSystemAndDelegates[] RadixSystemDelegatesAndControlsArray =
        {
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.BINARY_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtBinaryNumber",
                                             Label_Object_Name : "lblBinaryNumber",
                                             Label_Object_Text : "Binært tal (2 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.OCTAL_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtOctalNumber",
                                             Label_Object_Name : "lblOctalNumber",
                                             Label_Object_Text : "Oktalt tal (8 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtDecimalNumber",
                                             Label_Object_Name : "lblDecimalNumber",
                                             Label_Object_Text : "Decimaltal (10 tals system) : ",
                                             FunctionPointerToRadix10 : MainWindow.ConvertToRadix10IntFromRadix10String,
                                             FunctionPointerFromRadix10 : MainWindow.ConvertFromRadix10IntToRadix10String),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtHexadecimalNumber",
                                             Label_Object_Name : "lblHexadecimalNumber",
                                             Label_Object_Text : "Hexadecimalt tal (16 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.RADIX24_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtRadix24Number",
                                             Label_Object_Name : "lblRadixNumber",
                                             Label_Object_Text : "Radix 24 tal (24 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null),
            new ConstRadixSystemAndDelegates(ConstRadixSystem_Object :
                                             RadixSystemArray[(int)RadixNumber_ENUM.RADIX32_NUMBER],
                                             //TextBox_Object : null,
                                             TextBox_Object_Name : "txtRadix32Number",
                                             Label_Object_Name : "lblRadix32Number",
                                             Label_Object_Text : "Radix 32 tal (32 tals system) : ",
                                             FunctionPointerToRadix10 : null,
                                             FunctionPointerFromRadix10 : null)
        };

        public static readonly ConstRadixSystemAndDelegatesExtended[] RadixSystemDelegatesAndControlsExtendedArray =
        {
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.BINARY_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.BINARY_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.OCTAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.OCTAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.DECIMAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.HEXADECIMAL_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX24_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX24_NUMBER])),
            new ConstRadixSystemAndDelegatesExtended(ConstRadixSystemAndDelegates_Object : RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX32_NUMBER],
                                                     RadixNumber_Object : new RadixNumber(RadixSystemDelegatesAndControlsArray[(int)RadixNumber_ENUM.RADIX32_NUMBER]))
        };

        public static readonly KeyToCharConverter[] KeyToCharConverterArray =
        {
            new KeyToCharConverter(Value : 0, KeyValue : (int)Key.D0, KeyChar: '0'),
            new KeyToCharConverter(Value : 1, KeyValue : (int)Key.D1, KeyChar: '1'),
            new KeyToCharConverter(Value : 2, KeyValue : (int)Key.D2, KeyChar: '2'),
            new KeyToCharConverter(Value : 3, KeyValue : (int)Key.D3, KeyChar: '3'),
            new KeyToCharConverter(Value : 4, KeyValue : (int)Key.D4, KeyChar: '4'),
            new KeyToCharConverter(Value : 5, KeyValue : (int)Key.D5, KeyChar: '5'),
            new KeyToCharConverter(Value : 6, KeyValue : (int)Key.D6, KeyChar: '6'),
            new KeyToCharConverter(Value : 7, KeyValue : (int)Key.D7, KeyChar: '7'),
            new KeyToCharConverter(Value : 8, KeyValue : (int)Key.D8, KeyChar: '8'),
            new KeyToCharConverter(Value : 9, KeyValue : (int)Key.D9, KeyChar: '9'),
            new KeyToCharConverter(Value : 10, KeyValue : (int)Key.A, KeyChar: 'A'),
            new KeyToCharConverter(Value : 11, KeyValue : (int)Key.B, KeyChar: 'B'),
            new KeyToCharConverter(Value : 12, KeyValue : (int)Key.C, KeyChar: 'C'),
            new KeyToCharConverter(Value : 13, KeyValue : (int)Key.D, KeyChar: 'D'),
            new KeyToCharConverter(Value : 14, KeyValue : (int)Key.E, KeyChar: 'E'),
            new KeyToCharConverter(Value : 15, KeyValue : (int)Key.F, KeyChar: 'F'),
            new KeyToCharConverter(Value : 16, KeyValue : (int)Key.G, KeyChar: 'G'),
            new KeyToCharConverter(Value : 17, KeyValue : (int)Key.H, KeyChar: 'H'),
            new KeyToCharConverter(Value : 18, KeyValue : (int)Key.I, KeyChar: 'I'),
            new KeyToCharConverter(Value : 19, KeyValue : (int)Key.J, KeyChar: 'J'),
            new KeyToCharConverter(Value : 20, KeyValue : (int)Key.K, KeyChar: 'K'),
            new KeyToCharConverter(Value : 21, KeyValue : (int)Key.L, KeyChar: 'L'),
            new KeyToCharConverter(Value : 22, KeyValue : (int)Key.M, KeyChar: 'M'),
            new KeyToCharConverter(Value : 23, KeyValue : (int)Key.N, KeyChar: 'N'),
            new KeyToCharConverter(Value : 24, KeyValue : (int)Key.O, KeyChar: 'O'),
            new KeyToCharConverter(Value : 25, KeyValue : (int)Key.P, KeyChar: 'P'),
            new KeyToCharConverter(Value : 26, KeyValue : (int)Key.Q, KeyChar: 'Q'),
            new KeyToCharConverter(Value : 27, KeyValue : (int)Key.R, KeyChar: 'R'),
            new KeyToCharConverter(Value : 28, KeyValue : (int)Key.S, KeyChar: 'S'),
            new KeyToCharConverter(Value : 29, KeyValue : (int)Key.T, KeyChar: 'T'),
            new KeyToCharConverter(Value : 30, KeyValue : (int)Key.U, KeyChar: 'U'),
            new KeyToCharConverter(Value : 31, KeyValue : (int)Key.V, KeyChar: 'V'),
            new KeyToCharConverter(Value : 32, KeyValue : (int)Key.W, KeyChar: 'W'),
            new KeyToCharConverter(Value : 33, KeyValue : (int)Key.X, KeyChar: 'X'),
            new KeyToCharConverter(Value : 34, KeyValue : (int)Key.Y, KeyChar: 'Y'),
            new KeyToCharConverter(Value : 35, KeyValue : (int)Key.Z, KeyChar: 'Z')
        };

        public static List<Key> MakeKeyArrayToRadixSystem(int RadixSystemValue)
        {
            int Counter;
            List<Key> KeyList = new List<Key>();

            for (Counter = 0; Counter < RadixSystemValue; Counter++)
            {
                KeyList.Add((Key)KeyToCharConverterArray[Counter].KeyValue);
            }

            return (KeyList);
        }
        #endregion

        #region General_Stuff
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
