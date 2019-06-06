using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SpuFourDay : IDeliveryDriver
    {
        public string Name { get; }

        public double CalculateRate(int distance, double weight)
        {
            double rate = (weight * 0.0050) * distance;

            return rate;
        }
        public override string ToString()
        {
            return "SPU (4-Day Ground)      ";
        }
    }
}
