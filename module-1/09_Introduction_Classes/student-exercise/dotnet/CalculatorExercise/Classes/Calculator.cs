using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{


    /// <summary>
    /// Represents a "simple" calculator
    /// </summary>
    public class Calculator
    {
        public int Result { get; private set; }

        //methods
        public Calculator()
        {
            Result = 0;
        }

        public Calculator(int Result)
        {
            this.Result = Result;
        }

        public int GetResult()
        {
            return Result;
        }

        public int Add(int addend)
        {
            return Result += addend;
        }

        public int Subtract(int subtrahent)
        {
            return Result -= subtrahent;
        }

        public int Multiply(int multiplier)
        {
            return Result *= multiplier;
        }

        public int Power(int exponent)
        {
            return Result = (int)Math.Pow(Result, Math.Abs(exponent));
        }

        public void Reset()
        {
            Result = 0;
        }
    }
}
