using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class FirstClass : IDeliveryDriver
    {
        //Implementation
        private double rate;
        private int distace;

        public string Name { get; }

        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                rate = 0.035;
            }
            else if (weight <= 8)
            {
                rate = 0.040;
            }
            else if (weight <= 15)
            {
                rate = 0.047;
            }
            else if (weight <= 48)
            {
                rate = 0.195;
            }
            else if (weight <= 128)
            {
                rate = 0.450;
            }
            else
            {
                rate = 0.500;
            }
            return distance * rate;
        }


        public override string ToString()
        {
            return "Postal Service (1st Class)";
        }
    }
}
