using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Models
{
    public class EquationSystemRow
    {
        public string txtEquationText { get; set; }
        public string txtEquationName { get; set; }

        public ObservableCollection<EquationSystemColumn> EquationSystemColumns { get; set; }

        public ObservableCollection<EquationSystemColumnConstant> EquationSystemColumnConstants { get; set; }
        //public EquationSystemColumnConstant EquationSystemColumnConstant_Object { get; set; }

        public EquationSystemRow()
        {
        }

        public EquationSystemRow(string txtEquationName, string txtEquationText)
        {
            this.txtEquationText = txtEquationText;
            this.txtEquationName = txtEquationName;
            this.EquationSystemColumns = new ObservableCollection<EquationSystemColumn>();
            this.EquationSystemColumnConstants = new ObservableCollection<EquationSystemColumnConstant>();
            //EquationSystemColumnConstant_Object = new EquationSystemColumnConstant();
        }
    }
}
