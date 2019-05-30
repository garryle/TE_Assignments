using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SpuFourDay : IDeliveryDriver
    {
        private string Name = "SPU (4-Day Ground)\t";

        string IDeliveryDriver.Name
        {
            get
            {
                return "SPU (4-Day Ground)\t";
            }
        }

        public double CalculateRate(int distance, double weight)
        {
            double rate = (weight * 0.005) * distance;

            return rate;
        }
    }
}
