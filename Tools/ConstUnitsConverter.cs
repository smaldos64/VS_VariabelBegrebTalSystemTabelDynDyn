using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VariabelBegreb.Tools
{
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
        public UnitsConverter[] UnitsConverterArray { get; set; }
        public string UnitsBelongTo { get; set; }
        public Units_ENUM This_Units_ENUM { get; set; }
        public Button Button_Object { get; set; }

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
   
    public class ConstUnitsConverter
    {
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
    }
}
