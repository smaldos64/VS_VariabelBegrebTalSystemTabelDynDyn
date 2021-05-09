using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using VariabelBegreb.Models;

namespace VariabelBegreb
{
    /// <summary>
    /// Interaction logic for SecondOrderEquation.xaml
    /// </summary>
    public partial class SecondOrderEquation : Window
    {
        public ObservableCollection<FunctionValueCalculation> FunctionValueCalculations { get; set; }
        public SecondOrderFunction SecondOrderFunction_Object { get; set; }

        public SecondOrderEquation()
        {
            InitializeComponent();

            InitializeCalculations();
        }

        public SecondOrderEquation(SecondOrderFunction SecondOrderFunction_Object)
        {
            InitializeComponent();

            InitializeCalculations();

            this.SecondOrderFunction_Object = SecondOrderFunction_Object;
            lblCoefficients.Content = SecondOrderFunction_Object.MakeFunctionFormulaToPrint();
            SecondOrderFunction_Object.TextBlock_Object = txtParametersForParabel;
            SecondOrderFunction_Object.CalculateAndShowAllPoints();
        }

        private void InitializeCalculations()
        {
            DataGrid2OrderFunctionCalculations.ItemsSource = FunctionValueCalculations = new ObservableCollection<FunctionValueCalculation>();

            //EquationSystemRows.Add(new EquationSystemRow(TextboxName, TextboxText));
        }

        private void btnCalculateYvalue_Click(object sender, RoutedEventArgs e)
        {
            FunctionValueCalculations.Add(new FunctionValueCalculation(this.SecondOrderFunction_Object, Double.Parse(txtXValue.Text)));
            txtXValue.Text = String.Empty;
        }

        private void btnSecondOrderClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
