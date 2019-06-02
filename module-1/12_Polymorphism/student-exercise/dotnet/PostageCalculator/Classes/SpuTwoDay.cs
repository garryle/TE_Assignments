using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SpuTwoDay : IDeliveryDriver
    {
        public string Name { get; }

        public double CalculateRate(int distance, double weight)
        {
            double rate = 0;
            rate = (weight * 0.050) * distance;
            return rate;
        }
        public override string ToString()
        {
            return "SPU(2-Day Business)     ";
        }
    }
}
