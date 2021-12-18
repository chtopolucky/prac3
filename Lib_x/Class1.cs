using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_11
{
    public class Class1
    {
        public static void Calculate(int [,] matrix, out int numberString)
        {
            numberString = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int k = 0;
                int min = matrix[i, 0];
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= min)
                    {
                        min = matrix[i, j];
                        k++;
                    }
                    else break;
                }
                if(k==matrix.GetLength(1)-1) numberString++;
            }
        }
    }
}
