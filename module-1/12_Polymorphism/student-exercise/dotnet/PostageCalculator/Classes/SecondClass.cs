using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SecondClass : IDeliveryDriver
    {

        //Implementation
        public string Name { get; }

        public double CalculateRate(int distance, double weight)
        {
            throw new NotImplementedException();
        }
    }
}
