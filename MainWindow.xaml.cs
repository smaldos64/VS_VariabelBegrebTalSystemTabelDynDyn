﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VariabelBegreb.Tools;
using VariabelBegreb.Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using VariabelBegreb.NumberSystems;
using System.Windows.Threading;

namespace VariabelBegreb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<TextBox> TextBoxList = new List<TextBox>();
        private static List<TextBox> TextBox1List = new List<TextBox>();
        private static List<TextBox> TextBox2List = new List<TextBox>();

        private static List<ConstRadixSystemAndDelegatesExtended> ConstRadixSystemAndDelegatesList = new List<ConstRadixSystemAndDelegatesExtended>();

        private DispatcherTimer RadixSystemTimer = new DispatcherTimer();
        private static int Index_In_Number_System_List = -1;
        private static int FirstIndexForDynamicRadixSystemsAdded = -1;
        private static int NumberDynamicRadixSystemsAdded = 0;

        public ObservableCollection<EquationSystemRow> EquationSystemRows { get; set; }
        public static char StartCoefficientChar = 'x';
        public static bool IsCurrentEquationSystemSolved = false;
        public static int CurrentNumberOfEquations = 0;
        public static int Current_Number_Of_Decimals = 3;
        public static bool NumberOfDecimalsChanged = false;

        private static string cmbSpeedOldString = "";
        private static string cmbTimeOldString = "";
        private static string cmbDistanceOldString = "";

        private static int IndexNumberInGeometryArray = 0;
        private static int RowDeleteNumberInGeometryGrid;
        private static int FirstControlToBeDeletedInGeometryGridCount;

        //private static List<TextBox> TextBoxListFigureInput = new List<TextBox>();
        //private static List<TextBox> TextBoxListFigureOutput = new List<TextBox>();

        private static List<TextBox> TextBoxListGeometryInput = new List<TextBox>();
        private static List<TextBox> TextBoxListGeometryOutput = new List<TextBox>();

        private static string UnitToUse = "";

        private static int IndexNumberInTrigonometryArray = 0;
        private static int RowDeleteNumberInTrigonometryGrid;
        private static int FirstControlToBeDeletedInTrigonometryGridCount;

        private static List<TextBox> TextBoxListTrigonometryInput = new List<TextBox>();
        private static List<TextBox> TextBoxListTrigonometryOutput = new List<TextBox>();

        private double APart;
        private double BPart;
        private double CPart;


        public MainWindow()
        {
            InitializeComponent();

            SetupRadixSystemTimer();

            InitializeDrivingCalculationLabels();

            InitializeEquationSystem();

            InitializeRadixNumbersLabels();

            InitializeRadixNumbersList();

            InitializeGeometryLabels();

            InitializeGeometryControls(); 

            InitializeTrigonometryLabels(); 

            InitializeTrigonometryControls(); 

            //InitializeGeometryControls();

            //InitializeEquationSystemLabels();

            //lstEquationSystem.ItemsSource = EquationSystemRows = new ObservableCollection<EquationSystemRow>();

            //InitializeComboBoxes();
        }


        /* Code in region below belongs to "Firkant" Tab */
        #region Square
        private void btnCalculateAreaSquare_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtLengthSquare);
            TextBoxList.Add(txtWidthSquare);

            if (2 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Der skal indtastes både en gyldig længde og en gyldig bredde værdi !!!");
            }
            else
            {
                double AreaSquare;
                double PerimeterSquare;
                double LengthSquare = Convert.ToDouble(txtLengthSquare.Text);
                double WidthSquare = Convert.ToDouble(txtWidthSquare.Text);
                double w = WidthSquare;
                // For at vise, at man også kan bruge korte variabelnavne.
                // Det kan ikke anbefales, da meningen med en vaiabel bliver
                // meget sværer at gennemskue !!!
                AreaSquare = LengthSquare * WidthSquare;

                //PerimeterSquare = Length + Length + Width + Width;
                //PerimeterSquare = 2 * Length + 2 * Width;
                PerimeterSquare = 2 * (LengthSquare + WidthSquare);

                //txtAreaSquare.Text = AreaSquare.ToString();
                txtAreaSquare.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(AreaSquare, Const.DefaultNumberOfDecimals);
                //txtPerimeterSquare.Text = PerimeterSquare.ToString();
                txtPerimeterSquare.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PerimeterSquare, Const.DefaultNumberOfDecimals);
            }
        }

        private void btnClearResult_Click(object sender, RoutedEventArgs e)
        {
            txtLengthSquare.Text = "";
            txtWidthSquare.Text = "";
            txtAreaSquare.Text = "";
            txtPerimeterSquare.Text = "";
        }
        #endregion


        /* Code in region below belongs to "Cirkel" Tab */
        #region Circle
        private void btnClearCircleParameters_Click(object sender, RoutedEventArgs e)
        {
            txtAreaCircle.Text = "";
            txtRadiusCircle.Text = "";
            txtPerimeterCircle.Text = "";
        }

        private void btnCalculateCircleParameters_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtRadiusCircle);

            if (1 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Der skal indtastes en gyldig radius værdi !!!");
            }
            else
            {
                double AreaCircle;
                double PerimeterCircle;
                double RadiusCircle = Convert.ToDouble(txtRadiusCircle.Text);

                AreaCircle = Math.PI * Math.Pow(RadiusCircle, 2);
                PerimeterCircle = Math.PI * RadiusCircle * 2;
                //txtAreaCircle.Text = AreaCircle.ToString();
                txtAreaCircle.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(AreaCircle, Const.DefaultNumberOfDecimals);
                //txtPerimeterCircle.Text = PerimeterCircle.ToString();
                txtPerimeterCircle.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PerimeterCircle, Const.DefaultNumberOfDecimals);
            }
        }
        #endregion

        /* Code in region below belongs to "Potens og Rod" Tab */
        #region PotensAndRoot
        private void btnCalculatePowerAndRoot_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtRadixNumber);
            TextBoxList.Add(txtPowerRootNumber);

            if (2 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Der skal være info i både rod og eksponent tekstboksene !!!");
            }
            else
            {
                double XRaisedToPowerY;
                double XRaisedToPowerOneDividedByY;
                double XRaisedToPowerMinusY;
                double XRaisedToPowerMinusOneDividedByY;

                double YRootOfX;
                double OneDividedByYRootOfX;
                double MinusYRootOfX;
                double OneDividedByMinusYRootOfX;

                double RadixNumber;
                double PowerRootNumber;

                RadixNumber = Convert.ToDouble(txtRadixNumber.Text);
                PowerRootNumber = Convert.ToDouble(txtPowerRootNumber.Text);

                XRaisedToPowerY = Math.Pow(RadixNumber, PowerRootNumber);
                XRaisedToPowerOneDividedByY = Math.Pow(RadixNumber, 1 / PowerRootNumber);
                XRaisedToPowerMinusY = Math.Pow(RadixNumber, -PowerRootNumber);
                XRaisedToPowerMinusOneDividedByY = Math.Pow(RadixNumber, -1 / PowerRootNumber);

                YRootOfX = Math.Pow(RadixNumber, 1 / PowerRootNumber);
                OneDividedByYRootOfX = Math.Pow(RadixNumber, PowerRootNumber);
                MinusYRootOfX = 1 / Math.Pow(RadixNumber, 1 / PowerRootNumber);
                OneDividedByMinusYRootOfX = 1 / Math.Pow(RadixNumber, PowerRootNumber);

                //txtRadixNumberInPower.Text = XRaisedToPowerY.ToString();
                txtRadixNumberInPower.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XRaisedToPowerY, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInDividedPower.Text = XRaisedToPowerOneDividedByY.ToString();
                txtRadixNumberInDividedPower.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XRaisedToPowerOneDividedByY, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInMinusPower.Text = XRaisedToPowerMinusY.ToString();
                txtRadixNumberInMinusPower.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XRaisedToPowerMinusY, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInMinusDividedPower.Text = XRaisedToPowerMinusOneDividedByY.ToString();
                txtRadixNumberInMinusDividedPower.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XRaisedToPowerMinusOneDividedByY, Const.DefaultNumberOfDecimals);

                //txtRadixNumberInRoot.Text = YRootOfX.ToString();
                txtRadixNumberInRoot.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(YRootOfX, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInDividedRoot.Text = OneDividedByYRootOfX.ToString();
                txtRadixNumberInDividedRoot.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(OneDividedByYRootOfX, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInMinusRoot.Text = MinusYRootOfX.ToString();
                txtRadixNumberInMinusRoot.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(MinusYRootOfX, Const.DefaultNumberOfDecimals);
                //txtRadixNumberInMinusDividedRoot.Text = OneDividedByMinusYRootOfX.ToString();
                txtRadixNumberInMinusDividedRoot.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(OneDividedByMinusYRootOfX, Const.DefaultNumberOfDecimals);

                lblRadixNumberInPower.Content = RadixNumber.ToString() + " opløftet i " +
                                                PowerRootNumber.ToString() + " potens : ";
                lblRadixNumberInDividedPower.Content = RadixNumber.ToString() + " opløftet i 1/" +
                                                       PowerRootNumber.ToString() + " potens : ";
                lblRadixNumberInMinusPower.Content = RadixNumber.ToString() + " opløftet i -" +
                                                     PowerRootNumber.ToString() + " potens : ";
                lblRadixNumberInMinusDividedPower.Content = RadixNumber.ToString() + " opløftet i -1/" +
                                                            PowerRootNumber.ToString() + " potens : ";

                lblRadixNumberInRoot.Content = PowerRootNumber.ToString() + "'rod af " +
                                               RadixNumber.ToString() + " : ";
                lblRadixNumberInDividedRoot.Content = "1/" + PowerRootNumber.ToString() + "'rod af " +
                                               RadixNumber.ToString() + " : ";
                lblRadixNumberInMinusRoot.Content = "-" + PowerRootNumber.ToString() + "'rod af " +
                                               RadixNumber.ToString() + " : ";
                lblRadixNumberInMinusDividedRoot.Content = "-1/" + PowerRootNumber.ToString() + "'rod af " +
                                               RadixNumber.ToString() + " : ";
            }
        }

        private void btnClearPowerAndRootParameters_Click(object sender, RoutedEventArgs e)
        {
            txtRadixNumber.Text = "";
            txtPowerRootNumber.Text = "";

            txtRadixNumberInPower.Text = "";
            txtRadixNumberInDividedPower.Text = "";
            txtRadixNumberInMinusPower.Text = "";
            txtRadixNumberInMinusDividedPower.Text = "";

            txtRadixNumberInRoot.Text = "";
            txtRadixNumberInDividedRoot.Text = "";
            txtRadixNumberInMinusRoot.Text = "";
            txtRadixNumberInMinusDividedRoot.Text = "";

            lblRadixNumberInPower.Content = "x opløftet i y potens : ";
            lblRadixNumberInDividedPower.Content = "x opløftet i 1/y potens : ";
            lblRadixNumberInMinusPower.Content = "x opløftet i -y potens : ";
            lblRadixNumberInMinusDividedPower.Content = "x opløftet i -1/y potens : ";

            lblRadixNumberInRoot.Content = "y'rod af x : ";
            lblRadixNumberInDividedRoot.Content = "1/y'rod af x : ";
            lblRadixNumberInMinusRoot.Content = "-y'rod af x : ";
            lblRadixNumberInMinusDividedRoot.Content = "y'rod af x : ";
        }
        #endregion

        /* Code in region below belongs to "Kørsel Beregning" Tab */
        #region DrivingCalculations
        private void InitializeDrivingCalculationLabels()
        {
            lblKoersel1.Content = "På dette faneblad kan du øverst lave beregninger om, 1) hvad det  ";
            lblKoersel1.Content += "koster at køre en distance i bil afhængig af 2) turens distance,";

            lblKoersel2.Content = "3) literpris i Benzin/Diesel og 4) brændstoføkonomi => hvor mange kilometer biler kører pr. liter.";
            lblKoersel2.Content += "Det er lavet sådan, at man skal indtaste 3 af de 4 felter nævnt herover ";

            lblKoersel3.Content = "og så vil programmet selv beregne den manglende størrelse. ";
            lblKoersel3.Content += "Grundformlen er : Pris (kr) = (Distance (km) x Benzinpris (kr/l) ) / Brændstoføkonomi (km/l)";

            lblKoersel4.Content = "På dette faneblad kan du nederst lave beregninger om, 1) en bil gennemsnitsfart  ";
            lblKoersel4.Content += "i km/t og/eller ms/s 2) en bils distance i km og/eller m og 3) en bils tid";

            lblKoersel5.Content = "på vejen i timer som decimal eller timer og minutter eller minutter. Det er lavet sådan,";
            lblKoersel5.Content += " at man skal indtaste 2 af de 3 felter nævnt herover.";

            lblKoersel6.Content = "Og så vil programmet selv beregne den manglende størrelse. ";
            lblKoersel6.Content += "Grundformlen er : Distance (km) = Fart (km/t) x Tid (t)";

            cmbSpeed.Items.Add("km/t");
            cmbSpeed.Items.Add("m/s");
            cmbSpeedOldString = "km/t";
            cmbSpeed.SelectedIndex = 0;

            cmbTime.Items.Add("t,m");
            cmbTime.Items.Add("t og m");
            cmbTime.Items.Add("m");
            cmbTimeOldString = "t,m";
            cmbTime.SelectedIndex = 0;

            cmbDistance.Items.Add("km");
            cmbDistance.Items.Add("m");
            cmbDistanceOldString = "km";
            cmbDistance.SelectedIndex = 0;
        }

        private void btnCalculateCarClear_Click(object sender, RoutedEventArgs e)
        {
            txtDistance.Text = "";
            txtPrice.Text = "";
            txtKrPrLitre.Text = "";
            txtKilometerPrLitre.Text = "";
        }

        private void btnCalculateCarCalculate_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtDistance);
            TextBoxList.Add(txtKilometerPrLitre);
            TextBoxList.Add(txtKrPrLitre);
            TextBoxList.Add(txtPrice);

            if (3 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Der skal være info i 3 af tekstboksene og kun 3 !!!");
            }
            else
            {
                double Distance = 0;
                double Price = 0;
                double KilometerPrLitre = 0;
                double KrPrLitre = 0;

                try
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);
                }
                catch (Exception Error)
                {

                }

                if (0 == txtPrice.Text.Length)
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);

                    Price = (Distance * KrPrLitre) / KilometerPrLitre;
                    txtPrice.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Price, 2);
                }

                if (0 == txtDistance.Text.Length)
                {
                    Price = Convert.ToDouble(txtPrice.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);

                    Distance = (Price * KilometerPrLitre) / KrPrLitre;
                    txtDistance.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Distance, 2);
                }

                if (0 == txtKilometerPrLitre.Text.Length)
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);

                    KilometerPrLitre = (Distance * KrPrLitre) / Price;
                    txtKilometerPrLitre.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(KilometerPrLitre, 2);
                }

                if (0 == txtKrPrLitre.Text.Length)
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);

                    KrPrLitre = (Price * KilometerPrLitre) / Distance;
                    txtKrPrLitre.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(KrPrLitre, 2);
                }
            }
        }

        // Nedre blok ting herunder !!!

        private void btnCalculateCarCalculateDistance_Time_Speed_Click(object sender, RoutedEventArgs e)
        {
            bool ExtendedField = false;

            TextBox1List.Clear();
            TextBox1List.Add(txtDistance_1);
            TextBox1List.Add(txtSpeed);
            if ("t og m" == (string)cmbTime.SelectedValue)
            {
                TextBox1List.Add(txtTimeHour);
                TextBox1List.Add(txtTimeMinute);
                ExtendedField = true;
                TextBox2List.Clear();
                TextBox2List.Add(txtTimeHour);
                TextBox2List.Add(txtTimeMinute);
            }
            else
            {
                TextBox1List.Add(txtTime);
            }

            if (true == ExtendedField)
            {
                if (1 == ControlTools.CheckTextBoxesForInformation(TextBox2List))
                {
                    MessageBox.Show("Der skal være info i enten 0 eller 2 af tekstboksene med tid !!!");
                }
                else
                {
                    if (0 == ControlTools.CheckTextBoxesForInformation(TextBox2List))
                    {
                        if (2 != ControlTools.CheckTextBoxesForInformation(TextBox1List))
                        {
                            MessageBox.Show("Der skal være info i både Fart og Distance tekstboksene !!!");
                        }
                        else
                        {
                            CalculateTime();
                        }
                    }
                    else
                    {
                        if (0 == txtSpeed.Text.Length)
                        {
                            CalculateSpeed();
                        }
                        else
                        {
                            CalculateDistance();
                        }
                    }
                }
            }
            else
            {
                if (2 != ControlTools.CheckTextBoxesForInformation(TextBox1List))
                {
                    MessageBox.Show("Der skal være info i 2 af tekstboksene og kun 2 !!!");
                }
                else
                {
                    if (0 == txtTime.Text.Length)
                    {
                        CalculateTime();
                    }

                    if (0 == txtDistance_1.Text.Length)
                    {
                        CalculateDistance();
                    }

                    if (0 == txtSpeed.Text.Length)
                    {
                        CalculateSpeed();
                    }
                }
            }
        }

        private double CalculateSpeedInKmPrHour()
        {
            if ("km/t" == (string)cmbSpeed.SelectedValue)
            {
                return (Convert.ToDouble(txtSpeed.Text));
            }
            else
            {
                return (3.6 * Convert.ToDouble(txtSpeed.Text));
            }
        }

        private double CalculateSpeedInKmPrHour(string SelectedFormat)
        {
            if ("km/t" == SelectedFormat)
            {
                try
                {
                    return (Convert.ToDouble(txtSpeed.Text));
                }
                catch (Exception Error)
                {
                    return (0);
                }
            }
            else
            {
                try
                {
                    return (3.6 * Convert.ToDouble(txtSpeed.Text));
                }
                catch (Exception Error)
                {
                    return (0);
                }
            }
        }

        private double CalculateDistanceInKm(String SelectedFormat)
        {
            if ("km" == SelectedFormat)
            {
                try
                {
                    return (Convert.ToDouble(txtDistance_1.Text));
                }
                catch (Exception Error)
                {
                    return (0);
                }
            }
            else
            {
                try
                {
                    return (Convert.ToDouble(txtDistance_1.Text) / 1000);
                }
                catch (Exception Error)
                {
                    return (0);
                }
            }
        }

        private double CalculateDistanceInKm()
        {
            if ("km" == (string)cmbDistance.SelectedValue)
            {
                return (Convert.ToDouble(txtDistance_1.Text));
            }
            else
            {
                return (Convert.ToDouble(txtDistance_1.Text) / 1000);
            }
        }

        private double CalculateTimeInHours(string TimeString, string MinuteString = "")
        {
            double TimeInHour = 0;

            switch (cmbTime.SelectedValue)
            {
                case "t,m":
                    TimeInHour = Convert.ToDouble(TimeString);
                    break;

                case "t og m":
                    TimeInHour = Convert.ToDouble(TimeString) + Convert.ToDouble(MinuteString) / 60;
                    break;

                case "m":
                    TimeInHour = Convert.ToDouble(TimeString) / 60;
                    break;
            }
            return (TimeInHour);
        }

        private double CalculateTimeInHours(string SelectedFormat)
        {
            double TimeInHour = 0;

            switch (SelectedFormat)
            {
                case "t,m":
                    try
                    {
                        TimeInHour = Convert.ToDouble(txtTime.Text);
                    }
                    catch (Exception Error)
                    {
                        TimeInHour = 0;
                    }
                    break;

                case "t og m":
                    try
                    {
                        TimeInHour = Convert.ToDouble(txtTimeHour.Text) + Convert.ToDouble(txtTimeMinute.Text) / 60;
                    }
                    catch (Exception Error)
                    {
                        TimeInHour = 0;
                    }
                    break;

                case "m":
                    try
                    {
                        TimeInHour = Convert.ToDouble(txtTime.Text) / 60;
                    }
                    catch (Exception Error)
                    {
                        TimeInHour = 0;
                    }
                    break;
            }
            return (TimeInHour);
        }

        private double CalculateTimeInHours()
        {
            double TimeInHour = 0;

            switch (cmbTime.SelectedValue)
            {
                case "t,m":
                    TimeInHour = Convert.ToDouble(txtTime.Text);
                    break;

                case "t og m":
                    TimeInHour = Convert.ToDouble(txtTimeHour.Text) + Convert.ToDouble(txtTimeMinute.Text) / 60;
                    break;

                case "m":
                    TimeInHour = Convert.ToDouble(txtTime.Text) / 60;
                    break;
            }
            return (TimeInHour);
        }

        private void ConvertTimeInHoursToString(double TimeInHour)
        {
            switch (cmbTime.SelectedValue)
            {
                case "t,m":
                    if (TimeInHour > 0)
                    {
                        txtTime.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(TimeInHour, 2);
                    }
                    else
                    {
                        txtTime.Text = "";
                    }
                    break;

                case "t og m":
                    if (TimeInHour > 0)
                    {
                        txtTimeHour.Text = Math.Floor(TimeInHour).ToString();
                        txtTimeMinute.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals((TimeInHour - Math.Truncate(TimeInHour)) * 60, 2);
                    }
                    else
                    {
                        txtTimeHour.Text = "";
                        txtTimeMinute.Text = "";
                    }
                    break;

                case "m":
                    if (TimeInHour > 0)
                    {
                        txtTime.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(TimeInHour * 60, 2);
                    }
                    else
                    {
                        txtTime.Text = "";
                    }
                    break;
            }
        }

        private void ConvertDistanceInKmToString(double DistanceInKm)
        {
            txtDistance_1.Text = "";

            switch (cmbDistance.SelectedValue)
            {
                case "km":
                    if (DistanceInKm > 0)
                    {
                        txtDistance_1.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(DistanceInKm, 2);
                    }
                    break;

                case "m":
                    if (DistanceInKm > 0)
                    {
                        txtDistance_1.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(DistanceInKm * 1000, 2);
                    }
                    break;
            }
        }

        private void ConvertSpeedInKmPrHourToString(double SpeedInKmPrHour)
        {
            txtSpeed.Text = "";
            switch (cmbSpeed.SelectedValue)
            {
                case "km/t":
                    if (SpeedInKmPrHour > 0)
                    {
                        txtSpeed.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SpeedInKmPrHour, 2);
                    }
                    break;

                case "m/s":
                    if (SpeedInKmPrHour > 0)
                    {
                        txtSpeed.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SpeedInKmPrHour / 3.6, 2);
                    }
                    break;
            }
        }

        private void CalculateTime()
        {
            double SpeedInHourPrKm = CalculateSpeedInKmPrHour();
            double DistanceInKm = CalculateDistanceInKm();

            double TimeInHour = DistanceInKm / SpeedInHourPrKm;

            ConvertTimeInHoursToString(TimeInHour);
        }

        private void CalculateSpeed()
        {
            double TimeInHours = CalculateTimeInHours();
            double DistanceInKm = CalculateDistanceInKm();

            double SpeedInHourPrKm = DistanceInKm / TimeInHours;

            ConvertSpeedInKmPrHourToString(SpeedInHourPrKm);
        }

        private void CalculateDistance()
        {
            double TimeInHours = CalculateTimeInHours();
            double SpeedInHourPrKm = CalculateSpeedInKmPrHour();

            double DistanceInKm = SpeedInHourPrKm * TimeInHours;

            ConvertDistanceInKmToString(DistanceInKm);
        }

        private void ShowTimeAndHourTextBoxes(bool ShowExtendedHourAndMinutesTextBoxes)
        {
            if (true == ShowExtendedHourAndMinutesTextBoxes)
            {
                txtTime.Visibility = Visibility.Hidden;
                txtTimeHour.Visibility = Visibility.Visible;
                txtTimeMinute.Visibility = Visibility.Visible;
                lblTimeHour.Visibility = Visibility.Visible;
                lblTimeMinute.Visibility = Visibility.Visible;

                Grid.SetColumn(btnClearSpeedField, 6);
                Grid.SetColumn(btnClearTimeField, 6);
                Grid.SetColumn(btnClearDistanceField, 6);

                Grid.SetColumn(cmbSpeed, 7);
                Grid.SetColumn(cmbTime, 7);
                Grid.SetColumn(cmbDistance, 7);

                Grid.SetColumn(btnCalculateCarCalculateDistance_Time_Speed, 9);
                Grid.SetColumn(btnCalculateCarClearDistance_Time_Speed, 9);

            }
            else
            {
                txtTime.Visibility = Visibility.Visible;
                txtTimeHour.Visibility = Visibility.Hidden;
                txtTimeMinute.Visibility = Visibility.Hidden;
                lblTimeHour.Visibility = Visibility.Hidden;
                lblTimeMinute.Visibility = Visibility.Hidden;

                Grid.SetColumn(btnClearSpeedField, 4);
                Grid.SetColumn(btnClearTimeField, 4);
                Grid.SetColumn(btnClearDistanceField, 4);

                Grid.SetColumn(cmbSpeed, 5);
                Grid.SetColumn(cmbTime, 5);
                Grid.SetColumn(cmbDistance, 5);

                Grid.SetColumn(btnCalculateCarCalculateDistance_Time_Speed, 7);
                Grid.SetColumn(btnCalculateCarClearDistance_Time_Speed, 7);
            }
        }

        private void cmbTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double TimeInHours;

            if ("t og m" == (string)cmbTime.SelectedValue)
            {
                ShowTimeAndHourTextBoxes(true);
            }
            else
            {
                ShowTimeAndHourTextBoxes(false);
            }

            TimeInHours = CalculateTimeInHours(cmbTimeOldString);
            ConvertTimeInHoursToString(TimeInHours);
            cmbTimeOldString = (string)cmbTime.SelectedValue;
        }

        private void cmbSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double SpeedInKmPrHour;

            SpeedInKmPrHour = CalculateSpeedInKmPrHour(cmbSpeedOldString);
            ConvertSpeedInKmPrHourToString(SpeedInKmPrHour);
            cmbSpeedOldString = (string)cmbSpeed.SelectedValue;
        }

        private void cmbDistance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double DistanceInKm;

            DistanceInKm = CalculateDistanceInKm(cmbDistanceOldString);
            ConvertDistanceInKmToString(DistanceInKm);
            cmbDistanceOldString = (string)cmbDistance.SelectedValue;
        }

        private void btnClearField_Click(object sender, RoutedEventArgs e)
        {
            switch (((System.Windows.FrameworkElement)sender).Name)
            {
                case "btnClearSpeedField":
                    txtSpeed.Text = "";
                    break;


                case "btnClearTimeField":
                    txtTime.Text = "";
                    txtTimeHour.Text = "";
                    txtTimeMinute.Text = "";
                    break;

                case "btnClearDistanceField":
                    txtDistance_1.Text = "";
                    break;
            }
        }

        private void btnCalculateCarClearDistance_Time_Speed_Click(object sender, RoutedEventArgs e)
        {
            txtSpeed.Text = "";

            txtTime.Text = "";
            txtTimeHour.Text = "";
            txtTimeMinute.Text = "";

            txtDistance_1.Text = "";
        }
        #endregion


        /* Code in region below belongs to "1 Grads Ligning" Tab */
        #region FirstOrderEquation
        private void btnCalculate1OrderLineEquation_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txt1OrderLineXCoordinatePoint1);
            TextBoxList.Add(txt1OrderLineYCoordinatePoint1);
            TextBoxList.Add(txt1OrderLineXCoordinatePoint2);
            TextBoxList.Add(txt1OrderLineYCoordinatePoint2);

            if (4 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Husk at indtast både x og y koordinat for begge punkter !!!");
            }
            else
            {
                double APart;
                double BPart;

                double Point1XCoordinate = Convert.ToDouble(txt1OrderLineXCoordinatePoint1.Text);
                double Point1YCoordinate = Convert.ToDouble(txt1OrderLineYCoordinatePoint1.Text);
                double Point2XCoordinate = Convert.ToDouble(txt1OrderLineXCoordinatePoint2.Text);
                double Point2YCoordinate = Convert.ToDouble(txt1OrderLineYCoordinatePoint2.Text);

                // Formel 1 fra Fri Viden Veoklip : a = (y2 - y1) / (x2 - x1) !!!
                APart = (Point2YCoordinate - Point1YCoordinate) / (Point2XCoordinate - Point1XCoordinate);

                // Formel 2 fra Fri Viden Veoklip : b = y - ax !!!
                BPart = Point1YCoordinate - APart * Point1XCoordinate;

                txtParametersFor1OrderLine.Text = "Den rette linje, der går gennem punkterne : ";
                txtParametersFor1OrderLine.Text += Environment.NewLine;
                txtParametersFor1OrderLine.Text += "(x1 ; y1) = (" + txt1OrderLineXCoordinatePoint1.Text + " ; " + txt1OrderLineYCoordinatePoint1.Text + " )";
                txtParametersFor1OrderLine.Text += Environment.NewLine;
                txtParametersFor1OrderLine.Text += "(x2 ; y2) = (" + txt1OrderLineXCoordinatePoint2.Text + " ; " + txt1OrderLineYCoordinatePoint2.Text + " )";
                txtParametersFor1OrderLine.Text += Environment.NewLine;
                txtParametersFor1OrderLine.Text += "Har lignigen : y = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(APart, Const.DefaultNumberOfDecimals) + "*x";
                if (0 != BPart)
                {
                    if (BPart > 0)
                    {
                        txtParametersFor1OrderLine.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(BPart, Const.DefaultNumberOfDecimals);
                    }
                    else
                    {
                        txtParametersFor1OrderLine.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * BPart, Const.DefaultNumberOfDecimals);
                    }
                }

                txtParametersFor1OrderLine.Text += Environment.NewLine;
                txtParametersFor1OrderLine.Text += "Som også kan skrives som : f(x) = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(APart, Const.DefaultNumberOfDecimals) + "*x";
                if (0 != BPart)
                {
                    if (BPart > 0)
                    {
                        txtParametersFor1OrderLine.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(BPart, Const.DefaultNumberOfDecimals);
                    }
                    else
                    {
                        txtParametersFor1OrderLine.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * BPart, Const.DefaultNumberOfDecimals);
                    }
                }
                txtParametersFor1OrderLine.Text += Environment.NewLine;

                if (0 == BPart)
                {
                    txtParametersFor1OrderLine.Text += "Da den rette linje går gennem punktet (0 ; 0) er der tale om en ligefrem proportionalitet.";
                    txtParametersFor1OrderLine.Text += Environment.NewLine;
                }
                else
                {
                    txtParametersFor1OrderLine.Text += "Da den rette linje ikke går gennem punktet (0 ; 0) er der tale om en proportionalitet (ret linje).";
                    txtParametersFor1OrderLine.Text += Environment.NewLine;
                }

                double XCoordinateForIntersectionWithXAxis;
                double YCoordinateForIntersectionWithYAxis;

                if (0 == BPart)
                {
                    txtParametersFor1OrderLine.Text += "Den rette linje skærer y aksen i punktet (0 ; 0)";
                    txtParametersFor1OrderLine.Text += Environment.NewLine;
                    txtParametersFor1OrderLine.Text += "Den rette linje skærer x aksen i punktet (0 ; 0)";
                }
                else
                {
                    // Formel 3 fra Fri Viden Veoklip : x = (y - b) / a !!!
                    XCoordinateForIntersectionWithXAxis = -BPart / APart;
                    YCoordinateForIntersectionWithYAxis = BPart;

                    txtParametersFor1OrderLine.Text += "Den rette linje skærer y aksen i punktet (0 ; " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(YCoordinateForIntersectionWithYAxis, Const.DefaultNumberOfDecimals) + ")";
                    txtParametersFor1OrderLine.Text += Environment.NewLine;
                    txtParametersFor1OrderLine.Text += "Den rette linje skærer x aksen i punktet (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XCoordinateForIntersectionWithXAxis, Const.DefaultNumberOfDecimals) + " ; 0)";
                }
            }
        }

        private void btnCalculate1OrderLineEquationClear_Click(object sender, RoutedEventArgs e)
        {
            txt1OrderLineXCoordinatePoint1.Text = "";
            txt1OrderLineYCoordinatePoint1.Text = "";
            txt1OrderLineXCoordinatePoint2.Text = "";
            txt1OrderLineYCoordinatePoint2.Text = "";
            txtParametersFor1OrderLine.Text = Const.txtParametersFor1OrderLineString;
        }
        #endregion


        /* Code in region below belongs to "2 Grads Ligning" Tab */
        #region SecondOrderEquation
        private void btnCalculateParabelEquation_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtParabelXCoordinatePoint1);
            TextBoxList.Add(txtParabelYCoordinatePoint1);
            TextBoxList.Add(txtParabelXCoordinatePoint2);
            TextBoxList.Add(txtParabelYCoordinatePoint2);
            TextBoxList.Add(txtParabelXCoordinatePoint3);
            TextBoxList.Add(txtParabelYCoordinatePoint3);

            if (6 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Husk at indtast både x og y koordinat for alle punkter !!!");
            }
            else
            {
                double Point1XCoordinate = Convert.ToDouble(txtParabelXCoordinatePoint1.Text);
                double Point1YCoordinate = Convert.ToDouble(txtParabelYCoordinatePoint1.Text);
                double Point2XCoordinate = Convert.ToDouble(txtParabelXCoordinatePoint2.Text);
                double Point2YCoordinate = Convert.ToDouble(txtParabelYCoordinatePoint2.Text);
                double Point3XCoordinate = Convert.ToDouble(txtParabelXCoordinatePoint3.Text);
                double Point3YCoordinate = Convert.ToDouble(txtParabelYCoordinatePoint3.Text);

                double Denominator1;
                double Denominator2;
                double Denominator3;

                Denominator1 = (Point1XCoordinate - Point2XCoordinate) * (Point1XCoordinate - Point3XCoordinate);
                Denominator2 = (Point2XCoordinate - Point1XCoordinate) * (Point2XCoordinate - Point3XCoordinate);
                Denominator3 = (Point3XCoordinate - Point1XCoordinate) * (Point3XCoordinate - Point2XCoordinate);

                double Part1Multiplier = Point1YCoordinate / Denominator1;
                double Nominator1_X_Square = Part1Multiplier;
                double Nominator1_X = (-(Point2XCoordinate) - (Point3XCoordinate)) * Part1Multiplier;
                double Nominator1 = ((-1 * Point2XCoordinate) * (-1 * Point3XCoordinate)) * Part1Multiplier;

                double Part2Multiplier = Point2YCoordinate / Denominator2;
                double Nominator2_X_Square = Part2Multiplier;
                double Nominator2_X = (-(Point1XCoordinate) - (Point3XCoordinate)) * Part2Multiplier;
                double Nominator2 = ((-1 * Point1XCoordinate) * (-1 * Point3XCoordinate)) * Part2Multiplier;

                double Part3Multiplier = Point3YCoordinate / Denominator3;
                double Nominator3_X_Square = Part3Multiplier;
                double Nominator3_X = (-(Point1XCoordinate) - (Point2XCoordinate)) * Part3Multiplier;
                double Nominator3 = ((-1 * Point1XCoordinate) * (-1 * Point2XCoordinate)) * Part3Multiplier;

                APart = Nominator1_X_Square + Nominator2_X_Square + Nominator3_X_Square;
                BPart = Nominator1_X + Nominator2_X + Nominator3_X;
                CPart = Nominator1 + Nominator2 + Nominator3;

                txtParametersForParabel.Text = "Parablen der går gennem punkterne : ";
                txtParametersForParabel.Text += Environment.NewLine;
                txtParametersForParabel.Text += "(x1 ; y1) = (" + txtParabelXCoordinatePoint1.Text + " ; " + txtParabelYCoordinatePoint1.Text + " )";
                txtParametersForParabel.Text += Environment.NewLine;
                txtParametersForParabel.Text += "(x2 ; y2) = (" + txtParabelXCoordinatePoint2.Text + " ; " + txtParabelYCoordinatePoint2.Text + " )";
                txtParametersForParabel.Text += Environment.NewLine;
                txtParametersForParabel.Text += "(x3 ; y3) = (" + txtParabelXCoordinatePoint3.Text + " ; " + txtParabelYCoordinatePoint3.Text + " )";
                txtParametersForParabel.Text += Environment.NewLine;
                txtParametersForParabel.Text += "Har lignigen : y = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(APart, Const.DefaultNumberOfDecimals) + "*x^2";


                if (0 != BPart)
                {
                    if (BPart > 0)
                    {
                        txtParametersForParabel.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(BPart, Const.DefaultNumberOfDecimals) + "x";
                    }
                    else
                    {
                        txtParametersForParabel.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * BPart, Const.DefaultNumberOfDecimals) + "x";
                    }
                }

                if (0 != CPart)
                {
                    if (CPart > 0)
                    {
                        txtParametersForParabel.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(CPart, Const.DefaultNumberOfDecimals);
                    }
                    else
                    {
                        txtParametersForParabel.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * CPart, Const.DefaultNumberOfDecimals);
                    }
                }

                txtParametersForParabel.Text += Environment.NewLine;
                txtParametersForParabel.Text += "Som også kan skrives som : f(x) = " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(APart, Const.DefaultNumberOfDecimals) + "*x^2";

                if (0 != BPart)
                {
                    if (BPart > 0)
                    {
                        txtParametersForParabel.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(BPart, Const.DefaultNumberOfDecimals) + "x";
                    }
                    else
                    {
                        txtParametersForParabel.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * BPart, Const.DefaultNumberOfDecimals) + "x";
                    }
                }

                if (0 != CPart)
                {
                    if (CPart > 0)
                    {
                        txtParametersForParabel.Text += " + " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(CPart, Const.DefaultNumberOfDecimals);
                    }
                    else
                    {
                        txtParametersForParabel.Text += " - " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(-1 * CPart, Const.DefaultNumberOfDecimals);
                    }
                }

                txtParametersForParabel.Text += Environment.NewLine;

                double Diskriminant;
                double XParameterRoot1;
                double XParameterRoot2;

                Diskriminant = Math.Pow(BPart, 2) - 4 * APart * CPart;
                txtParametersForParabel.Text += "Diskriminanten er : " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Diskriminant, Const.DefaultNumberOfDecimals);
                txtParametersForParabel.Text += Environment.NewLine;

                if (Diskriminant < 0)
                {
                    txtParametersForParabel.Text += "Parablen har ingen rødder => den skærer ikke x-aksen i nogle punkter.";
                }
                else
                {
                    if (0 == Diskriminant)
                    {
                        XParameterRoot1 = -BPart / (2 * APart);
                        txtParametersForParabel.Text += "Parablen har dobbelt roden : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                    else
                    {
                        XParameterRoot1 = (-BPart - Math.Sqrt(Diskriminant)) / (2 * APart);
                        XParameterRoot2 = (-BPart + Math.Sqrt(Diskriminant)) / (2 * APart);
                        txtParametersForParabel.Text += "Parablen har rødderne : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0) og (" +
                            PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot2, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                }
                txtParametersForParabel.Text += Environment.NewLine;

                double PointExtremumXCoordinate;
                double PointExtremumYCoordinate;

                PointExtremumXCoordinate = -BPart / (2 * APart);
                PointExtremumYCoordinate = -Diskriminant / (4 * APart);

                txtParametersForParabel.Text += "Parablen har Toppunkt : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumXCoordinate, Const.DefaultNumberOfDecimals) + " ; " +
                   PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumYCoordinate, Const.DefaultNumberOfDecimals) + ")";

                btnShowGraphAndCalculatePointsForCalculatedParabel.IsEnabled = true;
            }
        }

        private void btnShowGraphAndCalculatePointsForCalculatedParabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalculateParabelEquationClear_Click(object sender, RoutedEventArgs e)
        {
            txtParametersForParabel.Text = Const.txtParametersForParabelString;
            txtParabelXCoordinatePoint1.Text = "";
            txtParabelYCoordinatePoint1.Text = "";
            txtParabelXCoordinatePoint2.Text = "";
            txtParabelYCoordinatePoint2.Text = "";
            txtParabelXCoordinatePoint3.Text = "";
            txtParabelYCoordinatePoint3.Text = "";
        }

        private void btnCalculateParabelRoots_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtACoefficientInParabel);
            TextBoxList.Add(txtBCoefficientInParabel);
            TextBoxList.Add(txtCCoefficientInParabel);

            if (3 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Husk at indtast både A, B og C led. Også selvom leddet har vædien 0");
            }
            else
            {
                SecondOrderFunction SecondOrderFunction_Object = new SecondOrderFunction(txtParametersForParabelByCoefficients);

                SecondOrderFunction_Object.ACoefficient = Convert.ToDouble(txtACoefficientInParabel.Text);
                SecondOrderFunction_Object.BCoefficient = Convert.ToDouble(txtBCoefficientInParabel.Text);
                SecondOrderFunction_Object.CCoefficient = Convert.ToDouble(txtCCoefficientInParabel.Text);

                SecondOrderFunction_Object.CalculateAndShowAllPoints();

                //double ACoefficient;
                //double BCoefficient;
                //double CCoefficient;

                //ACoefficient = Convert.ToDouble(txtACoefficientInParabel.Text);
                //BCoefficient = Convert.ToDouble(txtBCoefficientInParabel.Text);
                //CCoefficient = Convert.ToDouble(txtCCoefficientInParabel.Text);

                //double Diskriminant;
                //double XParameterRoot1;
                //double XParameterRoot2;

                //Diskriminant = Math.Pow(BCoefficient, 2) - 4 * ACoefficient * CCoefficient;

                //txtParametersForParabelByCoefficients.Text = "Diskriminanten er : " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Diskriminant, Const.DefaultNumberOfDecimals);
                //txtParametersForParabelByCoefficients.Text += Environment.NewLine;

                //if (Diskriminant < 0)
                //{
                //    txtParametersForParabelByCoefficients.Text += "Parablen har ingen rødder => den skærer ikke x-aksen i nogle punkter.";
                //}
                //else
                //{
                //    if (0 == Diskriminant)
                //    {
                //        XParameterRoot1 = -BCoefficient / (2 * ACoefficient);
                //        txtParametersForParabelByCoefficients.Text += "Parablen har dobbelt roden : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0)";
                //    }
                //    else
                //    {
                //        XParameterRoot1 = (-BCoefficient - Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                //        XParameterRoot2 = (-BCoefficient + Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                //        txtParametersForParabelByCoefficients.Text += "Parablen har rødderne : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0) og (" +
                //            PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot2, Const.DefaultNumberOfDecimals) + " ; 0)";
                //    }
                //}
                //txtParametersForParabelByCoefficients.Text += Environment.NewLine;

                //double PointExtremumXCoordinate;
                //double PointExtremumYCoordinate;

                //PointExtremumXCoordinate = -BCoefficient / (2 * ACoefficient);
                //PointExtremumYCoordinate = -Diskriminant / (4 * ACoefficient);

                //txtParametersForParabelByCoefficients.Text += "Parablen har Toppunkt : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumXCoordinate, Const.DefaultNumberOfDecimals) + " ; " +
                //   PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumYCoordinate, Const.DefaultNumberOfDecimals) + ")";
            }
        }

        private void btnCalculateParabelRootsClear_Click(object sender, RoutedEventArgs e)
        {
            txtParametersForParabelByCoefficients.Text = Const.txtParametersForParabelByCoefficientsString;

            TextBoxList.Clear();
            TextBoxList.Add(txtACoefficientInParabel);
            TextBoxList.Add(txtBCoefficientInParabel);
            TextBoxList.Add(txtCCoefficientInParabel);
            ControlTools.ClearTextBoxes(TextBoxList);
        }

        private void btnShowGraphAndCalculatePointsForParabel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtACoefficientInParabel);
            TextBoxList.Add(txtBCoefficientInParabel);
            TextBoxList.Add(txtCCoefficientInParabel);

            if (3 != ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                MessageBox.Show("Husk at indtast alle koefficienter A, B og C (ogsp selvom de er 0)");
            }
            else
            {
                SecondOrderFunction SecondOrderFunction_Object = new SecondOrderFunction(txtParametersForParabelByCoefficients);

                SecondOrderFunction_Object.ACoefficient = Convert.ToDouble(txtACoefficientInParabel.Text);
                SecondOrderFunction_Object.BCoefficient = Convert.ToDouble(txtBCoefficientInParabel.Text);
                SecondOrderFunction_Object.CCoefficient = Convert.ToDouble(txtCCoefficientInParabel.Text);
                
                SecondOrderEquation SecondOrderEquation_Object = new SecondOrderEquation(SecondOrderFunction_Object);
                SecondOrderEquation_Object.Show();
            }
        }
        #endregion


        /* Code in region below belongs to "Ligningssystemer" Tab */
        #region EquationSystem
        private void InitializeEquationSystem()
        {
            InitializeEquationSystemLabels();

            lstEquationSystem.ItemsSource = EquationSystemRows = new ObservableCollection<EquationSystemRow>();

            InitializeComboBoxes();
        }

        private void InitializeEquationSystemLabels()
        {
            lblEquationSystem_1.Content = "På dette faneblad, kan løsningen til ligningssystemer af vilkårlig orden mellem 2 og 20";
            lblEquationSystem_2.Content = "beregnes. Metoden der anvendes er den såkaldte Determinant-metode.";
            lblEquationSystem_3.Content = "Alle ligninger i et angivet ligningssystem, skal være på formen : k1*a + k2*b + k3*c etc. = konstant";
            lblEquationSystem_4.Content = "Ved ligningssystemer af 2. orden (2 ligninger med 2 ubekendte) anvendes betegnelserne x og y for variable.";
            lblEquationSystem_5.Content = "Ved ligningssystemer af 3. orden (3 ligninger med 3 ubekendte) anvendes betegnelserne x, y og z for variable.";
            lblEquationSystem_6.Content = "Grunden til dette valg for 2. og 3. ordens ligningssystemer er, at løsningerne her også kan illustreres grafisk i et koordinatsystem i 2 og 3 dimensioner.";
            lblEquationSystem_7.Content = "For højere ordens lignigssystemer (4 og derover) forsvinder denne mulighed. Defor navngives variabler her startende fra a,b c, d og så fremdeles.";
        }

        private void InitializeComboBoxes()
        {
            int Counter = 0;

            for (Counter = Const.Min_Order_Of_Equations; Counter <= Const.Max_Order_Of_Equations; Counter++)
            {
                cmbEquationSystem.Items.Add(Counter);
            }
            ControlTools.SetComboBoxSelectedItem(cmbEquationSystem, Const.Min_Order_Of_Equations);

            for (Counter = Const.Min_Number_Of_Decimals; Counter <= Const.Max_Number_Of_Decimals; Counter++)
            {
                cmbNumberOfDecimals.Items.Add(Counter);
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberOfDecimals, Current_Number_Of_Decimals);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsCurrentEquationSystemSolved = false;
            txtSolution.Text = Const.EquationSystemNotSolvedString;
        }

        private void cmbEquationSystem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentNumberOfEquations = (int)cmbEquationSystem.SelectedValue;
            MakeEquationSystem(CurrentNumberOfEquations);
        }

        private void cmbNumberOfDecimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Current_Number_Of_Decimals = (int)cmbNumberOfDecimals.SelectedValue;
            if (true == IsCurrentEquationSystemSolved)
            {
                CalculateEquationSystem();
            }
            NumberOfDecimalsChanged = true;
        }

        private void btnCalculateEquationSystem_Click(object sender, RoutedEventArgs e)
        {
            CalculateEquationSystem();
        }

        private void btnClearEquationSystem_Click(object sender, RoutedEventArgs e)
        {
            int Counter = 0;
            int Counter1 = 0;

            for (Counter = 0; Counter < CurrentNumberOfEquations; Counter++)
            {
                for (Counter1 = 0; Counter1 < CurrentNumberOfEquations; Counter1++)
                {
                    EquationSystemRows[Counter].EquationSystemColumns[Counter1].txtEquationColumnName_Text = "";
                }
                EquationSystemRows[Counter].EquationSystemColumnConstants[0].txtEquationColumnConstantName_Text = "";
            }
        }

        private string GetFileNameOpen()
        {
            if (!Directory.Exists(Const.EqutionSystemDirectory))
            {
                Directory.CreateDirectory(Const.EqutionSystemDirectory);
            }

            OpenFileDialog OpenFileDialog_Object = new OpenFileDialog();
            OpenFileDialog_Object.RestoreDirectory = true;
            OpenFileDialog_Object.InitialDirectory = Const.EqutionSystemDirectory;
            OpenFileDialog_Object.DefaultExt = Const.EquationSystemExtension;
            OpenFileDialog_Object.Filter = "*Lignings Filer (*.equ) | *.equ";

            if (OpenFileDialog_Object.ShowDialog() == true)
            {
                return (OpenFileDialog_Object.FileName);
            }
            else
            {
                return ("");
            }
        }

        private string GetFileNameSave()
        {
            if (!Directory.Exists(Const.EqutionSystemDirectory))
            {
                Directory.CreateDirectory(Const.EqutionSystemDirectory);
            }

            SaveFileDialog SaveFileDialog_Object = new SaveFileDialog();
            SaveFileDialog_Object.RestoreDirectory = true;
            SaveFileDialog_Object.InitialDirectory = Const.EqutionSystemDirectory;
            SaveFileDialog_Object.DefaultExt = Const.EquationSystemExtension;
            SaveFileDialog_Object.Filter = "*Lignings Filer (*.equ) | *.equ";

            if (SaveFileDialog_Object.ShowDialog() == true)
            {
                return (SaveFileDialog_Object.FileName);
            }
            else
            {
                return ("");
            }
        }

        private void btnGetEquationSystemFromFile_Click(object sender, RoutedEventArgs e)
        {
            StreamReader FileReader;
            string FileLine;
            string SubString;
            string SubStringColumn = "";
            int SearchPosition;
            int RowCounter = 0;
            int ColumnCounter = 0;
            double NumberHolder;
            bool SoluionNotFound = true;

            string FileName = GetFileNameOpen();

            if (0 != FileName.Length)
            {
                FileReader = new StreamReader(FileName);

                FileLine = FileReader.ReadLine();
                SearchPosition = FileLine.IndexOf(":");
                if (SearchPosition > 0)
                {
                    SubString = FileLine.Substring(SearchPosition + 1);
                    SearchPosition = StringTools.FindFirstNonSpacePositionInString(SubString);
                    if (SearchPosition > 0)
                    {
                        SubString = SubString.Substring(SearchPosition);
                        if (int.TryParse(SubString, out CurrentNumberOfEquations))
                        {
                            ControlTools.SetComboBoxSelectedItem(cmbEquationSystem, CurrentNumberOfEquations);
                            MakeEquationSystem(CurrentNumberOfEquations);
                            RowCounter = 0;
                            do
                            {
                                FileLine = FileReader.ReadLine();
                                SearchPosition = FileLine.IndexOf(":");
                                if (SearchPosition > 0)
                                {
                                    SubString = FileLine.Substring(SearchPosition + 1);
                                    SearchPosition = StringTools.FindFirstNonSpacePositionInString(SubString);
                                    SubString = SubString.Substring(SearchPosition);
                                    for (ColumnCounter = 0; ColumnCounter < CurrentNumberOfEquations; ColumnCounter++)
                                    {
                                        SearchPosition = SubString.IndexOf(" ");
                                        SubStringColumn = SubString.Substring(0, SearchPosition);
                                        if (double.TryParse(SubStringColumn, out NumberHolder))
                                        {
                                            EquationSystemRows[RowCounter].EquationSystemColumns[ColumnCounter].txtEquationColumnName_Text = SubStringColumn;
                                        }
                                        SubString = SubString.Substring(SearchPosition + 2);
                                        SubString = SubString.TrimStart();
                                    }
                                    if (double.TryParse(SubString, out NumberHolder))
                                    {
                                        SubString = SubString.TrimEnd();
                                        EquationSystemRows[RowCounter].EquationSystemColumnConstants[0].txtEquationColumnConstantName_Text = SubString;
                                    }
                                    RowCounter++;
                                }
                            } while (RowCounter < CurrentNumberOfEquations);

                            FileLine = FileReader.ReadLine();
                            while ((FileLine != null) && (true == SoluionNotFound))
                            {
                                if (FileLine.IndexOf(Const.EquationSystemSolvedString) >= 0)
                                {
                                    CalculateEquationSystem();

                                    SoluionNotFound = false;
                                    IsCurrentEquationSystemSolved = true;
                                }
                                else
                                {
                                    FileLine = FileReader.ReadLine();
                                }
                            }
                            FileReader.Close();
                        }
                    }
                }
            }
        }

        private void btnSaveEquationSystemToFile_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter FileWriter;
            string FileName = GetFileNameSave();

            if (0 != FileName.Length)
            {
                FileWriter = new StreamWriter(FileName);
                FileWriter.WriteLine("Orden af Ligningssystem : {0}", CurrentNumberOfEquations);
                FileTools.WriteEmptyLinesInFileLine(FileWriter, 1);
                int RowCounter = 0;
                int ColumnCounter = 0;
                for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                {
                    FileWriter.Write("Ligning {0} : ", (RowCounter + 1));
                    FileTools.WriteSpacesInFileLine(FileWriter, 3);
                    for (ColumnCounter = 0; ColumnCounter < CurrentNumberOfEquations; ColumnCounter++)
                    {
                        if (!EquationSystemRows[RowCounter].EquationSystemColumns[ColumnCounter].txtEquationColumnName_Text.ParseStringZeroOrEmpty())
                        {
                            FileWriter.Write("0");
                            FileTools.WriteSpacesInFileLine(FileWriter, 3);
                        }
                        else
                        {
                            FileWriter.Write(EquationSystemRows[RowCounter].EquationSystemColumns[ColumnCounter].txtEquationColumnName_Text);
                            FileTools.WriteSpacesInFileLine(FileWriter, 3);
                        }
                    }
                    if (!EquationSystemRows[RowCounter].EquationSystemColumnConstants[0].txtEquationColumnConstantName_Text.ParseStringZeroOrEmpty())
                    {
                        FileWriter.Write("0");
                    }
                    else
                    {
                        FileWriter.Write(EquationSystemRows[RowCounter].EquationSystemColumnConstants[0].txtEquationColumnConstantName_Text);
                    }
                    FileWriter.WriteLine();
                }

                if (true == IsCurrentEquationSystemSolved)
                {
                    FileTools.WriteEmptyLinesInFileLine(FileWriter, 1);
                    List<string> SolutionList = ControlTools.GetAllLinesInTextBlock(txtSolution);
                    int SolutionLineCounter;
                    for (SolutionLineCounter = 0; SolutionLineCounter < SolutionList.Count; SolutionLineCounter++)
                    {
                        FileWriter.WriteLine(SolutionList[SolutionLineCounter]);
                    }
                }
                FileWriter.Close();
            }
        }

        private void EraseDynamicControls(int CurrentNumberOfEquations)
        {
            EquationSystemRows.Clear();
        }

        private void MakeEquationSystem(int CurrentNumberOfEquations)
        {
            char LabelChar = 'a';
            string TextboxName;
            string TextboxText;
            string TextboxLblName;
            string TextboxLblText;

            EraseDynamicControls(CurrentNumberOfEquations);

            if ((2 == CurrentNumberOfEquations) || (3 == CurrentNumberOfEquations))
            {
                StartCoefficientChar = 'x';
            }
            else
            {
                StartCoefficientChar = 'a';
            }

            for (int Counter = 1; Counter <= CurrentNumberOfEquations; Counter++)
            {
                LabelChar = StartCoefficientChar;

                TextboxName = "txt_" + Counter.ToString();
                TextboxText = "Equation " + Counter.ToString("00") + " : ";
                EquationSystemRows.Add(new EquationSystemRow(TextboxName, TextboxText));

                for (int Counter1 = 1; Counter1 <= CurrentNumberOfEquations; Counter1++)
                {
                    TextboxName = "txt_" + Counter.ToString() + "_" + Counter1.ToString();
                    TextboxLblName = "txt_lbl" + Counter.ToString() + "_" + Counter1.ToString();

                    if (Counter1 < CurrentNumberOfEquations)
                    {
                        TextboxLblText = " " + LabelChar + " + ";
                    }
                    else
                    {
                        TextboxLblText = " " + LabelChar + " = ";
                    }
                    EquationSystemRows[Counter - 1].EquationSystemColumns.Add(new EquationSystemColumn(TextboxName, TextboxLblName, TextboxLblText));

                    LabelChar++;
                }
                TextboxName = "txt_Const_" + Counter.ToString();
                EquationSystemRows[Counter - 1].EquationSystemColumnConstants.Add(new EquationSystemColumnConstant(TextboxName));
            }
            txtSolution.Text = "";
        }

        private void CalculateEquationSystem()
        {
            int RowCounter = 0;
            int ColumnCounter = 0;
            int RowAndColumnCunter;
            int RowCounterBackup;
            int NumberOfCoefficientsInRowNotZero;
            int ColumnContainingValue;
            int NumberOfConstantsNotZero;
            char CharCounter;
            bool EmptyFieldFound = false;
            bool NonZeroCoefficientFound = false;
            bool NoSolutionToEquationSystem = false;
            double AddFactor;
            double MultiplyFactor;
            List<List<double>> MatrixList = new List<List<double>>();

            List<MatrixCalculationCoefficients> MatrixCalculationCoefficientsList = new List<MatrixCalculationCoefficients>();
            MatrixCalculationCoefficients MatrixCalculationCoefficients_Object;

            List<double> ConvertList = new List<double>();

            // Tjek om en ligning indeholder mindst én koefficient
            RowCounter = 0;
            do
            {
                ColumnCounter = 0;
                EmptyFieldFound = true;
                do
                {
                    if (EquationSystemRows[RowCounter].EquationSystemColumns[ColumnCounter].txtEquationColumnName_Text.ParseStringZeroOrEmpty())
                    {
                        EmptyFieldFound = false;
                    }
                    else
                    {
                        ColumnCounter++;
                    }
                } while ((ColumnCounter < CurrentNumberOfEquations) && (true == EmptyFieldFound));
                if (false == EmptyFieldFound)
                {
                    RowCounter++;
                }
            } while ((RowCounter < CurrentNumberOfEquations) && (false == EmptyFieldFound));

            if (true == EmptyFieldFound)
            {
                MessageBox.Show(String.Format("Mindst én af koefficienterne i ligning {0} skal være forskellig fra 0 !!!", (RowCounter + 1)));
            }
            else
            {
                // Tjek om en koefficient er brugt i mindst én ligning
                RowCounter = 0;
                do
                {
                    ColumnCounter = 0;
                    EmptyFieldFound = true;
                    do
                    {
                        if (EquationSystemRows[ColumnCounter].EquationSystemColumns[RowCounter].txtEquationColumnName_Text.ParseStringZeroOrEmpty())
                        {
                            EmptyFieldFound = false;
                        }
                        else
                        {
                            ColumnCounter++;
                        }
                    } while ((ColumnCounter < CurrentNumberOfEquations) && (true == EmptyFieldFound));
                    if (false == EmptyFieldFound)
                    {
                        RowCounter++;
                    }
                } while ((RowCounter < CurrentNumberOfEquations) && (false == EmptyFieldFound));

                if (true == EmptyFieldFound)
                {
                    MessageBox.Show(String.Format("Mindst én af ligningerne skal indeholde koefficient : {0} !!!", (char)(StartCoefficientChar + RowCounter)));
                }
                else
                {
                    // Lignngssystemet opfylder kriteierne. Så nu kan vi beregneen evt. løsning til dette.

                    for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                    {
                        ConvertList = new List<double>();
                        for (ColumnCounter = 0; ColumnCounter < CurrentNumberOfEquations; ColumnCounter++)
                        {
                            ConvertList.Add(EquationSystemRows[RowCounter].EquationSystemColumns[ColumnCounter].txtEquationColumnName_Text.ReturnValueOrZero());
                        }
                        ConvertList.Add(EquationSystemRows[RowCounter].EquationSystemColumnConstants[0].txtEquationColumnConstantName_Text.ReturnValueOrZero());
                        MatrixList.Add(ConvertList);
                        //ConvertList.Clear();
                    }

                    CharCounter = StartCoefficientChar;
                    for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                    {
                        MatrixCalculationCoefficients_Object = new MatrixCalculationCoefficients(CharCounter);
                        MatrixCalculationCoefficientsList.Add(MatrixCalculationCoefficients_Object);
                        CharCounter++;
                    }

                    for (RowAndColumnCunter = 0; RowAndColumnCunter < CurrentNumberOfEquations; RowAndColumnCunter++)
                    {
                        RowCounter = RowAndColumnCunter;
                        NonZeroCoefficientFound = false;
                        do
                        {
                            if (MatrixList[RowCounter][RowAndColumnCunter] != 0)
                            {
                                // Vi har fundet en koefficient i søjlen under den pågældende række
                                // hvor værdier er forskellig fra nul.
                                RowCounterBackup = RowCounter;
                                if (1 != MatrixList[RowAndColumnCunter][RowAndColumnCunter])
                                {
                                    // Hvis værdien på den fundne koefficient ikke er lig med 1, sætter vi den til 1
                                    // og ændrer alle de andre koeffiientværier og konstantværdien for den pågældende
                                    // række i henhold hertil.
                                    MultiplyFactor = 1 / MatrixList[RowAndColumnCunter][RowAndColumnCunter];

                                    for (ColumnCounter = RowAndColumnCunter; ColumnCounter <= CurrentNumberOfEquations; ColumnCounter++)
                                    {
                                        MatrixList[RowCounter][ColumnCounter] = MultiplyFactor * MatrixList[RowCounter][ColumnCounter];
                                    }
                                }

                                for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                                {
                                    if ((RowCounter != RowCounterBackup) && (0 != MatrixList[RowCounter][RowAndColumnCunter]))
                                    {
                                        // Adder den række vi arbejder på til de andre rækker for at få 
                                        // nul i alle andre rækkers koefficintværdi på den påældende søjle
                                        // position. Hvis en række indeholder 0 i den nuværende søjle position, skal
                                        // vi dog ikke behandle denne række. Derfor 0 betingelsen i ovennævnte if statement.
                                        // Da vi har skaffet værdien 1 til koefficienten i rækken "RowCounterBackup" og 
                                        // søjlen "RowAndColumnCunter", kan vi let finde den faktor, som alle
                                        // resterende koefficienter i rækken "RowCounterBackup" skal ganges med før 
                                        // de lægges til de tilsvarende koefficienter i rækken "RowCounter".
                                        MultiplyFactor = -MatrixList[RowCounter][RowAndColumnCunter];
                                        for (ColumnCounter = RowAndColumnCunter; ColumnCounter <= CurrentNumberOfEquations; ColumnCounter++)
                                        {
                                            AddFactor = MultiplyFactor * MatrixList[RowCounterBackup][ColumnCounter];
                                            MatrixList[RowCounter][ColumnCounter] += AddFactor;
                                        }
                                    }
                                }
                                NonZeroCoefficientFound = true;
                            }
                            else
                            {
                                RowCounter++;
                            }
                        } while ((RowCounter < CurrentNumberOfEquations) && (false == NonZeroCoefficientFound));
                    }

                    NumberOfConstantsNotZero = 0;
                    for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                    {
                        if (0 != MatrixList[RowCounter][CurrentNumberOfEquations])
                        {
                            NumberOfConstantsNotZero++;
                        }
                    }

                    for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                    {
                        NumberOfCoefficientsInRowNotZero = 0;
                        ColumnContainingValue = -1;
                        for (ColumnCounter = 0; ColumnCounter < CurrentNumberOfEquations; ColumnCounter++)
                        {
                            if (1 == MatrixList[RowCounter][ColumnCounter])
                            {
                                NumberOfCoefficientsInRowNotZero++;
                                ColumnContainingValue = ColumnCounter;
                            }
                        }

                        if (1 == NumberOfCoefficientsInRowNotZero)
                        {
                            MatrixCalculationCoefficientsList[RowCounter].CoefficientValue = MatrixList[RowCounter][CurrentNumberOfEquations];
                            MatrixCalculationCoefficientsList[RowCounter].CoefficientFound = true;
                        }
                        else
                        {
                            NoSolutionToEquationSystem = true;
                        }
                    }

                    if (true == NoSolutionToEquationSystem)
                    {
                        MessageBox.Show("Ingen løsning til ligningssystem !!!");
                    }
                    else
                    {
                        txtSolution.Text = Const.EquationSystemSolvedString;
                        txtSolution.Text += Environment.NewLine;
                        for (RowCounter = 0; RowCounter < CurrentNumberOfEquations; RowCounter++)
                        {
                            txtSolution.Text += MatrixCalculationCoefficientsList[RowCounter].CoefficientLetter + " = " +
                                PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(MatrixCalculationCoefficientsList[RowCounter].CoefficientValue, Current_Number_Of_Decimals) + ";";
                            txtSolution.Text += Environment.NewLine;
                        }
                        IsCurrentEquationSystemSolved = true;
                    }
                }
            }
        }
        #endregion


        /* Code in region below belongs to "Brøkregning" Tab */
        #region FractionCalculations
        private void btnCalculateFraction_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtNominatorFraction1);
            TextBoxList.Add(txtDenominatorFraction1);
            TextBoxList.Add(txtNominatorFraction2);
            TextBoxList.Add(txtDenominatorFraction2);

            if (4 == ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                int NominatorResultAddition = 0;
                int DenominatorResultAddition = 0;

                int NominatorResultSubtraction = 0;
                int DenominatorResultSubtraction = 0;

                int NominatorResultMultiplication = 0;
                int DenominatorResultMultiplication = 0;

                int NominatorResultDivision = 0;
                int DenominatorResultDivision = 0;

                int NominatorFraction1 = Convert.ToInt32(txtNominatorFraction1.Text);
                int DenominatorFraction1 = Convert.ToInt32(txtDenominatorFraction1.Text);

                int NominatorFraction2 = Convert.ToInt32(txtNominatorFraction2.Text);
                int DenominatorFraction2 = Convert.ToInt32(txtDenominatorFraction2.Text);

                lblPlusFractions.Content = txtNominatorFraction1.Text + " / " +
                                           txtDenominatorFraction1.Text + "  +  " +
                                           txtNominatorFraction2.Text + " / " +
                                           txtDenominatorFraction2.Text + " er : ";

                lblMinusFractions.Content = txtNominatorFraction1.Text + " / " +
                                           txtDenominatorFraction1.Text + "  -  " +
                                           txtNominatorFraction2.Text + " / " +
                                           txtDenominatorFraction2.Text + " er : ";

                lblMultiplyFractions.Content = txtNominatorFraction1.Text + " / " +
                                           txtDenominatorFraction1.Text + "  *  " +
                                           txtNominatorFraction2.Text + " / " +
                                           txtDenominatorFraction2.Text + " er : ";

                lblDivideFractions.Content = txtNominatorFraction1.Text + " / " +
                                           txtDenominatorFraction1.Text + "  /  " +
                                           txtNominatorFraction2.Text + " / " +
                                           txtDenominatorFraction2.Text + " er : ";

                NominatorResultMultiplication = NominatorFraction1 * NominatorFraction2;
                DenominatorResultMultiplication = DenominatorFraction1 * DenominatorFraction2;
                txtFractionsMultiplyResult.Text = NominatorResultMultiplication.ToString() + " / " +
                        DenominatorResultMultiplication.ToString();
                txtFractionsMultiplyResult.Text += DetermineFractionShorten(NominatorResultMultiplication, DenominatorResultMultiplication);

                NominatorResultDivision = NominatorFraction1 * DenominatorFraction2;
                DenominatorResultDivision = NominatorFraction2 * DenominatorFraction1;
                txtFractionsDivisionResult.Text = NominatorResultDivision.ToString() + " / " +
                        DenominatorResultDivision.ToString();
                txtFractionsDivisionResult.Text += DetermineFractionShorten(NominatorResultDivision, DenominatorResultDivision);

                if (DenominatorFraction1 != DenominatorFraction2)
                {
                    NominatorResultAddition = (NominatorFraction1 * DenominatorFraction2) +
                                              (NominatorFraction2 * DenominatorFraction1);
                    DenominatorResultAddition = DenominatorFraction1 * DenominatorFraction2;

                    NominatorResultSubtraction = (NominatorFraction1 * DenominatorFraction2) -
                                                 (NominatorFraction2 * DenominatorFraction1);
                    DenominatorResultSubtraction = DenominatorFraction1 * DenominatorFraction2;
                }
                else
                {
                    DenominatorResultAddition = DenominatorFraction1;
                    NominatorResultAddition = NominatorFraction1 + NominatorFraction2;

                    DenominatorResultSubtraction = DenominatorFraction1;
                    NominatorResultSubtraction = NominatorFraction1 - NominatorFraction2;
                }
                txtFractionsAdditionResult.Text = NominatorResultAddition.ToString() + " / " +
                        DenominatorResultAddition.ToString();
                txtFractionsAdditionResult.Text += DetermineFractionShorten(NominatorResultAddition, DenominatorResultAddition);

                txtFractionsSubtractionResult.Text = NominatorResultSubtraction.ToString() + " / " +
                        DenominatorResultSubtraction.ToString();
                txtFractionsSubtractionResult.Text += DetermineFractionShorten(NominatorResultSubtraction, DenominatorResultSubtraction);
            }
            else
            {
                MessageBox.Show("Husk at indtast både Tæller og Nævner for begge brøker !!!");
            }
        }

        private string DetermineFractionShorten(int Nominator, int Denominator)
        {
            int IntegerPart = 0;
            int FractionNominatorSubtractor = 0;
            int GreatestCommonDivisor = 1;
            string OutputString = "";

            IntegerPart = (int)Nominator / Denominator;
            if (0 != IntegerPart)
            {
                FractionNominatorSubtractor = IntegerPart * Denominator;
                Nominator -= FractionNominatorSubtractor;
                OutputString += " = " + IntegerPart.ToString();
            }

            if (0 != Nominator)
            {
                GreatestCommonDivisor = MathTools.GetGreatestDivisor(Math.Abs(Nominator), Denominator);

                if (GreatestCommonDivisor > 1)
                {
                    Nominator /= GreatestCommonDivisor;
                    Denominator /= GreatestCommonDivisor;
                }

                if ((0 != IntegerPart) || (GreatestCommonDivisor > 1))
                {
                    if (0 != IntegerPart)
                    {
                        OutputString += " + " + Nominator.ToString() + " / " + Denominator.ToString();
                    }
                    else
                    {
                        OutputString += " = " + Nominator.ToString() + " / " + Denominator.ToString();
                    }
                }
            }

            return (OutputString);
        }

        private void btnCalculateFractionClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtNominatorFraction1);
            TextBoxList.Add(txtDenominatorFraction1);
            TextBoxList.Add(txtNominatorFraction2);
            TextBoxList.Add(txtDenominatorFraction2);
            TextBoxList.Add(txtFractionsAdditionResult);
            TextBoxList.Add(txtFractionsSubtractionResult);
            TextBoxList.Add(txtFractionsMultiplyResult);
            TextBoxList.Add(txtFractionsDivisionResult);
            ControlTools.ClearTextBoxes(TextBoxList);

            Const.SetDefaultFractionsLabelsContent(lblPlusFractions, lblMinusFractions, lblMultiplyFractions, lblDivideFractions);
        }

        private void btnShortenFraction_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtDenominatorShortenFraction);
            TextBoxList.Add(txtNominatorShortenFraction);

            if (2 == ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                int NominatorFraction = Convert.ToInt32(txtNominatorShortenFraction.Text);
                int DenominatorFraction = Convert.ToInt32(txtDenominatorShortenFraction.Text);

                txtShortenedFraction.Text = DetermineFractionShorten(NominatorFraction, DenominatorFraction);
                if (0 == txtShortenedFraction.Text.Length)
                {
                    txtShortenedFraction.Text = "Brøken kan ikke forkortes !!!";
                }
            }
            else
            {
                MessageBox.Show("Husk at indtast både Tæller og Nævner for brøk, der ønskes forkortet !!!");
            }
        }

        private void btnShortenFractionClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtDenominatorShortenFraction);
            TextBoxList.Add(txtNominatorShortenFraction);
            TextBoxList.Add(txtShortenedFraction);
            //TextBoxList.Add(txNominatorShortenedFraction);

            ControlTools.ClearTextBoxes(TextBoxList);
        }
        #endregion

        /* Code in region below belongs to "Procentregning" Tab */
        #region PercentageCalculations
        private void btnCalculatePercentageOfAmount_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtBaseAmount);
            TextBoxList.Add(txtPercentageOfBase);

            if (2 == ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {
                double Amount = Convert.ToDouble(txtBaseAmount.Text);
                double Percentage = Convert.ToDouble(txtPercentageOfBase.Text);
                double PercentageAmount = (Amount / 100) * Percentage;
                txtPercentageOfBaseAmount.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PercentageAmount, 2);
                lblPercentageOfBaseAmount.Content = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Percentage, Const.DefaultNumberOfDecimals) + "% af " +
                    PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Amount, Const.DefaultNumberOfDecimals) + " er : ";
            }
            else
            {
                MessageBox.Show("Husk at indtast både beløb og Procentsats !!!");
            }
        }

        private void btnClearCalculatePercentageOfAmount_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtBaseAmount);
            TextBoxList.Add(txtPercentageOfBase);
            TextBoxList.Add(txtPercentageOfBaseAmount);
            ControlTools.ClearTextBoxes(TextBoxList);

            Const.SetDefaultUpDownLabelContent(lblPercentageOfBaseAmount);
        }

        private void btnCalculatePercentageUpDown_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtAmount1);
            TextBoxList.Add(txtAmount2);

            if (2 == ControlTools.CheckTextBoxesForInformation(TextBoxList))
            {

                double Amount1 = Convert.ToDouble(txtAmount1.Text);
                double Amount2 = Convert.ToDouble(txtAmount2.Text);
                double PercentageDown = ((Amount1 - Amount2) / Amount1) * 100;
                double PercentageUp = ((Amount1 - Amount2) / Amount2) * 100;

                txtPercentageDown.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PercentageDown, Const.DefaultNumberOfDecimals) + "%";
                txtPercentageUp.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PercentageUp, Const.DefaultNumberOfDecimals) + "%";
            }
            else
            {
                MessageBox.Show("Husk at indtast både før og efter beløb !!!");
            }
        }

        private void btnClearCalculatePercentageUpDown_Click(object sender, RoutedEventArgs e)
        {
            TextBoxList.Clear();
            TextBoxList.Add(txtAmount1);
            TextBoxList.Add(txtAmount2);
            TextBoxList.Add(txtPercentageDown);
            TextBoxList.Add(txtPercentageUp);
            ControlTools.ClearTextBoxes(TextBoxList);
        }
        #endregion


        /* Code in region below belongs to "Talsystemer" Tab */
        #region NumberSystems
        private void InitializeRadixNumbersLabels()
        {
            int Counter;
            string NumberSystemString;
            int StringLength = 0;

            lblTalsystemer1.Content = "På dette faneblad kan du lave konverteringer mellem ";
            lblTalsystemer1.Content += "alle talsystemerne opskrevet herunder.";
            lblTalsystemer2.Content = "Så snart du indtaster et gyldigt ciffer for et givet talssstem,";
            lblTalsystemer2.Content += "vil værdierne for alle andre talsystemer blive opdateret i henhold";
            lblTalsystemer3.Content = "hertil. Du kan indtaste værdier i alle tekstbokse herunder fuldstændig ";
            lblTalsystemer3.Content += "vilkårligt !!!";

            lblTalsystemer4.Content = "Oversigt over bogstavernes værdi";

            Key[] HighestValidKeyArray = ConstNumberSystems.RadixSystemArray[ConstNumberSystems.RadixSystemArray.Length - 1].ValidKeysArray;

            NumberSystemString = string.Empty;
            for (Counter = (int)Key.D0; Counter <= (int)HighestValidKeyArray[HighestValidKeyArray.Length - 1]; Counter++)
            {
                NumberSystemString += ControlTools.GetStringFromInt(Counter);
                NumberSystemString += " = ";
                NumberSystemString += ControlTools.GetStringValueFromInt(Counter);
                if (Counter < (int)HighestValidKeyArray[HighestValidKeyArray.Length - 1])
                {
                    NumberSystemString += ", ";
                }
            }

            StringLength = NumberSystemString.Length;
            StringLength = StringLength / 2;
            do
            {
                if (',' != NumberSystemString[StringLength])
                {
                    StringLength++;
                }
            } while ((',' != NumberSystemString[StringLength]) && (StringLength < NumberSystemString.Length));

            lblTalsystemer5.Content = NumberSystemString.Substring(0, StringLength);
            lblTalsystemer6.Content = NumberSystemString.Substring(StringLength + 1).Trim();

            for (Counter = ConstNumberSystems.MinRadixSystemValue; Counter <= ConstNumberSystems.MaxRadixSystemValue; Counter++)
            {
                if (10 != Counter)
                {
                    cmbNumberSystemRadix.Items.Add(Counter);
                }
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemRadix, ConstNumberSystems.MinRadixSystemValue);

            for (Counter = ConstNumberSystems.MinRadixSystemSpaces; Counter <= ConstNumberSystems.MaxRadixSystemSpaces; Counter++)
            {
                cmbNumberSystemSpaceCounter.Items.Add(Counter);
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemSpaceCounter, ConstNumberSystems.MinRadixSystemSpaces);

            for (Counter = 0; Counter <= ConstNumberSystems.RadixSystemSpaceCharacterArray.Length - 1; Counter++)
            {
                cmbNumberSystemSpaceCharacter.Items.Add(ConstNumberSystems.RadixSystemSpaceCharacterArray[Counter]);
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemSpaceCharacter, ConstNumberSystems.RadixSystemSpaceCharacterArray[0]);
        }

        private void SetupNumberSystemTextBoxes()
        {
            TextBoxList.Clear();

            for (int Counter = 0; Counter < ConstRadixSystemAndDelegatesList.Count; Counter++)
            {
                TextBoxList.Add(ConstRadixSystemAndDelegatesList[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object);
            }
        }

        private void InitializeRadixNumbersList()
        {
            for (int Counter = 0; Counter < ConstNumberSystems.RadixSystemDelegatesAndControlsExtendedArray.Length; Counter++)
            {
                ConstRadixSystemAndDelegatesExtended ConstRadixSystemAndDelegatesExtended_Object =
                    ConstNumberSystems.RadixSystemDelegatesAndControlsExtendedArray[Counter];

                ControlTools.InsertRowInGrid(GridNumberSystem);

                ControlTools.InsertLabelInGrid(GridNumberSystem,
                                               ConstNumberSystems.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.Label_Object_Name,
                                               ConstNumberSystems.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.Label_Object_Text,
                                               GridNumberSystem.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition,
                                               Const.LabelColumnSpan);

                ConstRadixSystemAndDelegatesExtended_Object.ConstRadixSystemAndDelegates_Object.TextBox_Object =
                    ControlTools.InsertTextBoxInGrid(GridNumberSystem,
                    ConstNumberSystems.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object_Name,
                    GridNumberSystem.RowDefinitions.Count - 1,
                    Const.TextBoxColumnPosition,
                    Const.TextBoxColumnSpan,
                    Const.TextBoxWidth,
                    Const.TextBoxHeight,
                    txtCheckForValidNumberSystemKeyPressed,
                    txtNumberSystem_TextChanged);

                ConstRadixSystemAndDelegatesList.Add(ConstRadixSystemAndDelegatesExtended_Object);
            }

            ControlTools.InsertRowInGrid(GridNumberSystem);
            ControlTools.InsertRowInGrid(GridNumberSystem);
            ControlTools.InsertLabelInGrid(GridNumberSystem,
                                           "lblTalsystemer8",
                                           "Dynamiske Oprettede Talsystemer herunder",
                                           GridNumberSystem.RowDefinitions.Count - 1,
                                           Const.LabelColumnPosition,
                                           10);
        }

        private int FindIndexInNumberSystemList(string TextBoxName)
        {
            int RadixSystemCounter = 0;

            do
            {
                if (TextBoxName == ConstRadixSystemAndDelegatesList[RadixSystemCounter].ConstRadixSystemAndDelegates_Object.TextBox_Object.Name)
                {
                    return (RadixSystemCounter);
                }
                else
                {
                    RadixSystemCounter++;
                }
            } while (RadixSystemCounter < ConstRadixSystemAndDelegatesList.Count);

            MessageBox.Show("Der er en fejl i din program konstruktion !!! Funktion : FindIndexInNumberSystemList (2)");
            return (-1);
        }

        public static int ConvertToRadix10IntFromRadix10String(string RadixStringToConvert, char CharacterToRemove)
        {
            int Radix10Number;

            RadixStringToConvert = StringHelper.TrimAndRemoveSpecifiedCharacterFromString(RadixStringToConvert, CharacterToRemove);

            try
            {
                Radix10Number = Convert.ToInt32(RadixStringToConvert);
            }
            catch (Exception Error)
            {
                MessageBox.Show("Der er fejl i det indtastede Tal !!! " + Error.ToString());
                return (Const.NumberFormatError);
            }
            return (Radix10Number);
        }

        public static string ConvertFromRadix10IntToRadix10String(int Radix10Number,
                                                                  char CharacterToInsert,
                                                                  int CharacterToInsertCouner)
        {
            string ReturnString = " ";

            ReturnString = Radix10Number.ToString();
            ReturnString = StringHelper.InsertCharacterInStringAtSpecifiedInterval(ReturnString,
                                                                                   CharacterToInsertCouner,
                                                                                   CharacterToInsert);
            return (ReturnString);
        }

        private void btnCalculateNumberSystemsClear_Click(object sender, RoutedEventArgs e)
        {
            ControlTools.ClearTextBoxes(TextBoxList);
        }

        private void UpdateRadixNumbersTextBoxes(int Radix10Value)
        {
            for (int Counter = 0; Counter < ConstRadixSystemAndDelegatesList.Count; Counter++)
            {
                ConstRadixSystemAndDelegatesList[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text =
                    ConstRadixSystemAndDelegatesList[Counter].RadixNumber_Object.ConvertFromRadix10(Radix10Value);

                ConstRadixSystemAndDelegatesList[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object.CaretIndex =
                    ConstRadixSystemAndDelegatesList[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text.Length;
            }
        }

        private void CalculateValueAndUpdateTextBoxes(int Current_Index_In_Number_System_List)
        {
            int Radix10Value;

            if (Current_Index_In_Number_System_List >= 0)
            {
                if (ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text.Length > 0)
                {
                    Radix10Value = ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].RadixNumber_Object.ConvertToRadix10(
                      ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text);
                    UpdateRadixNumbersTextBoxes(Radix10Value);
                }
                else
                {
                    ControlTools.ClearTextBoxes(TextBoxList);
                }
            }
        }

        private void txtNumberSystem_TextChanged(object sender, TextChangedEventArgs e)
        {
            Index_In_Number_System_List = FindIndexInNumberSystemList(((System.Windows.FrameworkElement)sender).Name);

            CalculateValueAndUpdateTextBoxes(Index_In_Number_System_List);
        }

        private void txtCheckForValidNumberSystemKeyPressed(object sender, KeyEventArgs e)
        {
            Index_In_Number_System_List = FindIndexInNumberSystemList(((System.Windows.FrameworkElement)sender).Name);

            if (!ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].RadixNumber_Object.IsKeyValid(e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
            //else
            //{
            //    RadixSystemTimer.Start();
            //}
        }

        private void RadixSystemTimer_Tick(object sender, EventArgs e)
        {
            int Radix10Value = 0;

            RadixSystemTimer.Stop();
            Radix10Value = ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].RadixNumber_Object.ConvertToRadix10(
              ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text);
            UpdateRadixNumbersTextBoxes(Radix10Value);
        }

        private void SetupRadixSystemTimer()
        {
            RadixSystemTimer.Interval = TimeSpan.FromMilliseconds(20);
            RadixSystemTimer.Tick += RadixSystemTimer_Tick;
        }

        private void btnMakeDynamicRadixSystem_Click(object sender, RoutedEventArgs e)
        {
            ConstRadixSystemAndDelegatesExtended ConstRadixSystemAndDelegatesExtended_Object =
                new ConstRadixSystemAndDelegatesExtended();
            ConstRadixSystemAndDelegates ConstRadixSystemAndDelegates_Object = new ConstRadixSystemAndDelegates();
            ConstRadixSystemAndDelegates_Object.Label_Object_Name = "lblRadixDynamic" + NumberDynamicRadixSystemsAdded.ToString();
            ConstRadixSystemAndDelegates_Object.Label_Object_Text = "Radix " + cmbNumberSystemRadix.SelectedValue.ToString() + " tal (" + cmbNumberSystemRadix.SelectedValue.ToString() + " tals system) : ";
            ConstRadixSystemAndDelegates_Object.TextBox_Object_Name = "txtRadixDynamic" + NumberDynamicRadixSystemsAdded.ToString();
            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCharacter_Name = "cmbRadixSpaceCharacter_" + NumberDynamicRadixSystemsAdded.ToString();
            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCharacter = null;
            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCounter_Name = "cmbRadixSpaceCounter_" + NumberDynamicRadixSystemsAdded.ToString();
            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCounter = null;
            ConstRadixSystemAndDelegates_Object.Button_Object_Delete_Name = "btnRadixDelete_" + NumberDynamicRadixSystemsAdded.ToString();
            ConstRadixSystemAndDelegates_Object.Button_Object_Delete = null;
            ConstRadixSystemAndDelegates_Object.FunctionPointerFromRadix10 = null;
            ConstRadixSystemAndDelegates_Object.FunctionPointerToRadix10 = null;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.ValidKeysArray = ConstNumberSystems.MakeKeyArrayToRadixSystem((int)cmbNumberSystemRadix.SelectedValue).ToArray();
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter = (char)cmbNumberSystemSpaceCharacter.SelectedValue;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCounter = (int)cmbNumberSystemSpaceCounter.SelectedValue;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixValue = (int)cmbNumberSystemRadix.SelectedValue;

            ControlTools.InsertRowInGrid(GridNumberSystem, Const.DynamicElementsRowHeight);

            ControlTools.InsertLabelInGrid(GridNumberSystem,
                                           "lblRadixDynamic" + NumberDynamicRadixSystemsAdded.ToString(),
                                           "Radix " + cmbNumberSystemRadix.SelectedValue.ToString() + " tal (" + cmbNumberSystemRadix.SelectedValue.ToString() + " tals system) : ",
                                           GridNumberSystem.RowDefinitions.Count - 1,
                                           Const.LabelColumnPosition,
                                           Const.LabelColumnSpan);

            ConstRadixSystemAndDelegates_Object.FirstLabelInGridRowPosition = GridNumberSystem.Children.Count - 1;

            ConstRadixSystemAndDelegates_Object.TextBox_Object =
                ControlTools.InsertTextBoxInGrid(GridNumberSystem,
                "txtRadixDynamic" + NumberDynamicRadixSystemsAdded.ToString(),
                GridNumberSystem.RowDefinitions.Count - 1,
                Const.TextBoxColumnPosition,
                Const.TextBoxColumnSpan,
                Const.TextBoxWidth,
                Const.TextBoxHeight,
                txtCheckForValidNumberSystemKeyPressed,
                txtNumberSystem_TextChanged);

            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCounter =
                ControlTools.InsertComboBoxInGrid(GridNumberSystem,
                cmbNumberSystemSpaceCounter,
                "cmbRadixDynamicSpaceCounter_" + NumberDynamicRadixSystemsAdded.ToString(),
                GridNumberSystem.RowDefinitions.Count - 1,
                ConstNumberSystems.ComboBoxRadixSpaceCounterColumn,
                1,
                Const.ComboBoxRowHeight,
                cmbNumberSystemSpaceCharacterCounter_SelectionChanged);

            ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCharacter =
                ControlTools.InsertComboBoxInGrid(GridNumberSystem,
                cmbNumberSystemSpaceCharacter,
                "cmbRadixDynamicSpaceCharacter_" + NumberDynamicRadixSystemsAdded.ToString(),
                GridNumberSystem.RowDefinitions.Count - 1,
                ConstNumberSystems.ComboBoxRadixSpaceCharacterColumn,
                1,
                Const.ComboBoxRowHeight,
                cmbNumberSystemSpaceCharacter_SelectionChanged);

            ConstRadixSystemAndDelegates_Object.Button_Object_Delete =
                ControlTools.InsertButtonInGrid(Grid_Object: GridNumberSystem,
                ButtonName: "btnRadixDelete_" + NumberDynamicRadixSystemsAdded.ToString(),
                ButtonText: "Slet System",
                RowPosition: GridNumberSystem.RowDefinitions.Count - 1,
                ColumnPosition: ConstNumberSystems.ButtonxRadixDeleteColumn,
                ColumnSpan: ConstNumberSystems.ButtonxRadixDeleteColumnSpan,
                Height: ConstNumberSystems.ButtonxRadixDeleteHeight,
                Width: ConstNumberSystems.ButtonxRadixDeleteWidth,
                FunctionButtonClicked: btnClearNumberSystem_Click);

            ConstRadixSystemAndDelegates_Object.GridRowPosition = GridNumberSystem.RowDefinitions.Count - 1;

            if (FirstIndexForDynamicRadixSystemsAdded < 0)
            {
                FirstIndexForDynamicRadixSystemsAdded = ConstRadixSystemAndDelegatesList.Count;
            }

            ConstRadixSystemAndDelegatesExtended_Object.ConstRadixSystemAndDelegates_Object = ConstRadixSystemAndDelegates_Object;
            ConstRadixSystemAndDelegatesExtended_Object.RadixNumber_Object = new RadixNumber(ConstRadixSystemAndDelegates_Object);
            ConstRadixSystemAndDelegatesList.Add(ConstRadixSystemAndDelegatesExtended_Object);
            SetupNumberSystemTextBoxes();

            NumberDynamicRadixSystemsAdded++;

            Index_In_Number_System_List = 0;
            CalculateValueAndUpdateTextBoxes(Index_In_Number_System_List);
        }

        private int GetIndexNumberInList(string ComboBoxName)
        {
            ComboBoxName = ComboBoxName.Trim();
            int SearchPosition = ComboBoxName.LastIndexOf('_');
            string ComboBoxNameNumber = ComboBoxName.Substring(SearchPosition);
            int Counter = FirstIndexForDynamicRadixSystemsAdded;

            do
            {
                string SearchString =
                    ConstRadixSystemAndDelegatesList[Counter].ConstRadixSystemAndDelegates_Object.ComboBox_Object_RadixSpaceCharacter_Name;
                SearchPosition = SearchString.LastIndexOf('_');
                SearchString = SearchString.Substring(SearchPosition);

                if (SearchString == ComboBoxNameNumber)
                {
                    return (Counter);
                }
                else
                {
                    Counter++;
                }
            } while (Counter < ConstRadixSystemAndDelegatesList.Count);

            return (-1);
        }

        private void cmbNumberSystemSpaceCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IndexNumberInList = GetIndexNumberInList(((System.Windows.FrameworkElement)sender).Name);

            if (IndexNumberInList > 0)
            {
                char OldRadixSpaceCharacter = ConstRadixSystemAndDelegatesList[IndexNumberInList].RadixNumber_Object.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter;
                ConstRadixSystemAndDelegatesList[IndexNumberInList].RadixNumber_Object.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter =
                    (char)((ComboBox)((System.Windows.FrameworkElement)sender)).SelectedValue;

                string WorkString = ConstRadixSystemAndDelegatesList[IndexNumberInList].RadixNumber_Object.ConstRadixSystemAndDelegates_Object.TextBox_Object.Text;
                WorkString = WorkString.Replace(OldRadixSpaceCharacter,
                    (char)((ComboBox)((System.Windows.FrameworkElement)sender)).SelectedValue);
                ConstRadixSystemAndDelegatesList[IndexNumberInList].RadixNumber_Object.ConstRadixSystemAndDelegates_Object.TextBox_Object.Text =
                    WorkString;
            }
        }

        private void cmbNumberSystemSpaceCharacterCounter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IndexNumberInList = GetIndexNumberInList(((System.Windows.FrameworkElement)sender).Name);

            if (IndexNumberInList > 0)
            {
                ConstRadixSystemAndDelegatesList[IndexNumberInList].RadixNumber_Object.ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCounter =
                    (int)((ComboBox)((System.Windows.FrameworkElement)sender)).SelectedValue;
                CalculateValueAndUpdateTextBoxes(Index_In_Number_System_List);
            }
        }

        private void btnClearNumberSystem_Click(object sender, RoutedEventArgs e)
        {
            int IndexNumberInList = GetIndexNumberInList(((System.Windows.FrameworkElement)sender).Name);

            if (IndexNumberInList > 0)
            {
                GridNumberSystem.Children.RemoveRange(ConstRadixSystemAndDelegatesList[IndexNumberInList].ConstRadixSystemAndDelegates_Object.FirstLabelInGridRowPosition, ConstNumberSystems.NumberOfControlsInGridRow);
                GridNumberSystem.RowDefinitions.RemoveAt(ConstRadixSystemAndDelegatesList[IndexNumberInList].ConstRadixSystemAndDelegates_Object.GridRowPosition);
                ConstRadixSystemAndDelegatesList.RemoveAt(IndexNumberInList);
            }
        }
        #endregion

        #region Length_Area_Volume_Weight_Liquid
        private void Setup_Length_Area_Volume_Weight_Liquid_Controls()
        {
            int NumberOfRows = ConstUnitsConverter.UnitsOverallConverterArray.Length;
            int MaxNumberOfColumns = 0;

            for (int Counter = 0; Counter < NumberOfRows; Counter++)
            {
                if (ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray.Length > MaxNumberOfColumns)
                {
                    MaxNumberOfColumns = ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray.Length;
                }
            }

            ColumnDefinition ColumnDefinition_Object = new ColumnDefinition();
            ColumnDefinition_Object.Width = GridLength.Auto;

            for (int Counter = 0; Counter < MaxNumberOfColumns + 2; Counter++)
            {
                Grid_Length_Area_Volume_Weight_Liquid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int Counter = 0; Counter < NumberOfRows; Counter++)
            {
                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);

                ControlTools.InsertLabelInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                                               "lblUnitsOverallConverter_" + Counter.ToString(),
                                               "Konverteringer i  " + ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsBelongTo + " : ",
                                               Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition,
                                               Const.LabelColumnSpan);

                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);
                ControlTools.InsertLabelInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                                               "lblUnitsOverallConverterLongName_" + Counter.ToString(),
                                               "Enhed Langt navn : ",
                                               Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition,
                                               Const.LabelColumnSpan);
                for (int Counter1 = 0; Counter1 < ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray.Length; Counter1++)
                {
                    ControlTools.InsertLabelInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                                               "lblUnitsLongName_" + Counter.ToString() + "_" + Counter1.ToString(),
                                               ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray[Counter1].UnitLongName,
                                               Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition + Counter1 + 1,
                                               Const.LabelColumnSpanShort);
                }

                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);
                ControlTools.InsertLabelInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                                               "lblUnitsOverallConverterLongName_" + Counter.ToString(),
                                               "Enhed Kort navn : ",
                                               Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition,
                                               Const.LabelColumnSpan);
                for (int Counter1 = 0; Counter1 < ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray.Length; Counter1++)
                {
                    ControlTools.InsertLabelInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                                               "lblUnitsShortName_" + Counter.ToString() + "_" + Counter1.ToString(),
                                               ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray[Counter1].UnitShortName,
                                               Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition + Counter1 + 1,
                                               Const.LabelColumnSpanShort);
                }

                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);
                for (int Counter1 = 0; Counter1 < ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray.Length; Counter1++)
                {
                    ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray[Counter1].TextBox_Object =
                    ControlTools.InsertTextBoxInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                    "txtUnitsShortName_" + Counter.ToString() + "_" + Counter1.ToString(),
                    Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                    Const.LabelColumnPosition + Counter1 + 1,
                    Const.TextBoxColumnSpanShort,
                    Const.TextBoxWidthShort,
                    Const.TextBoxHeight,
                    txtCheckForValidKeyPressed,
                    txtUnitSystem_TextChanged);
                    ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsConverterArray[Counter1].TextBox_Object.HorizontalAlignment = HorizontalAlignment.Left;
                }

                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);

                ConstUnitsConverter.UnitsOverallConverterArray[Counter].Button_Object =
                    ControlTools.InsertButtonInGrid(Grid_Length_Area_Volume_Weight_Liquid,
                    "btnUnits_" + Counter.ToString(),
                    "Clear All",
                    Grid_Length_Area_Volume_Weight_Liquid.RowDefinitions.Count - 1,
                    1,
                    2,
                    120,
                    23,
                    btnClearUnitSystem_Click);
                ConstUnitsConverter.UnitsOverallConverterArray[Counter].Button_Object.HorizontalAlignment = HorizontalAlignment.Left;

                ControlTools.InsertRowInGrid(Grid_Length_Area_Volume_Weight_Liquid, Const.DynamicElementsRowHeight);
            }
        }

        private void btnClearUnitSystem_Click(object sender, RoutedEventArgs e)
        {
            int IndexNumberInUnitsList = FindButtonIndexInUnitSystemList(((System.Windows.FrameworkElement)sender).Name);

            if (IndexNumberInUnitsList >= 0)
            {
                ClearAllTextBoxesInUnitSystem(IndexNumberInUnitsList);
            }
        }

        private int FindButtonIndexInUnitSystemList(string ButtonName)
        {
            int UnitSystemCounterRow = 0;

            do
            {
                if (ButtonName == ConstUnitsConverter.UnitsOverallConverterArray[UnitSystemCounterRow].Button_Object.Name)
                {
                    return (UnitSystemCounterRow);
                }
                else
                {
                    UnitSystemCounterRow++;
                }
            } while (UnitSystemCounterRow < ConstUnitsConverter.UnitsOverallConverterArray.Length);

            MessageBox.Show("Der er en fejl i din program konstruktion !!! Funktion : FindButtonIndexInUnitSystemList");
            return (-1);
        }

        private UnitInPlace FindIndexInUnitSystemList(string TextBoxName)
        {
            int UnitSystemCounterRow = 0;
            int UnitSystemCounterColumn = 0;
            UnitInPlace UnitInPlace_Object = new UnitInPlace(UnitInPlaceRow: -1, UnitInPlaceColumn: -1);

            do
            {
                UnitSystemCounterColumn = 0;
                do
                {
                    if (TextBoxName == ConstUnitsConverter.UnitsOverallConverterArray[UnitSystemCounterRow].UnitsConverterArray[UnitSystemCounterColumn].TextBox_Object.Name)
                    {
                        UnitInPlace_Object.UnitInPlaceRow = UnitSystemCounterRow;
                        UnitInPlace_Object.UnitInPlaceColumn = UnitSystemCounterColumn;
                        return (UnitInPlace_Object);
                    }
                    else
                    {
                        UnitSystemCounterColumn++;
                    }
                } while (UnitSystemCounterColumn < ConstUnitsConverter.UnitsOverallConverterArray[UnitSystemCounterRow].UnitsConverterArray.Length);
                UnitSystemCounterRow++;
            } while (UnitSystemCounterRow < ConstUnitsConverter.UnitsOverallConverterArray.Length);

            MessageBox.Show("Der er en fejl i din program konstruktion !!! Funktion : FindIndexInUnitSystemList");
            return (UnitInPlace_Object);
        }

        private void ClearAllTextBoxesInUnitSystem(int UnitInPlaceRow)
        {
            for (int UnitSystemCounterColumn = 0; UnitSystemCounterColumn < ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlaceRow].UnitsConverterArray.Length; UnitSystemCounterColumn++)
            {
                ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].TextBox_Object.Text = "";
            }
        }

        private void CalculateUnitValueAndUpdateTextBoxes(UnitInPlace UnitInPlace_Obbject)
        {
            TextBox TextBox_Object = new TextBox();
            int UnitSystemCounterColumn = 0;
            bool MainFactorToBaseUnitFound = false;
            double MainFactorUnitValue = 0;

            if (ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitInPlace_Obbject.UnitInPlaceColumn].TextBox_Object.Text.Length > 0)
            {
                do
                {
                    if (1 == ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].FactorToBaseUnit)
                    {
                        MainFactorToBaseUnitFound = true;
                        MainFactorUnitValue = Convert.ToDouble(ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitInPlace_Obbject.UnitInPlaceColumn].TextBox_Object.Text) *
                            ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitInPlace_Obbject.UnitInPlaceColumn].FactorToBaseUnit;
                    }
                    else
                    {
                        UnitSystemCounterColumn++;
                    }
                } while ((UnitSystemCounterColumn < ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray.Length) &&
                         (false == MainFactorToBaseUnitFound));

                if (false == MainFactorToBaseUnitFound)
                {
                    MessageBox.Show("Der er en fejl i din program konstruktion !!! Funktion : CalculateUnitValueAndUpdateTextBoxes");
                }
                else
                {
                    for (UnitSystemCounterColumn = 0; UnitSystemCounterColumn < ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray.Length; UnitSystemCounterColumn++)
                    {
                        if (UnitSystemCounterColumn != UnitInPlace_Obbject.UnitInPlaceColumn)
                        {
                            ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].TextBox_Object.TextChanged -= txtUnitSystem_TextChanged;
                            ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].TextBox_Object.Text =
                                PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(
                                (MainFactorUnitValue / ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].FactorToBaseUnit),
                                Const.DefaultNumberOfDecimals);
                        }
                    }

                    for (UnitSystemCounterColumn = 0; UnitSystemCounterColumn < ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray.Length; UnitSystemCounterColumn++)
                    {
                        if (UnitSystemCounterColumn != UnitInPlace_Obbject.UnitInPlaceColumn)
                        {
                            ConstUnitsConverter.UnitsOverallConverterArray[UnitInPlace_Obbject.UnitInPlaceRow].UnitsConverterArray[UnitSystemCounterColumn].TextBox_Object.TextChanged += txtUnitSystem_TextChanged;
                        }
                    }
                }
            }
            else
            {
                ClearAllTextBoxesInUnitSystem(UnitInPlace_Obbject.UnitInPlaceRow);
            }
        }

        private void txtUnitSystem_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitInPlace UnitInPlace_Obbject = FindIndexInUnitSystemList(((System.Windows.FrameworkElement)sender).Name);

            if ((UnitInPlace_Obbject.UnitInPlaceRow > -1) &&
                 (UnitInPlace_Obbject.UnitInPlaceColumn > -1))
            {
                CalculateUnitValueAndUpdateTextBoxes(UnitInPlace_Obbject);
            }
        }

        private void txtCheckForValiUnitKeyPressed(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValicControlKey(e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }
        #endregion

        #region Geometry
        private void InitializeGeometryLabels()
        {
            lblGeometry1.Content = "På dette faneblad kan du lave Areal og Omkreds beregninger";
            lblGeometry1.Content += " på valgte 2-dimensionelle figurer.";
            lblGeometry2.Content = "Endvidere kan du lave Rumfang og samlet Overflade Areal";
            lblGeometry2.Content += " på valgte 3-dimensionelle figurer";

            lblGeometry3.Content = "x-dimensionel figur beregninger";
        }
        
        private void InitializeGeometryControls()
        {
            IndexNumberInGeometryArray = 0;
            InitializeComboBoxesAndCalculateDeleteButtons(ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                          Grid_Geometry,
                                                          ConstGeometry.FigureCalculation_Object.ComboBox_Unit_Object,
                                                          cmbGeometryUnit_SelectionChanged,
                                                          ConstGeometry.FigureCalculation_Object.ComboBox_Figure_Object,
                                                          cmbGeometryFigure_SelectionChanged,
                                                          ConstGeometry.FigureCalculation_Object.Button_Clear_Object,
                                                          btnClearAllGeometryTextBoxes,
                                                          ConstGeometry.FigureCalculation_Object.Button_Result_Object,
                                                          btnCalculateGeometry,
                                                          ref RowDeleteNumberInGeometryGrid,
                                                          ref FirstControlToBeDeletedInGeometryGridCount);

            lblGeometry3.Content = ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray].FigureDimensions.ToString() + "-dimensionel figur beregninger på " +
                ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray].FigureName;

            SetupFigureLabels_TextBoxes_Buttons(IndexNumberInGeometryArray,
                                                  ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                  Grid_Geometry,
                                                  RowDeleteNumberInGeometryGrid,
                                                  FirstControlToBeDeletedInGeometryGridCount,
                                                  ref TextBoxListGeometryInput,
                                                  ref TextBoxListGeometryOutput);
        }
        
        private void cmbGeometryUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentFigureCalculation CurrentFigureCalculation_Object = ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray];
            string UnitToUse = (string)ConstGeometry.FigureCalculation_Object.ComboBox_Unit_Object.XamlControl.SelectedValue;
           
            HandleUnitChanged(CurrentFigureCalculation_Object, UnitToUse);
        }
        
        private void cmbGeometryFigure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ComboBoxName = ((System.Windows.FrameworkElement)sender).Name;
            string SelectedValue = (string)((ComboBox)(System.Windows.FrameworkElement)sender).SelectedValue;
            IndexNumberInGeometryArray = GetIndexNumberInFigureArray(ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                                     SelectedValue);

            if (IndexNumberInGeometryArray >= 0)
            {
                lblGeometry3.Content = ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray].FigureDimensions.ToString() + "-dimensionel figur beregninger på " +
                ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray].FigureName;
                SetupFigureLabels_TextBoxes_Buttons(IndexNumberInGeometryArray,
                                                    ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                    Grid_Geometry,
                                                    RowDeleteNumberInGeometryGrid,
                                                    FirstControlToBeDeletedInGeometryGridCount,
                                                    ref TextBoxListGeometryInput,
                                                    ref TextBoxListGeometryOutput);
            }
        }

        private void btnCalculateGeometry(object sender, RoutedEventArgs e)
        {
            int RowCounter;
            CurrentFigureCalculation CurrentFigureCalculation_Object = ConstGeometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInGeometryArray];

            if (ControlTools.CheckTextBoxesForInformation(TextBoxListGeometryInput, ConstGeometry.DefaultTextBoxValue))
            {
                List<double> NumberList = TextBoxListGeometryInput.Select(val => double.Parse(val.Text)).ToList();

                for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray.Length; RowCounter++)
                {
                    CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl.Text =
                        PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(
                        CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].CalculateOnFigure_Delegate(NumberList),
                        Const.DefaultNumberOfDecimals);
                }
            }
            else
            {
                MessageBox.Show("Husk at alle input felter skal have en værdi !!!");
            }
        }

        private void btnClearAllGeometryTextBoxes(object sender, RoutedEventArgs e)
        {
            ControlTools.ClearTextBoxes(TextBoxListGeometryInput, ConstGeometry.DefaultTextBoxValue, true);
            ControlTools.ClearTextBoxes(TextBoxListGeometryOutput, ConstGeometry.DefaultTextBoxValue);
        }
        #endregion

        #region Trignometri
        private void InitializeTrigonometryLabels()
        {
            lblTrigonometry1.Content = "På dette faneblad kan du beregne længder og vinkler i ";
            lblTrigonometry1.Content += " både retvinklede og ikke retvinklede trekaneter.";
            lblTrigonometry2.Content = "For retvinklede trekanter skal 2 størrelser udover den rette vinkel (C) angives.";
            lblTrigonometry2.Content += " For ikke retvinklede trekanter skal 3 størrelser angives.";
            lblTrigonometry3.Content = "Udover vinkler og længder vil der også blive beregnet Omkreds og Areal af trekanten. ";
            lblTrigonometry3.Content += "Samt Omkreds og Areal af trekantens indskrevne - og omskrevne cirkel";
        }

        private void InitializeTrigonometryControls()
        {
            IndexNumberInTrigonometryArray = 0;
            InitializeComboBoxesAndCalculateDeleteButtons(ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                          Grid_Trigonometry,
                                                          ConstTrigonometry.FigureCalculation_Object.ComboBox_Unit_Object,
                                                          cmbTrigonometryUnit_SelectionChanged,
                                                          ConstTrigonometry.FigureCalculation_Object.ComboBox_Figure_Object,
                                                          cmbTrigonometryFigure_SelectionChanged,
                                                          ConstTrigonometry.FigureCalculation_Object.Button_Clear_Object,
                                                          btnClearAllTrigonometryTextBoxes,
                                                          ConstTrigonometry.FigureCalculation_Object.Button_Result_Object,
                                                          btnCalculateTrigonometry,
                                                          ref RowDeleteNumberInTrigonometryGrid,
                                                          ref FirstControlToBeDeletedInTrigonometryGridCount);

            SetupFigureLabels_TextBoxes_Buttons(IndexNumberInTrigonometryArray,
                                                ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                Grid_Trigonometry,
                                                RowDeleteNumberInTrigonometryGrid,
                                                FirstControlToBeDeletedInTrigonometryGridCount,
                                                ref TextBoxListTrigonometryInput,
                                                ref TextBoxListTrigonometryOutput);
        }

        private void cmbTrigonometryUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentFigureCalculation CurrentFigureCalculation_Object = ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInTrigonometryArray];
            string UnitToUse = (string)ConstTrigonometry.FigureCalculation_Object.ComboBox_Unit_Object.XamlControl.SelectedValue;

            HandleUnitChanged(CurrentFigureCalculation_Object, UnitToUse);
        }

        private void cmbTrigonometryFigure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ComboBoxName = ((System.Windows.FrameworkElement)sender).Name;
            string SelectedValue = (string)((ComboBox)(System.Windows.FrameworkElement)sender).SelectedValue;
            IndexNumberInTrigonometryArray = GetIndexNumberInFigureArray(ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                                     SelectedValue);

            if (IndexNumberInTrigonometryArray >= 0)
            {
                SetupFigureLabels_TextBoxes_Buttons(IndexNumberInTrigonometryArray,
                                                    ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray,
                                                    Grid_Trigonometry,
                                                    RowDeleteNumberInTrigonometryGrid,
                                                    FirstControlToBeDeletedInTrigonometryGridCount,
                                                    ref TextBoxListTrigonometryInput,
                                                    ref TextBoxListTrigonometryOutput);
            }
        }
        private void btnCalculateTrigonometry(object sender, RoutedEventArgs e)
        {
            int RowCounter;
            CurrentFigureCalculation CurrentFigureCalculation_Object = ConstTrigonometry.FigureCalculation_Object.CurrentFigureCalculationArray[IndexNumberInTrigonometryArray];

            if (ControlTools.CheckTextBoxesForInformation(TextBoxListTrigonometryInput, ConstGeometry.DefaultTextBoxValue, ConstTrigonometry.NumberOfValuesSetInTriangle))
            {
                List<double> NumberList = TextBoxListTrigonometryInput.Select(val => double.Parse(val.Text)).ToList();

                if (MathTrigonometry.CalculateAnglesAndSidesInTriangle(ref NumberList))
                {
                    for (RowCounter = 0; RowCounter < TextBoxListTrigonometryInput.Count; RowCounter++)
                    {
                        CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControl.Text =
                            PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(
                            NumberList[RowCounter],
                            Const.DefaultNumberOfDecimals);
                    }

                    if (ControlTools.CheckTextBoxesForInformation(TextBoxListTrigonometryInput, ConstGeometry.DefaultTextBoxValue))
                    {
                        for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray.Length; RowCounter++)
                        {
                            CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl.Text =
                                PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(
                                CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].CalculateOnFigure_Delegate(NumberList),
                                Const.DefaultNumberOfDecimals);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Husk at alle input felter skal have en værdi !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Husk at mindst en længde i trekanaten skal have en værdi !!!");
                }
            }
            else
            {
                MessageBox.Show("Husk at " + ConstTrigonometry.NumberOfValuesSetInTriangle + " input felter skal have en værdi !!!");
            }
        }

        private void btnClearAllTrigonometryTextBoxes(object sender, RoutedEventArgs e)
        {
            ControlTools.ClearTextBoxes(TextBoxListTrigonometryInput, ConstGeometry.DefaultTextBoxValue, true);
            ControlTools.ClearTextBoxes(TextBoxListTrigonometryOutput, ConstGeometry.DefaultTextBoxValue);
        }
        #endregion
        /* General code below. */

        #region Figures
        private void InitializeComboBoxesAndCalculateDeleteButtons(CurrentFigureCalculation[] CurrentFigureCalculationArray,
                                                                   Grid CurrentGrid,
                                                                   MyControl<ComboBox> UnitComboBox,
                                                                   SelectionChangedEventHandler FunctionToBeExecutedOnUnitChange,
                                                                   MyControl<ComboBox> FigureComboBox,
                                                                   SelectionChangedEventHandler FunctionToBeExecutedOnFigureChange,
                                                                   MyControl<Button> ClearButton,
                                                                   RoutedEventHandler FunctionToBeExecutedOnClearButtonPress,
                                                                   MyControl<Button> ResultButton,
                                                                   RoutedEventHandler FunctionToBeExecutedOnResultButtonPress,
                                                                   ref int RowDeleteNumberInGrid,
                                                                   ref int FirstControlToBeDeletedInGridCount)
        {
            int Counter = 0;
            int Index = 0;

            ComboBox MyUnitComboBox;
            ComboBox MyFigureComboBox;
            Button MyClearButton;
            Button MyResultButton;

            MyUnitComboBox =
                ControlTools.InsertComboBoxInGrid(CurrentGrid,
                UnitComboBox.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                CurrentGrid.RowDefinitions.Count - 1,
                ConstGeometry.GeometryLabelStartColumn,
                ConstGeometry.GeometryLabelDefaultColumnSpan,
                Const.ComboBoxRowHeight,
                FunctionToBeExecutedOnUnitChange);

            do
            {
                if ("Længdemål" == ConstUnitsConverter.UnitsOverallConverterArray[Counter].UnitsBelongTo)
                {
                    break;
                }
                else
                {
                    Index++;
                }
            } while (Index < ConstUnitsConverter.UnitsOverallConverterArray.Length);

            if (Index < ConstUnitsConverter.UnitsOverallConverterArray.Length)
            {
                MyUnitComboBox.SelectionChanged -= FunctionToBeExecutedOnUnitChange;
                for (Counter = 0; Counter < ConstUnitsConverter.UnitsOverallConverterArray[Index].UnitsConverterArray.Length; Counter++)
                {
                    MyUnitComboBox.Items.Add(ConstUnitsConverter.UnitsOverallConverterArray[Index].UnitsConverterArray[Counter].UnitShortName);
                    if ("m" == ConstUnitsConverter.UnitsOverallConverterArray[Index].UnitsConverterArray[Counter].UnitShortName)
                    {
                        MyUnitComboBox.SelectedValue = "m";
                        UnitToUse = "m";
                    }
                }
                MyUnitComboBox.SelectionChanged += FunctionToBeExecutedOnUnitChange;
            }

            MyFigureComboBox =
                ControlTools.InsertComboBoxInGrid(CurrentGrid,
                FigureComboBox.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                CurrentGrid.RowDefinitions.Count - 1,
                ConstGeometry.GeometryLabelStartColumn + 2,
                ConstGeometry.GeometryLabelDefaultColumnSpan,
                Const.ComboBoxRowHeight,
                FunctionToBeExecutedOnFigureChange);

            for (Counter = 0; Counter < CurrentFigureCalculationArray.Length; Counter++)
            {
                MyFigureComboBox.Items.Add(CurrentFigureCalculationArray[Counter].FigureName);
                if (0 == Counter)
                {
                    MyFigureComboBox.SelectionChanged -= FunctionToBeExecutedOnFigureChange;
                    MyFigureComboBox.SelectedValue = CurrentFigureCalculationArray[Counter].FigureName;
                    MyFigureComboBox.SelectionChanged += FunctionToBeExecutedOnFigureChange;
                }
            }

            MyResultButton =
                    ControlTools.InsertButtonInGrid(
                    Grid_Object: CurrentGrid,
                    ButtonName: ResultButton.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                    ButtonText: ResultButton.XamlControlStringArray[ConstGeometry.ButtonTextPositionInArray],
                    RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                    ColumnPosition: 6,
                    ColumnSpan: 2,
                    Height: ConstNumberSystems.ButtonxRadixDeleteHeight,
                    Width: ConstNumberSystems.ButtonxRadixDeleteWidth,
                    FunctionButtonClicked: FunctionToBeExecutedOnResultButtonPress);

            MyClearButton =
                    ControlTools.InsertButtonInGrid(
                    Grid_Object: CurrentGrid,
                    ButtonName: ClearButton.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                    ButtonText: ClearButton.XamlControlStringArray[ConstGeometry.ButtonTextPositionInArray],
                    RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                    ColumnPosition: 8,
                    ColumnSpan: 2,
                    Height: ConstNumberSystems.ButtonxRadixDeleteHeight,
                    Width: ConstNumberSystems.ButtonxRadixDeleteWidth,
                    FunctionButtonClicked: FunctionToBeExecutedOnClearButtonPress);

            ControlTools.InsertRowInGrid(CurrentGrid, Const.DynamicElementsRowHeight);
            ControlTools.InsertRowInGrid(CurrentGrid, ConstGeometry.ImageHeight);
            ControlTools.InsertRowInGrid(CurrentGrid, Const.DynamicElementsRowHeight);

            FirstControlToBeDeletedInGridCount = CurrentGrid.Children.Count - 1;
            RowDeleteNumberInGrid = CurrentGrid.RowDefinitions.Count;

            UnitComboBox.XamlControl = MyUnitComboBox;
            FigureComboBox.XamlControl = MyFigureComboBox;

            ClearButton.XamlControl = MyClearButton;
            ResultButton.XamlControl = MyResultButton;
        }

        private void SetupFigureLabels_TextBoxes_Buttons(int IndexNumberInFigureArrayFunc,
                                                         CurrentFigureCalculation[] CurrentFigureCalculationArray,
                                                         Grid CurrentGrid,
                                                         int RowDeleteNumberInGrid,
                                                         int FirstControlToBeDeletedInGridCount,
                                                         ref List<TextBox> TextBoxListFigureInput,
                                                         ref List<TextBox> TextBoxListFigureOutput)
        {
            int RowCounter;
            string LabelText;
            string TextBoxText;
            CurrentFigureCalculation CurrentFigureCalculation_Object = CurrentFigureCalculationArray[IndexNumberInFigureArrayFunc];

            RemoveOldRowsInFigureGrid(CurrentGrid, RowDeleteNumberInGrid, FirstControlToBeDeletedInGridCount);
            TextBoxListFigureInput.Clear();
            TextBoxListFigureOutput.Clear();

            CurrentFigureCalculation_Object.Image_Figure_Object.XamlControl =
                ControlTools.InsertImageInGrid(
                  Grid_Object: CurrentGrid,
                  ImageFileName: CurrentFigureCalculation_Object.Image_Figure_Object.XamlControlStringArray[ConstGeometry.ImageFileNamePositionInArray],
                  RowPosition: CurrentGrid.RowDefinitions.Count - 2,
                  ColumnPosition: ConstGeometry.GeometryLabelStartColumn,
                  ColumnSpan: 5,
                  Width: 200,
                  Height: ConstGeometry.ImageHeight);

            ControlTools.InsertRowInGrid(CurrentGrid, Const.DynamicElementsRowHeight);

            for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.MyLabelTextBoxRowArray.Length; RowCounter++)
            {
                int ControlCounter = 0;
                CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControl =
                    ControlTools.InsertLabelInGrid(
                        Grid_Object: CurrentGrid,
                        LabelName: CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        LabelText: CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.LabelTextPositionInArray],
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ConstGeometry.GeometryLabelStartColumn,
                        ColumnSpan: 3);

                if (null != CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControl)
                {
                    TextBoxText = CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControl.Text;
                }
                else
                {
                    TextBoxText = CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControlStringArray[ConstGeometry.TextBoxTextPositionInArray];
                }

                CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControl =
                    ControlTools.InsertTextBoxInGrid(
                        Grid_Object: CurrentGrid,
                        TextBoxName: CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ConstGeometry.GeometryLabelStartColumn + 3,
                        ColumnSpan: 1,
                        Width: Const.TextBoxWidth,
                        Height: Const.TextBoxHeight,
                        FunctionKeyDown: txtCheckForValidPositiveNumberPressed,
                        FunctionTextChanged: null,
                        TextBox_Text: TextBoxText,
                        DisableTextBox: CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.Input_Output_Enum == Input_Output_Enum.Output_Enum);

                TextBoxListFigureInput.Add(CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].TextBox_Object.XamlControl);

                for (ControlCounter = 1; ControlCounter < CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray.Length; ControlCounter++)
                {
                    if (true == CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].IsCurrentLabelAnUnitLabel)
                    {
                        LabelText = UnitToUse + CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].UnitDimensionString;
                    }
                    else
                    {
                        LabelText = CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.LabelTextPositionInArray];
                    }

                    CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControl =
                    ControlTools.InsertLabelInGrid(
                        Grid_Object: CurrentGrid,
                        LabelName: CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        LabelText: LabelText,
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ControlCounter + 4,
                        ColumnSpan: ConstGeometry.GeometryLabelDefaultColumnSpan);
                }
                ControlTools.InsertRowInGrid(CurrentGrid, Const.DynamicElementsRowHeight);
            }


            for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray.Length; RowCounter++)
            {
                int ControlCounter = 0;
                CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControl =
                    ControlTools.InsertLabelInGrid(
                        Grid_Object: CurrentGrid,
                        LabelName: CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        LabelText: CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.LabelTextPositionInArray],
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ConstGeometry.GeometryLabelStartColumn,
                        ColumnSpan: 3);

                if (null != CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl)
                {
                    TextBoxText = CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl.Text;
                }
                else
                {
                    TextBoxText = CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControlStringArray[ConstGeometry.TextBoxTextPositionInArray];
                }

                CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl =
                    ControlTools.InsertTextBoxInGrid(
                        Grid_Object: CurrentGrid,
                        TextBoxName: CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ConstGeometry.GeometryLabelStartColumn + 3,
                        ColumnSpan: 1,
                        Width: Const.TextBoxWidth,
                        Height: Const.TextBoxHeight,
                        FunctionKeyDown: null,
                        FunctionTextChanged: null,
                        TextBox_Text: TextBoxText,
                        DisableTextBox: CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.Input_Output_Enum == Input_Output_Enum.Output_Enum);

                TextBoxListFigureOutput.Add(CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.TextBox_Object.XamlControl);

                for (ControlCounter = 1; ControlCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray.Length; ControlCounter++)
                {
                    if (true == CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].IsCurrentLabelAnUnitLabel)
                    {
                        LabelText = UnitToUse + CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].UnitDimensionString;
                    }
                    else
                    {
                        LabelText = CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.LabelTextPositionInArray];
                    }

                    CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControl =
                    ControlTools.InsertLabelInGrid(
                        Grid_Object: CurrentGrid,
                        LabelName: CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControlStringArray[ConstGeometry.ControlNamePositionInArray],
                        LabelText: LabelText,
                        RowPosition: CurrentGrid.RowDefinitions.Count - 1,
                        ColumnPosition: ControlCounter + 4,
                        ColumnSpan: ConstGeometry.GeometryLabelDefaultColumnSpan);
                }
                ControlTools.InsertRowInGrid(CurrentGrid, Const.DynamicElementsRowHeight);
            }
        }

        //private void btnClearAllFigureTextBoxes(object sender, RoutedEventArgs e)
        //{
        //    ControlTools.ClearTextBoxes(TextBoxListFigureInput, ConstGeometry.DefaultTextBoxValue);
        //    ControlTools.ClearTextBoxes(TextBoxListFigureOutput, ConstGeometry.DefaultTextBoxValue);
        //}

        private void HandleUnitChanged(CurrentFigureCalculation CurrentFigureCalculation_Object, string UnitToUse)
        {
            int RowCounter;
            int ControlCounter;
            string LabelText;

            for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.MyLabelTextBoxRowArray.Length; RowCounter++)
            {
                for (ControlCounter = 1; ControlCounter < CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray.Length; ControlCounter++)
                {
                    if (true == CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].IsCurrentLabelAnUnitLabel)
                    {
                        LabelText = UnitToUse + CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].UnitDimensionString;

                        if (null != CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControl)
                        {
                            CurrentFigureCalculation_Object.MyLabelTextBoxRowArray[RowCounter].LabelsArray[ControlCounter].XamlControl.Content = LabelText;
                        }
                    }
                }
            }

            for (RowCounter = 0; RowCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray.Length; RowCounter++)
            {
                for (ControlCounter = 1; ControlCounter < CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray.Length; ControlCounter++)
                {
                    if (true == CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].IsCurrentLabelAnUnitLabel)
                    {
                        LabelText = UnitToUse + CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].UnitDimensionString;

                        if (null != CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControl)
                        {
                            CurrentFigureCalculation_Object.ResultTextBoxToCalculationNewArray[RowCounter].MyLabelTextBoxRow_Object.LabelsArray[ControlCounter].XamlControl.Content = LabelText;
                        }
                    }
                }
            }
        }

        private int GetIndexNumberInFigureArray(CurrentFigureCalculation[] CurrentFigureCalculationArray, 
                                                string GeometryFigureName)
        {
            int Counter = 0;

            do
            {
                if (GeometryFigureName == CurrentFigureCalculationArray[Counter].FigureName)
                {
                    return (Counter);
                }
                else
                {
                    Counter++;
                }
            } while (Counter < CurrentFigureCalculationArray.Length);

            return (-1);
        }

        private void RemoveOldRowsInFigureGrid(Grid CurrentGrid,
                                               int RowDeleteNumberInGrid,
                                               int FirstControlToBeDeletedInGridCount)
        {
            int RowCounter;
            int StopRowNumber;

            CurrentGrid.Children.RemoveRange(FirstControlToBeDeletedInGridCount + 1,
                (CurrentGrid.Children.Count - 1) - FirstControlToBeDeletedInGridCount);

            StopRowNumber = CurrentGrid.RowDefinitions.Count;

            for (RowCounter = RowDeleteNumberInGrid; RowCounter < StopRowNumber; RowCounter++)
            {
                CurrentGrid.RowDefinitions.RemoveAt(RowDeleteNumberInGrid);
            }
        }
        #endregion

        #region General_Code
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TextBoxList.Clear();

            if (null != ((System.Windows.FrameworkElement)MainTabControl.SelectedItem))
            {
                switch (((System.Windows.FrameworkElement)MainTabControl.SelectedItem).Name)
                {
                    case "Square":
                        break;

                    case "Circle":
                        break;

                    case "PowerAndRoot":
                        break;

                    case "DrivingCalculations":
                        break;

                    case "FirstOrderEquation":
                        break;

                    case "SecondOrderEquation":
                        break;

                    case "EquationSystem":
                        if (false == NumberOfDecimalsChanged)
                        {
                            CurrentNumberOfEquations = (int)cmbEquationSystem.SelectedValue;
                            MakeEquationSystem(CurrentNumberOfEquations);
                        }
                        else
                        {
                            NumberOfDecimalsChanged = false;
                        }
                        break;

                    case "FractionCalculations":
                        //Const.SetDefaultFractionsLabels(lblPlusFractions, lblMinusFractions, lblMultiplyFractions, lblDivideFractions);
                        break;

                    case "PercentageCalculations":
                        break;

                    case "NumberSystems":
                        SetupNumberSystemTextBoxes();
                        break;

                    case "Length_Area_Volume_Weight_Liquid":
                        Setup_Length_Area_Volume_Weight_Liquid_Controls();
                        break;
                }
            }
        }

        private void txtCheckForValidKeyPressed(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidNumeric(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else
            {
                int Test = 10;
            }
        }

        private void txtCheckForValidIntegerNumberPressed(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidInteger(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void txtCheckForValidPositiveNumberPressed(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositive(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        #endregion
                
    }
}
