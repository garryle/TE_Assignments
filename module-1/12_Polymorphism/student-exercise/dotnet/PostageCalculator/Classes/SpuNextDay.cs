using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SpuNextDay : IDeliveryDriver
    {
        public string Name { get; }

        public double CalculateRate(int distance, double weight)
        {
            double rate = (weight * 0.075) * distance;

            return rate;
        }
        public override string ToString()
        {
            return "SPU(Next Day)               ";
        }
    }
}
