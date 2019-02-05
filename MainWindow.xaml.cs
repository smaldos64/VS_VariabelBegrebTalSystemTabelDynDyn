using System;
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

        private static List<ConstRadixSystemAndDelegatesExtended> ConstRadixSystemAndDelegatesList = new List<ConstRadixSystemAndDelegatesExtended>();
       
        private DispatcherTimer RadixSystemTimer = new DispatcherTimer();
        private static int Index_In_Number_System_List = -1;
        private static int NumberDynamicRadixSystemsAdded = 0;

        public ObservableCollection<EquationSystemRow> EquationSystemRows { get; set; }
        public static char StartCoefficientChar = 'x';
        public static bool IsCurrentEquationSystemSolved = false;
        public static int CurrentNumberOfEquations = 0;
        public static int Current_Number_Of_Decimals = 3;
        public static bool NumberOfDecimalsChanged = false;

        public MainWindow()
        {
            InitializeComponent();

            SetupRadixSystemTimer();

            InitializeDrivingCalculationLabels();

            InitializeEquationSystem();

            InitializeRadixNumbersLabels();

            InitializeRadixNumbersList();

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
            lblKoersel1.Content = "På dette faneblad kan du lave beregninger om, 1) hvad det  ";
            lblKoersel1.Content += "koster at køre en distance i bil afhængig af 2) turens distance,";

            lblKoersel2.Content = "3) literpris i Benzin/Diesel og 4) brændstoføkonomi => hvor mange kilometer biler kører pr. liter.";
            lblKoersel2.Content += "Det er lavet sådan, at man skal indtaste 3 af de 4 felter nævnt herover ";

            lblKoersel3.Content = "og så vil programmet selv beregne den manglende størrelse. ";
            lblKoersel3.Content += "Grundformlen er : Pris (kr) = (Distance (km) x Benzinpris (kr/l) ) / Brændstoføkonomi (km/l)";

            lblKoersel4.Content = "På dette faneblad kan du lave beregninger om, 1) hvad det  ";
            lblKoersel4.Content += "koster at køre en distance i bil afhængig af 2) turens distance,";

            lblKoersel5.Content = "3) literpris i Benzin/Diesel og 4) brændstoføkonomi => hvor mange kilometer biler kører pr. liter.";
            lblKoersel5.Content += "Det er lavet sådan, at man skal indtaste 3 af de 4 felter nævnt herover ";

            lblKoersel6.Content = "og så vil programmet selv beregne den manglende størrelse. ";
            lblKoersel6.Content += "Grundformlen er : Pris (kr) = (Distance (km) x Benzinpris (kr/l) ) / Brændstoføkonomi (km/l)";


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
                    //txtPrice.Text = string.Format("{0:0.00}", Price);
                    txtPrice.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Price, 2);
                }

                if (0 == txtDistance.Text.Length)
                {
                    Price = Convert.ToDouble(txtPrice.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);

                    Distance = (Price * KilometerPrLitre) / KrPrLitre;
                    //txtDistance.Text = string.Format("{0:0.00}", Distance);
                    txtDistance.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Distance, 2);
                }

                if (0 == txtKilometerPrLitre.Text.Length)
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    KrPrLitre = Convert.ToDouble(txtKrPrLitre.Text);

                    KilometerPrLitre = (Distance * KrPrLitre) / Price;
                    //txtKilometerPrLitre.Text = string.Format("{0:0.00}", KilometerPrLitre);
                    txtKilometerPrLitre.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(KilometerPrLitre, 2);
                }

                if (0 == txtKrPrLitre.Text.Length)
                {
                    Distance = Convert.ToDouble(txtDistance.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    KilometerPrLitre = Convert.ToDouble(txtKilometerPrLitre.Text);

                    KrPrLitre = (Price * KilometerPrLitre) / Distance;
                    //txtKrPrLitre.Text = string.Format("{0:0.00}", KrPrLitre);
                    txtKrPrLitre.Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(KrPrLitre, 2);
                }
            }
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

                double APart = Nominator1_X_Square + Nominator2_X_Square + Nominator3_X_Square;
                double BPart = Nominator1_X + Nominator2_X + Nominator3_X;
                double CPart = Nominator1 + Nominator2 + Nominator3;

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
            }
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
                double ACoefficient;
                double BCoefficient;
                double CCoefficient;

                ACoefficient = Convert.ToDouble(txtACoefficientInParabel.Text);
                BCoefficient = Convert.ToDouble(txtBCoefficientInParabel.Text);
                CCoefficient = Convert.ToDouble(txtCCoefficientInParabel.Text);

                double Diskriminant;
                double XParameterRoot1;
                double XParameterRoot2;

                Diskriminant = Math.Pow(BCoefficient, 2) - 4 * ACoefficient * CCoefficient;

                txtParametersForParabelByCoefficients.Text = "Diskriminanten er : " + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Diskriminant, Const.DefaultNumberOfDecimals);
                txtParametersForParabelByCoefficients.Text += Environment.NewLine;

                if (Diskriminant < 0)
                {
                    txtParametersForParabelByCoefficients.Text += "Parablen har ingen rødder => den skærer ikke x-aksen i nogle punkter.";
                }
                else
                {
                    if (0 == Diskriminant)
                    {
                        XParameterRoot1 = -BCoefficient / (2 * ACoefficient);
                        txtParametersForParabelByCoefficients.Text += "Parablen har dobbelt roden : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                    else
                    {
                        XParameterRoot1 = (-BCoefficient - Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                        XParameterRoot2 = (-BCoefficient + Math.Sqrt(Diskriminant)) / (2 * ACoefficient);
                        txtParametersForParabelByCoefficients.Text += "Parablen har rødderne : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot1, Const.DefaultNumberOfDecimals) + " ; 0) og (" +
                            PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(XParameterRoot2, Const.DefaultNumberOfDecimals) + " ; 0)";
                    }
                }
                txtParametersForParabelByCoefficients.Text += Environment.NewLine;

                double PointExtremumXCoordinate;
                double PointExtremumYCoordinate;

                PointExtremumXCoordinate = -BCoefficient / (2 * ACoefficient);
                PointExtremumYCoordinate = -Diskriminant / (4 * ACoefficient);

                txtParametersForParabelByCoefficients.Text += "Parablen har Toppunkt : (x ; y) = (" + PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumXCoordinate, Const.DefaultNumberOfDecimals) + " ; " +
                   PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(PointExtremumYCoordinate, Const.DefaultNumberOfDecimals) + ")";
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
        #region Talsystemer
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

            Key[] HighestValidKeyArray = Const.RadixSystemArray[Const.RadixSystemArray.Length - 1].ValidKeysArray;
            
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

            for (Counter = Const.MinRadixSystemValue; Counter <= Const.MaxRadixSystemValue; Counter++)
            {
                if (10 != Counter)
                {
                    cmbNumberSystemRadix.Items.Add(Counter);
                }
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemRadix, Const.MinRadixSystemValue);

            for (Counter = Const.MinRadixSystemSpaces; Counter <= Const.MaxRadixSystemSpaces; Counter++)
            {
                cmbNumberSystemSpaceCounter.Items.Add(Counter);
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemSpaceCounter, Const.MinRadixSystemSpaces);

            for (Counter = 0; Counter <= Const.RadixSystemSpaceCharacterArray.Length - 1; Counter++)
            {
                cmbNumberSystemSpaceCharacter.Items.Add(Const.RadixSystemSpaceCharacterArray[Counter]);
            }
            ControlTools.SetComboBoxSelectedItem(cmbNumberSystemSpaceCharacter, Const.RadixSystemSpaceCharacterArray[0]);

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
            for (int Counter = 0; Counter < Const.RadixSystemDelegatesAndControlsExtendedArray.Length; Counter++)
            {
                ConstRadixSystemAndDelegatesExtended ConstRadixSystemAndDelegatesExtended_Object =
                    Const.RadixSystemDelegatesAndControlsExtendedArray[Counter];
               
                ControlTools.InsertRowInGrid(GridNumberSystem);

                ControlTools.InsertLabelInGrid(GridNumberSystem,
                                               Const.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.Label_Object_Name,
                                               Const.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.Label_Object_Text,
                                               GridNumberSystem.RowDefinitions.Count - 1,
                                               Const.LabelColumnPosition,
                                               Const.LabelColumnSpan);

                ConstRadixSystemAndDelegatesExtended_Object.ConstRadixSystemAndDelegates_Object.TextBox_Object =
                    ControlTools.InsertTextBoxInGrid(GridNumberSystem,
                    Const.RadixSystemDelegatesAndControlsExtendedArray[Counter].ConstRadixSystemAndDelegates_Object.TextBox_Object_Name,
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

        //private int FindIndexInNumberSystemList(RadixNumber_ENUM RadixNumberEnum)
        //{
        //    int RadixSystemCounter = 0;

        //    do
        //    {
        //        if (RadixNumberEnum == ConstRadixSystemAndDelegatesList[RadixSystemCounter].ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixNumber)
        //        {
        //            return (RadixSystemCounter);
        //        }
        //        else
        //        {
        //            RadixSystemCounter++;
        //        }
        //    } while (RadixSystemCounter < ConstRadixSystemAndDelegatesList.Count);

        //    MessageBox.Show("Der er en fejl i din program konstruktion !!! Funktion : FindIndexInNumberSystemList (1)");
        //    return (-1);
        //}

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
            //int Radix10Value;

            Index_In_Number_System_List = FindIndexInNumberSystemList(((System.Windows.FrameworkElement)sender).Name);

            CalculateValueAndUpdateTextBoxes(Index_In_Number_System_List);

            //if (ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text.Length > 0)
            //{
            //    Radix10Value = ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].RadixNumber_Object.ConvertToRadix10(
            //      ConstRadixSystemAndDelegatesList[Index_In_Number_System_List].ConstRadixSystemAndDelegates_Object.TextBox_Object.Text);
            //    UpdateRadixNumbersTextBoxes(Radix10Value);
            //}
            //else
            //{
            //    ControlTools.ClearTextBoxes(TextBoxList);
            //}
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
            ConstRadixSystemAndDelegates_Object.TextBox_Object = null;
            ConstRadixSystemAndDelegates_Object.FunctionPointerFromRadix10 = null;
            ConstRadixSystemAndDelegates_Object.FunctionPointerToRadix10 = null;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.ValidKeysArray = Const.MakeKeyArrayToRadixSystem((int)cmbNumberSystemRadix.SelectedValue).ToArray();
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCharacter = (char)cmbNumberSystemSpaceCharacter.SelectedValue;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixSpaceCounter = (int)cmbNumberSystemSpaceCounter.SelectedValue;
            ConstRadixSystemAndDelegates_Object.ConstRadixSystem_Object.RadixValue = (int)cmbNumberSystemRadix.SelectedValue;
                                    
            ControlTools.InsertRowInGrid(GridNumberSystem);

            ControlTools.InsertLabelInGrid(GridNumberSystem,
                                           "lblRadixDynamic" + NumberDynamicRadixSystemsAdded.ToString(),
                                           "Radix " + cmbNumberSystemRadix.SelectedValue.ToString() + " tal (" + cmbNumberSystemRadix.SelectedValue.ToString() + " tals system) : ",
                                           GridNumberSystem.RowDefinitions.Count - 1,
                                           Const.LabelColumnPosition,
                                           Const.LabelColumnSpan);

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

            ConstRadixSystemAndDelegatesExtended_Object.ConstRadixSystemAndDelegates_Object = ConstRadixSystemAndDelegates_Object;
            ConstRadixSystemAndDelegatesExtended_Object.RadixNumber_Object = new RadixNumber(ConstRadixSystemAndDelegates_Object);
            ConstRadixSystemAndDelegatesList.Add(ConstRadixSystemAndDelegatesExtended_Object);
            SetupNumberSystemTextBoxes();

            CalculateValueAndUpdateTextBoxes(Index_In_Number_System_List);

            NumberDynamicRadixSystemsAdded++;
        }

        #endregion

        /* General code below. */

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
                        //TextBoxList.Add(txtAmount1);
                        //TextBoxList.Add(txtAmount2);
                        break;

                    case "NumberSystems":
                        SetupNumberSystemTextBoxes();
                        //TextBoxList.Clear();
                        //TextBoxList.Add(txtRomerNumber);
                        //TextBoxList.Add(txtDecimalNumber);
                        //TextBoxList.Add(txtBinaryNumber);
                        //TextBoxList.Add(txtOctalNumber);
                        //TextBoxList.Add(txtHexadecimalNumber);
                        //TextBoxList.Add(txtRadix24Number);
                        //TextBoxList.Add(txtRadix32Number);
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
