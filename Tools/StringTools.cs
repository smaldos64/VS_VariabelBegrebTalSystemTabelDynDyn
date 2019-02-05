using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public class StringTools
    {
        public static int FindFirstNonSpacePositionInString(string InputString)
        {
            int StringPositionCounter;
            bool NonSpacePositonFound = false;

            StringPositionCounter = 0;
            do
            {
                if (InputString[StringPositionCounter] != ' ')
                {
                    NonSpacePositonFound = true;
                }
                else
                {
                    StringPositionCounter++;
                }
            } while ((StringPositionCounter < InputString.Length) && (false == NonSpacePositonFound));

            if (true == NonSpacePositonFound)
            {
                return (StringPositionCounter);
            }
            else
            {
                return (-1);
            }
        }
    }
}
