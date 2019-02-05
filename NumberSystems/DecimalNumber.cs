using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VariabelBegreb.Tools;

namespace VariabelBegreb.NumberSystems
{
    public class DecimalNumber : NumberSystem
    {
        static Key[] ValidKeysArray = { Key.D0, Key.D1, Key.D2, Key.D2, Key.D3, Key.D4,
                                        Key.D5, Key.D6, Key.D7, Key.D8, Key.D9};

        public override bool IsKeyValid(Key ThisKey)
        {
            return (ValidKeysArray.Contains(ThisKey) || KeyHelper.IsKeyPressedValicControlKey(ThisKey));
        }

        public override string ConvertFromRadix10(int Radix10Number)
        {
            string ReturnString = " ";
            ConstRadixSystem ConstRadixSystem_Object = Const.FindRadixSystem(RadixNumber_ENUM.DECIMAL_NUMBER);

            if (null != ConstRadixSystem_Object)
            {
                ReturnString = Radix10Number.ToString();
                //ReturnString = StringHelper.InsertCharacterInStringAtSpecifiedInterval(ReturnString,
                //                                                                       ConstRadixSystem_Object.RadixSpaceCounter,
                //                                                                       ConstRadixSystem_Object.RadixSpaceCharacter);
            }
            else
            {
                MessageBox.Show("Der er vist en SW bug her !!!");
            }

            return (ReturnString);
        }

        public override int ConvertToRadix10(string RadixStringToConvert)
        {
            int Radix10Number;

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
    }
}