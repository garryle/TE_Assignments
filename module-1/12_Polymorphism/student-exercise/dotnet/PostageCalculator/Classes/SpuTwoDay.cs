using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SpuTwoDay : IDeliveryDriver
    {
        private string Name = "SPU (2-Day Business)\t";
        string IDeliveryDriver.Name
        {
            get
            {
                return "SPU (2-Day Business)\t";
            }
        }

        public double CalculateRate(int distance, double weight)
        {
            double rate = (weight * 0.050) * distance;
            return rate;
        }
    }
}
