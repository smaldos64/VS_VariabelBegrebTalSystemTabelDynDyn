using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb.Tools
{
    public class FileTools
    {
        public static void WriteSpacesInFileLine(StreamWriter ThisFileWriter, int NumberOfSpaces)
        {
            for (int SpaceCounter = 0; SpaceCounter < NumberOfSpaces; SpaceCounter++)
            {
                ThisFileWriter.Write(" ");
            }
        }

        public static void WriteEmptyLinesInFileLine(StreamWriter ThisFileWriter, int NumberOfEmptyLines)
        {
            for (int EmptyLineCounter = 0; EmptyLineCounter < NumberOfEmptyLines; EmptyLineCounter++)
            {
                ThisFileWriter.WriteLine();
            }
        }
    }
}
