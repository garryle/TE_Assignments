using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SecondClass : IDeliveryDriver
    {
        private double rate;
        //Implementation
        public string Name { get; }


        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                rate = 0.0035;
            }
            else if (weight <= 8)
            {
                rate = 0.0040;
            }
            else if (weight <= 15)
            {
                rate = 0.0047;
            }
            else if (weight <= 48)
            {
                rate = 0.0195;
            }
            else if (weight <= 128)
            {
                rate = 0.0450;
            }
            else
            {
                rate = 0.0500;
            }
            return distance * rate;
        }

        public override string ToString()
        {
            return "Postal Service (2nd Class)";
        }
    }
}
