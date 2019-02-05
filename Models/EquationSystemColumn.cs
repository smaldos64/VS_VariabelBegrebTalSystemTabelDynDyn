using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Models
{
    public class EquationSystemColumn : INotifyPropertyChanged
    {
        private string _txtEquationColumnName_Text;

        public string txtEquationColumnName { get; set; }

        public string txtEquationColumnName_Text
        {
            get
            {
                return (_txtEquationColumnName_Text);
            }
            set
            {
                _txtEquationColumnName_Text = value;
                OnPropertyChanged("txtEquationColumnName_Text");
            }
        }

        public string txtEquationColumnName_lbl { get; set; }

        public string txtEquationColumnName_lblText { get; set; }

        public string txtNameConstant { get; set; }

        public EquationSystemColumn(string txtEquationColumnName, string txtEquationColumnName_lbl, string txtEquationColumnName_lblText)
        {
            this.txtEquationColumnName = txtEquationColumnName;
            this.txtEquationColumnName_Text = "";
            this.txtEquationColumnName_lbl = txtEquationColumnName_lbl;
            this.txtEquationColumnName_lblText = txtEquationColumnName_lblText;
        }

        // Property Change Logic  
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
    }
}
