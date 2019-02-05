using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Models
{
    public class MatrixCalculationCoefficients
    {
        public bool CoefficientFound { get; set; }
        public char CoefficientLetter { get; set; }
        public double CoefficientValue { get; set; }

        public MatrixCalculationCoefficients(char CoefficientLetter)
        {
            this.CoefficientFound = false;
            this.CoefficientValue = 0;
            this.CoefficientLetter = CoefficientLetter;
        }
    }
}
