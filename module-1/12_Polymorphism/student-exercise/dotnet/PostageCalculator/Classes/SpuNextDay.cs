using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SpuNextDay : IDeliveryDriver
    {
        private string Name = "SPU (Next Day)\t\t";
        string IDeliveryDriver.Name
        {
            get
            {
                return "SPU (Next Day)\t\t";
            }
        }

        public double CalculateRate(int distance, double weight)
        {
            double rate = (weight * 0.075) * distance;

            return rate;
        }
    }
}
