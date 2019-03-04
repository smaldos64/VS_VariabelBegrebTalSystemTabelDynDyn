using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariabelBegreb
{
    public class MathTools
    {
        public static int GetGreatestDivisor(int m, int h)
        {
            do
            {
                for (int i = m; i >= 1; i--)
                {
                    if (m % i == 0 && h % i == 0)
                    {
                        int x = 0;
                        x = i;

                        return x;
                    }
                }
            } while (true);

            return m;
        }

    }
}

