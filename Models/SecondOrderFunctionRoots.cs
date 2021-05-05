using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Models
{
    public class SecondOrderFunctionRoots
    {
        public Point2Dimensions[] Roots = new Point2Dimensions[2];
        public int NumberOFRoots;
        public SecondOrderFunctionRoots()
        {
            Roots[0] = new Point2Dimensions();
            Roots[1] = new Point2Dimensions();
            this.NumberOFRoots = -1;
        }

    }
}
