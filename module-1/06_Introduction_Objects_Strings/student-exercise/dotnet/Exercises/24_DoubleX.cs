﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
         DoubleX("axxbb") → true
         DoubleX("axaxax") → false
         DoubleX("xxxxx") → true
         */
        public bool DoubleX(string str)
        {
            bool doubleX = false;

            for (int i = 0; i<str.Length-1; i++)
            {
                if (str[i] == 'x')
                {
                    if (str[i + 1] == 'x')
                        doubleX = true;
                    i = str.Length;
                }
            }
            return doubleX;
        }
    }
}
