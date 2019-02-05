using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Models
{
    public class EquationSystemColumnConstant : INotifyPropertyChanged
    {
        private string _txtEquationColumnConstantName_Text { get; set; }

        public string txtEquationColumnConstantName { get; set; }

        public string txtEquationColumnConstantName_Text
        {
            get
            {
                return (_txtEquationColumnConstantName_Text);
            }
            set
            {
                _txtEquationColumnConstantName_Text = value;
                OnPropertyChanged("txtEquationColumnConstantName_Text");
            }
        }

        public EquationSystemColumnConstant()
        {
        }

        public EquationSystemColumnConstant(string txtEquationColumnConstantName)
        {
            this.txtEquationColumnConstantName = txtEquationColumnConstantName;
            this.txtEquationColumnConstantName_Text = "";
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
