using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VariabelBegreb.Tools;

namespace VariabelBegreb.NumberSystems
{
    public delegate string ConvertFromRadix10Int(int Radix10Number);
    public delegate int ConvertToRadix10Int(string Radix10String);

    public class ConstRadixSystemAndDelegates
    {
        public ConstRadixSystem ConstRadixSystem_Object { get; set; }
        public ConvertToRadix10Int FunctionPointerToRadix10 { get; set; }
        public ConvertFromRadix10Int FunctionPointerFromRadix10 { get; set; }
        public TextBox TextBox_Object { get; set; }

        public ConstRadixSystemAndDelegates(ConstRadixSystem ConstRadixSystem_Object,
                                            TextBox TextBox_Object,
                                            ConvertToRadix10Int FunctionPointerToRadix10,
                                            ConvertFromRadix10Int FunctionPointerFromRadix10)
        {
            this.ConstRadixSystem_Object = ConstRadixSystem_Object;
            this.TextBox_Object = TextBox_Object;
            this.FunctionPointerToRadix10 = FunctionPointerToRadix10;
            this.FunctionPointerFromRadix10 = FunctionPointerFromRadix10;
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
    }

    public class Delegates
    {
        // Denne klasse bruges ikke. Den er kun medtaget for, at der er et sted at samle
        // alle programmets Delegates !!!
    }
}
